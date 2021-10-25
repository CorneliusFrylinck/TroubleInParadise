using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TroubleInParadise.Data;
using TroubleInParadise.Models;

namespace TroubleInParadise.Areas.User.Controllers
{
    [Area("User")]
    public class PlayersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User/Players/Id
        public async Task<IActionResult> Index(string id)
        {
            var userId = _context.Users.Where(u => u.Email.ToLower() == id.ToLower()).FirstOrDefault().Id;
            if (userId != null)
            {
                var user = _context.users.Where(u => u.NetUserId == userId).FirstOrDefault();
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(await _context.player.Where(p => p.UserId == user.Id).ToListAsync());
                }
            }
            return NotFound();
        }

        // GET: User/Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.player
                .FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // GET: User/Players/Create/id?user         - server id and user email
        [HttpGet("{id}&user={user}")]
        public IActionResult Create(int id, string user)
        {
            int userId = _context.users.Where(u => u.email == user.ToUpper()).FirstOrDefault().Id;
            if (userId == 0)
            {
                return NotFound();
            }
            Player player = new Player();
            player.ServerId = id;
            player.UserId = userId;
            player.Last_Updated = DateTime.UtcNow;
            player.Last_Seen = DateTime.UtcNow;
            player.Created = DateTime.UtcNow;
            return View(player);
        }

        // POST: User/Players/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ServerId,UserId,Last_Seen,Last_Updated,Created,PlayerTypeId")] Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ServerId,UserId")] Player player)
        {
            player.Created = player.Last_Seen = player.Last_Updated = DateTime.UtcNow;
            if (ModelState.IsValid)
            {
                _context.Add(player);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), User.Identity.Name);
            }
            return View(player);
        }

        // GET: User/Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        // POST: User/Players/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ServerId,UserId,Last_Seen,Last_Updated,Created,PlayerTypeId")] Player player)
        {
            if (id != player.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(player);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayerExists(player.Id))
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
            return View(player);
        }

        // GET: User/Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var player = await _context.player
                .FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        // POST: User/Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var player = await _context.player.FindAsync(id);
            _context.player.Remove(player);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), User.Identity.Name);
        }

        private bool PlayerExists(int id)
        {
            return _context.player.Any(e => e.Id == id);
        }
    }
}
