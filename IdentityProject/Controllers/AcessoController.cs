using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace IdentityProject.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AcessoController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Acesso Permitido!!!");
        }
    }
}