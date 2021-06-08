using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreApiAngMekanik.Models
{
    public class AccountModel
    {
        public int USERID { get; set; }
        public string USERNAME { get; set; } 
        public string PASSWORD { get; set; }
        public string ISACTIVE { get; set; }

        public string LoggedOn { get; set; }


    }
}
