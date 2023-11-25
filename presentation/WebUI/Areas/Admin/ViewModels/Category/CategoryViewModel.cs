namespace ECommerse.WebUI.Areas.Admin.Models.Category;

public class CategoryViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? ParentCategoryName { get; set; }
}
