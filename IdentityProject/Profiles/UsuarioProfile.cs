using AutoMapper;
using IdentityProject.Models;
using IdentityProject.Data.Dtos;

namespace IdentityProject.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDTO, UsuarioModel>();
        }
    }
}
