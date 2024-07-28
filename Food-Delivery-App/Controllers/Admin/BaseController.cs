using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Food_Delivery_App.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Policy = "RequireAdminRole")]
    public abstract class BaseController : ControllerBase
    {
    }
}
