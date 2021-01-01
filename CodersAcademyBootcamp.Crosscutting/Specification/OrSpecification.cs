using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CodersAcademyBootcamp.Crosscutting.Specification
{
    public class OrSpecification<T> : Specification<T>, ISpecification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;


        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            _right = right;
            _left = left;
        }


        public override Expression<Func<T, bool>> SatisfyByCriteria()
        {
            var leftExpression = _left.Criteria;
            var rightExpression = _right.Criteria;
            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.OrElse(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }
    }
}
