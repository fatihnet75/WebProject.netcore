using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EtüAkademiContext.Data;
using Microsoft.AspNetCore.Mvc;
using WebProject.Models; // EtuAkademiContext'ı içeren namespace

namespace WebProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly EtuAkademiContext _context; // EtuAkademiContext tipinde bir alan tanımladık

        public HomeController(EtuAkademiContext context) // Constructor injection kullanarak EtuAkademiContext nesnesini alıyoruz
        {
            _context = context;
        }

        public EtuAkademiContext Context => _context;

        public IActionResult Index()
        {
            // Veritabanından bölüm verilerini alıp ViewBag'e aktarıyoruz
            ViewBag.Bolumadi = Context.Bolum.ToList();

            return View();
        }
    }
}
