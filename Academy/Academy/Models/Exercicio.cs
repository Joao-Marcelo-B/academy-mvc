using System.ComponentModel.DataAnnotations;

namespace Academy.Models
{
    public class Exercicio
    {
        [Key]
        public int ExercicioId { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public ICollection<Treino> Treinos { get; set; }
    }
}
