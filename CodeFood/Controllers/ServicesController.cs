using CodeFood.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CodeFood.Controllers;

public class ServicesController : Controller
{
    private readonly DataManager _dataManager;

    public ServicesController(DataManager dataManager)
    {
        _dataManager = dataManager;
    }

    public IActionResult Index()
    {
        return View(_dataManager.TextFields.GetTextFieldByCodeWord("PageServices"));
    }
}
