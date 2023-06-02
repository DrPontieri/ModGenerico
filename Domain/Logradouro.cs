using core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public partial class Logradouro : Entity
    {
        public string Endereço { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }

        public string Complemento { get; set; }

        [JsonIgnore]
        public Pessoa Pessoa { get; set; }
    }
}
