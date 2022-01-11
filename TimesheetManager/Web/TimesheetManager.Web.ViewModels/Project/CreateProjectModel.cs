namespace TimesheetManager.Web.ViewModels.Project
{
    using System.ComponentModel.DataAnnotations;

    public class CreateProjectModel
    {
        [Required]
        public string Name { get; set; }
    }
}
