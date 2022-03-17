using System.ComponentModel.DataAnnotations;

namespace AlunoApi.Model
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        //nao pode ser null e maximo de chars
        [Required]
        [StringLength(80)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public int Idade { get; set; }
    }
}