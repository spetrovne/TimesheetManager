namespace TimesheetManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TimesheetManager.Data.Common.Models;

    public class TimesheetProject : BaseModel<int>
    {
        public int TimesheetId { get; set; }

        public Timesheet Timesheet { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
