using ECommerse.WebUI.Enums;
using System.ComponentModel.DataAnnotations;

namespace ECommerse.WebUI.Models.User;

public class UserViewModel
{
    [Required(ErrorMessage = "İsdifadəçi adı daxil edilməyib.")]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = "Ad daxil edilməyib.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Soyad daxil edilməyib.")]
    public string Surname { get; set; } = null!;

    [Required(ErrorMessage = "Telefon nömrəsi daxil edilməyib.")]
    //[RegularExpression(@"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$", ErrorMessage = "Telefon nömrəsi uyğun formatda deyil")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "Email adresi daxil edilməyib.")]
    [EmailAddress(ErrorMessage = "Email adresiniz doğru formatda değil")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Şifrə daxil edin.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Şifrə təkrarını daxil edin.")]
    [Compare("Password", ErrorMessage = "Şifrə və şifrə təkaraı eyni deyil.")]
    [DataType(DataType.Password)]
    public string PasswordConfirm { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateTime? BirthDay { get; set; }

    public string? Picture { get; set; }

    public Gender? Gender { get; set; }
}
