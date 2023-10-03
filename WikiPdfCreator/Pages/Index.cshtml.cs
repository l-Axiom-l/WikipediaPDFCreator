using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Web;
using WikipediaPDFCreatorDesktop;

namespace WikiPdfCreator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string Message = "";
        public bool downloadready;
        public List<string> searches;

        public static List<PDFCreator> creatorinstances;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;

            if (creatorinstances == null)
            {
                creatorinstances = new List<PDFCreator>();
            }
        }

        public void finished(object? sender, EventArgs e)
        {
            downloadready = true;
        }


        public void OnGet(bool f)
        {
            if (!HttpContext.Session.TryGetValue("list", out byte[] t))
                searches = new List<string>();
            else
                searches = HttpContext.Session.GetString("list").Split('-').ToList();

                downloadready = f;

            Message = "";
        }

        public async Task<IActionResult> OnPostCreatePdf()
        {
            if (!HttpContext.Session.TryGetValue("list", out byte[] t))
                return new RedirectToPageResult("Index");
            else
                searches = HttpContext.Session.GetString("list").Split('-').ToList();

            Console.WriteLine("Test");
            PDFCreator temp = new PDFCreator(searches.ToArray(), "wwwroot/documents", "test");
            creatorinstances.Add(temp);
            creatorinstances.Last().CreatePdf();
            creatorinstances.Last().finished += finished;

            while(!downloadready)
            {
                await Task.Delay(100);
            }

            return new RedirectToPageResult("Index", new {f = downloadready });
        }

        public void OnPost()
        {
            Message = Request.Form[nameof(Message)];

            if (!HttpContext.Session.TryGetValue("list", out byte[] t))
                searches = new List<string>();
            else
                searches = HttpContext.Session.GetString("list").Split('-').ToList();

            if (searches == null)
                searches = new List<string>();

            if (Message.Length > 0)
                searches.Add(Message);

            Message = "";
            HttpContext.Session.SetString("list", String.Join('-', searches));
        }
    }
}