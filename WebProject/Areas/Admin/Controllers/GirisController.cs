using EtüAkademiContext.Data;
using WebProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebProject.Areas.Admin.Filters;

namespace WebProject.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class GirisController : Controller
    {
        // [ServiceFilter(typeof(AdminUserSecurityAttribute))]

        private readonly EtuAkademiContext db;

        public GirisController(EtuAkademiContext context)
        {
            db = context;
        }

        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GirisSorgula([FromBody] Kullanicilar data)
        {
            try
            {
                string Email = data.Email;
                string Parola = data.Parola;

                if (String.IsNullOrEmpty(Parola) && String.IsNullOrEmpty(Email))
                {
                    return Json(new { Result = false, Message = "Kullanıcı Adınızı ve Şifrenizi Girmediniz!" });
                }
                else if (String.IsNullOrEmpty(Email))
                {
                    return Json(new { Result = false, Message = "Kullanıcı Adınızı girmediniz!" });
                }
                else if (String.IsNullOrEmpty(Parola))
                {
                    return Json(new { Result = false, Message = "Şifrenizi Girmediniz!" });
                }
                else
                {

                    var kullanici = db.Kullanicilar.FirstOrDefault(x => x.Email == Email && x.Parola == Parola && x.Rol == 1);

                    if (kullanici == null) return Json(new { Result = false, Message = "Kullanıcı Adınızı ya da Şifreyi hatalı girdiniz!" });


                    //Güvenlik açısından bilgileri şifreleyerek saklamamız daha doğru bir yöntemdir.
                    //Asp.Net Membership yapısı, bu güvenliği sunmaktadır.

                    HttpContext.Session.SetInt32("Kullanici_ID", kullanici.id); // Yeni bir session oluşturma.
                    HttpContext.Session.SetString("Ad", kullanici.Ad);
                    HttpContext.Session.SetString("Soyad", kullanici.Soyad);
                    HttpContext.Session.SetString("Resim", kullanici.ResimUrl);
                    HttpContext.Session.SetInt32("Rol", kullanici.Rol);



                    HttpContext.Session.SetInt32("KullaniciRol", kullanici.Rol);
                    HttpContext.Session.SetInt32("YoneticiRol", kullanici.Rol);



                    //Burada eğer, kullanıcı bilgileri, sistemde eşleşirse, geriye girişin başarılı
                    //olduğuna dair bir mesaj ve 3 saniye sonra, ana sayfaya yönlendirecek bir
                    //javascript kodu ekliyoruz.        
                    return Json(new { Result = true, Message = "Başarıyla Giriş Yaptınız. Yönlendiriliyorsunuz...", url = "Giris/Anasayfa" });
                    // return "Başarıyla Giriş Yaptınız. Yönlendiriliyorsunuz...<script type='text/javascript'>setTimeout(function(){window.location='/Admin/Giris/AnaSayfa'},2000);</script>";
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = ex.Message });
            }
        }



        //    [HttpPost]
        //public string GirisSorgula()
        //{
        //    string Email = Request.Form["Email"];
        //    string Parola = Request.Form["Parola"];

        //    if (String.IsNullOrEmpty(Parola) && String.IsNullOrEmpty(Email))
        //    {
        //        return "Kullanıcı Adınızı ve Şifrenizi Girmediniz.";
        //    }
        //    else if (String.IsNullOrEmpty(Email))
        //    {
        //        return "Kullanıcı Adınızı girmediniz.";
        //    }
        //    else if (String.IsNullOrEmpty(Parola))
        //    {
        //        return "Şifrenizi Girmediniz.";
        //    }
        //    else
        //    {

        //        var kullanici = db.Kullanicilar.FirstOrDefault(x => x.Email == Email && x.Parola == Parola && x.Rol == 1);

        //        if (kullanici == null) return "Kullanıcı Adınızı ya da Şifreyi hatalı girdiniz.";


        //        //Güvenlik açısından bilgileri şifreleyerek saklamamız daha doğru bir yöntemdir.
        //        //Asp.Net Membership yapısı, bu güvenliği sunmaktadır.

        //        HttpContext.Session.SetInt32("Kullanici_ID", kullanici.Id); // Yeni bir session oluşturma.
        //        HttpContext.Session.SetString("Ad", kullanici.Ad);
        //        HttpContext.Session.SetString("Soyad", kullanici.Soyad);
        //        HttpContext.Session.SetString("Resim", kullanici.KucukResimYolu);
        //        HttpContext.Session.SetInt32("Rol", kullanici.Rol);


        //        if (kullanici.Rol == 1)
        //        {
        //            HttpContext.Session.SetInt32("KullaniciRol", kullanici.Rol);
        //            HttpContext.Session.SetInt32("YoneticiRol", kullanici.Rol);
        //        }


        //        //Burada eğer, kullanıcı bilgileri, sistemde eşleşirse, geriye girişin başarılı
        //        //olduğuna dair bir mesaj ve 3 saniye sonra, ana sayfaya yönlendirecek bir
        //        //javascript kodu ekliyoruz.
        //        return "Başarıyla Giriş Yaptınız. Yönlendiriliyorsunuz...<script type='text/javascript'>setTimeout(function(){window.location='/Admin/Giris/AnaSayfa'},2000);</script>";

        //    }
        //}

        public IActionResult OturumuKapat()
        {
            HttpContext.Session.Clear(); // Tüm sessionları temizle
            return View("Giris");
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        public IActionResult Anasayfa()
        {
            return View();
        }

        public IActionResult Hata()
        {
            return View();
            //return Redirect("/Admin/Giris");
        }


        //[ServiceFilter(typeof(AdminUserSecurityAttribute))]
        public IActionResult GenelAyarlar()
        {
            var genelayarlar = db.GenelAyarlar.FirstOrDefault();

            return View(genelayarlar);
        }

        [HttpPost]
        [Route("Admin/Giris/GenelAyarlar")]
        public IActionResult GenelAyarlar(GenelAyarlar bilgiler)
        {
            var duzenle = db.GenelAyarlar.FirstOrDefault();

            duzenle.SiteAdi = bilgiler.SiteAdi;
            duzenle.MetaAuthor = bilgiler.MetaAuthor;
            //diğerleri de yazılacak


            db.SaveChanges();
            return RedirectToAction("GenelAyarlar", "Giris");
        }





    }
}
