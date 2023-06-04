using AutoMapper;
using IdentityProject.Models;
using Microsoft.AspNetCore.Mvc;
using IdentityProject.Services;
using IdentityProject.Data.Dtos;
using Microsoft.AspNetCore.Identity;

namespace IdentityProject.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDTO usuarioDto)
        {
            try
            {
                await _usuarioService.Cadastrar(usuarioDto);
                
                return Ok("Usuário cadastrado com sucesso!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUsuario(LoginUsuarioDTO usuarioDto)
        {
            try
            {
                var token = await _usuarioService.Login(usuarioDto);
                                
                return Ok(token);
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }
    }
}
