using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Class;

namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var value = context.Blogs.ToList();

            return View(value);
        }
        [HttpGet]
        [Authorize]
        public ActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddBlog(Blog b)
        {
            context.Blogs.Add(b);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult DeleteBlog(int id)
        {
            var blog = context.Blogs.Find(id);
            context.Blogs.Remove(blog);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize]
        public ActionResult UpdateBlog(int id)
        {
            var blogs = context.Blogs.Find(id);
            return View(blogs);
        }
        [HttpPost]
        [Authorize]
        public ActionResult UpdateBlog(Blog b)
        {
            var blg = context.Blogs.Find(b.ID);
            blg.Baslik = b.Baslik;
            blg.Tarih = b.Tarih;
            blg.Aciklama = b.Aciklama;
            blg.BlogImage = b.BlogImage;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult YorumListesi()
        {
            var value = context.Yorumlars.ToList();
            return View(value);
        }
        [Authorize]
        public ActionResult DeleteYorum(int id)
        {
            var yorum = context.Yorumlars.Find(id);
            context.Yorumlars.Remove(yorum);
            context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        [Authorize]
        [HttpGet]
        public ActionResult UpdateYorum(int id)
        {
            var value = context.Yorumlars.Find(id);
            return View(value);
        }
        [HttpPost]
        [Authorize]
        public ActionResult UpdateYorum(Yorumlar y)
        {
            var yorum = context.Yorumlars.Find(y.ID);
            yorum.KullaniciAdi = y.KullaniciAdi;
            yorum.Mail = y.Mail;
            yorum.Yorum = y.Yorum;
            context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        [Authorize]
        public ActionResult HakkimizdaListesi()
        {
            var value = context.Hakkimizdas.ToList();
            return View(value);
        }
        [Authorize]
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = context.Hakkimizdas.Find(id);
            return View(value);
        }
        [HttpPost]
        [Authorize]
        public ActionResult UpdateAbout(Hakkimizda y)
        {
            var hak = context.Hakkimizdas.Find(y.ID);
            hak.Aciklama = y.Aciklama;
            hak.ResimUrl = y.ResimUrl;
            context.SaveChanges();
            return RedirectToAction("HakkimizdaListesi");
        }
        [Authorize]
        public ActionResult ContactListesi()
        {
            var value = context.AdresBlogs.ToList();
            return View(value);
        }
        [Authorize]
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = context.AdresBlogs.Find(id);
            return View(value);
        }
        [HttpPost]
        [Authorize]
        public ActionResult UpdateContact(AdresBlog a)
        {
            var cont = context.AdresBlogs.Find(a.ID);
            cont.Aciklama = a.Aciklama;
            cont.Baslik = a.Baslik;
            cont.AdresAcik = a.AdresAcik;
            cont.Telefon = a.Telefon;
            cont.Mail = a.Mail;
            cont.Konum = a.Konum;
            context.SaveChanges();
            return RedirectToAction("ContactListesi");
        }
    }
}