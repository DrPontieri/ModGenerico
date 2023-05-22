using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Models
{
    public class Entity
    {
        public Guid Id { get; private set; }

        protected Entity(Guid id)
        {
            Id = id;
        }
    }
}
