using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Util.Ui.Expressions {
    /// <summary>
    /// 表达式解析器
    /// </summary>
    public abstract class ExpressionResolverBase : IExpressionResolver {
        /// <inheritdoc />
        public ModelExpressionInfo Resolve( ModelExpression expression ) {
            var result = new ModelExpressionInfo();
            result.Name = expression.Name;
            return result;
        }
    }
}
