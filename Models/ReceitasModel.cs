using System.ComponentModel.DataAnnotations;

namespace Receitas_Fiap.Models
{
    public class ReceitasModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string DataCriacao { get; set; }

        public string DataAlteracao { get; set; }

        public string Descricao { get; set; }

        public string Ingredientes { get; set; }
    }
}
