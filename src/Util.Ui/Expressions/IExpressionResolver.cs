using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Util.Ui.Expressions {
    /// <summary>
    /// 模型表达式解析器
    /// </summary>
    public interface IExpressionResolver {
        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="expression">模型表达式</param>
        ModelExpressionInfo Resolve( ModelExpression expression );
    }
}
