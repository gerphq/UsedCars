using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UsedCars.Infrastructure.Repositories;
using UsedCars.Web.Models;

namespace UsedCars.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestRepository _testRepository;

        public HomeController(ILogger<HomeController> logger, TestRepository testRepository)
        {
            _logger = logger;
            _testRepository = testRepository;
        }

        public IActionResult Index()
        {
            var keyboardPrograms = _testRepository.GetAllKeyboardPrograms();
            List<KeyboardProgramsViewModel> keyboardProgramsViewModel = new List<KeyboardProgramsViewModel>();
            foreach (var keyboard in keyboardPrograms)
            {
                var keyboardModel = new KeyboardProgramsViewModel
                {
                    SetlistOrder = keyboard.SetlistOrder.Value,
                    Title = keyboard.Title,
                    KorgProgram = keyboard.KorgProgram,
                    NordProgram = keyboard.NordProgram
                };
                keyboardProgramsViewModel.Add(keyboardModel);
            }
            return View(keyboardProgramsViewModel);
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
