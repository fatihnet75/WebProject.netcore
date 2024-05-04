    using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
    {
        public class Person
        {
        [Key]
            public int AkademisyenNo { get; set; }
            public int BolumNo { get; set; }
            public string AdSoyad { get; set; }
            public string TelefonNUmarasý { get; set; }
            public string ResimUrl { get; set; }
            public string Hakkýnda { get; set; }
            public string Eposta { get; set; }
            public string Doktora { get; set; }
            public string YüksekLisans { get; set; }
            public string lisans { get; set; }
            public string ArastirmaAlaný { get; set; }
    }
    }
