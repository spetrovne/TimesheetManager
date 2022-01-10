namespace TimesheetManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TimesheetManager.Data.Common.Models;

    public class TimesheetTask : BaseModel<int>
    {
        public TimesheetTask()
        {
            this.TasksHours = new HashSet<TaskHours>();
        }

        public int TimesheetId { get; set; }

        public Timesheet Timesheet { get; set; }

        public int ProjectTaskId { get; set; }

        public ProjectTask ProjectTask { get; set; }

        public ICollection<TaskHours> TasksHours { get; set; }

        //public double MondayHours { get; set; }

        //public double TuesdayHours { get; set; }

        //public double WednesdayHours { get; set; }

        //public double ThursdayHours { get; set; }

        //public double FridayHours { get; set; }

        //public double SaturdayHours { get; set; }

        //public double SundayHours { get; set; }
    }
}
