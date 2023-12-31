using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Text.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly IuserService _userService;
        private readonly IMapper _Mapper;
        private readonly ILogger<userController> _logger;


        public userController(IuserService userService, IMapper mapper, ILogger<userController> logger)
        {
            _userService = userService;
            _Mapper = mapper;
            _logger = logger;

        }


        // POST: api/<userController>
        [HttpPost("login")]
        public async Task<ActionResult<UserLoginDTO>> login([FromBody] UserLoginDTO userLogin)
        {
            User user = await _userService.getUserByEmailAndPassword(userLogin.UserName, userLogin.Password);

            if (user != null)
            {
                    UserLoginDTO userCreate = _Mapper.Map<User, UserLoginDTO>(user);
                    _logger.LogInformation($"Login attempted with User name ,{userCreate.UserName} and password {userCreate.Password}");
                    return Ok(userCreate);
            }
            return NoContent();
            
        }

        // GET api/<userController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get([FromRoute]int id)
        {
            User user = await _userService.getUserById(id);
            UserDTO userDTO = _Mapper.Map<User, UserDTO>(user);

            if (user == null)
                return NoContent();
            return Ok(userDTO);
            
        }


        // POST api/<userController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO userDTO)
        {
            User user = _Mapper.Map<UserDTO, User>(userDTO);
            User newUser = await _userService.addUser(user);
            UserDTO newUserDTO = _Mapper.Map<User, UserDTO>(newUser);

            if (newUser == null)
                    return BadRequest();
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, newUserDTO);
            
        }

        [HttpPost("check")]
        public int Check([FromBody] string pwd)
        {
            return _userService.checkPassword(pwd);
        }
        // PUT api/<userController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UserDTO userToUpdate)
        {
                userToUpdate.UserId = id;
                User user = _Mapper.Map<UserDTO, User>(userToUpdate);
                await _userService.updateUser(id, user);
          

        }

    }
}
