namespace Util.Ui.Expressions {
    /// <summary>
    /// 表达式加载器
    /// </summary>
    public class ExpressionLoader : ExpressionLoaderBase {
        /// <summary>
        /// 初始化表达式加载器
        /// </summary>
        public ExpressionLoader() : base( new ExpressionResolver() ) {
        }
    }
}
