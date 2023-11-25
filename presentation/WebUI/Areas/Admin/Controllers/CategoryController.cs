using ECommerse.Business.DTO_s;
using ECommerse.Business.Services.Abstract;
using ECommerse.WebUI.Areas.Admin.Models.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerse.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    private readonly ICategoryService categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        this.categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await categoryService.GetAllAsync();
        return View(categories.Select(c => new CategoryViewModel
        {
            Id = c.Id, Name = c.Name, ParentCategoryName = categories.FirstOrDefault(c2 => c2.Id == c.ParentCategoryID)?.Name
        }).ToList());
    }


    public async Task<ActionResult> AddCategory()
    {
        ViewBag.categoryList = new SelectList(await categoryService.GetAllAsync(), "Id", "Name"); ;
        return View();
    }


    [HttpPost]
    public async Task<ActionResult> AddCategory(CategoryDTO category)
    {
        await categoryService.Create(category);
        await categoryService.SaveChangesAsync(CancellationToken.None);
        return RedirectToAction("Index");
    }
}
