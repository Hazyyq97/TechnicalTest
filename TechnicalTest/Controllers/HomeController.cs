using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TechnicalTest.Models;
using TechnicalTest.Service.IService;

namespace TechnicalTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INumberToWordsService _numberToWordsService;

        public HomeController(ILogger<HomeController> logger, INumberToWordsService numberToWordsService)
        {
            _logger = logger;
            _numberToWordsService = numberToWordsService;
        }

        public IActionResult Index()
        {
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

        public IActionResult NumberToWord()
        {
            ViewData["Answer"] = null;
            return View();
        }

        [HttpPost]
        public IActionResult NumberToWord(NumberDto model)
        {
            if (ModelState.IsValid)
            {
                if (model.Number < 0)
                {
                    ViewData["Answer"] = "The field cannot be negative amount";
                    return View();
                }
                var result = _numberToWordsService.ConvertNumberToWords(model.Number);
                ViewData["Answer"] = result;
            }
            return View();
        }
    }
}