using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityProject.Models
{
    [Table("Usuarios")]
    public class UsuarioModel : IdentityUser
    {
        public UsuarioModel()
        : base()
        {
            
        }

        public DateTime DataNascimento { get; set; }
    }
}