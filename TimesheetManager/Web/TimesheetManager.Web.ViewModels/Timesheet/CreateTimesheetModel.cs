using System;
using System.Collections.Generic;
using System.Text;

namespace TimesheetManager.Web.ViewModels.Timesheet
{
    public class CreateTimesheetModel
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public ICollection<TimesheetTaskCreateModel> TimesheetTasks { get; set; }

        public ICollection<int> TimesheetProjects { get; set; }
    }
}
