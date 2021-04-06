using Crkvena_Kancelarija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crkvena_Kancelarija.Controllers
{
    public class UmrliceController : Controller
    {
        // GET: Umrlice
        CrkvenaKancelarijaEntities cr = new CrkvenaKancelarijaEntities();

        public ActionResult NovaUmrlica()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("UserDashBoard", "Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult NovaUmrlica(Umrlica umrlica)
        {

            try
            {
                cr.Umrlicas.Add(umrlica);
                cr.SaveChanges();
                return RedirectToAction("Index", "Pocetna");
            }
            catch
            {
                return View();
            }



        }
    }
}