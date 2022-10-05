using Ajax_homework.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ajax_homework.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment _host;
        
        public HomeController(IWebHostEnvironment host, ILogger<HomeController> logger)
        {
            _host = host;
            _logger = logger;
        }
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Fetch()
        {
            return View();
        }
        public IActionResult checkdata(string Name)
        {
            if (!String.IsNullOrEmpty(Name))
            {
            DemoContext db = new DemoContext();
            Member membername = db.Members.Where(p=>p.Name==Name).FirstOrDefault();
                if (membername == null)
                {
                    return Content("輸入的名字可使用", "text/html", System.Text.Encoding.UTF8);
                }
                else
                    return Content("輸入的名字已註冊", "text/html", System.Text.Encoding.UTF8);
            }

            return Content("名字不可空白", "text/html", System.Text.Encoding.UTF8);
        }
        //[HttpPost]
        //public IActionResult Register(Member member,IFormFile file)
        //{

        //    string info = $"{file.FileName}-{file.Length}-{file.ContentType}";
        //    //string info = _host.ContentRootPath;
        //    return Content(info, "text/plain",System.Text.Encoding.UTF8);
        //}
    }
}
