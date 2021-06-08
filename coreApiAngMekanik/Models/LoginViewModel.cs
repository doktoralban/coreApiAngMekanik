using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coreApiAngMekanik.Models
{
    public class LoginViewModel
    {
       
        [Key]
        [Required]
        [Display(Name ="User Name")]
        public string USERNAME { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PASSWORD { get; set; }

    }
}
