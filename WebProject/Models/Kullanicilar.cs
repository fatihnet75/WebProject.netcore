using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Kullanicilar
    {
        [Key]
        
        public int id { get; set; }
        public string Parola { get; set; }
        public string Email { get; set; }

    }
}
