using System.ComponentModel.DataAnnotations;

namespace IdentityProject.Data.Dtos
{
    public class CreateUsuarioDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }
    }
}
