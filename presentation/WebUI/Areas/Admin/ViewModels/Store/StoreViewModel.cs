using ECommerse.Core.Entities;
using ECommerse.Core.Identity;

namespace ECommerse.WebUI.Areas.Admin.Models.Store;

public class StoreViewModel
{
    public string Name { get; set; } = null!;
    public string? Desription { get; set; }

    public string? OwnerID { get; set; }
}
