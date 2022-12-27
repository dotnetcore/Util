using Util.Applications.Trees;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Config = Util.Ui.Configs.Config;

namespace Util.Ui.NgZorro.Components.Trees.Helpers {
    /// <summary>
    /// 树形服务
    /// </summary>
    public class TreeService {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 标识
        /// </summary>
        private string _id;

        /// <summary>
        /// 初始化树形服务
        /// </summary>
        /// <param name="config">配置</param>
        public TreeService( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 扩展标识
        /// </summary>
        public string ExtendId => $"x_{GetId()}";

        /// <summary>
        /// 获取标识
        /// </summary>
        private string GetId() {
            if ( _id.IsEmpty() == false )
                return _id;
            _id = _config.GetValue( UiConst.Id );
            if ( _id.IsEmpty() )
                _id = Id.Create();
            return _id;
        }

        /// <summary>
        /// 是否启用基础扩展
        /// </summary>
        public bool IsEnableExtend() {
            if ( GetEnableExtend() == false ) {
                return false;
            }
            if ( GetEnableExtend() == true || 
                 GetUrl().IsEmpty() == false ||
                 GetBindUrl().IsEmpty() == false ||
                 GetLoadUrl().IsEmpty() == false ||
                 GetBindLoadUrl().IsEmpty() == false ||
                 GetQueryUrl().IsEmpty() == false ||
                 GetBindQueryUrl().IsEmpty() == false ||
                 GetLoadChildrenUrl().IsEmpty() == false ||
                 GetBindLoadChildrenUrl().IsEmpty() == false ) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取启用扩展属性
        /// </summary>
        private bool? GetEnableExtend() {
            return _config.GetValue<bool?>( UiConst.EnableExtend );
        }

        /// <summary>
        /// 获取地址
        /// </summary>
        private string GetUrl() {
            return _config.GetValue( UiConst.Url );
        }

        /// <summary>
        /// 获取地址
        /// </summary>
        private string GetBindUrl() {
            return _config.GetValue( AngularConst.BindUrl );
        }

        /// <summary>
        /// 获取加载地址
        /// </summary>
        private string GetLoadUrl() {
            return _config.GetValue( UiConst.LoadUrl );
        }

        /// <summary>
        /// 获取加载地址
        /// </summary>
        private string GetBindLoadUrl() {
            return _config.GetValue( AngularConst.BindLoadUrl );
        }

        /// <summary>
        /// 获取查询地址
        /// </summary>
        private string GetQueryUrl() {
            return _config.GetValue( UiConst.QueryUrl );
        }

        /// <summary>
        /// 获取查询地址
        /// </summary>
        private string GetBindQueryUrl() {
            return _config.GetValue( AngularConst.BindQueryUrl );
        }

        /// <summary>
        /// 获取加载下级节点地址
        /// </summary>
        private string GetLoadChildrenUrl() {
            return _config.GetValue( UiConst.LoadChildrenUrl );
        }

        /// <summary>
        /// 获取加载下级节点地址
        /// </summary>
        private string GetBindLoadChildrenUrl() {
            return _config.GetValue( AngularConst.BindLoadChildrenUrl );
        }

        /// <summary>
        /// 配置标签生成器
        /// </summary>
        /// <param name="builder">标签生成器</param>
        public void ConfigBuilder( TagBuilder builder ) {
            Url( builder );
            LoadUrl( builder );
            QueryUrl( builder );
            LoadChildrenUrl( builder );
            AutoLoad( builder );
            QueryParam( builder );
            Sort( builder );
            ExpandForRootAsync( builder );
            LoadMode( builder );
            Events( builder );
            ConfigExtend( builder );
        }

        /// <summary>
        /// 配置Api地址
        /// </summary>
        private void Url( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "url", _config.GetValue( UiConst.Url ) );
            builder.AttributeIfNotEmpty( "[url]", _config.GetValue( AngularConst.BindUrl ) );
        }

        /// <summary>
        /// 配置加载地址
        /// </summary>
        private void LoadUrl( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "loadUrl", _config.GetValue( UiConst.LoadUrl ) );
            builder.AttributeIfNotEmpty( "[loadUrl]", _config.GetValue( AngularConst.BindLoadUrl ) );
        }

        /// <summary>
        /// 配置查询地址
        /// </summary>
        private void QueryUrl( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "queryUrl", _config.GetValue( UiConst.QueryUrl ) );
            builder.AttributeIfNotEmpty( "[queryUrl]", _config.GetValue( AngularConst.BindQueryUrl ) );
        }

        /// <summary>
        /// 配置加载子节点地址
        /// </summary>
        private void LoadChildrenUrl( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "loadChildrenUrl", _config.GetValue( UiConst.LoadChildrenUrl ) );
            builder.AttributeIfNotEmpty( "[loadChildrenUrl]", _config.GetValue( AngularConst.BindLoadChildrenUrl ) );
        }

        /// <summary>
        /// 配置自动加载
        /// </summary>
        private void AutoLoad( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[autoLoad]", _config.GetBoolValue( UiConst.AutoLoad ) );
        }

        /// <summary>
        /// 配置查询参数
        /// </summary>
        private void QueryParam( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[(queryParam)]", _config.GetValue( UiConst.QueryParam ) );
        }

        /// <summary>
        /// 配置排序条件
        /// </summary>
        private void Sort( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "order", _config.GetValue( UiConst.Sort ) );
            builder.AttributeIfNotEmpty( "[order]", _config.GetValue( AngularConst.BindSort ) );
        }

        /// <summary>
        /// 配置根节点异步加载模式是否展开子节点
        /// </summary>
        private void ExpandForRootAsync( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[isExpandForRootAsync]", _config.GetBoolValue( UiConst.ExpandForRootAsync ) );
        }

        /// <summary>
        /// 配置加载模式
        /// </summary>
        private void LoadMode( TagBuilder builder ) {
            var value = _config.GetValue<LoadMode?>( UiConst.LoadMode );
            if ( value == null )
                return;
            builder.AttributeIfNotEmpty( "loadMode", value.Value().SafeString() );
            if ( value == Applications.Trees.LoadMode.Sync )
                return;
            builder.AttributeIfNotEmpty( "[nzAsyncData]", "true" );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void Events( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[onLoadChildrenBefore]", _config.GetValue( UiConst.OnLoadChildrenBefore ) );
            builder.AttributeIfNotEmpty( "(onLoadChildren)", _config.GetValue( UiConst.OnLoadChildren ) );
            builder.AttributeIfNotEmpty( "(onExpand)", _config.GetValue( UiConst.OnExpand ) );
            builder.AttributeIfNotEmpty( "(onCollapse)", _config.GetValue( UiConst.OnCollapse ) );
        }

        /// <summary>
        /// 配置树形扩展指令及默认属性
        /// </summary>
        public void ConfigExtend( TagBuilder builder ) {
            if ( IsEnableExtend() == false )
                return;
            builder.Attribute( "x-tree-extend" );
            builder.Attribute( $"#{ExtendId}", "xTreeExtend" );
        }
    }
}
