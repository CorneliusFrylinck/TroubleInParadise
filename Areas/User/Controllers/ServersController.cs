using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TroubleInParadise.Data;
using TroubleInParadise.Models;

namespace TroubleInParadise.Areas.User.Controllers
{
    [Area("User")]
    public class ServersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User/Servers/id                     id => user email
        public async Task<IActionResult> Index(string id)
        {
            IEnumerable<Server> servers = await _context.servers.ToListAsync();
            List<PlayerServer> playerServers = new List<PlayerServer>();
            foreach (Server server in servers)
            {
                PlayerServer playerServer = new PlayerServer();
                playerServer.Id = server.Id;
                playerServer.Name = server.Name;
                playerServer.ReleaseDate = server.ReleaseDate;
                playerServer.CloseDate = server.CloseDate;
                playerServer.Created = server.Created;

                Models.User usr = await _context.users.Where(u => u.email == id.ToUpper()).FirstOrDefaultAsync() ?? new Models.User();
                Player player = await _context.player.Where(p => p.UserId == usr.Id && p.ServerId == server.Id).FirstOrDefaultAsync() ?? new Player();

                playerServer.HasPlayer = player.Id == 0 ? false : true;

                playerServers.Add(playerServer);
            }
            return View(playerServers);
        }

        // GET: User/Servers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var server = await _context.servers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (server == null)
            {
                return NotFound();
            }

            return View(server);
        }

        // GET: User/Servers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Servers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Created,ReleaseDate,CloseDate")] Server server)
        {
            if (ModelState.IsValid)
            {
                _context.Add(server);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(server);
        }

        // GET: User/Servers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var server = await _context.servers.FindAsync(id);
            if (server == null)
            {
                return NotFound();
            }
            return View(server);
        }

        // POST: User/Servers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Created,ReleaseDate,CloseDate")] Server server)
        {
            if (id != server.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(server);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServerExists(server.Id))
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
            return View(server);
        }

        // GET: User/Servers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var server = await _context.servers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (server == null)
            {
                return NotFound();
            }

            return View(server);
        }

        // POST: User/Servers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var server = await _context.servers.FindAsync(id);
            _context.servers.Remove(server);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServerExists(int id)
        {
            return _context.servers.Any(e => e.Id == id);
        }
    }
}
