using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coreApiAngMekanik.Models
{
    public class User
    {
        [Key]
        public string USERNAME { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PASSWORD { get; set; }
        [Required]
        public bool ISACTIVE { get; set; }
        public string PHOTOPATH { get; set; }
    }
}
