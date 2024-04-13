using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academy.Models
{
    public class Aluno
    {
        [Key]
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        [Column(TypeName = "date")]
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Instagram { get; set; }
        public string Telefone { get; set; }
        public string Observacoes { get; set; }
        public int PersonalId { get; set; }
        public Personal Personal { get; set; }
        public ICollection<Treino> Treinos { get; set; }
    }
}
