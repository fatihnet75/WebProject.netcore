using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Kullanicilar
    {
        [Key]
        
        public int id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Parola { get; set; }
        public string Email { get; set; }
        public string ResimUrl { get; set; }
        public System.DateTime EklemeTarihi { get; set; }
        public int Rol { get; set; }

    }
}
