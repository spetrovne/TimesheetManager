namespace TimesheetManager.Web.ViewModels.User
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    using TimesheetManager.Data.Models;
    using TimesheetManager.Services.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public string Token { get; set; }

        public DateTime DateCreated { get; set; }

        public string Role { get; set; }
    }
}
