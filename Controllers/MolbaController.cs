using Crkvena_Kancelarija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crkvena_Kancelarija.Controllers
{
    public class MolbaController : Controller
    {
        CrkvenaKancelarijaEntities cr = new CrkvenaKancelarijaEntities();
        // GET: Molba
        public ActionResult NovaMolba()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("UserDashBoard", "Login");
            }
            return View();
            
        }

        [HttpPost]
        public ActionResult NovaMolba(Narudzbenica narudzbenica)
        {
            try
            {
               
                cr.Narudzbenicas.Add(narudzbenica);
                cr.SaveChanges();
                TempData["NovaMolba"] = "Успешно сте послали молбу!";
                return RedirectToAction("NovaMolba", "Molba");

            }
            catch
            {
                return View();
                
            }
        }

        public ActionResult listaMolbi()
        {
            return View("listaMolbi", Narudzbenica.listaMolbi());
        }


        public ActionResult DeleteMolba(int id)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("UserDashBoard", "Login");
            }
            Narudzbenica narudzbenicaZaBrisanje = cr.Narudzbenicas.Where(t => t.SifraNarudzbenice == id).FirstOrDefault();
            return View(narudzbenicaZaBrisanje);

        }
        [HttpPost]
        public ActionResult DeleteMolba(int id, Narudzbenica narudzbenica)
        {
            Narudzbenica k = cr.Narudzbenicas.Where(t => t.SifraNarudzbenice == id).FirstOrDefault();

            cr.Narudzbenicas.Remove(k);
            cr.SaveChanges();
            TempData["DeleteMolba"] = "Успешно сте обрисали молбу!";
            return RedirectToAction("listaMolbi", "Molba");
        }

        public ActionResult GetByDate(DateTime start, DateTime end)
        {
            return View("listaMolbi", Narudzbenica.GetByDate(start, end));
        }

       
        
        public ActionResult resiMolbu(int id)
        {
            Narudzbenica k = cr.Narudzbenicas.Where(t => t.SifraNarudzbenice == id).FirstOrDefault();

            k.Reseno = true;
            cr.SaveChanges();
            
            return RedirectToAction("listaMolbi", "Molba");
        }
    }
}