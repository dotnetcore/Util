using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Tabs.Builders;

namespace Util.Ui.Material.Tabs.Renders {
    /// <summary>
    /// 选项卡组渲染器
    /// </summary>
    public class TabGroupRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化选项卡组渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TabGroupRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TabGroupBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigContent( builder );
            ConfigColor( builder );
            ConfigHeight( builder );
            ConfigStretch( builder );
            ConfigSelectedIndex( builder );
            ConfigHeaderPosition( builder );
        }

        /// <summary>
        /// 配置颜色
        /// </summary>
        private void ConfigColor( TagBuilder builder ) {
            builder.AddAttribute( "backgroundColor", _config.GetValue( UiConst.BackgroundColor )?.ToLower() );
            builder.AddAttribute( "color", _config.GetValue( UiConst.Color )?.ToLower() );
        }

        /// <summary>
        /// 配置高度
        /// </summary>
        private void ConfigHeight( TagBuilder builder ) {
            if( _config.Contains( UiConst.Height ) )
                builder.AddAttribute( "style", $"height:{_config.GetValue( UiConst.Height )}px" );
            if ( _config.GetValue<bool>( MaterialConst.DynamicHeight ) )
                builder.AddAttribute( "dynamicHeight" );
        }

        /// <summary>
        /// 配置拉伸选项卡
        /// </summary>
        private void ConfigStretch( TagBuilder builder ) {
            if ( _config.GetValue<bool>( UiConst.Stretch ) )
                builder.AddAttribute( "mat-stretch-tabs" );
        }

        /// <summary>
        /// 配置选中索引
        /// </summary>
        private void ConfigSelectedIndex( TagBuilder builder ) {
            builder.AddAttribute( "[(selectedIndex)]", _config.GetValue( UiConst.SelectedIndex ) );
        }

        /// <summary>
        /// 配置标题位置
        /// </summary>
        private void ConfigHeaderPosition( TagBuilder builder ) {
            builder.AddAttribute( "headerPosition", _config.GetValue<YPosition?>( MaterialConst.HeaderPosition )?.Description() );
        }
    }
}