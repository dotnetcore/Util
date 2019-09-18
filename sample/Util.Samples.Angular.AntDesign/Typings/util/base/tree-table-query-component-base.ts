//=============== 树形表格查询基类================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { Injector, ViewChild, forwardRef, OnInit } from '@angular/core';
import { MessageConfig } from '../config/message-config';
import { PagerList } from "../core/pager-list";
import { TreeViewModel, TreeQueryParameter } from "../core/tree-model";
import { TreeTable } from "../zorro/tree-table-wrapper.component";
import { QueryComponentBase } from "./query-component-base";

/**
 * 树形表格查询基类
 */
export abstract class TreeTableQueryComponentBase<TViewModel extends TreeViewModel, TQuery extends TreeQueryParameter> extends QueryComponentBase implements OnInit {
    /**
     * 查询参数
     */
    queryParam: TQuery;
    /**
     * 树形表格组件
     */
    @ViewChild( forwardRef( () => TreeTable ), { "static": false }) protected table: TreeTable<TViewModel>;

    /**
     * 初始化树形表格查询基类
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        super( injector );
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
        this.loadCheckedIds();
    }

    /**
     * 加载勾选的复选框标识
     */
    protected loadCheckedIds() {
        let selection = this.getSelection();
        this.checkedIds = this.util.helper.getIds( selection );
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
     * 删除
     * @param button 按钮
     * @param id 标识
     */
    delete( button?, id?) {
        this.table.delete( {
            button: button,
            ids: id,
            handler: () => {
                this.deleteAfter();
            }
        } );
    }

    /**
     * 删除后操作
     */
    protected deleteAfter = () => {
    }

    /**
     * 勾选标识列表
     * @param checkedIds 要勾选的标识列表
     */
    checkIds( checkedIds?) {
        if ( checkedIds )
            this.checkedIds = checkedIds;
        this.table.checkIds( this.checkedIds );
    }

    /**
     * 刷新
     * @param button 按钮
     * @param handler 刷新后回调函数
     */
    refresh( button?, handler?: ( data ) => void ) {
        handler = handler || this.refreshAfter;
        this.queryParam = this.createQuery();
        this.table.refresh( this.queryParam, button, handler );
    }

    /**
     * 刷新完成后操作
     */
    protected refreshAfter = data => {
        this.checkIds();
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
            this.util.message.warn( MessageConfig.notSelected );
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
     * 获取创建弹出框数据
     */
    protected getCreateDialogData( data?): any {
        return { parent: data };
    }
}