using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExemploDojo.WebApi.Models
{
    public class Tarefa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Chave { get; set; }
        public string Nome { get; set; }
        public bool EstaCompleta { get; set; }
    }
}
