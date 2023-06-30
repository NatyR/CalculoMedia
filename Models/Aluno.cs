using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Aluno
    {

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "é preciso informar a listagem de notas do aluno para realizar o cálculo!")]
        public List<double> Notas { get; set; } = new List<double>();

    }
}