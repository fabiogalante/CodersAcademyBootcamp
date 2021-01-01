using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CodersAcademyBootcamp.Crosscutting.Specification
{
    public class Specification<T> : ISpecification<T>
    {

        public Expression<Func<T, bool>> Criteria { get; private set; }

        public virtual Expression<Func<T, bool>> SatisfyByCriteria()
        {
            return this.Criteria;
        }

        internal Specification()
        {

        }

        internal Specification(Expression<Func<T, bool>> expression)
        {
            this.Criteria = expression ?? throw new ArgumentNullException();
        }

        public bool IsSatisfiedBy(T entity)
        {
            return this.Criteria.Compile().Invoke(entity);
        }

        public Specification<T> And(ISpecification<T> specification)
        {
            this.Criteria = new AndSpecification<T>(this, specification as Specification<T>).SatisfyByCriteria();
            return this;
        }

        public Specification<T> Or(ISpecification<T> specification)
        {
            this.Criteria = new OrSpecification<T>(this, specification as Specification<T>).SatisfyByCriteria();
            return this;
        }


        public static ISpecification<T> CreateSpecification(Expression<Func<T, bool>> expression)
        {
            return new Specification.Specification<T>(expression);
        }

    }
}
