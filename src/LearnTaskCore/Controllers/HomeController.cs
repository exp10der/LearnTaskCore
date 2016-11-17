namespace LearnTaskCore.Controllers
{
    using System.Threading.Tasks;
    using Features.Home;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _mediator.SendAsync(new Index.Query());

            return View(model);
        }

        public async Task<IActionResult> Details(Details.Query query)
        {
            var model = await _mediator.SendAsync(query);

            return View(model);
        }

        public async Task<IActionResult> Download(Download.Query query)
        {
            var model = await _mediator.SendAsync(query);

            return File(model.FileContents, "application/zip", "Documents.zip");
        }
    }
}