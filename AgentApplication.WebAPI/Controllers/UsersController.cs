using AgentApplication.WebAPI.Entitites.DTO;
using AgentApplication.WebAPI.Entitites.Model;
using AgentApplication.WebAPI.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgentApplication.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenCreationService _tokenCreationService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UsersController(
            UserManager<User> userManager,
            ITokenCreationService tokenCreationService,
            IMapper mapper,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _tokenCreationService = tokenCreationService;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> RegisterAsync([FromBody] UserDTO userDTO)
        {
            if (!userDTO.Password.Equals(userDTO.ConfirmPassword))
                return BadRequest("Passwords doesn't match");

            var user = _mapper.Map<User>(userDTO);
            var result = await _userManager.CreateAsync(user, userDTO.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("RegisterAdmin")]
        public async Task<ActionResult> RegisterAdminAsync()
        {
            var admin = await _userManager.FindByNameAsync(_configuration["Administrator:UserName"]);
            if (admin == null)
            {
                var user = new User
                {
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    IsAdmin = true,
                    UserName = _configuration["Administrator:UserName"],
                    Email = _configuration["Administrator:Email"]
                };

                var result = await _userManager.CreateAsync(user, _configuration["Administrator:Password"]);

                if (!result.Succeeded)
                    return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult<TokenDTO>> SignInAsync([FromBody] SignInDTO signInDTO)
        {
            var user = await _userManager.FindByNameAsync(signInDTO.UserName);
            if (user == null)
                return BadRequest("Bad credentials");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, signInDTO.Password);
            if (!isPasswordValid)
                return BadRequest("Bad credentials");

            var token = _tokenCreationService.CreateToken(user);
            return Ok(token);
        }
    }
}
