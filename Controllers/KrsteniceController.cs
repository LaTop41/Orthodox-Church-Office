using Crkvena_Kancelarija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crkvena_Kancelarija.Controllers
{
    public class KrsteniceController : Controller
    {
        CrkvenaKancelarijaEntities cr = new CrkvenaKancelarijaEntities();
        // GET: Krstenice
        public ActionResult NovaKrstenica()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("UserDashBoard", "Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult NovaKrstenica(Krstenica krstenica)
        {

            try
            {
                cr.Krstenicas.Add(krstenica);
                cr.SaveChanges();
                TempData["NovaKrstenica"] = "Успешно сте креирали нову крштеницу!";
                return RedirectToAction("Index", "Pocetna");

            }
            catch
            {
                return View();
            }



        }
    }
}