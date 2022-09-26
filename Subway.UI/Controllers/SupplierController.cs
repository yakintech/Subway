using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Subway.UI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {

        public string Index()
        {
            return "Yetkilendirme başarılı...";
        }
    }
}
