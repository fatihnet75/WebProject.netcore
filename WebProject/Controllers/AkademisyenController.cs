using Microsoft.AspNetCore.Mvc;
using WebProject.Models;
using EtüAkademiContext.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebProject.Controllers
{
    public class AkademisyenController : Controller
    {
        private readonly EtuAkademiContext _context;

        public AkademisyenController(EtuAkademiContext context)
        {
            _context = context;
        }

        // Listeleme işlemi
        public  IActionResult Index()
        {
            var people =  _context.Person.ToList();
            return View(people);
        }

        // Ekleme işlemi (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Ekleme işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person.FirstOrDefaultAsync(m => m.AkademisyenNo == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Person.Remove(person);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}