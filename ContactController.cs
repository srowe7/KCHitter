using KCHitterDAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KCHitterDAD.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return View(new ContactForm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> Submit(ContactForm model)
        {
            bool isMessageSent = true;

            if (ModelState.IsValid)
            {
                try
                {
                    await EmailService.SendContactForm(model);
                }
                catch (Exception ex)
                {
                    isMessageSent = false;
                }
            }
            else
            {
                isMessageSent = false;
            }
            return PartialView("_SubmitMessage", isMessageSent);
        }
    }
}