using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ElifOzkolTMTask.Models
{
    public class Rule
    {
        public Func<int, int> compiledRule;

        private string Operator
        {
            get;
            set;
        }

        private string TargetValue
        {
            get;
            set;
        }

        private int ExpectedResult
        {
            get;
            set;
        }

        public string Output
        {
            get;
        }


        static Expression BuildExpr<T>(Rule r, ParameterExpression param)
        {
            var left = param;
            var tProp = typeof(int);
            ExpressionType tBinary;
            if (ExpressionType.TryParse(r.Operator, out tBinary))
            {
                var right = Expression.Constant(Convert.ChangeType(r.TargetValue, tProp));
                return Expression.MakeBinary(tBinary, left, right);
            } else
            {
                var method = tProp.GetMethod(r.Operator);
                var tParam = method.GetParameters()[0].ParameterType;
                var right = Expression.Constant(Convert.ChangeType(r.TargetValue, tParam));
                return Expression.Call(left, method, right);
            }
        }

        private Func<T, int> CompileRule<T>(Rule r)
        {
            var param = Expression.Parameter(typeof(int));
            Expression expr = BuildExpr<T>(r, param);
            return Expression.Lambda<Func<T, int>>(expr, param).Compile();
        }

        public bool execute(int input)
        {
            int result = this.compiledRule(input);
            if (result == ExpectedResult)
                return true;
            else
                return false;
        }
        public Rule(string Operator, string TargetValue,
            string ExpectedResult, string Output)
        {
            this.Output = Output;
            this.Operator = Operator;
            this.TargetValue = TargetValue;
            this.ExpectedResult = Convert.ToInt32(ExpectedResult);
            this.compiledRule = CompileRule<int>(this);
        }

    }
}