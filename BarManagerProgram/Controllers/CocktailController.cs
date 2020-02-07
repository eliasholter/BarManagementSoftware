using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using static BarManagerProgram.Models.TwilioAPIKey;
using BarManagerProgram.Models;
using PickUpSports.Controllers;

namespace BarManagerProgram.Controllers
{
    public class CocktailController : Controller
    {
        ApplicationDbContext context;
        SMSController SMS;

        public CocktailController()
        {
            context = new ApplicationDbContext();
            SMS = new SMSController();
        }

        // GET: Cocktail
        public ActionResult Index(string searchString)
        {
            var cocktails = from c in context.Cocktail
                            select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                cocktails = cocktails.Where(c => c.CocktailName.Contains(searchString)
                                       || c.FlavorProfile.Contains(searchString) || c.CocktailType.Contains(searchString)
                                       || c.JuiceName.Contains(searchString) || c.SyrupName.Contains(searchString)
                                       || c.LiqueurName.Contains(searchString) || c.BitterName.Contains(searchString)
                                       || c.TopperName.Contains(searchString));
            }
            return View(cocktails.ToList());
        }

        // GET: Cocktail/Details/5
        public ActionResult Details(int id)
        {
            var cocktail = GetCocktailById(id);
            return View(cocktail);
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
            var cocktail = context.Cocktail.Where(c => c.CocktailId == id).FirstOrDefault();

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

        // POST: Cocktail/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cocktail cocktail)
        {
            try
            {
                // TODO: Add update logic here
                Cocktail updatedCocktail = context.Cocktail.Where(c => c.CocktailId == id).FirstOrDefault();
                updatedCocktail.CocktailName = cocktail.CocktailName;
                updatedCocktail.CocktailType = cocktail.CocktailType;
                updatedCocktail.FlavorProfile = cocktail.FlavorProfile;
                updatedCocktail.Price = cocktail.Price;
                updatedCocktail.IsBubble = cocktail.IsBubble;
                updatedCocktail.LiquorName = cocktail.LiquorName;
                updatedCocktail.LiquorAmount = cocktail.LiquorAmount;
                updatedCocktail.JuiceName = cocktail.JuiceName;
                updatedCocktail.JuiceAmount = cocktail.JuiceAmount;
                updatedCocktail.SyrupName = cocktail.SyrupName;
                updatedCocktail.SyrupAmount = cocktail.SyrupAmount;
                updatedCocktail.LiqueurName = cocktail.LiqueurName;
                updatedCocktail.LiqueurAmount = cocktail.LiqueurAmount;
                updatedCocktail.BitterName = cocktail.BitterName;
                updatedCocktail.BitterAmount = cocktail.BitterAmount;
                updatedCocktail.TopperName = cocktail.TopperName;
                updatedCocktail.TopperAmount = cocktail.TopperAmount;
                context.SaveChanges();

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
            var cocktail = GetCocktailById(id);
            return View(cocktail);
        }

        // POST: Cocktail/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Cocktail cocktail)
        {
            try
            {
                // TODO: Add delete logic here
                cocktail = GetCocktailById(id);
                context.Cocktail.Remove(cocktail);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult MakeCocktail(int id)
        {
            Cocktail cocktail = GetCocktailById(id);
            Inventory inventory = GetInventoryByManagerId(cocktail.ManagerId);
            var liquorToRemove = Math.Round(cocktail.LiquorAmount / 33.814, 2);

            switch (cocktail.LiquorName)
            {
                case "Vodka":
                    inventory.VodkaBottleCount = inventory.VodkaBottleCount - liquorToRemove;
                    if (inventory.VodkaBottleCount < 3)
                    {
                        SMS.SendSMSToManager("vodka");
                    }
                    break;
                case "Gin":
                    inventory.GinBottleCount = inventory.GinBottleCount - liquorToRemove;
                    if (inventory.GinBottleCount < 2)
                    {
                        SMS.SendSMSToManager("gin");
                    }
                    break;
                case "White Rum":
                    inventory.WhiteRumBottleCount = inventory.WhiteRumBottleCount - liquorToRemove;
                    if (inventory.WhiteRumBottleCount < 2)
                    {
                        SMS.SendSMSToManager("white rum");
                    }
                    break;
                case "Tequila":
                    inventory.TequilaBottleCount = inventory.TequilaBottleCount - liquorToRemove;
                    if (inventory.TequilaBottleCount < 2)
                    {
                        SMS.SendSMSToManager("tequila");
                    }
                    break;
                case "Spiced Rum":
                    inventory.SpicedRumBottleCount = inventory.SpicedRumBottleCount - liquorToRemove;
                    if (inventory.SpicedRumBottleCount < 2)
                    {
                        SMS.SendSMSToManager("spiced rum");
                    }
                    break;
                case "Brandy":
                    inventory.BrandyBottleCount = inventory.BrandyBottleCount - liquorToRemove;
                    if (inventory.BrandyBottleCount < 3)
                    {
                        SMS.SendSMSToManager("brandy");
                    }
                    break;
                case "Whiskey":
                    inventory.WhiskeyBottleCount = inventory.WhiskeyBottleCount - liquorToRemove;
                    if (inventory.WhiskeyBottleCount < 3)
                    {
                        SMS.SendSMSToManager("whiskey");
                    }
                    break;
                case "Scotch":
                    inventory.ScotchBottleCount = inventory.ScotchBottleCount - liquorToRemove;
                    if (inventory.ScotchBottleCount < 1)
                    {
                        SMS.SendSMSToManager("scotch");
                    }
                    break;
                case "Cava":
                    inventory.CavaBottleCount = inventory.CavaBottleCount - liquorToRemove;
                    if (inventory.CavaBottleCount < 3)
                    {
                        SMS.SendSMSToManager("cava");
                    }
                    break;

            }

            return RedirectToAction("RateCocktail");
        }

        public ActionResult RateCocktail(int id)
        {
            return View();
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
        public Cocktail GetCocktailById(int id)
        {
            var cocktail = context.Cocktail.Where(c => c.CocktailId == id).FirstOrDefault();
            return cocktail;
        }
        public Inventory GetInventoryByManagerId(int managerId)
        {
            var bar = context.Bar.Where(b => b.ManagerId == managerId).FirstOrDefault();
            var inventory = context.Inventory.Where(i => i.BarId == bar.BarId).FirstOrDefault();
            return inventory;
        }
    }
}
