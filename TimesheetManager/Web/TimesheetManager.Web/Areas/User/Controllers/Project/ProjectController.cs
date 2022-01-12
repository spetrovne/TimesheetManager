namespace TimesheetManager.Web.Areas.User.Controllers.Project
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TimesheetManager.Common;
    using TimesheetManager.Services.Data.Contracts.Project;
    using TimesheetManager.Web.ViewModels.Project;

    using static TimesheetManager.Common.GlobalConstants.ControllerRoutes;
    using static TimesheetManager.Common.GlobalConstants.ControllersResponseMessages;

    public class ProjectController : ProjectBaseController
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet]
        [Route(GetAllRoute)]
        public async Task<IEnumerable<ProjectViewModel>> GetAll()
        => await this.projectService.GetAllAsync<ProjectViewModel>();

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectModel model)
        {
            var result = await this.projectService.CreateAsync(model);

            if (result.Failure)
            {
                return this.BadRequest(result.Error);
            }

            return this.Ok(SuccesfullyCreated);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await this.projectService.RemoveAsync(id);

            if (result.Failure)
            {
                return this.BadRequest(result.Error);
            }

            return this.Ok(SuccesfullyDeleted);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProjectViewModel model)
        {
            var result = await this.projectService.UpdateAsync(model);

            if (result.Failure)
            {
                return this.BadRequest(result.Error);
            }

            return this.Ok(SuccesfullyEdited);
        }
    }
}
