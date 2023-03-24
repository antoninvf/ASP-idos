using System.Diagnostics;
using ASP_idos.FormModel;
using Microsoft.AspNetCore.Mvc;
using ASP_idos.Models;

namespace ASP_idos.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        SearchInputFormModel model = new SearchInputFormModel();
        return View(model);
    }
    
    public IActionResult Lines()
    {
        SearchInputFormModel model = new SearchInputFormModel();
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    [HttpPost]
    public IActionResult Index(SearchInputFormModel model)
    {
        ViewData["SearchInput"] = model.SearchInput;
        return View("Index", model.SearchInput);
    }
    
    [HttpPost]
    public IActionResult Lines(SearchInputFormModel model)
    {
        ViewData["SearchInput"] = model.SearchInput;
        return View("Lines", model.SearchInput);
    }
}