namespace TimesheetManager.Services.Data.Contracts.Task
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ITaskService
    {
        Task<bool> ValidateTask(int id);
    }
}
