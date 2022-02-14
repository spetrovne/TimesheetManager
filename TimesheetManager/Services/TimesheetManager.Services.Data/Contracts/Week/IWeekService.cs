namespace TimesheetManager.Services.Data.Contracts.Week
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using TimesheetManager.Data.Models;

    public interface IWeekService
    {
        Task CreateAsync(Week week);
    }
}
