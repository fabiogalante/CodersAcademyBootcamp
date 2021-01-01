using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CodersAcademyBootcamp.Crosscutting.Specification
{
    public class AndSpecification<T> : Specification<T>, ISpecification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;


        public AndSpecification(Specification<T> left, Specification<T> right) 
        {
            _right = right;
            _left = left;
        }


        public override Expression<Func<T, bool>> SatisfyByCriteria()
        {
            Expression<Func<T, bool>> leftExpression = _left.Criteria;
            Expression<Func<T, bool>> rightExpression = _right.Criteria;

            var paramExpr = Expression.Parameter(typeof(T));
            var exprBody = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
            exprBody = (BinaryExpression)new ParameterReplacer(paramExpr).Visit(exprBody);
            var finalExpr = Expression.Lambda<Func<T, bool>>(exprBody, paramExpr);

            return finalExpr;
        }
    }
}
