namespace TimesheetManager.Services.Data.Week
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TimesheetManager.Data.Models;
    using TimesheetManager.Data.Common.Repositories;
    using TimesheetManager.Common;
    using System.Threading.Tasks;
    using TimesheetManager.Services.Data.Contracts.Week;

    public class WeekService : IWeekService
    {
        private readonly IDeletableEntityRepository<Week> weeks;

        public WeekService(IDeletableEntityRepository<Week> weeks)
        {
            this.weeks = weeks;
        }

        public async Task CreateAsync(Week week)
        {
            await this.weeks.AddAsync(week);
            await this.weeks.SaveChangesAsync();
        }
    }
}
