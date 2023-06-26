using core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public partial class PostPessoaDto : Entity
    {
        public string DtCadastro { get; set; }

        //Dados Pessoais
        public string nome { get; set; }
        public string email { get; set; }
        public string pais { get; set; }
        public string dtNascimento { get; set; }

        //Logradouro
        public string cidade { get; set; }
        public string estado { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public int numero { get; set; }
        public string bairro { get; set; }
        public string complemento { get; set; }

        //PaymentDetail Detail
        public string cardownername { get; set; }
        public string cardnumber { get; set; }
        public string expirationdate { get; set; }
        public string securitycode { get; set; }
    }
}