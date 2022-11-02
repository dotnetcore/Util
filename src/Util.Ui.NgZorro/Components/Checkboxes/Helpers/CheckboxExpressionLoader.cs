using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.Expressions;
using Util.Ui.NgZorro.Expressions;

namespace Util.Ui.NgZorro.Components.Checkboxes.Helpers {
    /// <summary>
    /// 复选框表达式加载器
    /// </summary>
    public class CheckboxExpressionLoader : NgZorroExpressionLoaderBase {
        /// <summary>
        /// 加载模型信息
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="info">模型表达式信息</param>
        protected override void Load( Config config, ModelExpressionInfo info ) {
            LoadLabel( config, info );
            LoadName( config, info );
            LoadNgModel( config, info );
        }

        /// <summary>
        /// 加载标签
        /// </summary>
        protected virtual void LoadLabel( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( UiConst.LabelText, info.DisplayName, false );
        }

        /// <summary>
        /// 加载名称
        /// </summary>
        protected virtual void LoadName( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( UiConst.Name, info.LastPropertyName, false );
        }

        /// <summary>
        /// 加载模型绑定
        /// </summary>
        protected virtual void LoadNgModel( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( AngularConst.NgModel, info.SafePropertyName, false );
        }
    }
}
