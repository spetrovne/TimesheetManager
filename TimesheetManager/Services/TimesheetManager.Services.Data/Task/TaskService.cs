namespace TimesheetManager.Services.Data.Task
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TimesheetManager.Data.Common.Repositories;
    using TimesheetManager.Data.Models;
    using TimesheetManager.Services.Data.Contracts.Task;

    public class TaskService : ITaskService
    {
        private readonly IDeletableEntityRepository<ProjectTask> tasks;

        public TaskService(IDeletableEntityRepository<ProjectTask> tasks)
        {
            this.tasks = tasks;
        }

        public async Task<bool> ValidateTask(int id)
        {
            var task = await this.tasks.AllAsNoTracking().Where(t => t.Id == id).FirstOrDefaultAsync();

            if (task == null)
            {
                return false;
            }

            return true;
        }
    }
}
