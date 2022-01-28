namespace TimesheetManager.Web.Areas.User.Controllers.Timesheet
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Area("User")]
    [Route("[controller]")]
    public class TimesheetBaseController : ControllerBase
    {
    }
}
