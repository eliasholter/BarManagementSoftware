using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using static BarManagerProgram.Models.TwilioAPIKey;
using BarManagerProgram.Models;
using Microsoft.AspNet.Identity;

namespace PickUpSports.Controllers
{
    public class SMSController : TwilioController
    {
        public ApplicationDbContext context;

        public SMSController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult SendSMSToManager(string liquorName)
        {
            var accountSid = TwilioAcct;
            var authToken = TwilioToken;
            TwilioClient.Init(accountSid, authToken);

            var userId = User.Identity.GetUserId();
            var bartender = context.Bartender.Where(b => b.ApplicationId == userId).FirstOrDefault();
            var manager = context.Manager.Where(m => m.ManagerId == bartender.ManagerId).FirstOrDefault();



            var message = MessageResource.Create(
                body: "Your stock of " + liquorName + "is below your inventory threshold. Remember to add to your next order.",
                from: new PhoneNumber("+12562420890"),
                to: new PhoneNumber(manager.PhoneNumber)
            );

            //Console.WriteLine($"Message to {manager.PhoneNumber} has been {message.Status}.");

            return RedirectToAction("Index", "Cocktail");
        }
    }
}