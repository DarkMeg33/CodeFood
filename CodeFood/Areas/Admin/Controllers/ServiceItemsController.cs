using CodeFood.Domain;
using CodeFood.Domain.Entities;
using CodeFood.Service;
using Microsoft.AspNetCore.Mvc;

namespace CodeFood.Areas.Admin.Controllers;

[Area("Admin")]
public class ServiceItemsController : Controller
{
    private readonly DataManager _dataManager;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ServiceItemsController(DataManager dataManager, IWebHostEnvironment webHostEnvironment)
    {
        _dataManager = dataManager;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Edit(Guid id)
    {
        var entity = id == default ? new ServiceItem() : _dataManager.ServiceItems.GetServiceItemById(id);
        return View(entity);
    }

    [HttpPost]
    public IActionResult Edit(ServiceItem model, IFormFile? titleImageFile)
    {
        if (ModelState.IsValid)
        {
            if (titleImageFile is not null)
            {
                model.TitleImagePath = titleImageFile.FileName;
                using (var stream = new FileStream(Path.Combine(_webHostEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                {
                    titleImageFile.CopyTo(stream);
                }
            }
            _dataManager.ServiceItems.SaveServiceItem(model);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
        return View(model);
    }


    [HttpPost]
    public IActionResult Delete(Guid id)
    {
        _dataManager.ServiceItems.DeleteServiceItem(id);
        return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
    }
}
