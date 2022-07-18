using Util.Ui.Configs;

namespace Util.Ui.Expressions {
    /// <summary>
    /// 表达式加载器
    /// </summary>
    public interface IExpressionLoader {
        /// <summary>
        /// 加载模型表达式配置
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="expressionPropertyName">模型表达式属性名,默认值为for</param>
        void Load( Config config, string expressionPropertyName = "for" );
    }
}
