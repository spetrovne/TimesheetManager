namespace TimesheetManager.Services.Data.Timesheet
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using TimesheetManager.Common;
    using TimesheetManager.Data.Common.Repositories;
    using TimesheetManager.Data.Models;
    using TimesheetManager.Services.Data.Contracts.Project;
    using TimesheetManager.Services.Data.Contracts.Timesheet;
    using TimesheetManager.Web.ViewModels.Timesheet;

    using static Common.GlobalConstants.ControllersResponseMessages;

    public class TimesheetService : ITimesheetService
    {
        private readonly IDeletableEntityRepository<Timesheet> timesheets;
        private readonly IDeletableEntityRepository<ProjectTask> tasks;
        private readonly IRepository<TaskHours> taskHours;
        private readonly IRepository<TimesheetProject> timesheerProjects;
        private readonly IProjectService projectService;

        public TimesheetService(
            IDeletableEntityRepository<Timesheet> timesheets,
            IDeletableEntityRepository<ProjectTask> tasks,
            IRepository<TaskHours> taskHours,
            IRepository<TimesheetProject> timesheetProjects,
            IRepository<TimesheetTask> timesheetTasks,
            IProjectService projectService)
        {
            this.timesheets = timesheets;
            this.tasks = tasks;
            this.taskHours = taskHours;
            this.timesheerProjects = timesheetProjects;
            this.projectService = projectService;
        }

        public async Task<Result> CreateAsync(CreateTimesheetModel model)
        {
            var areProductsValid = await this.ValidateProjects(model.TimesheetProjects);

            if (!areProductsValid)
            {
                return DoesNotExist;
            }

            var areTasksValid = await this.ValidateTasks(model.TimesheetTasks);

            if (!areTasksValid)
            {
                return DoesNotExist;
            }

            var timesheetExists=this.timesheets.AllAsNoTracking().FirstOrDefaultAsync(t => t.StartDate == model.StartDate && t.FinishDate == model.FinishDate);

            if (timesheetExists != null)
            {
                return AlreadyExist;
            }

            var timesheet = new Timesheet
            {
                Name = model.Name,
                StartDate = model.StartDate,
                FinishDate = model.FinishDate,
                IsSubmitted = false,
            };

            await this.timesheets.AddAsync(timesheet);
            await this.timesheets.SaveChangesAsync();

            await this.AddProductsToTimesheet(model.TimesheetProjects, model.StartDate, model.FinishDate);

            // ToDo Add product tasks and hours...

            return true;
        }

        private async Task<bool> ValidateProjects(ICollection<int> projectIds)
        {
            var projects = await this.projectService.GetAllAsync<Project>();

            foreach (var projectId in projectIds)
            {
                var project = projects.FirstOrDefault(p => p.Id == projectId);

                if (project == null)
                {
                    return false;
                }
            }

            return true;
        }

        private async Task<bool> ValidateTasks(ICollection<TimesheetTaskCreateModel> taskModel)
        {
            var tasksFromDb = await this.tasks.AllAsNoTracking().ToListAsync();

            foreach (var task in taskModel)
            {
                var validTask = tasksFromDb.FirstOrDefault(t => t.Id == task.TaskId);

                if (validTask == null)
                {
                    return false;
                }
            }

            return true;
        }

        private async Task AddProductsToTimesheet(
            ICollection<int> productIds,
            DateTime startDate,
            DateTime finishDate)
        {
            var timesheet = await this.timesheets.AllAsNoTracking().Where(t => t.StartDate == startDate && t.FinishDate == finishDate).FirstOrDefaultAsync();

            foreach (var productId in productIds)
            {
                var timesheetProduct = new TimesheetProject
                {
                    TimesheetId = timesheet.Id,
                    ProjectId=productId,
                };

                await this.timesheerProjects.AddAsync(timesheetProduct);
                await this.timesheerProjects.SaveChangesAsync();
            }
        }
    }
}
