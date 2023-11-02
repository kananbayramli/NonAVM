namespace ECommerse.WebUI.Areas.Admin.Models.CategoryViewModels
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ParentCategoryName { get; set; }
    }
}
