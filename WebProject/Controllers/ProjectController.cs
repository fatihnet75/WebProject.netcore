using EtüAkademiContext.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class ProjectController : Controller
    {
        private readonly EtuAkademiContext _context;

        public ProjectController(EtuAkademiContext context)
        {
            _context = context;
        }

        // Listeleme işlemi
        public IActionResult Index()
        {
            var projects = _context.Project.ToList();
            return View(projects);
        }

        // Ekleme işlemi (GET)
        public IActionResult Create()
        {
            ViewBag.PersonList = _context.Person.ToList();
            return View();
        }

        // Ekleme işlemi (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Project.Add(project);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.PersonList = _context.Person.ToList();
            return View(project);
        }

        // Silme işlemi (GET)
        public async Task<IActionResult> Delete(int? projeNo)
        {
            if (projeNo == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.ProjeNo == projeNo);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // Silme işlemi (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int projeNo)
        {
            var project = await _context.Project.FindAsync(projeNo);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int projeNo)
        {
            return _context.Project.Any(e => e.ProjeNo == projeNo);
        }
    }
}
