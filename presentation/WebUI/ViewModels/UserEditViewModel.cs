using ECommerse.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace ECommerse.WebUI.ViewModels;

public class UserEditViewModel
{
    [Required(ErrorMessage = "İsdifadəçi adı daxil edilməyib.")]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = "Ad daxil edilməyib.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Soyad daxil edilməyib.")]
    public string Surname { get; set; } = null!;

    [Required(ErrorMessage = "Telefon nömrəsi daxil edilməyib.")]
    //[RegularExpression(@"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$", ErrorMessage = "Telefon nömrəsi uyğun formatda deyil")]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "Email adresi daxil edilməyib.")]
    [EmailAddress(ErrorMessage = "Email adresiniz doğru formatda değil")]
    public string Email { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateTime? BirthDay { get; set; }

    public IFormFile? ProfilePicture { get; set; }

    public Gender? Gender { get; set; }
}
