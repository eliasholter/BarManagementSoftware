using BarManagerProgram.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BarManagerProgram.Controllers
{
    public class CocktailController : Controller
    {
        ApplicationDbContext context;

        public CocktailController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Cocktail
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cocktail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cocktail/Create
        public ActionResult Create()
        {
            Cocktail cocktail = new Cocktail();
            var liquors = context.Liquor.Select(s => s.LiquorName).ToList();
            var juices = context.Juice.Select(s => s.JuiceName).ToList();
            var syrups = context.Syrup.Select(s => s.SyrupName).ToList();
            var liqueurs = context.Liqueur.Select(s => s.LiqueurName).ToList();
            var bitters = context.Bitter.Select(s => s.BitterName).ToList();
            var toppers = context.Topper.Select(s => s.TopperName).ToList();
            ViewBag.LiquorName = new SelectList(liquors);
            ViewBag.JuiceName = new SelectList(juices);
            ViewBag.SyrupName = new SelectList(syrups);
            ViewBag.LiqueurName = new SelectList(liqueurs);
            ViewBag.BitterName = new SelectList(bitters);
            ViewBag.TopperName = new SelectList(toppers);
            return View(cocktail);
        }

        // POST: Cocktail/Create
        [HttpPost]
        public ActionResult Create(Cocktail cocktail)
        {
            try
            {
                // TODO: Add insert logic here
                var liquors = context.Liquor.Select(s => s.LiquorName).ToList();
                var juices = context.Juice.Select(s => s.JuiceName).ToList();
                var syrups = context.Syrup.Select(s => s.SyrupName).ToList();
                var liqueurs = context.Liqueur.Select(s => s.LiqueurName).ToList();
                var bitters = context.Bitter.Select(s => s.BitterName).ToList();
                var toppers = context.Topper.Select(s => s.TopperName).ToList();
                ViewBag.LiqourName = new SelectList(liquors);
                ViewBag.JuiceName = new SelectList(juices);
                ViewBag.SyrupName = new SelectList(syrups);
                ViewBag.LiqueurName = new SelectList(liqueurs);
                ViewBag.BitterName = new SelectList(bitters);
                ViewBag.TopperName = new SelectList(toppers);

                var userId = GetAppId();
                var manager = GetManagerByAppId(userId);
                cocktail.ManagerId = manager.ManagerId;

                context.Cocktail.Add(cocktail);
                context.SaveChanges();

                return RedirectToAction("Index", "Manager");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cocktail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cocktail/Edit/5
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

        // GET: Cocktail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cocktail/Delete/5
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
        public Manager GetManagerByAppId(string userid)
        {
            var manager = context.Manager.Where(b => b.ApplicationId == userid).FirstOrDefault();
            return manager;
        }
    }
}
