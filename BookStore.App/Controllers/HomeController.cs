using BookStore.App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.App.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
