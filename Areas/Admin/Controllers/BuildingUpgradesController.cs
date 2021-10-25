using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TroubleInParadise.Data;
using TroubleInParadise.Models;

namespace TroubleInParadise.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BuildingUpgradesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BuildingUpgradesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/BuildingUpgrades
        public async Task<IActionResult> Index()
        {
            return View(await _context.buildingUpgrades.ToListAsync());
        }

        // GET: Admin/BuildingUpgrades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingUpgrade = await _context.buildingUpgrades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingUpgrade == null)
            {
                return NotFound();
            }

            return View(buildingUpgrade);
        }

        // GET: Admin/BuildingUpgrades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/BuildingUpgrades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UpgradeId")] BuildingUpgrade buildingUpgrade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buildingUpgrade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buildingUpgrade);
        }

        // GET: Admin/BuildingUpgrades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingUpgrade = await _context.buildingUpgrades.FindAsync(id);
            if (buildingUpgrade == null)
            {
                return NotFound();
            }
            return View(buildingUpgrade);
        }

        // POST: Admin/BuildingUpgrades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UpgradeId")] BuildingUpgrade buildingUpgrade)
        {
            if (id != buildingUpgrade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buildingUpgrade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingUpgradeExists(buildingUpgrade.Id))
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
            return View(buildingUpgrade);
        }

        // GET: Admin/BuildingUpgrades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingUpgrade = await _context.buildingUpgrades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buildingUpgrade == null)
            {
                return NotFound();
            }

            return View(buildingUpgrade);
        }

        // POST: Admin/BuildingUpgrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buildingUpgrade = await _context.buildingUpgrades.FindAsync(id);
            _context.buildingUpgrades.Remove(buildingUpgrade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingUpgradeExists(int id)
        {
            return _context.buildingUpgrades.Any(e => e.Id == id);
        }
    }
}
