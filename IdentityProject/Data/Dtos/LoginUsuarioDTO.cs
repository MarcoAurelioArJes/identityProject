using System.ComponentModel.DataAnnotations;


namespace IdentityProject.Data.Dtos
{
    public class LoginUsuarioDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}