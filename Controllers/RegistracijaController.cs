using Crkvena_Kancelarija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crkvena_Kancelarija.Controllers
{
    public class RegistracijaController : Controller
    {
        CrkvenaKancelarijaEntities cr = new CrkvenaKancelarijaEntities();
        // GET: Registracija
        public ActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Index(Login registracija)
        {
            if (ModelState.IsValid)
            {
                var email = cr.Logins.Any(x => x.Email == registracija.Email);
                if (email)
                {
                    TempData["EmailPostoji"] = "Корисник са том е-поштом већ постоји!";
                    return View();
                }
                //registracija.Poruka = "Успешно сте послали молбу, ваш документ можете преузети у вашој цркви/манастиру.";
                cr.Logins.Add(registracija);
                cr.SaveChanges();
                TempData["Uspeh"] = "Успешно сте се регистровали!";
                return RedirectToAction("Index", "Login");

                
            }
            return View();
        }
    }
}