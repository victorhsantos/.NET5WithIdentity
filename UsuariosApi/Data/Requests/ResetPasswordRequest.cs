using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Requests
{
    public class ResetPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Senhas informadas não conferem.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Token { get; set; }

    }
}
