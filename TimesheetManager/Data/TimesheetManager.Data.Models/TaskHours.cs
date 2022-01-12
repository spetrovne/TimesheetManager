namespace TimesheetManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TimesheetManager.Data.Common.Models;

    public class TaskHours : BaseDeletableModel<int>
    {
        public int ProjectTaskId { get; set; }

        public ProjectTask ProjectTask { get; set; }

        public int TimesheetId { get; set; }

        public Timesheet Timesheet { get; set; }

        public DateTime Date { get; set; }

        public string Day { get; set; }

        public double Hours { get; set; }

        public string Notes { get; set; }
    }
}
