using AutoCompleter.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace AutoCompleter.Controllers
{
    public class HomeController : Controller
    {
        NimedContext db = new NimedContext();

        /*public ActionResult Index(string searching)
        {

        Поиск

            IEnumerable<Nimed> nimeds = db.Nimeds;
            ViewBag.Nimeds = nimeds;
            return View(db.Nimeds.Where(x => x.Emakeelnenimi.Contains(searching) || searching == null).ToList());




        }*/

        /*
        
        Index.cshtml

         @using (Html.BeginForm("Index", "Home", FormMethod.Get))
        {
        <p>Otsing emakeelne nimide eest</p>
            @Html.TextBox("searching")
            <input type="submit" value="Otsing" class="btn btn-primary" />

        }*/

        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Sugu" : "";
            ViewBag.NameSortParm1 = String.IsNullOrEmpty(sortOrder) ? "Emakeelnenimi" : "";
            ViewBag.NameSortParm2 = String.IsNullOrEmpty(sortOrder) ? "Voorkeelnenimi" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";
            var nimeds = from s in db.Nimeds
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                nimeds = nimeds.Where(s => s.Emakeelnenimi.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Sugu":
                    nimeds = nimeds.OrderByDescending(s => s.Sugu);
                    break;
                case "Emakeelnenimi":
                    nimeds = nimeds.OrderBy(s => s.Emakeelnenimi);
                    break;
                case "Voorkeelnenimi":
                    nimeds = nimeds.OrderByDescending(s => s.Voorkeelnenimi);
                    break;
                default:
                    nimeds = nimeds.OrderBy(s => s.Emakeelnenimi);
                    break;
            }
            return View(nimeds.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Nimed nimed)
        {
            db.Nimeds.Add(nimed);
            db.SaveChanges();

            return RedirectToAction("Create");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();

            /*@Html.ActionLink("Edit", "Edit", new { id = item.Id }) |
                @Html.ActionLink("Details", "Details", new { id = item.Id }) |
                @Html.ActionLink("Delete", "Delete", new { id = item.Id })*/
        }

        [HttpGet]
        public ActionResult EditNimi(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Nimed nimed = db.Nimeds.Find(id);
            if (nimed != null)
            {
                return View(nimed);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult EditNimi(Nimed nimed)
        {
            db.Entry(nimed).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Nimed b = new Nimed { Id = id };
            db.Entry(b).State = EntityState.Deleted;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}