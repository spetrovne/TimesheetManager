namespace TimesheetManager.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using TimesheetManager.Data.Models;
    using TimesheetManager.Services.Data.Contracts.User;
    using TimesheetManager.Web.ViewModels.User;

    using static TimesheetManager.Common.GlobalConstants.ControllerRoutes;
    using static TimesheetManager.Common.GlobalConstants.ControllersResponseMessages;

    [ApiController]
    [Area("User")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly JWTConfig jwtConfig;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(IUserService userService, IOptions<JWTConfig> jwtConfig, UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            this.jwtConfig = jwtConfig.Value;
            this.userManager = userManager;
        }

        [HttpPost(RegisterRoute)]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            var result = await this.userService.RegisterAsync(model);

            if (result.Failure)
            {
                return this.BadRequest(result.Error);
            }

            return this.Ok(SuccesfullyRegistered);
        }

        [HttpPost(LoginRoute)]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    var result = await this.userService.LoginAsync(model);

                    if (result.Failure)
                    {
                        return this.BadRequest(result.Error);
                    }

                    var appUser = await this.userManager.FindByEmailAsync(model.Email);
                    var user = new UserViewModel
                    {
                        Email = appUser.Email,
                        FullName = appUser.FullName,
                        Token = this.GenerateToken(appUser),
                        DateCreated = appUser.CreatedOn,
                    };

                    return this.Ok(user);
                }

                return this.BadRequest(PasswordAndEmailCannotBeEmpty);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        private string GenerateToken(ApplicationUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.jwtConfig.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.NameId, user.Id),
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new System.Security.Claims.Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
