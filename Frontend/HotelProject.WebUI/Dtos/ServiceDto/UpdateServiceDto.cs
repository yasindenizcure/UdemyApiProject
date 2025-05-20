﻿using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "Hizmet başlığı giriniz.")]
        [StringLength(100, ErrorMessage = "Hizmet başlığı 100 karakterden fazla olamaz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Hizmet ikon adresi giriniz.")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet açıklaması giriniz.")]
        [StringLength(500, ErrorMessage = "Hizmet açıklaması 500 karakterden fazla olamaz.")]
        public string Description { get; set; }
    }
}
