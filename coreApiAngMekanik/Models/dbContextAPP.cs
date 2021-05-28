using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using coreApiAngMekanik.Models;

namespace coreApiAngMekanik.Models
{
    public class dbContextAPP:DbContext
    {
        public dbContextAPP(DbContextOptions<dbContextAPP> options) : base(options)
        {

        }
        public DbSet< User> User { get; set; }





    }
}
