using IdentityProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IdentityProject.Data
{
    public class UsuarioDbContext : IdentityDbContext<UsuarioModel>
    {
        public UsuarioDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
            
        }
    }
}