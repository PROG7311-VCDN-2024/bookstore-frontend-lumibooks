using Microsoft.AspNetCore.Mvc;
using Sprint1.Models;
using System.Diagnostics;

namespace Sprint1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Order()
        {
            return RedirectToAction("Index", "Order");
        }

        public IActionResult Book()
        {
            return RedirectToAction("Index", "Books");
        }

        public IActionResult Cart()
        {
            return RedirectToAction("Index", "Cart");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
