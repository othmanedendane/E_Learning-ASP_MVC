using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class SecondController : Controller
    {
        // GET: Second
        public ActionResult Index()
        {
            return View();
        }

     
        public ActionResult Succes()
        {
            return View();
        }
        public ActionResult Fail()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Insert(WebApplication3.Models.Class1 li)
        {


            return View(li);
        }

        public ActionResult InsertData(WebApplication3.Models.Class1 li)
        {
            if (ModelState.IsValid)
            {
                WebApplication3.Models.Enterwhatever en = new Models.Enterwhatever();
                en.InsertData(li);
                //  ViewBag.name = li.nom;


                try
                {
                    if (ModelState.IsValid)
                    {
                        var senderEmail = new MailAddress("funfunny573@gmail.com", "Othmane.D");
                        var receiverEmail = new MailAddress(li.nom, "Receiver");
                        var passwordd = "dimaraja";
                        var body = "Votre Username est : " + li.login + "  et Votre Password est : " + li.pw;
                        var smtp = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            UseDefaultCredentials = false,
                            Credentials = new NetworkCredential(senderEmail.Address, passwordd)
                        };
                        using (var mess = new MailMessage(senderEmail, receiverEmail)
                        {
                            Subject = "Personal first Login Infos",
                            Body = body

                        })
                        {
                            smtp.Send(mess);
                        }
                        return View();
                    }
                }
                catch (Exception)
                {
                    ViewBag.Error = "Some Error";
                }




                @ViewBag.data = "Data inserted successfully !";
                return View("Insert");
            }
            else
            {
                return View("Insert");
            }



        }


        public ActionResult Loginn(WebApplication3.Models.Class1 li)
        {
            return View(li);

        }
        public ActionResult Loginsearch(WebApplication3.Models.Class1 li)
        {
            WebApplication3.Models.Search ss = new Models.Search();
            string pass = ss.searchLP(li);


            if (pass == li.pw)
            {

                return View("Succes");

            }
            @ViewBag.data = "invalide Login (Plz try again...)";
            return View("Fail");

        }





    }
}