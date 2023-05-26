﻿using core.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Abstractions
{
    public interface IPessoaAbstractRepository
    {
        Task AddAsync(Pessoa entity);

    }
}