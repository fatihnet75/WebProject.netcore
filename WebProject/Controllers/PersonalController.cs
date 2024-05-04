using Microsoft.AspNetCore.Mvc;
using WebProject.Models;
using EtüAkademiContext.Data; // EtüAkademiContext'ın bulunduğu isim alanı eklenmeli
using System.Linq;
using System.Collections.Generic;


namespace WebProject.Controllers
{
    public class PersonalController : Controller
    {
         private readonly EtüAkademiContext.Data.EtuAkademiContext _context; // EtüAkademiContext'ı tür olarak kullanmak için doğru isim alanı kullanılmalı

        public PersonalController(EtüAkademiContext.Data.EtuAkademiContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var targetPerson = _context.Person.FirstOrDefault(person => person.AkademisyenNo == id);

            if (targetPerson != null)
            {
                return View(new List<WebProject.Models.Person> { targetPerson }); // Kişinin detaylarını içeren view'e koleksiyon olarak yönlendir
            }

            return NotFound(); // Kişi bulunamazsa 404 Not Found dön
        }

    }
}
