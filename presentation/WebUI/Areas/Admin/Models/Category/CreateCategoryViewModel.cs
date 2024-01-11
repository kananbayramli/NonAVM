namespace ECommerse.WebUI.Areas.Admin.Models.Category;

public class CreateCategoryViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int? ParentCategoryID { get; set; }
    public string Slug { get; set; } = String.Empty;
}
