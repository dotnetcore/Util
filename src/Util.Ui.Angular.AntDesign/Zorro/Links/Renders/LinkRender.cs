﻿using Util.Ui.Angular;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Extensions;
using Util.Ui.Zorro.Icons.Builders;

namespace Util.Ui.Zorro.Links.Renders {
    /// <summary>
    /// 链接渲染器
    /// </summary>
    public class LinkRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化链接渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public LinkRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new AnchorBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigButton( builder );
            ConfigStyle( builder );
            ConfigIcon( builder );
            ConfigText( builder );
            ConfigTooltip( builder );
            ConfigLink( builder );
            ConfigEvents( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置按钮
        /// </summary>
        private void ConfigButton( TagBuilder builder ) {
            var isButton = _config.GetValue<bool?>( UiConst.IsButton );
            if( isButton == true || _config.Contains( UiConst.Color ) || _config.Contains( UiConst.Size )
                || _config.Contains( UiConst.Shape ) || _config.Contains( UiConst.Block ) || _config.Contains( UiConst.Ghost ) )
                builder.AddAttribute( "nz-button" );
        }

        /// <summary>
        /// 配置样式
        /// </summary>
        private void ConfigStyle( TagBuilder builder ) {
            builder.AddAttribute( "nzType", _config.GetValue<Color?>( UiConst.Color )?.Description() );
            builder.AddAttribute( "nzSize", _config.GetValue<ButtonSize?>( UiConst.Size )?.Description() );
            builder.AddAttribute( "nzShape", _config.GetValue<ButtonShape?>( UiConst.Shape )?.Description() );
            builder.AddAttribute( "[nzBlock]", _config.GetBoolValue( UiConst.Block ) );
            builder.AddAttribute( "[nzGhost]", _config.GetBoolValue( UiConst.Ghost ) );
        }

        /// <summary>
        /// 配置图标
        /// </summary>
        private void ConfigIcon( TagBuilder builder ) {
            if( _config.Contains( UiConst.Icon ) == false )
                return;
            var iconBuilder = new IconBuilder();
            iconBuilder.AddType( _config.GetValue<AntDesignIcon?>( UiConst.Icon )?.Description() );
            builder.AppendContent( iconBuilder );
        }

        /// <summary>
        /// 配置文本
        /// </summary>
        private void ConfigText( TagBuilder builder ) {
            if( _config.Contains( UiConst.Text ) )
                builder.AppendContent( _config.GetValue( UiConst.Text ) );
            if( _config.Contains( AngularConst.BindText ) )
                builder.AppendContent( $"{{{{{_config.GetValue( AngularConst.BindText )}}}}}" );
        }

        /// <summary>
        /// 配置提示
        /// </summary>
        private void ConfigTooltip( TagBuilder builder ) {
            if ( _config.Contains( UiConst.Tooltip ) == false )
                return;
            builder.AddAttribute( "nz-tooltip" );
            builder.AddAttribute( "nzTitle", _config.GetValue( UiConst.Tooltip ) );
        }

        /// <summary>
        /// 配置链接
        /// </summary>
        private void ConfigLink( TagBuilder builder ) {
            builder.Link( _config );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(click)", _config.GetValue( UiConst.OnClick ) );
        }
    }
}