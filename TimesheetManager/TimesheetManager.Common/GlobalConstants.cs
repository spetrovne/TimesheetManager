namespace TimesheetManager.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "TimesheetManager";

        public const string AdministratorRoleName = "Administrator";

        public static class ControllerRoutes
        {
            public const string GetAllRoute = "getAll";
        }

        public class ControllersResponseMessages
        {
            public const string AlreadyExist = "This already exist.";

            public const string DoesNotExist = "This doesn't exist.";

            public const string UserDoNotExist = "This user with this role does not exist.";

            public const string SuccesfullyCreated = "Successfully created.";

            public const string SuccesfullyEdited = "Successfully edited.";

            public const string SuccesfullyDeleted = "Successfully removed";

            public const string SuccesfullyRegistered = "Successfully registered.";
        }
    }
}
