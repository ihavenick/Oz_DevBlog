using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Oz_DevBlog.UI.Models.AccountVM
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "E-Posta")]
        [EmailAddress(ErrorMessage="Email Geçersiz")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "Adres")]        
        public string Address { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password",ErrorMessage="Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}