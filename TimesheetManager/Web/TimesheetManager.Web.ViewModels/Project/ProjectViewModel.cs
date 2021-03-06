namespace TimesheetManager.Web.ViewModels.Project
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TimesheetManager.Data.Models;
    using TimesheetManager.Services.Mapping;

    public class ProjectViewModel : IMapFrom<Project>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
