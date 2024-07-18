using Microsoft.AspNetCore.Mvc;

namespace Food_Delivery_App.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}
