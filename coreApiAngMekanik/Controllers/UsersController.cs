using coreApiAngMekanik.Models;
using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreApiAngMekanik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

       
        [HttpGet("{userName}")]
        public async Task<ActionResult<User>> GetUser(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return NotFound();
            }
            var user = await csDB.GetUser(userName);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }



        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            var result = await csDB.GetUsers();

            return result;
        }


        [HttpPost]
        public async Task<bool> Add([FromBody] User _user)
        {
            
           if (_user == null || string.IsNullOrEmpty(_user.USERNAME) || string.IsNullOrEmpty( _user.PASSWORD))
            {
                return false;
            }

            return await csDB.AddUser(_user)  ;
        }





        }
}
