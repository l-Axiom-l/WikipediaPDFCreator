using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Cms;

namespace WikipediaPDFCreator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string Text;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        void texzt()
        { 
        }

        public void OnGet()
        {
            Text = "Enter your message here";
        }

        public void OnPost()
        {
            Text = Request.Form[nameof(Text)];
        }
    }
}