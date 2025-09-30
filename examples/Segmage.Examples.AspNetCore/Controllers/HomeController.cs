using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Segmage.Examples.AspNetCore.Models;
using Segmage.Models;

namespace Segmage.Examples.AspNetCore.Controllers;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;

	public HomeController(ILogger<HomeController> logger)
	{
		_logger = logger;
	}

	public async Task<IActionResult> Index()
	{
		var result = await SegmageApp.DefaultInstance.EventSender.SendCustomEventAsync("customEventUniqName", new Custom()
		{
			Data = "test"
		});
		return View();
	}

	public IActionResult Privacy()
	{
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}