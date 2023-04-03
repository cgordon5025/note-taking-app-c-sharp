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

        //this will pull all of our notes
        [HttpGet]
        public IActionResult _note_list()
        {
            var result = db.Notes.OrderByDescending(n => n.Date).AsQueryable();
            return PartialView(result);
        }

        //get a single note to view the details
        [HttpGet]
        public JsonResult getNoteById(string Id)
        {
            var result = db.Notes.Find(new Guid(Id));
            return Json(result);
        }

        [HttpGet]
        public JsonResult deleteNoteById(string Id) 
        {
            Notes note = db.Notes.Find(new Guid(Id));
            db.Entry(note).State = EntityState.Deleted;
            db.SaveChanges();

            return Json("Successfully deleted Note");

        }

        [HttpPost]
        public JsonResult updatedNote(Notes note)
            {
            Notes oldNoteModel = db.Notes.Find(note.Id); 

            if(oldNoteModel == null)
            {
                //we'll add a new one if there is none, if not we will update the existing
                note.Id = Guid.NewGuid();
                note.Date = DateTime.Now; 
                db.Notes.Add(note);
                db.SaveChanges();
            }
            else
            {
                note.Date = DateTime.UtcNow;
                db.Entry(oldNoteModel).CurrentValues.SetValues(note); 
                db.SaveChanges();
            }

            return Json(note);
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