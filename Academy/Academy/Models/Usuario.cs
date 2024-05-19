using System.ComponentModel.DataAnnotations;

namespace Academy.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public string Nome { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Deve fornecer um email válido")]
        public string Email { get; set; }
    }
}
