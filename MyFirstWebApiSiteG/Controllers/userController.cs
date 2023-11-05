using Entity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;
using System.Text.Json;

//using (StreamReader reader = System.IO.File.OpenText("M:\\web-api\\userFile.txt"));
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        IuserService userService ; //_userService - convention 

        //IuserService userService (instead of  iuserService)
        public userController(IuserService iuserService)
        {
            userService = iuserService;
        }

        // GET: api/<userController>
        [HttpGet]
        //IEnumerable? 
        public async Task<ActionResult<IEnumerable<User>>> Get([FromQuery] string userName, [FromQuery] string password)
        {
            User user = await userService.getUserByEmailAndPassword(userName, password);
            if (user == null)
                return NoContent();
            return Ok(user);

        }
        
        // GET api/<userController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> Get(int id)
        {
            User user = await userService.getUserById(id);
            if(user==null)
                return NoContent();
             return Ok(user);
        }


        // POST api/<userController>
        [HttpPost]
        //async await???? Task<ActionResult<User>>
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                User newUser = userService.addUser(user);
                //Replace user by newUser  in - new { id = user.userId }
                //newUser.Id (User in Entity doesn't contain a definition for usreId)
                return CreatedAtAction(nameof(Get), new { id = user.userId }, newUser);
                //Check if newUser==null return BadRequest()
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
        // PUT api/<userController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User userToUpdate)
        {
            try
            {
                User newUser = await userService.updateUser(id, userToUpdate);
                return Ok(newUser);
                //Check if newUser==null return BadRequest()
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Clean code -Remove unnecessary lines of code.
        // DELETE api/<userController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
