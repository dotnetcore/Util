using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Trees.Helpers;

namespace Util.Ui.NgZorro.Components.Trees.Builders {
    /// <summary>
    /// 树形控件标签生成器
    /// </summary>
    public class TreeBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 树形服务
        /// </summary>
        private readonly TreeService _service;

        /// <summary>
        /// 初始化树形控件标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TreeBuilder( Config config ) : base( config, "nz-tree" ) {
            _config = config;
            _service = new TreeService( _config );
        }

        /// <summary>
        /// 扩展标识
        /// </summary>
        private string ExtendId => _service.ExtendId;

        /// <summary>
        /// 配置数据
        /// </summary>
        public TreeBuilder Data() {
            return Data( _config.GetValue( UiConst.Data ) );
        }

        /// <summary>
        /// 配置数据
        /// </summary>
        public TreeBuilder Data( string data ) {
            AttributeIfNotEmpty( "[nzData]", data );
            return this;
        }

        /// <summary>
        /// 配置是否节点占一行
        /// </summary>
        public TreeBuilder BlockNode() {
            AttributeIfNotEmpty( "[nzBlockNode]", _config.GetBoolValue( UiConst.BlockNode ) );
            AttributeIfNotEmpty( "[nzBlockNode]", _config.GetValue( AngularConst.BindBlockNode ) );
            return this;
        }

        /// <summary>
        /// 配置节点前是否显示复选框
        /// </summary>
        public TreeBuilder Checkable() {
            Checkable( _config.GetBoolValue( UiConst.Checkable ) );
            AttributeIfNotEmpty( "[nzCheckable]", _config.GetValue( AngularConst.BindCheckable ) );
            return this;
        }

        /// <summary>
        /// 配置节点前是否显示复选框
        /// </summary>
        public TreeBuilder Checkable( string value ) {
            AttributeIfNotEmpty( "[nzCheckable]", value );
            return this;
        }

        /// <summary>
        /// 配置节点前是否显示展开图标
        /// </summary>
        public TreeBuilder ShowExpand() {
            AttributeIfNotEmpty( "[nzShowExpand]", _config.GetBoolValue( UiConst.ShowExpand ) );
            AttributeIfNotEmpty( "[nzShowExpand]", _config.GetValue( AngularConst.BindShowExpand ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示连接线
        /// </summary>
        public TreeBuilder ShowLine() {
            AttributeIfNotEmpty( "[nzShowLine]", _config.GetBoolValue( UiConst.ShowLine ) );
            AttributeIfNotEmpty( "[nzShowLine]", _config.GetValue( AngularConst.BindShowLine ) );
            return this;
        }

        /// <summary>
        /// 配置自定义展开图标
        /// </summary>
        public TreeBuilder ExpandedIcon() {
            AttributeIfNotEmpty( "[nzExpandedIcon]", _config.GetValue( UiConst.ExpandedIcon ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示节点文本前图标
        /// </summary>
        public TreeBuilder ShowIcon() {
            AttributeIfNotEmpty( "[nzShowIcon]", _config.GetBoolValue( UiConst.ShowIcon ) );
            AttributeIfNotEmpty( "[nzShowIcon]", _config.GetValue( AngularConst.BindShowIcon ) );
            return this;
        }

        /// <summary>
        /// 配置是否异步加载
        /// </summary>
        public TreeBuilder AsyncData() {
            AsyncData( _config.GetBoolValue( UiConst.AsyncData ) );
            AsyncData( _config.GetValue( AngularConst.BindAsyncData ) );
            return this;
        }

        /// <summary>
        /// 配置是否异步加载
        /// </summary>
        public TreeBuilder AsyncData( string value ) {
            AttributeIfNotEmpty( "[nzAsyncData]", value );
            return this;
        }

        /// <summary>
        /// 配置节点是否可拖拽
        /// </summary>
        public TreeBuilder Draggable() {
            AttributeIfNotEmpty( "[nzDraggable]", _config.GetBoolValue( UiConst.Draggable ) );
            AttributeIfNotEmpty( "[nzDraggable]", _config.GetValue( AngularConst.BindDraggable ) );
            return this;
        }

        /// <summary>
        /// 配置是否支持点选多个节点
        /// </summary>
        public TreeBuilder Multiple() {
            AttributeIfNotEmpty( "[nzMultiple]", _config.GetBoolValue( UiConst.Multiple ) );
            AttributeIfNotEmpty( "[nzMultiple]", _config.GetValue( AngularConst.BindMultiple ) );
            return this;
        }

        /// <summary>
        /// 配置是否隐藏未匹配节点
        /// </summary>
        public TreeBuilder HideUnMatched() {
            AttributeIfNotEmpty( "[nzHideUnMatched]", _config.GetBoolValue( UiConst.HideUnmatched ) );
            AttributeIfNotEmpty( "[nzHideUnMatched]", _config.GetValue( AngularConst.BindHideUnmatched ) );
            return this;
        }

        /// <summary>
        /// 配置严格勾选
        /// </summary>
        public TreeBuilder CheckStrictly() {
            AttributeIfNotEmpty( "[nzCheckStrictly]", _config.GetBoolValue( UiConst.CheckStrictly ) );
            AttributeIfNotEmpty( "[nzCheckStrictly]", _config.GetValue( AngularConst.BindCheckStrictly ) );
            return this;
        }

        /// <summary>
        /// 配置自定义节点模板
        /// </summary>
        public TreeBuilder TreeTemplate() {
            AttributeIfNotEmpty( "[nzTreeTemplate]", _config.GetValue( UiConst.TreeTemplate ) );
            return this;
        }

        /// <summary>
        /// 配置是否默认展开所有节点
        /// </summary>
        public TreeBuilder ExpandAll() {
            AttributeIfNotEmpty( "[nzExpandAll]", _config.GetBoolValue( UiConst.ExpandAll ) );
            AttributeIfNotEmpty( "[nzExpandAll]", _config.GetValue( AngularConst.BindExpandAll ) );
            return this;
        }

        /// <summary>
        /// 配置展开节点的键集合
        /// </summary>
        public TreeBuilder ExpandedKeys() {
            ExpandedKeys( _config.GetValue( UiConst.ExpandedKeys ) );
            return this;
        }

        /// <summary>
        /// 配置展开节点的键集合
        /// </summary>
        /// <param name="keys">键集合</param>
        public TreeBuilder ExpandedKeys( string keys ) {
            AttributeIfNotEmpty( "[nzExpandedKeys]", keys );
            return this;
        }

        /// <summary>
        /// 配置勾选节点复选框的键集合
        /// </summary>
        public TreeBuilder CheckedKeys() {
            CheckedKeys( _config.GetValue( UiConst.CheckedKeys ) );
            return this;
        }

        /// <summary>
        /// 配置勾选节点复选框的键集合
        /// </summary>
        /// <param name="keys">键集合</param>
        public TreeBuilder CheckedKeys( string keys ) {
            AttributeIfNotEmpty( "[nzCheckedKeys]", keys );
            return this;
        }

        /// <summary>
        /// 配置选中节点的键集合
        /// </summary>
        public TreeBuilder SelectedKeys() {
            SelectedKeys( _config.GetValue( UiConst.SelectedKeys ) );
            return this;
        }

        /// <summary>
        /// 配置选中节点的键集合
        /// </summary>
        /// <param name="keys">键集合</param>
        public TreeBuilder SelectedKeys( string keys ) {
            AttributeIfNotEmpty( "[nzSelectedKeys]", keys );
            return this;
        }

        /// <summary>
        /// 配置搜索值
        /// </summary>
        public TreeBuilder SearchValue() {
            AttributeIfNotEmpty( "nzSearchValue", _config.GetValue( UiConst.SearchValue ) );
            AttributeIfNotEmpty( "[nzSearchValue]", _config.GetValue( AngularConst.BindSearchValue ) );
            AttributeIfNotEmpty( "[(nzSearchValue)]", _config.GetValue( AngularConst.BindonSearchValue ) );
            return this;
        }

        /// <summary>
        /// 配置自定义搜索方法
        /// </summary>
        public TreeBuilder SearchFunc() {
            AttributeIfNotEmpty( "[nzSearchFunc]", _config.GetValue( UiConst.SearchFunc ) );
            return this;
        }

        /// <summary>
        /// 配置拖拽前函数
        /// </summary>
        public TreeBuilder BeforeDrop() {
            AttributeIfNotEmpty( "[nzBeforeDrop]", _config.GetValue( UiConst.BeforeDrop ) );
            return this;
        }

        /// <summary>
        /// 配置虚拟高度
        /// </summary>
        public TreeBuilder VirtualHeight() {
            AttributeIfNotEmpty( "nzVirtualHeight", _config.GetValue( UiConst.VirtualHeight ) );
            AttributeIfNotEmpty( "[nzVirtualHeight]", _config.GetValue( AngularConst.BindVirtualHeight ) );
            return this;
        }

        /// <summary>
        /// 配置虚拟滚动列高
        /// </summary>
        public TreeBuilder VirtualItemSize() {
            AttributeIfNotEmpty( "nzVirtualItemSize", _config.GetValue( UiConst.VirtualItemSize ) );
            AttributeIfNotEmpty( "[nzVirtualItemSize]", _config.GetValue( AngularConst.BindVirtualItemSize ) );
            return this;
        }

        /// <summary>
        /// 配置虚拟滚动缓冲区最大高度
        /// </summary>
        public TreeBuilder VirtualMaxBufferPx() {
            AttributeIfNotEmpty( "nzVirtualMaxBufferPx", _config.GetValue( UiConst.VirtualMaxBufferPx ) );
            AttributeIfNotEmpty( "[nzVirtualMaxBufferPx]", _config.GetValue( AngularConst.BindVirtualMaxBufferPx ) );
            return this;
        }

        /// <summary>
        /// 配置虚拟滚动缓冲区最小高度
        /// </summary>
        public TreeBuilder VirtualMinBufferPx() {
            AttributeIfNotEmpty( "nzVirtualMinBufferPx", _config.GetValue( UiConst.VirtualMinBufferPx ) );
            AttributeIfNotEmpty( "[nzVirtualMinBufferPx]", _config.GetValue( AngularConst.BindVirtualMinBufferPx ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public TreeBuilder Events() {
            AttributeIfNotEmpty( "(nzClick)", _config.GetValue( UiConst.OnClick ) );
            AttributeIfNotEmpty( "(nzDblClick)", _config.GetValue( UiConst.OnDblClick ) );
            AttributeIfNotEmpty( "(nzContextMenu)", _config.GetValue( UiConst.OnContextmenu ) );
            AttributeIfNotEmpty( "(nzCheckBoxChange)", _config.GetValue( UiConst.OnCheckBoxChange ) );
            OnExpandChange( _config.GetValue( UiConst.OnExpandChange ) );
            AttributeIfNotEmpty( "(nzSearchValueChange)", _config.GetValue( UiConst.OnSearchValueChange ) );
            AttributeIfNotEmpty( "(nzOnDragStart)", _config.GetValue( UiConst.OnDragStart ) );
            AttributeIfNotEmpty( "(nzOnDragEnter)", _config.GetValue( UiConst.OnDragEnter ) );
            AttributeIfNotEmpty( "(nzOnDragOver)", _config.GetValue( UiConst.OnDragOver ) );
            AttributeIfNotEmpty( "(nzOnDragLeave)", _config.GetValue( UiConst.OnDragLeave ) );
            AttributeIfNotEmpty( "(nzOnDrop)", _config.GetValue( UiConst.OnDrop ) );
            AttributeIfNotEmpty( "(nzOnDragEnd)", _config.GetValue( UiConst.OnDragEnd ) );
            return this;
        }

        /// <summary>
        /// 展开收缩节点事件
        /// </summary>
        public TreeBuilder OnExpandChange( string value ) {
            AttributeIfNotEmpty( "(nzExpandChange)", value );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Data().BlockNode().Checkable().ShowExpand().ShowLine().ExpandedIcon().ShowIcon()
                .AsyncData().Draggable().Multiple().HideUnMatched().CheckStrictly().TreeTemplate().ExpandAll()
                .ExpandedKeys().CheckedKeys().SelectedKeys()
                .SearchValue().SearchFunc().BeforeDrop()
                .VirtualHeight().VirtualItemSize().VirtualMaxBufferPx().VirtualMinBufferPx()
                .Events();
            _service.ConfigBuilder( this );
            ConfigDefault();
        }

        /// <summary>
        /// 配置默认属性
        /// </summary>
        private void ConfigDefault() {
            if ( _service.IsEnableExtend() == false )
                return;
            Checkable( "true" ).
                Data( $"{ExtendId}.dataSource" )
                .CheckedKeys( $"{ExtendId}.checkedKeys" )
                .SelectedKeys( $"{ExtendId}.selectedKeys" )
                .OnExpandChange( $"{ExtendId}.expandChange($event)" );
        }
    }
}