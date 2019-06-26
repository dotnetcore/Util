using Util.Helpers;
using Util.Ui.Angular.Base;
using Util.Ui.Angular.Builders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Dividers.Builders;

namespace Util.Ui.Zorro.Dividers.Renders {
    /// <summary>
    /// 分隔线渲染器
    /// </summary>
    public class DividerRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化分隔线渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public DividerRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new DividerBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigDashed( builder );
            ConfigVertical( builder );
            ConfigText( builder );
            ConfigOrientation( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置垂直方向
        /// </summary>
        private void ConfigDashed( TagBuilder builder ) {
            builder.AddAttribute( "[nzDashed]", _config.GetBoolValue( UiConst.Dashed ) );
        }

        /// <summary>
        /// 配置垂直方向
        /// </summary>
        private void ConfigVertical( TagBuilder builder ) {
            if( _config.GetValue<bool?>( UiConst.Vertical ) == true )
                builder.AddAttribute( "nzType", "vertical" );
        }

        /// <summary>
        /// 配置文字
        /// </summary>
        private void ConfigText( TagBuilder builder ) {
            if( _config.Content.IsEmpty() )
                builder.AddAttribute( "nzText", _config.GetValue( UiConst.Text ) );
        }

        /// <summary>
        /// 配置文字方向
        /// </summary>
        private void ConfigOrientation( TagBuilder builder ) {
            builder.AddAttribute( "nzOrientation", _config.GetValue<Orientation?>( UiConst.Orientation )?.Description() );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent( TagBuilder builder ) {
            if( _config.Content.IsEmpty() )
                return;
            var id = $"m_{Id.Guid()}";
            builder.AddAttribute( "[nzText]", id );
            var templateBuilder = new TemplateBuilder();
            templateBuilder.AddAttribute( $"#{id}" );
            templateBuilder.AppendContent( _config.Content );
            builder.AppendContent( templateBuilder );
        }
    }
}