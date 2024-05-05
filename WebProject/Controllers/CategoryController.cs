using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly EtüAkademiContext.Data.EtuAkademiContext _context; // EtüAkademiContext'ı tür olarak kullanmak için doğru isim alanı kullanılmalı

        public CategoryController(EtüAkademiContext.Data.EtuAkademiContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            // Belirli bir kategoriye ait tüm kişileri veritabanından çekiyoruz
            var peopleInCategory = _context.Person.Where(p => p.BolumNo == id).ToList();

            return View(peopleInCategory); // Kişileri Index.cshtml görünümüne iletiyoruz
        }


    }
}
