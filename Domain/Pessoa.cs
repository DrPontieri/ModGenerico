using core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Pessoa")]
    public partial class Pessoa : Entity
    {
        public DateTime DataCadastro { get; set; }
        public DadosPessoais DadosPessoais { get; set; }

        public Logradouro Logradouro { get; set; }

        public PaymentDetail PaymentDetail { get; set; }

        //public List<Logradouro> Logradouros { get; set;}

        //public Pessoa(DateTime? dataCadastro)
        //{
        //    DataCadastro = dataCadastro;
        //}











        //public Pessoa(Guid id, DateTime? datacadastro) : base(id)
        //{
        //    DataCadastro = datacadastro;
        //}
    }
}
   
