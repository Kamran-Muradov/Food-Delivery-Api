using Microsoft.AspNetCore.Mvc;

namespace Food_Delivery_App.Controllers.UI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}
