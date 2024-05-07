using EtüAkademiContext.Data;
using WebProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using WebProject.Areas.Admin.Filters;
namespace WebProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GirisController : Controller
    {
        private readonly EtuAkademiContext _db;

        public GirisController(EtuAkademiContext context)
        {
            _db = context;
        }

        [HttpGet]
        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GirisSorgula( Login data)
        {
            try
            {
                string Email = data.Email;
                string Parola = data.Parola;

                if (String.IsNullOrEmpty(Parola) || String.IsNullOrEmpty(Email))
                {
                    return Json(new { Result = false, Message = "Kullanıcı Adınızı ve Şifrenizi Girmediniz!" });
                }
                else
                {
                    var kullanici = _db.Kullanicilar.FirstOrDefault(x => x.Email == Email && x.Parola == Parola && x.Rol == 1);

                    if (kullanici == null)
                        return Json(new { Result = false, Message = "Kullanıcı Adınızı ya da Şifreyi hatalı girdiniz!" });

                    // Başarılı giriş durumunda gerekli işlemleri yapın
                    // Örneğin, oturum bilgilerini saklayın

                    return Json(new { Result = true, Message = "Başarıyla Giriş Yaptınız. Yönlendiriliyorsunuz...", url = Url.Action("Anasayfa") });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = ex.Message });
            }
        }


        public IActionResult OturumuKapat()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Giris");
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        public IActionResult Anasayfa()
        {
            return View();
        }

        public IActionResult Hata()
        {
            return View();
        }

        public IActionResult GenelAyarlar()
        {
            var genelayarlar = _db.GenelAyarlar.FirstOrDefault();
            return View(genelayarlar);
        }

        [HttpPost]
        public IActionResult GenelAyarlar(GenelAyarlar bilgiler)
        {
            var duzenle = _db.GenelAyarlar.FirstOrDefault();
            duzenle.SiteAdi = bilgiler.SiteAdi;
            duzenle.MetaAuthor = bilgiler.MetaAuthor;
            // diğer bilgileri de düzenleyin

            _db.SaveChanges();
            return RedirectToAction("GenelAyarlar");
        }
    }
}
