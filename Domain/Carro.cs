﻿using core.Models;
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
        public string Nome { get;  set; }

        public int Potencia { get; set; }

        public DateTime DtNascimento { get; set; }

        public Carro(string nome, int potencia, DateTime dtNascimento)
        {
            Nome = nome;
            Potencia = potencia;
            DtNascimento = dtNascimento;
        }
    }
}
