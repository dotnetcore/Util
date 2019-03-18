using Util.Helpers;
using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Prime.TreeTables.Builders;

namespace Util.Ui.Prime.TreeTables.Renders {
    /// <summary>
    /// 树型表格渲染器
    /// </summary>
    public class TreeTableRender : AngularRenderBase {
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
            ConfigId( builder );
            ConfigQueryParam( builder );
            ConfigUrl( builder );
            ConfigSelectionMode( builder );
            ConfigSelection( builder );
            ConfigAutoLoad( builder );
            ConfigPageSizeOptions( builder );
            ConfigContent( builder );
            ConfigEvents( builder );
        }

        /// <summary>
        /// 配置标识
        /// </summary>
        protected override void ConfigId( TagBuilder builder ) {
            var id = _config.GetValue( UiConst.Id );
            id = id.IsEmpty() ? Id.Guid() : id;
            builder.AddAttribute( $"#{id}" );
            builder.AddAttribute( "key", _config.GetValue( UiConst.Key ) );
        }

        /// <summary>
        /// 配置查询参数
        /// </summary>
        private void ConfigQueryParam( TagBuilder builder ) {
            builder.AddAttribute( "[(queryParam)]", _config.GetValue( UiConst.QueryParam ) );
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
        /// 配置选择模式
        /// </summary>
        private void ConfigSelectionMode( TagBuilder builder ) {
            var mode = _config.GetValue<SelectionMode?>( UiConst.SelectionMode );
            switch ( mode ) {
                case SelectionMode.Multiple:
                    builder.AddAttribute( "selectionMode", "checkbox" );
                    return;
                case SelectionMode.Single:
                    builder.AddAttribute( "selectionMode", "single" );
                    return;
                case SelectionMode.SingleLeafOnly:
                    builder.AddAttribute( "selectionMode", "single" );
                    builder.AddAttribute( "[leafOnly]", "true" );
                    return;
            }
        }

        /// <summary>
        /// 配置选中节点
        /// </summary>
        private void ConfigSelection( TagBuilder builder ) {
            builder.AddAttribute( "[(selection)]", _config.GetValue( UiConst.Selection ) );
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

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AddAttribute( "(onLoad)", _config.GetValue( UiConst.OnLoad ) );
            builder.AddAttribute( "(onCheck)", _config.GetValue( UiConst.OnCheck ) );
            builder.AddAttribute( "(onClickRow)", _config.GetValue( UiConst.OnClickRow ) );
            builder.AddAttribute( "[checkOnClickRow]", _config.GetBoolValue( UiConst.CheckOnClickRow ) );
        }
    }
}