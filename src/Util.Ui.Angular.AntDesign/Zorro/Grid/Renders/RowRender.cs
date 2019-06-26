using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Zorro.Grid.Builders;

namespace Util.Ui.Zorro.Grid.Renders {
    /// <summary>
    /// 栅格行渲染器
    /// </summary>
    public class RowRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化栅格行渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public RowRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new RowBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigGutter( builder );
            ConfigType( builder );
            ConfigAlign( builder );
            ConfigJustify( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置间隔
        /// </summary>
        private void ConfigGutter( TagBuilder builder ) {
            builder.AddAttribute( "[nzGutter]", _config.GetValue( UiConst.Gutter ) );
        }

        /// <summary>
        /// 配置布局模式
        /// </summary>
        private void ConfigType( TagBuilder builder ) {
            var isFlex = _config.GetValue<bool?>( UiConst.IsFlex );
            if( isFlex == true )
                builder.AddAttribute( "nzType", "flex" );
        }

        /// <summary>
        /// 配置对齐
        /// </summary>
        private void ConfigAlign( TagBuilder builder ) {
            if( _config.Contains( UiConst.Align ) == false )
                return;
            builder.AddAttribute( "nzType", "flex" );
            builder.AddAttribute( "nzAlign", _config.GetValue<Align?>( UiConst.Align )?.Description() );
        }

        /// <summary>
        /// 配置水平排列方式
        /// </summary>
        private void ConfigJustify( TagBuilder builder ) {
            if( _config.Contains( UiConst.Justify ) == false )
                return;
            builder.AddAttribute( "nzType", "flex" );
            builder.AddAttribute( "nzJustify", _config.GetValue<Justify?>( UiConst.Justify )?.Description() );
        }
    }
}