//=============== 树形表格查询基类================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { Injector, ViewChild, Input, forwardRef, OnInit } from '@angular/core';
import { MessageConfig } from '../config/message-config';
import { util, TreeViewModel, TreeQueryParameter, TreeTable, PagerList } from '../index';

/**
 * 树形表格查询基类
 */
export abstract class TreeTableQueryComponentBase<TViewModel extends TreeViewModel, TQuery extends TreeQueryParameter> implements OnInit {
    /**
     * 操作库
     */
    protected util = util;
    /**
     * 查询参数
     */
    queryParam: TQuery;
    /**
     * 复选框选中的标识列表
     */
    checkedIds;
    /**
     * 传入弹出框的数据
     */
    @Input() data;
    /**
     * 树形表格组件
     */
    @ViewChild( forwardRef( () => TreeTable ) ) protected table: TreeTable<TViewModel>;

    /**
     * 初始化树形表格查询基类
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        util.ioc.componentInjector = injector;
        this.queryParam = this.createQuery();
    }

    /**
     * 创建查询参数
     */
    protected createQuery(): TQuery {
        return <TQuery>{};
    }

    /**
     * 初始化
     */
    ngOnInit() {
        this.queryParam = this.createQuery();
        this.loadChecked();
    }

    /**
     * 还原勾选的复选框
     */
    protected loadChecked() {
        let selection = this.getSelection();
        this.checkedIds = util.helper.getIds( selection );
    }

    /**
     * 获取选中项标识列表
     */
    protected getSelection() {
        return this.data;
    }

    /**
     * 查询
     * @param button 按钮
     * @param handler 查询成功回调函数
     */
    query( button?, handler?: ( data: PagerList<TViewModel> ) => void ) {
        handler = handler || this.queryAfter;
        this.table.query( {
            button: button,
            handler: handler
        } );
    }

    /**
     * 查询完成后操作
     */
    protected queryAfter = ( data: PagerList<TViewModel> ) => {
    }

    /**
     * 延迟搜索
     */
    search() {
        //this.table.search( this.getDelay() );
    }

    /**
     * 获取查询延迟间隔，单位：毫秒，默认500
     */
    protected getDelay() {
        return 500;
    }

    /**
     * 删除
     * @param id 标识
     * @param button 按钮
     */
    delete( id?, button?) {
        //id = this.table.getId( id );
        //this.table.delete( id, null, null, button );
    }

    /**
     * 刷新
     * @param button 按钮
     * @param handler 刷新后回调函数
     */
    refresh( button?, handler?: ( data: PagerList<TViewModel> ) => void ) {
        handler = handler || this.refreshAfter;
        this.queryParam = this.createQuery();
        this.table.refresh( this.queryParam, button, handler );
    }

    /**
     * 刷新完成后操作
     */
    protected refreshAfter = ( data: PagerList<TViewModel> ) => {
    }

    /**
     * 选中实体
     */
    select() {
        let selection = null;
        if ( !selection || selection.length === 0 ) {
            this.util.dialog.close( new TreeViewModel() );
            return;
        }
        if ( selection.length === 1 ) {
            this.util.dialog.close( selection[0] );
            return;
        }
        this.util.dialog.close( selection );
    }

    /**
     * 选中行
     * @param node 节点
     * @param event 事件
     */
    selectRow( node, event?) {
        //this.table.selectRow( node );
        //event && event.stopPropagation();
    }

    /**
     * 是否首行
     * @param node 节点
     */
    isFirst( node ) {
        //return this.table.isFirst( node );
    }

    /**
     * 是否尾行
     * @param node 节点
     */
    isLast( node ) {
        //return this.table.isLast( node );
    }

    /**
     * 上移
     * @param node 节点
     * @param button 按钮
     * @param event 事件
     */
    moveUp( node, button?, event?) {
        //this.table.moveUp( node, button );
        this.selectRow( node, event );
    }

    /**
     * 下移
     * @param node 节点
     * @param button 按钮
     * @param event 事件
     */
    moveDown( node, button?, event?) {
        //this.table.moveDown( node, button );
        this.selectRow( node, event );
    }

    /**
     * 启用
     * @param node 节点
     * @param button 按钮
     * @param url 启用服务端Url
     */
    enable( node?, button?, url?: string ) {
        this.enableNode( true, node, button, url );
    }

    /**
     * 禁用
     * @param node 节点
     * @param button 按钮
     * @param url 禁用服务端Url
     */
    disable( node?, button?, url?: string ) {
        this.enableNode( false, node, button, url );
    }

    /**
     * 启用禁用
     */
    private enableNode( enabled: boolean, node?, btn?, url?: string ) {
        let list = this.getSelectedNodes( node );
        if ( !list || list.length === 0 ) {
            util.message.warn( MessageConfig.notSelected );
            return;
        }
        url = url || `/api/${this.table.baseUrl}/${enabled ? 'enable' : 'disable'}`;
        //this.util.form.submit( {
        //    url: url,
        //    data: this.table.getCheckedIds( list ),
        //    httpMethod: HttpMethod.Post,
        //    button: btn,
        //    confirm: this.getEnableConfirmMessage( enabled ),
        //    ok: ( result: any[] ) => {
        //        if ( !result || result.length === 0 )
        //            return;
        //        result.forEach( value => {
        //            if ( !value )
        //                return;
        //            let item = list.find( t => t.data.id === value.id );
        //            if ( !item )
        //                return;
        //            item.data.enabled = value.enabled;
        //            item.data.version = value.version;
        //        } );
        //    }
        //} );
    }

    /**
     * 获取选中列表
     */
    private getSelectedNodes( node ): any[] {
        let list = new Array();
        if ( node && node.data ) {
            list.push( node );
            return list;
        }
        return this.table.getChecked();
    }

    /**
     * 获取启用确认消息
     */
    private getEnableConfirmMessage( enabled: boolean ) {
        return enabled ? MessageConfig.enableConfirm : MessageConfig.disableConfirm;
    }

    /**
     * 获取选中列表
     */
    getCheckedNodes() {
        return this.table.getChecked();
    }

    /**
     * 获取选中标识列表
     */
    getCheckedIds() {
        return this.table.getCheckedIds();
    }

    /**
     * 获取勾选的单个节点
     */
    getCheckedNode() {
        return this.table.getCheckedNode();
    }

    /**
     * 打开创建页面弹出框
     * @param parent 父节点
     */
    openCreateDialog( parent?) {
        this.util.dialog.open( {
            component: this.getCreateDialogComponent(),
            data: this.getCreateDialogData( parent ),
            width: this.getCreateDialogWidth(),
            disableClose: true,
            showFooter: false,
            onBeforeOpen: () => {
                return this.onCreateBeforeOpen();
            },
            onBeforeClose: result => {
                return this.onCreateBeforeClose( result );
            },
            onClose: result => {
                this.onCreateClose( result );
            }
        } );
    }

    /**
     * 获取创建弹出框组件
     */
    protected getCreateDialogComponent(): any {
        return {};
    }

    /**
     * 获取创建弹出框数据
     */
    protected getCreateDialogData( parent?): any {
        return { parent: parent };
    }

    /**
     * 获取创建弹出框宽度
     */
    protected getCreateDialogWidth() {
        return this.getDialogWidth();
    }

    /**
     * 获取弹出框宽度，默认值：60%
     */
    protected getDialogWidth() {
        return "60%";
    }

    /**
     * 创建弹出框打开前回调函数，返回 false 阻止打开
     */
    protected onCreateBeforeOpen() {
        return true;
    }

    /**
     * 创建弹出框关闭前回调函数，返回 false 阻止关闭
     * @param result 返回结果
     */
    protected onCreateBeforeClose( result ) {
        return true;
    }

    /**
     * 创建弹出框关闭回调函数
     * @param result 返回结果
     */
    protected onCreateClose( result ) {
        this.query();
    }

    /**
     * 打开修改页面弹出框
     * @param id 标识
     */
    openEditDialog( id ) {
        this.util.dialog.open( {
            component: this.getEditDialogComponent(),
            data: this.getEditDialogData( id ),
            width: this.getEditDialogWidth(),
            disableClose: true,
            showFooter: false,
            onBeforeOpen: () => {
                return this.onEditBeforeOpen();
            },
            onBeforeClose: result => {
                return this.onEditBeforeClose( result );
            },
            onClose: result => {
                this.onEditClose( result );
            }
        } );
    }

    /**
     * 获取更新弹出框组件
     */
    protected getEditDialogComponent(): any {
        return this.getCreateDialogComponent();
    }

    /**
     * 获取更新弹出框数据
     */
    protected getEditDialogData( id ) {
        return { id: id };
    }

    /**
     * 获取编辑弹出框宽度
     */
    protected getEditDialogWidth() {
        return this.getDialogWidth();
    }

    /**
     * 更新弹出框打开前回调函数，返回 false 阻止打开
     */
    protected onEditBeforeOpen() {
        return true;
    }

    /**
     * 更新弹出框关闭前回调函数，返回 false 阻止关闭
     * @param result 返回结果
     */
    protected onEditBeforeClose( result ) {
        return true;
    }

    /**
     * 更新弹出框关闭回调函数
     * @param result 返回结果
     */
    protected onEditClose( result ) {
        this.query();
    }

    /**
     * 打开详情页面弹出框
     * @param id 标识
     */
    openDetailDialog( id ) {
        this.util.dialog.open( {
            component: this.getDetailDialogComponent(),
            data: this.getDetailDialogData( id ),
            width: this.getDetailDialogWidth(),
            showOk: false
        } );
    }

    /**
     * 获取详情弹出框组件
     */
    protected getDetailDialogComponent(): any {
        return {};
    }

    /**
     * 获取详情弹出框数据
     */
    protected getDetailDialogData( id ) {
        return this.getEditDialogData( id );
    }

    /**
     * 获取详情弹出框宽度
     */
    protected getDetailDialogWidth() {
        return this.getDialogWidth();
    }
}