﻿using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Kullanıcı adı giriniz.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifreyi giriniz.")]
        public string Password { get; set; }
    }
}
