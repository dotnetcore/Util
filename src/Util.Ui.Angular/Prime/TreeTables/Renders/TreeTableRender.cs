using Util.Helpers;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.Prime.TreeTables.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Prime.TreeTables.Renders {
    /// <summary>
    /// 树型表格渲染器
    /// </summary>
    public class TreeTableRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化树型表格渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TreeTableRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new PrimeTreeTableBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected virtual void Config( TagBuilder builder ) {
            builder.Class( _config );
            builder.Style( _config );
            ConfigId( builder );
            ConfigQueryParam( builder );
            ConfigUrl( builder );
            ConfigCheckbox( builder );
            ConfigAutoLoad( builder );
            ConfigPageSizeOptions( builder );
            ConfigContent( builder );
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        protected override void ConfigId( TagBuilder builder ) {
            var id = _config.GetValue( UiConst.Id );
            id = id.IsEmpty() ? Id.Guid() : id;
            builder.AddAttribute( $"#{id}" );
            builder.AddAttribute( "key", id );
        }

        /// <summary>
        /// 配置查询参数
        /// </summary>
        private void ConfigQueryParam( TagBuilder builder ) {
            builder.AddAttribute( "[queryParam]", _config.GetValue( UiConst.QueryParam ) );
            builder.AddAttribute( "(onQueryRestore)", _config.GetValue( UiConst.OnQueryRestore ) );
        }

        /// <summary>
        /// 配置地址
        /// </summary>
        private void ConfigUrl( TagBuilder builder ) {
            builder.AddAttribute( "baseUrl", _config.GetValue( UiConst.BaseUrl ) );
            builder.AddAttribute( "url", _config.GetValue( UiConst.Url ) );
            builder.AddAttribute( "deleteUrl", _config.GetValue( UiConst.DeleteUrl ) );
        }

        /// <summary>
        /// 配置复选框
        /// </summary>
        private void ConfigCheckbox( TagBuilder builder ) {
            if( _config.GetValue<bool>( UiConst.Checkbox ) )
                builder.AddAttribute( "selectionMode", "checkbox" );
            if( _config.GetValue<bool>( UiConst.Radio ) )
                builder.AddAttribute( "selectionMode", "single" );
        }

        /// <summary>
        /// 配置自动加载
        /// </summary>
        private void ConfigAutoLoad( TagBuilder builder ) {
            builder.AddAttribute( "[autoLoad]", _config.GetBoolValue( UiConst.AutoLoad ) );
        }

        /// <summary>
        /// 配置分页长度列表
        /// </summary>
        private void ConfigPageSizeOptions( TagBuilder builder ) {
            var value = _config.GetValue( UiConst.PageSizeOptions );
            if( string.IsNullOrWhiteSpace( value ) )
                return;
            if( value.StartsWith( "[" ) == false )
                value = $"[{value}]";
            builder.AddAttribute( "[pageSizeOptions]", value );
        }
    }
}