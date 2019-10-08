using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Helpers;
using Util.Ui.Material.Grids.Builders;

namespace Util.Ui.Material.Grids.Renders {
    /// <summary>
    /// 网格渲染器
    /// </summary>
    public class GridRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化网格渲染器
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
            ConfigContent( builder );
            ConfigColumns( builder );
            ConfigRowHeight( builder );
            ConfigGutterSize( builder );
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
            if( _config.Contains( UiConst.RowHeight ) == false )
                return;
            var value = _config.GetValue( UiConst.RowHeight );
            builder.AddAttribute( "rowHeight", CommonHelper.GetPixelValue( value ) );
        }

        /// <summary>
        /// 配置单元格间距
        /// </summary>
        private void ConfigGutterSize( TagBuilder builder ) {
            if( _config.Contains( MaterialConst.GutterSize ) == false )
                return;
            var value = _config.GetValue( MaterialConst.GutterSize );
            builder.AddAttribute( "gutterSize", CommonHelper.GetPixelValue( value ) );
        }
    }
}