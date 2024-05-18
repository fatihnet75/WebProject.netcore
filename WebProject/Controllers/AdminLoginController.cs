using EtüAkademiContext.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

                // Veritabanından kullanıcıyı bul
                var kullanici = _db.Kullanicilar.FirstOrDefault(u => u.Email == data.Email);
                if (kullanici == null)
                {
                    ModelState.AddModelError("Giris", "Geçersiz Email veya Parola.");
                    return BadRequest(ModelState);
                }

                // Girilen parolayı SHA-256 ile şifrele
                string hashedPassword = HashSHA256(data.Parola);

                // Veritabanındaki şifre ile karşılaştır
                if (kullanici.Parola != hashedPassword)
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

        // SHA-256 ile şifreleme işlemi
        private string HashSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
