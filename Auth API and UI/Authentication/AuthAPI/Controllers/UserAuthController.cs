using AuthAPI.Data;
using AuthAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UserAuthController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            if (registerDTO == null 
                || string.IsNullOrEmpty(registerDTO.Name)
                || string.IsNullOrEmpty(registerDTO.Email)
                || string.IsNullOrEmpty(registerDTO.Password))
            {
                return BadRequest("Invalid Registration Details");
            }

            // Check if the user already exists
            var existingUser = await _userManager.FindByEmailAsync(registerDTO.Email);

            if(existingUser != null)
            {
                return Conflict($"User Already Exists With this:{registerDTO.Email} Email");
            }

            var user = new ApplicationUser
            {
                UserName = registerDTO.Email,
                Email = registerDTO.Email,
                Name = registerDTO.Name
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok($"User ({registerDTO.Email}) Created Successfully");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (loginDTO == null
                || string.IsNullOrEmpty(loginDTO.Email)
                || string.IsNullOrEmpty(loginDTO.Password))
            {
                return BadRequest("Invalid Login Details");
            }

            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user == null)
            {
                //return Unauthorized("Invalid Email or Password");
                return Unauthorized(new { success = false, message = "Invalid Username Or Password" });
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if (!result.Succeeded) 
            {
                return Unauthorized(new { success = false, message = "Invalid Username Or Password" });
            }

             var token = GenerateJWTToken(user);
            return Ok(new { success = true,  token});
        }

        private string GenerateJWTToken(ApplicationUser user)
        {
            return "Generated JWT Token- Test "; // Implement JWT token generation logic here
        }
    }
}
