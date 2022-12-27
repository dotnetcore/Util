using Util.Ui.Configs;
using Util.Ui.Expressions;
using Util.Ui.NgZorro.Components.Label.Helpers;

namespace Util.Ui.NgZorro.Components.Descriptions.Helpers {
    /// <summary>
    /// 描述列表项表达式加载器
    /// </summary>
    public class DescriptionItemExpressionLoader : LabelExpressionLoader {
        /// <summary>
        /// 加载模型信息
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="info">模型表达式信息</param>
        protected override void Load( Config config, ModelExpressionInfo info ) {
            LoadTitle( config, info );
            LoadValue( config, info );
        }

        /// <summary>
        /// 加载标题
        /// </summary>
        protected override void LoadTitle( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( UiConst.Title, info.DisplayName, false );
        }
    }
}
