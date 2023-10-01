using iText;
using iText.Kernel.Pdf;
using System.Diagnostics;

namespace WikipediaPDFCreatorDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Main();
        }

        async void Main()
        {
            string[] s = {"Axiom", "Cat", "Fire" };
            PDFCreator creator = new PDFCreator(s, @"C:\Programmieren\Test", "Tesst");
            creator.CreatePdf();
        }
    }
}