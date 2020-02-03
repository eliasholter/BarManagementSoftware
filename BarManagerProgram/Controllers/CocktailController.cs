using BarManagerProgram.Models;
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
            cocktail.Liquors = context.Liquor.ToList();
            cocktail.Juices = context.Juice.ToList();
            cocktail.Syrups = context.Syrup.ToList();
            cocktail.Liqueurs = context.Liqueur.ToList();
            cocktail.Bitters = context.Bitter.ToList();
            cocktail.Toppers = context.Topper.ToList();
            return View(cocktail);
        }

        // POST: Cocktail/Create
        [HttpPost]
        public ActionResult Create(Cocktail cocktail)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
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
    }
}
