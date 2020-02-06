using BarManagerProgram.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 

namespace BarManagerProgram.Controllers
{
    public class InventoryController : Controller
    {
        ApplicationDbContext context;

        public InventoryController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Inventory
        public ActionResult Index()
        {
            var userId = GetAppId();
            var manager = GetManagerByAppId(userId);
            var bar = GetBarByManagerId(manager.ManagerId);
            var inventory = GetInventoryByBarId(bar.BarId);
            return View(inventory);
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            var inventory = GetInventoryById(id);
            return View(inventory);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            Inventory inventory = new Inventory();
            return View(inventory);
        }

        // POST: Players/Create
        [HttpPost]
        public ActionResult Create(Inventory inventory)
        {
            try
            {
                // TODO: Add insert logic here
                var userId = GetAppId();
                var manager = GetManagerByAppId(userId);
                var bar = GetBarByManagerId(manager.ManagerId);
                inventory.BarId = bar.BarId;

                context.Inventory.Add(inventory);
                context.SaveChanges();

                return RedirectToAction("LogOut", "Account");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            var inventory = GetInventoryById(id);
            return View(inventory);
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Inventory inventory)
        {
            try
            {
                // TODO: Add update logic here
                Inventory updatedInventory = context.Inventory.Where(i => i.InventoryId == id).FirstOrDefault();
                updatedInventory.VodkaBottleCount = inventory.VodkaBottleCount;
                updatedInventory.GinBottleCount = inventory.GinBottleCount;
                updatedInventory.WhiteRumBottleCount = inventory.WhiteRumBottleCount;
                updatedInventory.TequilaBottleCount = inventory.TequilaBottleCount;
                updatedInventory.SpicedRumBottleCount = inventory.SpicedRumBottleCount;
                updatedInventory.BrandyBottleCount = inventory.BrandyBottleCount;
                updatedInventory.WhiskeyBottleCount = inventory.WhiskeyBottleCount;
                updatedInventory.ScotchBottleCount = inventory.ScotchBottleCount;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inventory/Delete/5
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
        public Bar GetBarByManagerId(int managerid)
        {
            var bar = context.Bar.Where(b => b.ManagerId == managerid).FirstOrDefault();
            return bar;
        }
        public Inventory GetInventoryByBarId(int id)
        {
            var inventory = context.Inventory.Where(i => i.BarId == id).FirstOrDefault();
            return inventory;
        }
        public Inventory GetInventoryById(int id)
        {
            var inventory = context.Inventory.Where(i => i.InventoryId == id).FirstOrDefault();
            return inventory;
        }
    }
}
