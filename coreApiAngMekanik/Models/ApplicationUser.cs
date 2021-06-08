using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreApiAngMekanik.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int USERID { get; set; }
        public string PASSWORD { get; set; }
        public bool ISACTIVE { get; set; }
        public string PHOTOPATH { get; set; }

    }
}
