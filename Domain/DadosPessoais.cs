using core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    [Table("DadosPessoais")]
    public partial class DadosPessoais : Entity
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Pais { get; set; }

        public DateTime DtNascimento { get; set; }

        [JsonIgnore]
        public Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }

        //public DadosPessoais(string nome, string email, string pais, DateTime? dtNascimento)
        //{
        //    Nome = nome;
        //    Email = email;
        //    Pais = pais;
        //    DtNascimento = dtNascimento;
        //}






        //public DadosPessoais(Guid id, string nome, string email, string pais, Guid dadospessoaisid , DateTime? dtnascimento) : base(id)
        //{
        //    //Pessoa = pessoa;
        //    //DadosPessoaisId = pessoa.Id;
        //    Nome = nome;
        //    Email = email;
        //    Pais = pais;
        //    DadosPessoaisId = dadospessoaisid;
        //    DtNascimento = dtnascimento = null;
        //}
    }
}
