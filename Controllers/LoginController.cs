using Crkvena_Kancelarija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crkvena_Kancelarija.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Autorizacija(Login login)
        {
            CrkvenaKancelarijaEntities ck = new CrkvenaKancelarijaEntities();
            //Додај ид логин у линк
            var pr = ck.Logins.Where(x => x.Korisnik == login.Korisnik  && x.Sifra == login.Sifra && x.TipKorisnika == "korisnik").FirstOrDefault();
            var pr1 = ck.Logins.Where(y => y.Korisnik == login.Korisnik && y.Sifra == login.Sifra && y.TipKorisnika == "admin" ).FirstOrDefault();
            if (pr1 == null && pr==null)
            {
                login.LoginErrorPoruka = "Унели сте погрешно корисничко име или шифру.";
                return View("Index", login);
            }
            else if(pr1 !=null && pr == null)
            {
                Session["id"] = pr1.ID;
                Session["korisnik"] = login.Korisnik;
                TempData["PorukaAdminu"] = "Добродошли свештениче!";
                TempData["id"] = login.ID;
                return RedirectToAction("Index", "Pocetna");
            }
            else
            {
                Session["id"] = pr.ID;
                Session["korisnik"] = login.Korisnik;
                TempData["PorukaKorisniku"] = "Добродошли!";
                return RedirectToAction("NovaMolba", "Molba");
            }
        }

        public ActionResult Logout()
        {
            int i = (int)Session["id"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public ActionResult UserDashBoard()
        {
            if (Session["id"] != null)
            {
                return RedirectToAction("Index", "Pregledi");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
    }
}