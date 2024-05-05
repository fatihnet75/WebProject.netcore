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
            // Kişiyi veritabanından al
            var person = _context.Person.FirstOrDefault(p => p.AkademisyenNo == id);

            // Kişiye ait projeleri veritabanından al
            var projects = _context.Project.Where(project => project.ProjeNe == id).ToList();

            // Kişi ve projelerin koleksiyonunu View'e gönder
            var personProjects = new Dictionary<Person, List<Project>>();
            personProjects.Add(person, projects);
            return View(personProjects);
        }




    }
}
