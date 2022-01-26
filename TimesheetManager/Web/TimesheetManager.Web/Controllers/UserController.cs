namespace TimesheetManager.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TimesheetManager.Services.Data.Contracts.User;
    using TimesheetManager.Web.ViewModels.User;

    [ApiController]
    [Area("User")]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            var result = await this.userService.RegisterAsync(model);

            if (result.Failure)
            {
                return this.BadRequest(result.Error);
            }

            return this.Ok(result.Succeeded);
        }
    }
}
