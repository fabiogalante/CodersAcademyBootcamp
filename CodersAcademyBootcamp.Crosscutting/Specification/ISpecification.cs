using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CodersAcademyBootcamp.Crosscutting.Specification
{
    public interface ISpecification<T>
    {
      
        bool IsSatisfiedBy(T entity);

        Expression<Func<T, bool>> SatisfyByCriteria();

        Specification<T> And(ISpecification<T> specification);

        Specification<T> Or(ISpecification<T> specification);
    }
}
