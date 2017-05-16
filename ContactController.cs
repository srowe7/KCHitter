using KCHitterDAD;
using KCHitterDAD.Models;
using KCHitterDAD.Services;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KCHitterDaD.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ContactForm myContactForm)
        {
            bool success;
            string body = "<p>The following is a message from {0} ({1})</p><p>{2}</p>";
            success =  SendMessage(string.Format(body, myContactForm.SenderName, myContactForm.Email, myContactForm.Message));
            if (success )       
                return View("ThankYou");
            else
                return View("MessageNotSent");
        }

        public bool SendMessage(string message)
        {
            var msgService = new KCHitterDAD.Services.EmailService();
           return msgService.Send(message);
              }


    }
}