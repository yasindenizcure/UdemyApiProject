using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="Ad bilgisi girmek zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad bilgisi girmek zorunludur.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı bilgisi girmek zorunludur.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mail Bilgisi girmek zorunludur.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre bilgisi girmek zorunludur.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar girmek zorunludur.")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }

    }
}
