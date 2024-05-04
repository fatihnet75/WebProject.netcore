using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Bolum
    {
        [Key]
        
        public int id { get; set; }
        public int Bolumno { get; set; }
        public string Rutbe { get; set; }
        public string BolumAdý { get; set; }
        
    }
}
