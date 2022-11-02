using Util.Ui.Configs;

namespace Util.Ui.Expressions {
    /// <summary>
    /// 表达式加载器
    /// </summary>
    public class ExpressionLoader : ExpressionLoaderBase {
        /// <summary>
        /// 加载模型信息
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="info">模型表达式信息</param>
        protected override void Load( Config config, ModelExpressionInfo info ) {
            LoadName( config, info );
            LoadDisplayName( config, info );
            LoadRequired( config, info );
        }

        /// <summary>
        /// 加载属性名
        /// </summary>
        protected virtual void LoadName( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( UiConst.Name, info.PropertyName );
        }

        /// <summary>
        /// 加载显示名称
        /// </summary>
        protected virtual void LoadDisplayName( Config config, ModelExpressionInfo info ) {
            config.SetAttribute( UiConst.Title, info.DisplayName );
        }

        /// <summary>
        /// 加载必填项验证
        /// </summary>
        protected virtual void LoadRequired( Config config, ModelExpressionInfo info ) {
            if ( info.IsRequired == false )
                return;
            config.SetAttribute( UiConst.Required, "true", false );
            config.SetAttribute( UiConst.RequiredMessage, info.RequiredMessage, false );
        }
    }
}
