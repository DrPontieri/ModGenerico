using core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("DadosPessoais")]
    public partial class DadosPessoais : Entity
    {
        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string Nome { get; private set; }

        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string Email { get; private set; }

        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string Pais { get; private set; }


        [Column(TypeName = "datetime")]
        public DateTime? DtNascimento { get; private set; }

        [NotMapped]
        public Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }

        public DadosPessoais(string nome, string email, string pais, DateTime? dtNascimento)
        {
            Nome = nome;
            Email = email;
            Pais = pais;
            DtNascimento = dtNascimento;
        }






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
