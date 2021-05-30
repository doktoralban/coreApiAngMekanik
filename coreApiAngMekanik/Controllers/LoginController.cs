using coreApiAngMekanik.Models;
using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreApiAngMekanik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<User>> LoginKontrol(string userName,string passWord)
        {
            var user = await csDB.GetUser(userName);

            if (user == null || user.PASSWORD !=passWord)
            {
                return NotFound();
            }

            return user;
        }




    }
}
