using System.ComponentModel.DataAnnotations;

namespace Academy.Models
{
    public class Personal
    {
        [Key]
        public int PersonalId { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public ICollection<Aluno> Alunos { get; set; }
    }
}
