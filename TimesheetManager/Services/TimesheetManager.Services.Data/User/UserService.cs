namespace TimesheetManager.Services.Data.User
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using TimesheetManager.Common;
    using TimesheetManager.Data.Common.Repositories;
    using TimesheetManager.Data.Models;
    using TimesheetManager.Services.Data.Contracts.User;
    using TimesheetManager.Web.ViewModels.User;

    using static Common.GlobalConstants.ControllersResponseMessages;
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IDeletableEntityRepository<ApplicationUser> users;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IDeletableEntityRepository<ApplicationUser> users)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.users = users;
        }

        public async Task<Result> RegisterAsync(RegisterViewModel model)
        {
            var user = new ApplicationUser
            {
                FullName = model.FullName,
                Email = model.Email,
                CreatedOn = DateTime.UtcNow,
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return SuccesfullyRegistered;
            }

            return result.Errors.Select(x => x.Description).ToString();
        }
    }
}
