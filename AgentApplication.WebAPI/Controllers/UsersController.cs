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

        public UsersController(
            UserManager<User> userManager,
            ITokenCreationService tokenCreationService,
            IMapper mapper)
        {
            _userManager = userManager;
            _tokenCreationService = tokenCreationService;
            _mapper = mapper;
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
