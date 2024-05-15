using EtüAkademiContext.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class AdminLoginController : Controller
    {
        private readonly EtuAkademiContext _db;

        public AdminLoginController(EtuAkademiContext context)
        {
            _db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GirisSorgula([FromBody] Kullanicilar data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (string.IsNullOrEmpty(data.Email))
                {
                    ModelState.AddModelError("Email", "Email adresi boş olamaz.");
                    return BadRequest(ModelState);
                }

                if (string.IsNullOrEmpty(data.Parola))
                {
                    ModelState.AddModelError("Parola", "Parola boş olamaz.");
                    return BadRequest(ModelState);
                }

                var kullanici = _db.Kullanicilar.FirstOrDefault(u => u.Email == data.Email && u.Parola == data.Parola);
                if (kullanici == null)
                {
                    ModelState.AddModelError("Giris", "Geçersiz Email veya Parola.");
                    return BadRequest(ModelState);
                }

                return Ok(new { Result = true, Message = "Başarıyla Giriş Yaptınız.", url = "/AdminAnasayfa/Index" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Result = false, Message = ex.Message });
            }
        }
    }

}
