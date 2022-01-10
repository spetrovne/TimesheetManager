namespace TimesheetManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TimesheetManager.Data.Common.Models;

    public class Project : BaseDeletableModel<int>
    {
        public Project()
        {
            this.TimesheetProjects = new HashSet<TimesheetProject>();
        }

        public string Name { get; set; }

        public ICollection<ProjectTask> Tasks { get; set; }

        public ICollection<TimesheetProject> TimesheetProjects { get; set; }
    }
}
