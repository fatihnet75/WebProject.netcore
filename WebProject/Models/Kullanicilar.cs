using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Kullanicilar
    {
        [Key]
        
        public int id { get; set; }
        [Required(ErrorMessage = "Eposta gereklidir.")]
        [EmailAddress(ErrorMessage = "Ge�erli bir eposta adresi girin.")]
        [RegularExpression(@"^[^@]+@[^@]+\.[^@]+$", ErrorMessage = "Eposta adresi ge�erli de�il.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola gereklidir.")]
        public string Parola { get; set; }

    }
}
