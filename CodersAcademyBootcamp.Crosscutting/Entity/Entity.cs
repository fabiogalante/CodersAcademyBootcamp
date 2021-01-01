using System;
using System.Collections.Generic;
using System.Text;

namespace CodersAcademyBootcamp.Crosscutting.Entity
{
    public abstract class Entity<T>
    {
        public virtual T Id { get; set; }
    }
}
