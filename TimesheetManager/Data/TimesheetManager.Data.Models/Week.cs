namespace TimesheetManager.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TimesheetManager.Data.Common.Models;

    public class Week : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public int TimesheetId { get; set; }

        public virtual Timesheet Timesheet { get; set; }

        public double MondayHours { get; set; }

        public double TuesdayHours { get; set; }

        public double WednesdayHours { get; set; }

        public double ThursdayHours { get; set; }

        public double FridayHours { get; set; }

        public double SaturdayHours { get; set; }

        public double SundayHours { get; set; }
    }
}
