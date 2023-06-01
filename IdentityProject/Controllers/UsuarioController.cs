using IdentityProject.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult CadastrarUsuario(CreateUsuarioDTO createUsuarioDTO)
        {
            throw new NotImplementedException();
        }
    }
}
