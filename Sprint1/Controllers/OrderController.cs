using Microsoft.AspNetCore.Mvc;

namespace Sprint1.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int orderId)
        {
            return View();
        }

        public IActionResult PlaceOrder()
        {
            return RedirectToAction("Index", "Order");
        }

        
    }
}
