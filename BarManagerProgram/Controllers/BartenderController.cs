using BarManagerProgram.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BarManagerProgram.Controllers
{
    public class BartenderController : Controller
    {
        ApplicationDbContext context;

        public BartenderController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Bartender
        public ActionResult Index()
        {
            var userId = GetAppId();
            var bartender = GetBartenderByAppId(userId);
            return View(bartender);
        }

        // GET: Bartender/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            Bartender bartender = new Bartender();
            return View(bartender);
        }

        // POST: Players/Create
        [HttpPost]
        public ActionResult Create(Bartender bartender)
        {
            try
            {
                // TODO: Add insert logic here

                bartender.ApplicationId = GetAppId();

                context.Bartender.Add(bartender);
                context.SaveChanges();

                return RedirectToAction("LogOut", "Account");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bartender/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bartender/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bartender/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bartender/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public string GetAppId()
        {
            var userid = User.Identity.GetUserId();
            return userid;
        }

        public Bartender GetBartenderByAppId(string userid)
        {
            var bartender = context.Bartender.Where(b => b.ApplicationId == userid).FirstOrDefault();
            return bartender;
        }
        public Bartender GetBartenderByBartenderId(int id)
        {
            var  bartender = context.Bartender.Where(b => b.BartenderId == id).FirstOrDefault();
            return bartender;
        }
    }
}
