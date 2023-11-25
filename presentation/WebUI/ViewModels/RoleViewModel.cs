using System.ComponentModel.DataAnnotations;

namespace ECommerse.WebUI.ViewModels;

public class RoleViewModel
{
    [Display(Name = "Role ismi")]
    [Required(ErrorMessage = "Role ismi gereklidir")]
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public bool IsSelected { get; set; }

}
