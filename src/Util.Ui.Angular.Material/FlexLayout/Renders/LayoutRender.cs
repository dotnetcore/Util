using System.Linq;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.FlexLayout.Enums;

namespace Util.Ui.FlexLayout.Renders {
    /// <summary>
    /// 浮动布局渲染器
    /// </summary>
    public class LayoutRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化浮动布局渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public LayoutRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new DivBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigDirection( builder );
            ConfigAlign( builder );
            ConfigGap( builder );
            ConfigFlex( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置方向
        /// </summary>
        private void ConfigDirection( TagBuilder builder ) {
            if ( _config.GetValue<bool>( UiConst.Wrap ) ) {
                builder.AddAttribute( "fxLayout", "row wrap" );
                return;
            }
            if( _config.AllAttributes.Any( t => t.Name.StartsWith( UiConst.Direction ) ) == false ) {
                builder.AddAttribute( "fxLayout", "row" );
                return;
            }
            builder.AddAttribute( "fxLayout", _config.GetValue<LayoutDirection?>( UiConst.Direction )?.Description() );
            Util.Helpers.Enum.GetItems<BreakpointAlias>().ForEach( 
                t => builder.AddAttribute( $"fxLayout.{t.Text}", _config.GetValue<LayoutDirection?>( $"{UiConst.Direction}-{t.Text}" )?.Description() )
            );
        }

        /// <summary>
        /// 配置对齐方式
        /// </summary>
        private void ConfigAlign( TagBuilder builder ) {
            if ( _config.Contains( UiConst.XAlign ) == false && _config.Contains( UiConst.YAlign ) == false )
                return;
            var xAlign = _config.GetValue<XAlign?>( UiConst.XAlign )?.Description();
            var yAlign = _config.GetValue<YAlign?>( UiConst.YAlign )?.Description();
            if( string.IsNullOrWhiteSpace( xAlign ) )
                xAlign = XAlign.Start.Description();
            if( string.IsNullOrWhiteSpace( yAlign ) )
                yAlign = YAlign.Start.Description();
            builder.AddAttribute( "fxLayoutAlign", $"{xAlign} {yAlign}" );
        }

        /// <summary>
        /// 配置间隙
        /// </summary>
        private void ConfigGap( TagBuilder builder ) {
            var value = _config.GetValue( UiConst.Gap );
            if ( Util.Helpers.Validation.IsNumber( value ) )
                value = $"{value}px";
            builder.AddAttribute( "fxLayoutGap", value );
        }

        /// <summary>
        /// 配置布局策略
        /// </summary>
        private void ConfigFlex( TagBuilder builder ) {
            if ( _config.Contains( UiConst.Flex ) == false )
                return;
            var itemBuilder = new DivBuilder();
            itemBuilder.AddAttribute( "fxFlex", _config.GetValue( UiConst.Flex ) );
            itemBuilder.AppendContent( _config.Content );
            builder.AppendContent( itemBuilder );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent( TagBuilder builder ) {
            if( _config.Contains( UiConst.Flex ) )
                return;
            base.ConfigContent( builder );
        }
    }
}