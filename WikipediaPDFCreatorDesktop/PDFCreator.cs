using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Pdf.Navigation;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Renderer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Text = iText.Layout.Element.Text;

namespace WikipediaPDFCreatorDesktop
{
    class PDFCreator
    {
        string[] s;
        string outputPath;
        string name;

        public event EventHandler finished;

        public PDFCreator(string[] searches, string outputPath, string title)
        {
            s = searches;
            this.outputPath = outputPath;
            name = title;
        }

        public async void CreatePdf()
        {
            int count = 3;
            Dictionary<string, int> toc = new Dictionary<string, int>();
            FileStream s = File.Create(outputPath + @"\" + name + ".pdf");
            PdfFont font = PdfFontFactory.CreateFont();

            WriterProperties wp = new WriterProperties();
            wp.SetModifiedDocumentId(new PdfString("AxiomSoftware"));

            using (PdfWriter w = new PdfWriter(s))
            {
                PdfDocument result = new PdfDocument(w);
                Document doc = new Document(result);

                foreach (string search in this.s)
                {
                    PdfPage page = result.AddNewPage();
                    PdfCanvas c = new PdfCanvas(page);
                    iText.Kernel.Geom.Rectangle rec = new iText.Kernel.Geom.Rectangle(result.GetDefaultPageSize().GetX(), result.GetDefaultPageSize().GetY(), result.GetDefaultPageSize().GetHeight(), result.GetDefaultPageSize().GetWidth());
                    Canvas canvas = new Canvas(c, rec);
                    Paragraph para = new Paragraph(search);
                    para.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                    para.SetMarginLeft(140);
                    para.SetFont(PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.TIMES_ROMAN));
                    para.SetFontSize(40);
                    para.SetUnderline();
                    canvas.Add(para);
                    canvas.Close();
                    toc.Add(search, count);
                    result.AddNamedDestination($"{search}{count}", PdfExplicitDestination.CreateFitH(page, page.GetPageSize().GetTop()).GetPdfObject());

                    PdfDocument d = await GetArticle(search);
                    int temp = d.GetNumberOfPages();
                    d.CopyPagesTo(1, temp, result);
                    count += temp;
                }


                doc.SetFont(font);

                PdfPage p = result.AddNewPage(1);
                Paragraph par = new Paragraph();
                par.SetFont(PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.COURIER));
                par.SetFontSize(60);
                par.SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                par.SetMarginTop(200);
                par.Add(name);
                par.Add("\n");
                par.AddTabStops(new TabStop(500, iText.Layout.Properties.TabAlignment.CENTER, new SolidLine()));
                par.Add(new Tab());
                doc.Add(par);

                doc.Add(new AreaBreak(iText.Layout.Properties.AreaBreakType.NEXT_PAGE));

                p = result.AddNewPage(2);

                foreach(KeyValuePair<string, int> pair in toc)
                {
                    Text text = new Text(pair.Key);
                    text.SetAction(PdfAction.CreateGoTo($"{pair.Key}{pair.Value}"));
                    par = new Paragraph(text);
                    par.SetFont(font);
                    par.SetFontSize(12);
                    par.AddTabStops(new TabStop(750, iText.Layout.Properties.TabAlignment.RIGHT, new DottedLine()));
                    par.Add(new Tab());
                    text = new Text(pair.Value.ToString());
                    text.SetAction(PdfAction.CreateGoTo($"{pair.Key}{pair.Value}"));
                    par.Add(text);
                    doc.Add(par);
                }

                doc.Close();
                finished.Invoke(this, EventArgs.Empty);
            }
        }

        async Task<PdfDocument> GetArticle(string search)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Api-User-Agent", "axiom@mail.gmx");
                //client.DefaultRequestHeaders.UserAgent.ParseAdd("axiom@mail.gmx");
                HttpResponseMessage response = await client.GetAsync("https://en.wikipedia.org/api/rest_v1/page/pdf/" + search);

                PdfDocument d = new PdfDocument(new PdfReader(response.Content.ReadAsStream()));
                return d;
            }
        }
    }
}
