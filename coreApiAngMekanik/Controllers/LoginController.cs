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

        [HttpPost]
        [Route("LoginControl")]
        public async Task<ActionResult<User>> LoginControl([FromBody] LoginViewModel loginViewModel)
        {
            var user = await csDB.GetUser(loginViewModel.USERNAME);

            if (user == null || user.PASSWORD != loginViewModel.PASSWORD)
            {
                return NotFound();
            }

            return user;
        }




    }
}
