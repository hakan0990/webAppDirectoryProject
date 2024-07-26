using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TelefonRehberi.Data;
using TelefonRehberi.Models;

namespace TelefonRehberi.Controllers
{
	public class HomeController : Controller
	{
       

        private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

	
	}
}
