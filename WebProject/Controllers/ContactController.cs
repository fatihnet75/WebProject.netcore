using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly EtüAkademiContext.Data.EtuAkademiContext _context; // EtüAkademiContext'ı tür olarak kullanmak için doğru isim alanı kullanılmalı

        public ContactController(EtüAkademiContext.Data.EtuAkademiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            // Tüm kişileri veritabanından çekiyoruz
            var persons = _context.Person.ToList();

            return View(persons); // Kişileri Index.cshtml görünümüne iletiyoruz
        }
    }
}
