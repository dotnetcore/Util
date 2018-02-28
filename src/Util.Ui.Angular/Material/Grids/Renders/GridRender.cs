using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Commons.Configs;
using Util.Ui.Material.Grids.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Grids.Renders {
    /// <summary>
    /// 栅格渲染器
    /// </summary>
    public class GridRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化栅格渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public GridRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new GridBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigColumns( builder );
            ConfigRowHeight( builder );
            ConfigGutterSize( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置列数
        /// </summary>
        private void ConfigColumns( TagBuilder builder ) {
            builder.AddAttribute( "cols", _config.GetValue( UiConst.Columns ) );
        }

        /// <summary>
        /// 配置行高
        /// </summary>
        private void ConfigRowHeight( TagBuilder builder ) {
            if ( _config.Contains( UiConst.RowHeight ) == false )
                return;
            var value = _config.GetValue( UiConst.RowHeight );
            if ( Util.Helpers.Validation.IsNumber( value ) )
                value = $"{value}px";
            builder.AddAttribute( "rowHeight", value );
        }

        /// <summary>
        /// 配置单元格间距
        /// </summary>
        private void ConfigGutterSize( TagBuilder builder ) {
            if( _config.Contains( MaterialConst.GutterSize ) == false )
                return;
            var value = _config.GetValue( MaterialConst.GutterSize );
            if( Util.Helpers.Validation.IsNumber( value ) )
                value = $"{value}px";
            builder.AddAttribute( "gutterSize", value );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        private void ConfigContent( TagBuilder builder ) {
            if( _config.Content == null )
                return;
            builder.SetContent( _config.Content );
        }
    }
}