using Crkvena_Kancelarija.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Crkvena_Kancelarija.Controllers
{
    public class PocetnaController : Controller
    {
        // GET: Pocetna
        CrkvenaKancelarijaEntities cr = new CrkvenaKancelarijaEntities();
        public ActionResult Index()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("UserDashBoard", "Login");
            }

            ViewBag.Dokumenti = Dokument.GetDok();
            return View();
        }


        public ActionResult GetDokumentBySifra(int Sifra)
        {

            if (Sifra == 1)
            {
                return PartialView("_ListaKrstenica", Krstenica.GetBySifraKr(Sifra));
            }
            else if (Sifra == 2)
            {
                return PartialView("_ListaUmrlica", Umrlica.GetBySifraUm(Sifra));
            }
            else 
            {
                return PartialView("_ListaVencanih", VencaniList.GetBySifraVe(Sifra));
            }
        }

        public ActionResult GetByImeK(String ime)
        {
            return PartialView("TraziKrstenicu", Krstenica.GetByIdKr(ime));
        }
        public ActionResult GetByImeU(String ime)
        {
            return PartialView("TraziUmrlicu", Umrlica.GetByIdUm(ime));
        }

        public ActionResult GetByImeV(String ime)
        {
            return PartialView("TraziVencaniList", VencaniList.GetByIdVe(ime));
        }

        public ActionResult EditKrstenica(int id)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("UserDashBoard", "Login");
            }
            Krstenica krstenicaZaAzuriranje = cr.Krstenicas.Where(t => t.SifraKrstenice == id).FirstOrDefault();
            return View(krstenicaZaAzuriranje);
        }

        public ActionResult EditUmrlica(int id)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("UserDashBoard", "Login");
            }
            Umrlica umrlicaZaAzuriranje = cr.Umrlicas.Where(t => t.SifraUmrlice == id).FirstOrDefault();
            return View(umrlicaZaAzuriranje);
        }

        public ActionResult EditVencaniList(int id)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("UserDashBoard", "Login");
            }
            VencaniList vencanilistZaAzuriranje = cr.VencaniLists.Where(t => t.SifraVencanogLista == id).FirstOrDefault();
            return View(vencanilistZaAzuriranje);

        }

        [HttpPost]
        public ActionResult EditKrstenica(Krstenica krstenica)
        {
            Krstenica krstenicaZaIzmenu = cr.Krstenicas.FirstOrDefault(t => t.SifraKrstenice == krstenica.SifraKrstenice);

            krstenicaZaIzmenu.SifraKrstenice = krstenica.SifraKrstenice;

            krstenicaZaIzmenu.ImeVernika = krstenica.ImeVernika;

            krstenicaZaIzmenu.PrezimeVernika = krstenica.PrezimeVernika;

            krstenicaZaIzmenu.Pol = krstenica.Pol;

            krstenicaZaIzmenu.DatumRodjenja = krstenica.DatumRodjenja;

            krstenicaZaIzmenu.Eparhija = krstenica.Eparhija;

            krstenicaZaIzmenu.Hram = krstenica.Hram;

            krstenicaZaIzmenu.TekucaGodina = krstenica.TekucaGodina;

            krstenicaZaIzmenu.ZanimanjeVernika = krstenica.ZanimanjeVernika;

            krstenicaZaIzmenu.MestoRodjenja = krstenica.MestoRodjenja;

            krstenicaZaIzmenu.DatumKrstenja = krstenica.DatumKrstenja;

            krstenicaZaIzmenu.ImeOca = krstenica.ImeOca;

            krstenicaZaIzmenu.PrezimeOca = krstenica.PrezimeOca;

            krstenicaZaIzmenu.ImeMajke = krstenica.ImeMajke;

            krstenicaZaIzmenu.PrezimeMajke = krstenica.PrezimeMajke;

            krstenicaZaIzmenu.ZanimanjeOca = krstenica.ZanimanjeOca;

            krstenicaZaIzmenu.ZanimanjeMajke = krstenica.ZanimanjeMajke;

            krstenicaZaIzmenu.MestoStanovanjaRoditelja = krstenica.MestoStanovanjaRoditelja;

            krstenicaZaIzmenu.NarodnostOca = krstenica.NarodnostMajke;

            krstenicaZaIzmenu.NarodnostMajke = krstenica.NarodnostMajke;

            krstenicaZaIzmenu.DetePoRedu = krstenica.DetePoRedu;

            krstenicaZaIzmenu.DeteBlizanac = krstenica.DeteBlizanac;

            krstenicaZaIzmenu.TelesniNedostaci = krstenica.TelesniNedostaci;

            krstenicaZaIzmenu.ImeKuma = krstenica.ImeKuma;

            krstenicaZaIzmenu.PrezimeKuma = krstenica.PrezimeKuma;

            krstenicaZaIzmenu.MestoStanovanjaKuma = krstenica.MestoStanovanjaKuma;

            krstenicaZaIzmenu.ImeSvestenika = krstenica.ImeSvestenika;

            krstenicaZaIzmenu.PrezimeSvestenika = krstenica.PrezimeSvestenika;

            krstenicaZaIzmenu.Primedba = krstenica.Primedba;

            cr.SaveChanges();
            TempData["PorukaIzmeneK"] = "Успешно сте изменили крштеницу!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditUmrlica(Umrlica umrlica)
        {
            Umrlica umrlicaZaIzmenu = cr.Umrlicas.FirstOrDefault(t => t.SifraUmrlice == umrlica.SifraUmrlice);

            umrlicaZaIzmenu.SifraUmrlice = umrlica.SifraUmrlice;

            umrlicaZaIzmenu.ImePreminulog = umrlica.ImePreminulog;

            umrlicaZaIzmenu.PrezimePreminulog = umrlica.PrezimePreminulog;

            umrlicaZaIzmenu.Pol = umrlica.Pol;

            umrlicaZaIzmenu.DatumRodjenja = umrlica.DatumRodjenja;

            umrlicaZaIzmenu.MestoRodjenja = umrlica.MestoRodjenja;

            umrlicaZaIzmenu.Eparhija = umrlica.Eparhija;

            umrlicaZaIzmenu.Hram = umrlica.Hram;

            umrlicaZaIzmenu.TekucaGodina = umrlica.TekucaGodina;

            umrlicaZaIzmenu.ZanimanjePreminulog = umrlica.ZanimanjePreminulog;

            umrlicaZaIzmenu.BracnoStanje = umrlica.BracnoStanje;

            umrlicaZaIzmenu.ImeBracnogPartnera = umrlica.ImeBracnogPartnera;

            umrlicaZaIzmenu.PrezimeBracnogPartnera = umrlica.PrezimeBracnogPartnera;

            umrlicaZaIzmenu.ZanimanjeBracnogPartnera = umrlica.ZanimanjeBracnogPartnera;

            umrlicaZaIzmenu.MestoStanovanjaBracnogPartnera = umrlica.MestoStanovanjaBracnogPartnera;

            umrlicaZaIzmenu.BrojDece = Convert.ToInt32(umrlica.BrojDece);

            umrlicaZaIzmenu.PodaciODeci = umrlica.PodaciODeci;

            umrlicaZaIzmenu.MestoPreminuca = umrlica.MestoPreminuca;

            umrlicaZaIzmenu.DatumSmrti = umrlica.DatumSmrti;

            umrlicaZaIzmenu.DatumSahrane = umrlica.DatumSahrane;

            umrlicaZaIzmenu.MestoIGrobljeSahrane = umrlica.MestoIGrobljeSahrane;

            umrlicaZaIzmenu.UzrokSmrti = umrlica.UzrokSmrti;

            umrlicaZaIzmenu.ImeSvestenika = umrlica.ImeSvestenika;

            umrlicaZaIzmenu.PrezimeSvestenika = umrlica.PrezimeSvestenika;

            umrlicaZaIzmenu.Primedba = umrlica.Primedba;

            cr.SaveChanges();
            TempData["PorukaIzmeneU"] = "Успешно сте изменили умрлицу!";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult EditVencaniList(VencaniList vencaniList)
        {
            VencaniList vencaniListZaIzmenu = cr.VencaniLists.FirstOrDefault(t => t.SifraVencanogLista == vencaniList.SifraVencanogLista);

            vencaniListZaIzmenu.SifraVencanogLista = vencaniList.SifraVencanogLista;

            vencaniListZaIzmenu.ImeMladozenje = vencaniList.ImeMladozenje;

            vencaniListZaIzmenu.PrezimeMladozenje = vencaniList.PrezimeMladozenje;

            vencaniListZaIzmenu.ImeMlade = vencaniList.ImeMlade;

            vencaniListZaIzmenu.PrezimeMlade = vencaniList.PrezimeMlade;

            vencaniListZaIzmenu.DatumRodjenjaMladozenje = vencaniList.DatumRodjenjaMladozenje;

            vencaniListZaIzmenu.DatumRodjenjaMlade = vencaniList.DatumRodjenjaMlade;

            vencaniListZaIzmenu.MestoStanovanjaMladenaca = vencaniList.MestoStanovanjaMladenaca;

            vencaniListZaIzmenu.VeroispovestMladozenje = vencaniList.VeroispovestMladozenje;

            vencaniListZaIzmenu.VeroispovestMlade = vencaniList.VeroispovestMlade;

            vencaniListZaIzmenu.NarodnostMladozenje = vencaniList.NarodnostMladozenje;

            vencaniListZaIzmenu.NarodnostMlade = vencaniList.NarodnostMlade;

            vencaniListZaIzmenu.Eparhija = vencaniList.Eparhija;

            vencaniListZaIzmenu.Hram = vencaniList.Hram;

            vencaniListZaIzmenu.TekucaGodina = vencaniList.TekucaGodina;

            vencaniListZaIzmenu.ImeOcaMladozenje = vencaniList.ImeOcaMladozenje;

            vencaniListZaIzmenu.PrezimeOcaMladozenje = vencaniList.PrezimeOcaMladozenje;

            vencaniListZaIzmenu.ImeMajkeMladozenje = vencaniList.ImeMajkeMladozenje;

            vencaniListZaIzmenu.PrezimeMajkeMladozenje = vencaniList.PrezimeMajkeMladozenje;

            vencaniListZaIzmenu.ImeOcaMlade = vencaniList.ImeOcaMlade;

            vencaniListZaIzmenu.PrezimeOcaMlade = vencaniList.PrezimeOcaMlade;

            vencaniListZaIzmenu.ImeMajkeMlade = vencaniList.ImeMajkeMlade;

            vencaniListZaIzmenu.PrezimeMajkeMlade = vencaniList.PrezimeMajkeMlade;

            vencaniListZaIzmenu.BrakPoReduMladozenja = vencaniList.BrakPoReduMladozenja;

            vencaniListZaIzmenu.BrakPoReduMlada = vencaniList.BrakPoReduMlada;

            vencaniListZaIzmenu.IspitaniIOglaseni = vencaniList.IspitaniIOglaseni;

            vencaniListZaIzmenu.DatumVencanja = vencaniList.DatumVencanja;

            vencaniListZaIzmenu.MestoVencanja = vencaniList.MestoVencanja;

            vencaniListZaIzmenu.HramVencanja = vencaniList.HramVencanja;

            vencaniListZaIzmenu.ImeIPrezimeKuma = vencaniList.ImeIPrezimeKuma;

            vencaniListZaIzmenu.ZanimanjeKuma = vencaniList.ZanimanjeKuma;

            vencaniListZaIzmenu.MestoStanovanjaKuma = vencaniList.MestoStanovanjaKuma;

            vencaniListZaIzmenu.ImeIPrezimeStarogSvata = vencaniList.ImeIPrezimeStarogSvata;

            vencaniListZaIzmenu.ZanimanjeStarogSvata = vencaniList.ZanimanjeStarogSvata;

            vencaniListZaIzmenu.VeroispovestStarogSvata = vencaniList.VeroispovestStarogSvata;

            vencaniListZaIzmenu.MestoStanovanjaStarogSvata = vencaniList.MestoStanovanjaStarogSvata;

            vencaniListZaIzmenu.Smetnje = vencaniList.Smetnje;

            vencaniListZaIzmenu.Primedba = vencaniList.Primedba;

            cr.SaveChanges();
            TempData["PorukaIzmeneV"] = "Успешно сте изменили венчани лист!";
            return RedirectToAction("Index");
        }

        public ActionResult DeleteKrstenica(int id)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("UserDashBoard", "Login");
            }
            Krstenica krstenicaZaBrisanje = cr.Krstenicas.Where(t => t.SifraKrstenice == id).FirstOrDefault();
            return View(krstenicaZaBrisanje);

        }
        [HttpPost]
        public ActionResult DeleteKrstenica(int id, Krstenica krstenica)
        {
            Krstenica k = cr.Krstenicas.Where(t => t.SifraKrstenice == id).FirstOrDefault();

            cr.Krstenicas.Remove(k);
            cr.SaveChanges();
            TempData["PorukaDeleteK"] = "Успешно сте избрисали крштеницу!";
            return RedirectToAction("Index");
        }


        public ActionResult DeleteUmrlica(int id)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("UserDashBoard", "Login");
            }
            Umrlica umrlicaZaBrisanje = cr.Umrlicas.Where(t => t.SifraUmrlice == id).FirstOrDefault();
            return View(umrlicaZaBrisanje);

        }
        [HttpPost]
        public ActionResult DeleteUmrlica(int id, Umrlica umrlica)
        {
            Umrlica u = cr.Umrlicas.Where(t => t.SifraUmrlice == id).FirstOrDefault();

            cr.Umrlicas.Remove(u);
            cr.SaveChanges();
            TempData["PorukaDeleteU"] = "Успешно сте избрисали умрлицу!";
            return RedirectToAction("Index");
        }


        public ActionResult DeleteVencaniList(int id)
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("UserDashBoard", "Login");
            }
            VencaniList vencaniListZaBrisanje = cr.VencaniLists.Where(t => t.SifraVencanogLista == id).FirstOrDefault();
            return View(vencaniListZaBrisanje);

        }
        [HttpPost]
        public ActionResult DeleteVencaniList(int id, VencaniList vencaniList)
        {
            VencaniList v = cr.VencaniLists.Where(t => t.SifraVencanogLista == id).FirstOrDefault();

            cr.VencaniLists.Remove(v);
            cr.SaveChanges();
            TempData["PorukaDeleteV"] = "Успешно сте избрисали венчани лист!";
            return RedirectToAction("Index");
        }

        public ActionResult KrstenicaDetalji(int id)
        {
            
            Krstenica krDetalji = cr.Krstenicas.Where(t => t.SifraKrstenice == id).FirstOrDefault();
            return View(krDetalji);

        }
        public ActionResult UmrlicaDetalji(int id)
        {
           
            Umrlica umDetalji = cr.Umrlicas.Where(t => t.SifraUmrlice == id).FirstOrDefault();
            return View(umDetalji);

        }
        public ActionResult VencaniListDetalji(int id)
        {
           
            VencaniList veDetalji = cr.VencaniLists.Where(t => t.SifraVencanogLista == id).FirstOrDefault();
            return View(veDetalji);

        }

        public ActionResult PrintK(int id)
        {
          
            var q = new ActionAsPdf("KrstenicaDetalji", new { id = id })
            {
               PageMargins = new Rotativa.Options.Margins(10,10,10,10),
               PageSize = Rotativa.Options.Size.A4,
               PageOrientation = Rotativa.Options.Orientation.Landscape

            }; 
            return q;
        }

        public ActionResult PrintU(int id)
        {
            
            var w = new ActionAsPdf("UmrlicaDetalji", new { id = id });
            return w;
        }

        public ActionResult PrintV(int id)
        {
            
            var e = new ActionAsPdf("VencaniListDetalji", new { id = id });
            return e;
        }
    }
}
