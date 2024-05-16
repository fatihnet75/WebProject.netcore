using EtüAkademiContext.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class BolumController : Controller
    {
        private readonly EtuAkademiContext _context;

        public BolumController(EtuAkademiContext context)
        {
            _context = context;
        }
        // Listeleme işlemi
        public IActionResult Index()
        {
            var Bolum = _context.Bolum.ToList();
            return View(Bolum);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bolum bolum)
        {
            if (ModelState.IsValid)
            {
                _context.Bolum.Add(bolum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bolum);
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Bolum = await _context.Bolum.FirstOrDefaultAsync(m => m.id == id);
            if (Bolum == null)
            {
                return NotFound();
            }

            return View(Bolum);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var bolum = await _context.Bolum.FindAsync(id);
            _context.Bolum.Remove(bolum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



    }
}
