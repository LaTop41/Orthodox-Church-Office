using Crkvena_Kancelarija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crkvena_Kancelarija.Controllers
{
    public class VencaniListoviController : Controller
    {
        
        // GET: VencaniListovi
        CrkvenaKancelarijaEntities cr = new CrkvenaKancelarijaEntities();

        public ActionResult NoviVencaniList()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("UserDashBoard", "Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult NoviVencaniList(VencaniList vencaniList)
        {

            try
            {
                cr.VencaniLists.Add(vencaniList);
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