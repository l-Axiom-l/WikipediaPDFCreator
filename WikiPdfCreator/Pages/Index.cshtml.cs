using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Web;

namespace WikiPdfCreator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string Message = "";
        public List<string> searches;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnLoad()
        {
            searches = (List<string>)ViewData["list"];

            if(searches == null)
                searches = new List<string>();
        }


        public void OnGet()
        {
            Message = "";
        }

        public void OnPost()
        {
            Message = Request.Form[nameof(Message)];

            if(!HttpContext.Session.TryGetValue("list", out byte[] t))
                searches = new List<string>();
            else
                searches = HttpContext.Session.GetString("list").Split('-').ToList();

            if (searches == null)
                searches = new List<string>();

            if(Message.Length > 0)
                searches.Add(Message);

            Message = "";
            HttpContext.Session.SetString("list", String.Join('-', searches));
        }
    }
} 