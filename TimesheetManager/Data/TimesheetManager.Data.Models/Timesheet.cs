namespace TimesheetManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TimesheetManager.Data.Common.Models;

    public class Timesheet : BaseDeletableModel<int>
    {
        public Timesheet()
        {
            this.TimesheetTasks = new HashSet<TimesheetTask>();
            this.TimesheetProjects = new HashSet<TimesheetProject>();
        }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public bool IsSubmitted { get; set; }

        public ICollection<TimesheetTask> TimesheetTasks { get; set; }

        public ICollection<TimesheetProject> TimesheetProjects { get; set; }
    }
}
