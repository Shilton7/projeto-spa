using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace servico_aula_api.Models
{
    [Table("tb_usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = false;
    }
}
