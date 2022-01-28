namespace TimesheetManager.Web.Areas.User.Controllers.Timesheet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TimesheetManager.Services.Data.Contracts.Timesheet;
    using TimesheetManager.Web.ViewModels.Timesheet;

    using static TimesheetManager.Common.GlobalConstants.ControllersResponseMessages;

    public class TimesheetController : TimesheetBaseController
    {
        private readonly ITimesheetService timesheetService;

        public TimesheetController(ITimesheetService timesheetService)
        {
            this.timesheetService = timesheetService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTimesheetModel timesheet)
        {
            var result = await this.timesheetService.CreateAsync(timesheet);

            if (result.Failure)
            {
                return this.BadRequest(result.Error);
            }

            return this.Ok(SuccesfullyCreated);
        }
    }
}
