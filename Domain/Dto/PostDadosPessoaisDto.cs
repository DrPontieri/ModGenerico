using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class PostDadosPessoaisDto
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string pais { get; set; }
        public DateTime dtNascimento { get; set; }
        public int PessoaID { get; set; }
    }
}