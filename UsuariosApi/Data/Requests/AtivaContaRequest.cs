using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Requests
{
    public class AtivaContaRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Code { get; set; }
    }
}
