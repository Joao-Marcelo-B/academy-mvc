using System.ComponentModel.DataAnnotations;

namespace Academy.Models
{
    public class Treino
    {
        [Key]
        public int TreinoId { get; set; }
        public int AlunoId { get; set; }
        public DateTime Data { get; set; }
        public Aluno Aluno { get; set; }
        public ICollection<Exercicio> Exercicios { get; set; }
    }
}
