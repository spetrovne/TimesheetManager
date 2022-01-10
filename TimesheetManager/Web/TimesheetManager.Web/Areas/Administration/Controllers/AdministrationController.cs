namespace TimesheetManager.Web.Areas.Administration.Controllers
{
    using TimesheetManager.Common;
    using TimesheetManager.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
