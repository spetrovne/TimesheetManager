namespace TimesheetManager.Web.Areas.User.Controllers.Project
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Authorize(Roles = "Employee")]
    [Area("User")]
    [Route("[controller]")]
    public abstract class ProjectBaseController : ControllerBase
    {
    }
}
