namespace TimesheetManager.Services.Data.Timesheet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TimesheetManager.Common;
    using TimesheetManager.Data.Common.Repositories;
    using TimesheetManager.Data.Models;
    using TimesheetManager.Services.Data.Contracts.Project;
    using TimesheetManager.Services.Data.Contracts.Timesheet;
    using TimesheetManager.Web.ViewModels.Project;
    using TimesheetManager.Web.ViewModels.Timesheet;

    using static TimesheetManager.Common.GlobalConstants.ControllersResponseMessages;

    public class TimesheetService : ITimesheetService
    {
        private readonly IDeletableEntityRepository<Timesheet> timesheets;
        private readonly IDeletableEntityRepository<ProjectTask> tasks;
        private readonly IRepository<TaskHours> taskHours;
        private readonly IRepository<TimesheetProject> timesheerProjects;
        private readonly IRepository<TimesheetTask> timesheetTasks;
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
            this.timesheetTasks = timesheetTasks;
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

            var timesheetExists =await this.timesheets.AllAsNoTracking().Where(t => t.StartDate == model.StartDate && t.FinishDate == model.FinishDate).FirstOrDefaultAsync();

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

            var timesheetFromDb = await this.timesheets.AllAsNoTracking().Where(t => t.StartDate == model.StartDate && t.FinishDate == model.FinishDate).FirstOrDefaultAsync();

            await this.AddProductsToTimesheet(model.TimesheetProjects, model.StartDate, model.FinishDate);
            await this.AddTasksToTimesheet(model.TimesheetTasks, timesheetFromDb.Id);

            return true;
        }

        private async Task AddTasksToTimesheet(
            ICollection<TimesheetTaskCreateModel> timesheetTasks,
            int timesheetId)
        {

            foreach (var taskModel in timesheetTasks)
            {
                var timesheetTask = new TimesheetTask
                {
                    ProjectTaskId = taskModel.TaskId,
                    TimesheetId = timesheetId,
                    Date = taskModel.Date,
                    Day = taskModel.Day,
                    MondayHours = taskModel.MondayHours,
                    TuesdayHours = taskModel.TuesdayHours,
                    WednesdayHours = taskModel.WednesdayHours,
                    ThursdayHours = taskModel.ThursdayHours,
                    FridayHours = taskModel.FridayHours,
                    SaturdayHours = taskModel.SaturdayHours,
                    SundayHours = taskModel.SundayHours,
                };

                await this.timesheetTasks.AddAsync(timesheetTask);
                await this.timesheetTasks.SaveChangesAsync();

                //await this.AddHoursWorkedOnTask(taskModel, timesheetId);
            }
        }

        private async Task AddHoursWorkedOnTask(
            TimesheetTaskCreateModel timesheetTask,
            int timesheetId)
        {
            var timesheetTaskFromDb = await this.timesheetTasks.All().Where(tt => tt.ProjectTaskId == timesheetTask.TaskId && tt.TimesheetId == timesheetId).FirstOrDefaultAsync();

            var workedHoursOnTask = new TaskHours
            {
                TimesheetId = timesheetTaskFromDb.TimesheetId,
                ProjectTaskId = timesheetTaskFromDb.ProjectTaskId,
                Date = timesheetTask.Date,
                Day = timesheetTask.Day,
 //               Hours = timesheetTask.HoursWorked,
            };

            await this.taskHours.AddAsync(workedHoursOnTask);
            await this.taskHours.SaveChangesAsync();
        }

        private async Task<bool> ValidateProjects(ICollection<int> projectIds)
        {
            var projects = await this.projectService.GetAllAsync<ProjectViewModel>();

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
                    ProjectId = productId,
                };

                await this.timesheerProjects.AddAsync(timesheetProduct);
                await this.timesheerProjects.SaveChangesAsync();
            }
        }
    }
}
