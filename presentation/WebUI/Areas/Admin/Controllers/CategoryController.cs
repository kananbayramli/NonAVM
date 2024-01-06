using AutoMapper;
using ECommerse.Business.DTO_s;
using ECommerse.Business.Services.Abstract;
using ECommerse.WebUI.Areas.Admin.Models.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerse.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        this._categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetAllAsync();
        return View(categories.Select(c => new CategoryViewModel
        {
            Id = c.Id, Name = c.Name, Slug = c.Slug
        }).ToList());
    }    
    
    public async Task<IActionResult> CategoryHierarchi()
    {
        var categories = await _categoryService.GetAllAsync();
        return View(categories.Select(c => new CategoryViewModel
        {
            Id = c.Id,
            Name = c.Name,
            ParentCategoryName = categories.FirstOrDefault(c2 => c2.Id == c.ParentCategoryID)?.Name
        }).GroupBy(c => c.ParentCategoryName));
    }


    public async Task<ActionResult> AddCategory()
    {
        ViewBag.categoryList = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name"); ;
        return View();
    }


    [HttpPost]
    public async Task<ActionResult> AddCategory(CreateCategoryViewModel category)
    {
        var pCategory = await _categoryService.GetAsync(c => c.Id == category.ParentCategoryID);
        category.Slug =$"{pCategory.Name}-{category.Name}";
        await _categoryService.Create(new CategoryDTO
        {
            Name = category.Name,
            ParentCategoryID = category.ParentCategoryID,
            Slug = category.Slug,
        });
        await _categoryService.SaveChangesAsync(CancellationToken.None);
        return RedirectToAction("Index");
    }
}
