using Microsoft.AspNetCore.Mvc;
using noteTakingApp.Models;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace noteTakingApp.Controllers
{
    public class HomeController : Controller
    {

        private NoteWebDbContext db = new NoteWebDbContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult _note_list()
        {
            var result = db.Notes.OrderByDescending(n => n.Date).AsQueryable();
            return(PartialView)(result);
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
    }
}