using Ajax_homework.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ajax_homework.Controllers
{
    public class HomeworkController : Controller
    {
        private readonly IWebHostEnvironment _host;
        private readonly DemoContext _context;
        public HomeworkController(IWebHostEnvironment host, DemoContext context)
        {
            _host = host;
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult GetDemo()
        {
            return View();
        }
        public IActionResult demo(string keyword)
        {
            if (String.IsNullOrEmpty(keyword))
            {
                keyword = "ajax";
            }
            return Content($"{keyword}，您好歡迎", "text/html", System.Text.Encoding.UTF8);
        }
        public IActionResult Ajevent()
        {
            return View();
        }
        public IActionResult sleep()
        {
            System.Threading.Thread.Sleep(5000);
            return Content("hello ajaxEvent","text/plain");
        }
        public IActionResult Register(Member member, IFormFile File1)
        {
            string filePath = Path.Combine(_host.WebRootPath, "uploads", File1.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                File1.CopyTo(fileStream);
            }
            byte[] imgByte = null;
            using (var memoryStream = new MemoryStream())
            {
                File1.CopyTo(memoryStream);
                imgByte = memoryStream.ToArray();
            }
            member.FileName = File1.FileName;
            member.FileData = imgByte;

            _context.Members.Add(member);
            _context.SaveChanges();

            //string info = $"{file.FileName}-{file.Length}-{file.ContentType}";
            //string info = _host.ContentRootPath;
            return Content(filePath, "text/plain", System.Text.Encoding.UTF8);
        }
        public IActionResult City()
        {
            var cities = _context.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }
        public IActionResult Site(string city)
        {
            var sites = _context.Addresses.Where(a => a.City == city).Select(a => a.SiteId).Distinct();
            return Json(sites);
        }


        //根據鄉鎮區名稱讀取路的資料
        public IActionResult Road(string site)
        {
            var roads = _context.Addresses.Where(a => a.SiteId == site).Select(a => a.Road).Distinct();
            return Json(roads);
        }
        public IActionResult Address()
        {
            return View();
        }
    }
}
