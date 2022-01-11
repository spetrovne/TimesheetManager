namespace TimesheetManager.Services.Data.Project
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TimesheetManager.Common;
    using TimesheetManager.Data.Common.Repositories;
    using TimesheetManager.Data.Models;
    using TimesheetManager.Services.Data.Contracts.Project;
    using TimesheetManager.Services.Mapping;
    using TimesheetManager.Web.ViewModels.Project;

    using static TimesheetManager.Common.GlobalConstants.ControllersResponseMessages;

    public class ProjectService : IProjectService
    {
        private readonly IDeletableEntityRepository<Project> projects;

        public ProjectService(IDeletableEntityRepository<Project> projects)
        {
            this.projects = projects;
        }

        public async Task<Result> CreateAsync(CreateProjectModel model)
        {
            var project = new Project
            {
                Name = model.Name,
            };

            await this.projects.AddAsync(project);
            await this.projects.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>()
        {
            var projectsModel = await this.projects.AllAsNoTracking()
                .To<TModel>()
                .ToListAsync();

            return projectsModel;
        }

        public async Task<Result> RemoveAsync(int id)
        {
            var project = await this.projects.All().FirstOrDefaultAsync(p => p.Id == id);

            if (project == null)
            {
                return DoesNotExist;
            }

            this.projects.Delete(project);
            await this.projects.SaveChangesAsync();

            return true;
        }

        public async Task<Result> UpdateAsync(UpdateProjectViewModel model)
        {
            var project = await this.projects.All().FirstOrDefaultAsync();

            if (project == null)
            {
                return DoesNotExist;
            }

            project.Name = model.Name;
            await this.projects.SaveChangesAsync();

            return true;
        }
    }
}
