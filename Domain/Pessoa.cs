using core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Pessoa")]
    public class Pessoa : Entity
    {
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataCadastro { get => DateTime.Now; private set => value.ToString(); }

        public ICollection<DadosPessoais> lstDadosPessoais => new List<DadosPessoais>();

        public Pessoa(DateTime? dataCadastro)
        { 
            DataCadastro = dataCadastro;
        }









        //public Pessoa(Guid id, DateTime? datacadastro) : base(id)
        //{
        //    DataCadastro = datacadastro;
        //}
    }
}
   
