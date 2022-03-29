using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Requests
{
    public class GetTokenResetPasswordRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
