using core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public partial class PostPessoaDto : Entity
    {
        public DateTime DtCadastro { get; set; } = DateTime.Now;

        //Dados Pessoais
        public string? nome { get; set; } = "Daniel Pontieri";
        public string email { get; set; } = "drpontieri@gmail.com";
        public string pais { get; set; } = "Brasil";
        public DateTime dtNascimento { get; set; } = DateTime.Now;

        //Logradouro
        public string cidade { get; set; } = "São Paulo";
        public string estado { get; set; } = "SP";
        public string cep { get; set; } = "04002-031";
        public string endereco { get; set; } = "Rua Teixeira da Silva";
        public int numero { get; set; } = 363;
        public string bairro { get; set; } = "Paraiso";
        public string complemento { get; set; } = "ap-61";

        //PaymentDetail Detail
        public string cardownername { get; set; } = "Daniel Pontieri";
        public string cardnumber { get; set; } = "1234 5678 9012 3456";
        public string expirationdate { get; set; } = "04/27";
        public string securitycode { get; set; } = "648";
    }
}