namespace TimesheetManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TimesheetManager.Data.Common.Models;

    public class ProjectTask : BaseDeletableModel<int>
    {
        //public ProjectTask()
        //{
        //    this.TimesheetTasks = new HashSet<TimesheetTask>();
        //}

        public string Name { get; set; }

        public virtual ICollection<Timesheet> Timesheets { get; set; }

        //public int ProjectId { get; set; }

        //public Project Project { get; set; }

        //public ICollection<TimesheetTask> TimesheetTasks { get; set; }
    }
}
