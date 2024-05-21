using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Kullanicilar
    {
        [Key]
        
        public int id { get; set; }
        [Required(ErrorMessage = "Eposta gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir eposta adresi girin.")]
        [RegularExpression(@"^[^@]+@[^@]+\.[^@]+$", ErrorMessage = "Eposta adresi geçerli deðil.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parola gereklidir.")]
        public string Parola { get; set; }

    }
}
