using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace E3SLinqProvider
{
    public class ExpressionToFTSRequestTranslator : ExpressionVisitor
	{
		StringBuilder resultString;

		public string Translate(Expression exp)
		{
			resultString = new StringBuilder();
			Visit(exp);

			return resultString.ToString();
		}

		protected override Expression VisitMethodCall(MethodCallExpression node)
		{
            if (node.Method.DeclaringType == typeof(Queryable))
            {
                switch (node.Method.Name)
                {
                    case "Where": 
                        var predicate = node.Arguments[1];
                        Visit(predicate);
                        return node;
                }
			}
            else if (node.Method.DeclaringType == typeof(string))
            {
                switch (node.Method.Name)
                {
                    case "Contains":
                        Visit(node.Object);
                        var arg = node.Arguments[0];
                        if (arg.NodeType == ExpressionType.Constant)
                        {
                            var constExpr = (ConstantExpression)arg;
                            resultString.Append("(*").Append(constExpr.Value).Append("*)");
                        }
                        else
                        {
                            Visit(arg);
                        }
                        return node;
                    case "StartsWith":
                        Visit(node.Object);
                        arg = node.Arguments[0];
                        if (arg.NodeType == ExpressionType.Constant)
                        {
                            var constExpr = (ConstantExpression)arg;
                            resultString.Append("(").Append(constExpr.Value).Append("*)");
                        }
                        else
                        {
                            Visit(arg);
                        }
                        return node;
                    case "EndsWith":
                        Visit(node.Object);
                        arg = node.Arguments[0];
                        if (arg.NodeType == ExpressionType.Constant)
                        {
                            var constExpr = (ConstantExpression)arg;
                            resultString.Append("(*").Append(constExpr.Value).Append(")");
                        }
                        else
                        {
                            Visit(arg);
                        }
                        return node;
                }
            }
            return base.VisitMethodCall(node);
		}



		protected override Expression VisitBinary(BinaryExpression node)
		{
			switch (node.NodeType)
			{
				case ExpressionType.Equal:
                    Expression memberAssess;
                    Expression constant;
                    if (node.Left.NodeType == ExpressionType.MemberAccess && node.Right.NodeType == ExpressionType.Constant)
                    {
                        memberAssess = node.Left;
                        constant = node.Right;
                    }
                    else if (node.Left.NodeType == ExpressionType.Constant && node.Right.NodeType == ExpressionType.MemberAccess)
                    {
                        memberAssess = node.Right;
                        constant = node.Left;
                    }
                    else
                    {
                        throw new NotSupportedException(string.Format("Operation {0} is not supported", node.NodeType));
                    }
                    Visit(memberAssess);
                    resultString.Append("(");
                    Visit(constant);
                    resultString.Append(")");
                    break;

                case ExpressionType.AndAlso:
                    Visit(node.Left);
                    resultString.Append(" AND ");
                    Visit(node.Right);
                    break;
                case ExpressionType.OrElse:
                    Visit(node.Left);
                    resultString.Append(" OR ");
                    Visit(node.Right);
                    break;
                default:
					throw new NotSupportedException(string.Format("Operation {0} is not supported", node.NodeType));
			};

			return node;
		}

		protected override Expression VisitMember(MemberExpression node)
		{
			resultString.Append(node.Member.Name).Append(":");

			return base.VisitMember(node);
		}

		protected override Expression VisitConstant(ConstantExpression node)
		{
			resultString.Append(node.Value);

			return node;
		}
	}
}
