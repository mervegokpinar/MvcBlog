using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mervegokpinar.com.Models;

namespace mervegokpinar.com.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Login()
        {
           return View();
        }
        
        public ActionResult Kaydol()
        {
            return View();
        }

        BlogDB _db = new BlogDB();

        [HttpPost]
        public ActionResult Ekle(Kullanici gonKul)
        {
            Kullanici kln = new Kullanici();
            kln.username = gonKul.username;
            kln.email = gonKul.email;
            kln.password = gonKul.password;
            _db.Kullanicis.Add(kln);
            _db.SaveChanges();          
            return RedirectToAction("Login");
        }

        public  ActionResult Default()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(string username, string pass)
        {
            using (BlogDB db = new BlogDB())
            {
                var kln = _db.Kullanicis.Where(a => a.username == username && a.password == pass).SingleOrDefault();
                if (kln != null)
                {
                    return RedirectToAction("HomePage", "Home");
                }
                else
                {
                    return RedirectToAction("Kaydol", "Home");
                }
            }          
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Default(FormCollection frm)
        {
            string makale = frm.Get("makale");
            MakaleDB _db = new MakaleDB();
            Makale m = new Makale();
             m.yazi = makale;
            _db.Makales.Add(m);
            _db.SaveChanges();
            return RedirectToAction("MakaleList");
        }

        MakaleDB _dbM = new MakaleDB();
        public ActionResult MakaleList()
        {
            var makaleler = _dbM.Makales.ToList();
            return View(makaleler);
        }

        public ActionResult HomePage()
        {
            return View();
        }


        MakaleDB _dbK = new MakaleDB();
        public ActionResult Duzenle(int id)
        {
            Makale duzenlnenecek = _dbK.Makales.Find(id);
            return View(duzenlnenecek);
        }

        [HttpPost]

        [ValidateInput(false)]

        public ActionResult Duzenle2(Makale duzenlenen)
        {
           
            Makale gonderilecek = _dbK.Makales.Find(duzenlenen.ID);
            gonderilecek.yazi = duzenlenen.yazi;        
            _dbK.SaveChanges();
            return RedirectToAction("MakaleList");
        }

        public ActionResult Sil(int id)
        {
            Makale mk = _dbK.Makales.Find(id);
            _dbK.Makales.Remove(mk);
            _dbK.SaveChanges();
            return RedirectToAction("MakaleList");
        }
    }
}