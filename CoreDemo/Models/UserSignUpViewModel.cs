using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Ad Soyad alanı zorunludur!")]
        public string FullName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı zorunludur!")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrarı")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email alanı zorunludur!")]
        public string Email { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı giriniz!")]
        public string UserName { get; set; }
    }
}
