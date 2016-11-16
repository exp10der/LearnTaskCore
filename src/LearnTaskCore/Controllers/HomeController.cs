namespace LearnTaskCore.Controllers
{
    using System;
    using System.Linq;
    using Infrastructure;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() => Content($"Hello MVC!{Environment.NewLine}{_context.Items.Count()}");

        public IActionResult SimpleView()
        {
            return View();
        }
    }
}