using BarManagerProgram.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BarManagerProgram.Controllers
{
    public class ManagerController : Controller
    {
        ApplicationDbContext context;

        public ManagerController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Manager
        public ActionResult Index()
        {
            var userId = GetAppId();
            var manager = GetManagerByAppId(userId);
            return View(manager);
        }

        // GET: Manager/Details/5
        public ActionResult Details(int id)
        {
            var manager = GetManagerById(id);
            return View(manager);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            Manager manager = new Manager();
            return View(manager);
        }

        // POST: Players/Create
        [HttpPost]
        public ActionResult Create(Manager manager)
        {
            try
            {
                // TODO: Add insert logic here

                manager.ApplicationId = GetAppId();

                context.Manager.Add(manager);
                context.SaveChanges();

                return RedirectToAction("CreateBar", "Manager");
            }
            catch
            {
                return View();
            }
        }

        // GET: Players/Create
        public ActionResult CreateBar()
        {
            Bar bar = new Bar();
            return View(bar);
        }

        // POST: Players/Create
        [HttpPost]
        public ActionResult CreateBar(Bar bar)
        {
            try
            {
                // TODO: Add insert logic here
                var userId = GetAppId();
                var manager = GetManagerByAppId(userId);
                bar.ManagerId = manager.ManagerId;

                context.Bar.Add(bar);
                context.SaveChanges();

                return RedirectToAction("Create", "Inventory");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manager/Edit/5
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

        // GET: Manager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manager/Delete/5
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
        public Manager GetManagerById(int id)
        {
            var manager = context.Manager.Where(m => m.ManagerId == id).FirstOrDefault();
            return manager;
        }
        public Bar GetBarByManagerId(int managerid)
        {
            var bar = context.Bar.Where(b => b.ManagerId == managerid).FirstOrDefault();
            return bar;
        }
    }
}
