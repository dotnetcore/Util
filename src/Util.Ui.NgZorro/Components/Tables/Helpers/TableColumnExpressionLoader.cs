using Util.Ui.Configs;
using Util.Ui.Expressions;

namespace Util.Ui.NgZorro.Components.Tables.Helpers {
    /// <summary>
    /// 表格列表达式加载器
    /// </summary>
    public class TableColumnExpressionLoader : ExpressionLoader {
        /// <summary>
        /// 加载属性名
        /// </summary>
        protected override void LoadName( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( UiConst.Column, info.PropertyName );
        }
    }
}
