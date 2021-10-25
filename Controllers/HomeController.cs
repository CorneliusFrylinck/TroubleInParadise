using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TroubleInParadise.Models;

namespace TroubleInParadise.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                bool isInRole = User.IsInRole("User");
                //var user = await _userManager.GetUserAsync(HttpContext.User);

                //var roles = await _userManager.GetRolesAsync(user);

                //var matchingvalues = roles.SingleOrDefault(stringToCheck => stringToCheck.Equals("User"));
                if (isInRole)
                {
                    return RedirectToAction("Index", new RouteValueDictionary(
                        new { controller = "Players", action = "Index", area = "User", Id = User.Identity.Name }));
                    //return RedirectToAction("Index", "Players", new { area = "User" });
                }
            }catch (Exception ex)
            {
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}