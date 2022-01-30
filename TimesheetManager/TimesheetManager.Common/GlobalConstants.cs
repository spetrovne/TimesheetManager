namespace TimesheetManager.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "TimesheetManager";

        public const string AdministratorRoleName = "Administrator";

        public static class ControllerRoutes
        {
            public const string GetAllRoute = "getAll";

            public const string RegisterRoute = "register";

            public const string LoginRoute = "login";

            public const string AddRoleRoute = "addRole";
        }

        public class ControllersResponseMessages
        {
            public const string PasswordAndEmailCannotBeEmpty = "Password/Email cannot be empty";

            public const string InvalidPasswordOrEmail = "Invalid Password/Email";

            public const string AlreadyExist = "This already exist.";

            public const string RoleCannotBeEmpty = "{0} cannot be empty.";

            public const string DoesNotExist = "This doesn't exist.";

            public const string UserDoNotExist = "This user with this role does not exist.";

            public const string SuccesfullyCreated = "Successfully created.";

            public const string SuccesfullyEdited = "Successfully edited.";

            public const string SuccesfullyDeleted = "Successfully removed";

            public const string SuccesfullyRegistered = "Successfully registered.";

            public const string SuccesfullyLoggedIn = "Successfully logged in.";
        }
    }
}
