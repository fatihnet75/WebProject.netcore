using EtüAkademiContext.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Controllers
{
    public class MainController : Controller
    {
        private EtuAkademiContext _context;

        public MainController(EtüAkademiContext.Data.EtuAkademiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            // Tüm kişileri veritabanından çekiyoruz
            var Projects = _context.Project.ToList();

            return View(Projects); // Kişileri Index.cshtml görünümüne iletiyoruz
        }
    }
}
