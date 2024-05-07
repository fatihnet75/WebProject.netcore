using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Login
    {
        [Key]
        

        public string Email { get; set; }
        public string Parola { get; set; }
      

    }
}
