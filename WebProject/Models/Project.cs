using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Project
    {
        [Key]
        public int ProjeNo { get; set; }
        public string ProjeIsmi { get; set; }
        public string ProjeHakkýnda { get; set; }
        public string ResimUrl { get; set; }
        public int ProjeNe { get; set; }
    }
}
