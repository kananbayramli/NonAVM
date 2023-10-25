﻿using ECommerse.WebUI.Enums;
using System.ComponentModel.DataAnnotations;

namespace ECommerse.WebUI.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Kullanıcı ismi gerekldir.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; } = null!;

        //[Required(ErrorMessage = "Ad gerekldir.")]
        //[Display(Name = "Ad")]
        //public string? Name { get; set; }

        //[Required(ErrorMessage = "Kullanıcı ismi gerekldir.")]
        //[Display(Name = "Soyad")]
        //public string? Surname { get; set; }


        [Display(Name = "Tel No:")]
        [RegularExpression(@"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$", ErrorMessage = "Telefon numarası uygun formatta değil")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email adresi gereklidir.")]
        [Display(Name = "Email Adresiniz")]
        [EmailAddress(ErrorMessage = "Email adresiniz doğru formatta değil")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Şifreniz gereklidir.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Doğum tarihi")]
        [DataType(DataType.Date)]
        public DateTime? BirthDay { get; set; }

        public string? Picture { get; set; }

        [Display(Name = "Şehir")]
        public string? City { get; set; }

        [Display(Name = "Cinsiyet")]
        public Gender? Gender { get; set; }
    }
}
