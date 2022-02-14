using System;
using System.Collections.Generic;
using System.Text;

namespace TimesheetManager.Web.ViewModels.Timesheet
{
    public class CreateTimesheetModel
    {
        public int ProjectId { get; set; }

        public int TaskId { get; set; }

        public string WeekName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double TotalHours { get; set; }

        public string Notes { get; set; }

        public double MondayHours { get; set; }

        public double TuesdayHours { get; set; }

        public double WednesdayHours { get; set; }

        public double ThursdayHours { get; set; }

        public double FridayHours { get; set; }

        public double SaturdayHours { get; set; }

        public double SundayHours { get; set; }

        public string UserEmail { get; set; }

        //public string Name { get; set; }

        //public DateTime StartDate { get; set; }

        //public DateTime FinishDate { get; set; }

        //public ICollection<TimesheetTaskCreateModel> TimesheetTasks { get; set; }

        //public ICollection<int> TimesheetProjects { get; set; }
    }
}
