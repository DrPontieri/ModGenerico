using core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public partial class Carro : Entity
    {
        [StringLength(100)]
        public string Nome { get;  set; }

        public int Potencia { get; set; }

        public Carro(string nome, int potencia)
        {
            Nome = nome;
            Potencia = potencia;
        }
    }
}
