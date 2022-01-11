namespace TimesheetManager.Services.Data.Contracts.Timesheet
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using TimesheetManager.Common;
    using TimesheetManager.Web.ViewModels.Timesheet;

    public interface ITimesheetService
    {
        Task<Result> CreateAsync(CreateTimesheetModel model);
    }
}
