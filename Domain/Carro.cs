using core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Carro : Entity
    {
        [StringLength(100)]
        public string Nome { get; private set; }

        public int Potencia { get; private set; }

        public Carro(Guid id, string nome, int potencia) : base(id)
        {
            Nome = nome;
            Potencia = potencia;
        }
    }
}
