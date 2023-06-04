using AutoMapper;
using System.Text;
using IdentityProject.Models;
using IdentityProject.Data.Dtos;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentityProject.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<UsuarioModel> _usermanager;
        private SignInManager<UsuarioModel> _signInManager;
        private TokenService _tokenService;

        public UsuarioService(IMapper mapper, UserManager<UsuarioModel> userManager, 
                              SignInManager<UsuarioModel> signInManager, 
                              TokenService tokenService)
        {
            _mapper = mapper;
            _usermanager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task Cadastrar(CreateUsuarioDTO usuarioDto) 
        {
                var usuario = _mapper.Map<UsuarioModel>(usuarioDto);
            
                var resultado = await _usermanager.CreateAsync(usuario, usuarioDto.Password);
                
                if (!resultado.Succeeded) 
                {
                    var erros = new StringBuilder();
                    foreach(var erro in resultado.Errors) 
                        erros.AppendLine(erro.Description + " ");

                    throw new Exception(erros.ToString());
                }
        }

        public async Task<string> Login(LoginUsuarioDTO usuarioDto) 
        {
                var resultado = await _signInManager.PasswordSignInAsync(usuarioDto.UserName, usuarioDto.Password, false, false);

                if (!resultado.Succeeded) 
                {
                    throw new ApplicationException("Usuário não autenticado!!!");
                }

                var claims = new Claim[] {
                    new Claim("username", usuarioDto.UserName)
                };

                var usuario = _signInManager
                                .UserManager
                                .Users.FirstOrDefault(u => u.NormalizedUserName == usuarioDto.UserName.ToUpper());
                
                return _tokenService.GerarToken(usuario);
        }
    }
}