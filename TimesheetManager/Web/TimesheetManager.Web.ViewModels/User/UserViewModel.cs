namespace TimesheetManager.Web.ViewModels.User
{
    using System;

    public class UserViewModel
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public string Token { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
