using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgendaDominio
{
    public class Contato
    {
        [Key]
        public int ContatoId { get; set; }

        [Display(Name = "Nome", Prompt = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome", Prompt = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Display(Name = "Telefone Fixo", Prompt = "Telefone Fixo")]
        public string TelefoneFixo { get; set; }

        [Display(Name = "Celular", Prompt = "Celular")]
        public string Celular { get; set; }

        [Display(Name = "E-Mail", Prompt = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool Masculino { get; set; }
        public bool Feminino { get; set; }

        [Display(Name = "Imagem", Prompt = "Imagem")]
        public byte[] Imagem { get; set; }

        [Display(Name = "Tipo da Imagem", Prompt = "Tipo da Imagem")]
        public string ImagemTipo { get; set; }

        
    }
}
