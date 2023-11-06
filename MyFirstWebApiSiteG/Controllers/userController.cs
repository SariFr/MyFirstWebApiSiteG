using Entity;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services;
using System.Text.Json;


namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        IuserService userService ;

        public userController(IuserService iuserService)
        {
            userService = iuserService;
        }

        [HttpGet]
         public async Task<ActionResult<User>> Get([FromQuery] string userName, [FromQuery] string password)
        {
            User user = await userService.getUserByEmailAndPassword(userName, password);
            if (user == null)
                return NoContent();
            return Ok(user);

        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> Get(int id)
        {
            User user = await userService.getUserById(id);
            if(user==null)
                return NoContent();
             return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                User newUser =await userService.addUser(user);
                if (newUser == null)
                    return BadRequest();
                return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost("check")]
        public int Check([FromBody] string pwd)
        {
            return userService.checkPassword(pwd);
        }

        [HttpPut("{id}")]
        public async  Task Put(int id, [FromBody] User userToUpdate)
        {
            try
            {
                await userService.updateUser(id, userToUpdate);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    
    }
}
