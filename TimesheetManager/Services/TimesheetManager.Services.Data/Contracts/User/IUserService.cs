namespace TimesheetManager.Services.Data.Contracts.User
{
    using System.Threading.Tasks;

    using TimesheetManager.Common;
    using TimesheetManager.Web.ViewModels.User;

    public interface IUserService
    {
        Task<Result> RegisterAsync(RegisterViewModel model);

        Task<Result> LoginAsync(LoginViewModel model);

        Task<Result> AddRoleAsync(AddRoleViewModel model);

        Task<TModel> GetUserAsync<TModel>(string email);
    }
}
