using Util.Ui.Configs;
using Util.Ui.Expressions;

namespace Util.Ui.NgZorro.Expressions {
    /// <summary>
    /// NgZorro表达式加载器
    /// </summary>
    public abstract class NgZorroExpressionLoaderBase : ExpressionLoaderBase {
        /// <summary>
        /// 创建模型表达式解析器
        /// </summary>
        /// <param name="config">配置</param>
        protected override IExpressionResolver CreateExpressionResolver( Config config ) {
            return new NgZorroExpressionResolver( config );
        }
    }
}
