using Util.Ui.Configs;
using Util.Ui.Expressions;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Expressions;

namespace Util.Ui.NgZorro.Components.Display.Helpers {
    /// <summary>
    /// 数据项展示表达式加载器
    /// </summary>
    public class DisplayExpressionLoader : NgZorroExpressionLoaderBase {
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
        protected void LoadTitle( Config config, ModelExpressionInfo info ) {
            if ( IsEnabledFormLabel( config ) ) {
                config.SetAttribute( UiConst.LabelText, info.DisplayName, false );
                return;
            }
            config.SetAttribute( UiConst.Title, info.DisplayName, false );
        }

        /// <summary>
        /// 是否启用表单标签
        /// </summary>
        private bool IsEnabledFormLabel( Config config ) {
            if ( config.GetValueFromItems<FormShareConfig>() != null && config.GetValue<bool?>( UiConst.ShowLabel ) == true )
                return true;
            return false;
        }
        

        /// <summary>
        /// 加载值
        /// </summary>
        protected virtual void LoadValue( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( UiConst.Value, info.SafePropertyName, false );
            if ( info.IsBool ) {
                config.SetAttribute( UiConst.DataType, DataType.Bool );
                return;
            }
            if ( info.IsDate ) {
                config.SetAttribute( UiConst.DataType, DataType.Date );
                return;
            }
        }
    }
}
