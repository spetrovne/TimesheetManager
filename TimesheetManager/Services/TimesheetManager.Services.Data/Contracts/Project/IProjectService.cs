namespace TimesheetManager.Services.Data.Contracts.Project
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using TimesheetManager.Common;
    using TimesheetManager.Web.ViewModels.Project;

    public interface IProjectService
    {
        Task<IEnumerable<TModel>> GetAllAsync<TModel>();

        Task<Result> CreateAsync(CreateProjectModel model);

        Task<Result> UpdateAsync(UpdateProjectViewModel model);

        Task<Result> RemoveAsync(int id);

        Task<bool> ValidateProject(int id);
    }
}
