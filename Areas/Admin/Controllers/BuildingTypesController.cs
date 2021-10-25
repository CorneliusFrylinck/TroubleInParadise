using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TroubleInParadise.Data;
using TroubleInParadise.Models;

namespace TroubleInParadise.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BuildingTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BuildingTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/BuildingTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.buildingTypes.ToListAsync());
        }

        // GET: Admin/BuildingTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingType = await _context.buildingTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingType == null)
            {
                return NotFound();
            }

            return View(buildingType);
        }

        // GET: Admin/BuildingTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/BuildingTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] BuildingType buildingType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buildingType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buildingType);
        }

        // GET: Admin/BuildingTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingType = await _context.buildingTypes.FindAsync(id);
            if (buildingType == null)
            {
                return NotFound();
            }
            return View(buildingType);
        }

        // POST: Admin/BuildingTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] BuildingType buildingType)
        {
            if (id != buildingType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buildingType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingTypeExists(buildingType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(buildingType);
        }

        // GET: Admin/BuildingTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingType = await _context.buildingTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingType == null)
            {
                return NotFound();
            }

            return View(buildingType);
        }

        // POST: Admin/BuildingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buildingType = await _context.buildingTypes.FindAsync(id);
            _context.buildingTypes.Remove(buildingType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingTypeExists(int id)
        {
            return _context.buildingTypes.Any(e => e.Id == id);
        }
    }
}
