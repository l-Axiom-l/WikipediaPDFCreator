﻿using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Data;
using System.Diagnostics;
using System.Web;
using WikipediaPDFCreatorDesktop;

namespace WikiPdfCreator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string Message = "";
        public string title = "";
        public bool downloadready;
        public List<string> searches;
        public string id;

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

        public void OnGet(bool f, string id)
        {
            if (!HttpContext.Session.TryGetValue("list", out byte[] t))
                searches = new List<string>();
            else
                searches = HttpContext.Session.GetString("list").Split('-').ToList();

            downloadready = f;
            this.id = id;

            Message = "";
        }

        public async Task<IActionResult> OnPostCreatePdf()
        {
            title = Request.Form[nameof(title)];

            downloadready = false;
            if (!HttpContext.Session.TryGetValue("list", out byte[] t))
                return new RedirectToPageResult("Index");
            else
                searches = HttpContext.Session.GetString("list").Split('-').ToList();

            Console.WriteLine("Test");
            PDFCreator temp = new PDFCreator(searches.ToArray(), "wwwroot/documents" + "/" + HttpContext.Session.Id, title);
            id = HttpContext.Session.Id;
            creatorinstances.Add(temp);
            creatorinstances.Last().CreatePdf();
            creatorinstances.Last().finished += finished;

            while (!downloadready)
            {
                await Task.Delay(100);
            }

            return new RedirectToPageResult("Index", new { f = downloadready, id = HttpContext.Session.Id });
        }

        public async Task<IActionResult> OnPostEdit(int edit, int index)
        {
            downloadready = false;
            if (!HttpContext.Session.TryGetValue("list", out byte[] t))
                return new RedirectToPageResult("Index");
            else
                searches = HttpContext.Session.GetString("list").Split('-').ToList();

            Debug.WriteLine("DebugNumber:" + edit.ToString() + "-" + index.ToString());

            switch (edit)
            {
                case 0:
                    if (index >= searches.Count - 1) break;
                    string temp = searches[index];
                    searches.RemoveAt(index);
                    searches.Insert(index + 1, temp);
                    break;
                case 1:
                    if (index <= 0) break;
                    string temp2 = searches[index];
                    searches.RemoveAt(index);
                    searches.Insert(index - 1, temp2);
                    break;
                case 3:
                    searches.RemoveAt(index);
                    break;
            }

            HttpContext.Session.SetString("list", String.Join('-', searches));
            return new RedirectToPageResult("Index", new { f = downloadready, id = HttpContext.Session.Id });
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