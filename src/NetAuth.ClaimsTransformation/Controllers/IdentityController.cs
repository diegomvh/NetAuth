
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NetAuth.ClaimsTransformation.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        [HttpGet]
        [Authorize(Policy="Over21")]
        [Route("alcohol")]
        public IActionResult Alcohol()
        {
            
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
