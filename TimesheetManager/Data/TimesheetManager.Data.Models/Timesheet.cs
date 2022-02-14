namespace TimesheetManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TimesheetManager.Data.Common.Models;

    public class Timesheet : BaseDeletableModel<int>
    {
        //public Timesheet()
        //{
        //    this.TimesheetTasks = new HashSet<TimesheetTask>();
        //    this.TimesheetProjects = new HashSet<TimesheetProject>();
        //}

        public Status Status { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public int TaskId { get; set; }

        public virtual ProjectTask ProjectTask { get; set; }

        public Week Week { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        //public ICollection<TimesheetTask> TimesheetTasks { get; set; }

        //public ICollection<TimesheetProject> TimesheetProjects { get; set; }
    }
}
