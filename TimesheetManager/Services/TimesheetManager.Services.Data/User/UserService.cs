namespace TimesheetManager.Services.Data.User
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using TimesheetManager.Common;
    using TimesheetManager.Data.Common.Repositories;
    using TimesheetManager.Data.Models;
    using TimesheetManager.Services.Data.Contracts.User;
    using TimesheetManager.Services.Mapping;
    using TimesheetManager.Web.ViewModels.User;

    using static TimesheetManager.Common.GlobalConstants.ControllersResponseMessages;

    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IDeletableEntityRepository<ApplicationUser> users;
        private readonly RoleManager<ApplicationRole> roleManager;

        public UserService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IDeletableEntityRepository<ApplicationUser> users,
            RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.users = users;
            this.roleManager = roleManager;
        }

        public async Task<Result> AddRoleAsync(AddRoleViewModel model)
        {
            try
            {
                if (model.Role == null || model.Role == string.Empty)
                {
                    return string.Format(RoleCannotBeEmpty, "Role");
                }

                if (await this.roleManager.RoleExistsAsync(model.Role))
                {
                    return AlreadyExist;
                }

                var role = new ApplicationRole
                {
                    Name = model.Role,
                };

                var result = await this.roleManager.CreateAsync(role);

                if (!result.Succeeded)
                {
                    return string.Join(", ", result.Errors.Select(x => x.Description));
                }

                return true;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<TModel> GetUserAsync<TModel>(string email)
        {
            var appUser = await this.users.AllAsNoTracking().Where(u => u.Email == email).To<TModel>().FirstOrDefaultAsync();
            return appUser;
        }

        public async Task<Result> LoginAsync(LoginViewModel model)
        {
            if (model.Email == string.Empty || model.Password == string.Empty)
            {
                return PasswordAndEmailCannotBeEmpty;
            }

            var result = await this.signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                return true;
            }

            return InvalidPasswordOrEmail;
        }

        public async Task<Result> RegisterAsync(RegisterViewModel model)
        {
            try
            {
                var user = new ApplicationUser
                {
                    FullName = model.FullName,
                    UserName = model.Email,
                    NormalizedUserName = model.FullName.ToUpper(),
                    Email = model.Email,
                    NormalizedEmail = model.Email.ToUpper(),
                    CreatedOn = DateTime.UtcNow,
                };

                var result = await this.userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var tempUser = await this.userManager.FindByEmailAsync(model.Email);
                    await this.userManager.AddToRoleAsync(tempUser, "Employee");
                    return true;
                }

                return string.Join(", ", result.Errors.Select(x => "Code: " + x.Code + Environment.NewLine + "Description: " + x.Description));
            }
            catch (Exception ex)
            {
                return string.Join(", ", ex.Message);
            }
        }
    }
}
