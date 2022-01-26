namespace TimesheetManager.Services.Data.Contracts.User
{
    using System.Threading.Tasks;

    using TimesheetManager.Common;
    using TimesheetManager.Web.ViewModels.User;

    public interface IUserService
    {
        Task<Result> RegisterAsync(RegisterViewModel model);
    }
}
