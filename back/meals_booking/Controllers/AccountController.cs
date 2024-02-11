using API.DTO;
using API.ErrorsHandeling;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthService _authService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAuthService authService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(AppUserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AppUserDto>> Register(RegisterDto model)
        {
            if (CheckEmailExist(model.Email).Result.Value)
                return BadRequest(new ApiValidationErrorResponse() { Errors = new string[] { "This email has already been used" } });

            var user = new AppUser()
            {
                Name = model.Name,
                UserName = model.Email.Split('@')[0],
                Email = model.Email,
                SSN = model.SSN,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded is false)
                return BadRequest(new ApiResponse(400));

            await _userManager.AddToRoleAsync(user, "Student");

            return Ok(new AppUserDto
            {
                Name = user.Name,
                UserName = user.UserName,
                Email = model.Email,
                Role = new List<string>() { "Student" },
                Token = await _authService.CreateTokenAsync(user, _userManager)
            });
        }

        [HttpPost("addAdmin")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(AppUserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AppUserDto>> AddAdmin(RegisterDto model)
        {
            if (CheckEmailExist(model.Email).Result.Value)
                return BadRequest(new ApiValidationErrorResponse() { Errors = new string[] { "This email has already been used" } });

            var user = new AppUser()
            {
                Name = model.Name,
                UserName = model.Email.Split('@')[0],
                Email = model.Email,
                SSN = model.SSN,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded is false)
                return BadRequest(new ApiResponse(400));

            await _userManager.AddToRoleAsync(user, "Admin");

            return Ok(new AppUserDto
            {
                Name = user.Name,
                UserName = user.UserName,
                Email = model.Email,
                Role = new List<string>() { "Admin" },
                Token = await _authService.CreateTokenAsync(user, _userManager)
            });
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(AppUserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AppUserDto>> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
                return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (result.Succeeded is false)
                return Unauthorized(new ApiResponse(401));

            var userRole = await _userManager.GetRolesAsync(user);

            return Ok(new AppUserDto
            {
                Name = user.Name,
                UserName = model.Email.Split('@')[0],
                Email = model.Email,
                Role = userRole,
                Token = await _authService.CreateTokenAsync(user, _userManager)
            });
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<AppUserDto>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            return Ok(new AppUserDto()
            {
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
                Token = await _authService.CreateTokenAsync(user, _userManager)
            });
        }

        [HttpPost("resetpasswordtoken")]
        public async Task<ActionResult> ResetPasswordToken([FromBody] ResetPasswordTokenDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user is null)
                return Unauthorized(new ApiResponse(401));

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var userRole = await _userManager.GetRolesAsync(user);

            return Ok(new AppUserDto
            {
                Name = user.Name,
                UserName = user.UserName,
                Email = user.Email,
                Token = token,
                Role = userRole
            });
        }

        [HttpPost("resetpassword")]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
                return Unauthorized(new ApiResponse(401));

            if (string.IsNullOrEmpty(model.Token))
                return Unauthorized(new ApiResponse(401));

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (result.Succeeded is false)
                return Unauthorized(new ApiResponse(401));

            var userRole = await _userManager.GetRolesAsync(user);

            return Ok(new AppUserDto
            {
                Name = user.Name,
                UserName = user.UserName,
                Email = model.Email,
                Token = model.Token,
                Role = userRole
            });
        }


        [HttpGet("emailexists")]
        public async Task<ActionResult<bool>> CheckEmailExist(string email)
        {
            return await _userManager.FindByEmailAsync(email) is not null;
        }
    }
}