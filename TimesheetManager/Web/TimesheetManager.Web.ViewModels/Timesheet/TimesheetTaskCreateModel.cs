namespace TimesheetManager.Web.ViewModels.Timesheet
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TimesheetTaskCreateModel
    {
        public int TaskId { get; set; }

        public DateTime Date { get; set; }

        public string Day { get; set; }

        public double Hours { get; set; }

        public string Notes { get; set; }

        public double MondayHours { get; set; }

        public double TuesdayHours { get; set; }

        public double WednesdayHours { get; set; }

        public double ThursdayHours { get; set; }

        public double FridayHours { get; set; }

        public double SaturdayHours { get; set; }

        public double SundayHours { get; set; }
    }
}
