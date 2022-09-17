using Util.Ui.Angular.Extensions;
using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms.Builders;

namespace Util.Ui.NgZorro.Components.Forms.Renders {
    /// <summary>
    /// 表单渲染器
    /// </summary>
    public class FormRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表单渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public FormRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new FormBuilder( _config );
            builder.Config();
            ConfigContent( builder );
            return builder;
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        protected override void ConfigId( TagBuilder builder ) {
            builder.RawId( _config );
            if( _config.Contains( UiConst.Id ) )
                builder.Attribute( $"#{_config.GetValue( UiConst.Id )}", "ngForm" );
        }
    }
}
