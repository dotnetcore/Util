//============== NgZorro树形包装器=======================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Component, Input, Output, AfterContentInit, EventEmitter, ViewChild, forwardRef } from '@angular/core';
import { NzTreeNodeOptions, NzFormatEmitEvent, NzTreeComponent } from "ng-zorro-antd";
import { WebApi as webapi } from '../common/webapi';
import { TreeQueryParameter } from "../core/tree-model";

/**
 * NgZorro树形包装器
 */
@Component( {
    selector: 'x-tree',
    template: `
        <nz-tree [nzData]="dataSource" [nzAsyncData]="async"
            [nzCheckable]="showCheckbox" [nzBlockNode]="blockNode" [nzMultiple]="multiple"
            [nzShowExpand]="showExpand" [nzShowLine]="showLine" [nzExpandAll]="expandAll" [nzShowIcon]="showIcon"
            [nzExpandedKeys]="expandedKeys" [nzCheckedKeys]="checkedKeys" [nzSelectedKeys]="selectedKeys" 
            (nzClick)="click($event)" (nzDblClick)="dblClick($event)" (nzExpandChange)="expandChange($event)"
            (nzCheckBoxChange)="checkBoxChange($event)">
        </nz-tree>
    `
} )
export class Tree implements AfterContentInit {
    /**
     * 是否异步加载
     */
    @Input() async: boolean;
    /**
     * 数据源
     */
    @Input() dataSource: NzTreeNodeOptions[];
    /**
     * 初始化时是否自动加载数据，默认为true,设置成false则手工加载
     */
    @Input() autoLoad: boolean;
    /**
     * 数据加载地址，范例：/api/test
     */
    @Input() url: string;
    /**
     * 查询参数
     */
    @Input() queryParam: TreeQueryParameter;
    /**
     * 查询参数变更事件
     */
    @Output() queryParamChange = new EventEmitter<TreeQueryParameter>();
    /**
     * 是否显示复选框
     */
    @Input() showCheckbox: boolean;
    /**
     * 节点是否占据一行
     */
    @Input() blockNode: boolean;
    /**
     * 节点前是否添加展开图标
     */
    @Input() showExpand: boolean;
    /**
     * 是否显示连接线
     */
    @Input() showLine: boolean;
    /**
     * 展开所有节点
     */
    @Input() expandAll: boolean;
    /**
     * 展开节点的标识列表
     */
    @Input() expandedKeys: string[];
    /**
     * 复选框选中节点的标识列表
     */
    @Input() checkedKeys: string[];
    /**
     * 选中节点的标识列表
     */
    @Input() selectedKeys: string[];
    /**
     * 允许选中多个节点
     */
    @Input() multiple: boolean;
    /**
     * 是否显示图标
     */
    @Input() showIcon: boolean;
    /**
     * 单击事件
     */
    @Output() onClick = new EventEmitter<NzFormatEmitEvent>();
    /**
     * 双击事件
     */
    @Output() onDblClick = new EventEmitter<NzFormatEmitEvent>();
    /**
     * 复选框变更事件
     */
    @Output() onCheckBoxChange = new EventEmitter<NzFormatEmitEvent>();
    /**
     * 展开事件
     */
    @Output() onExpand = new EventEmitter<NzFormatEmitEvent>();
    /**
     * 树形组件
     */
    @ViewChild( forwardRef( () => NzTreeComponent ), { "static": false } ) protected tree: NzTreeComponent;

    /**
     * 初始化树形包装器
     */
    constructor() {
        this.dataSource = new Array<any>();
        this.autoLoad = true;
        this.queryParam = new TreeQueryParameter();
        this.showExpand = true;
        this.showIcon = true;
        this.async = true;
    }

    /**
     * 内容加载完成时进行初始化
     */
    ngAfterContentInit() {
        if ( this.autoLoad )
            this.query();
    }

    /**
     * 发送请求
     * @param option 参数
     */
    query( option?: {
        url?: string;
        param?;
        before?: () => boolean;
        complete?: () => void;
        ok?: ( value ) => void;
    } ) {
        option = option || {};
        let url = option.url || this.url;
        if ( !url )
            return;
        let param = option.param || this.queryParam;
        webapi.get<any>( url ).param( param ).handle( {
            before: option.before,
            ok: result => {
                if ( option.ok ) {
                    option.ok( result );
                    return;
                }
                this.loadData( result );
            },
            complete: option.complete
        } );
    }

    /**
     * 加载数据
     */
    private loadData( result ) {
        if ( !result )
            return;
        this.dataSource = result.nodes || [];
        this.expandedKeys = this.expandedKeys ? [...this.expandedKeys] : result.expandedKeys || [];
        this.checkedKeys = this.checkedKeys ? [...this.checkedKeys] : result.checkedKeys || [];
        this.selectedKeys = this.selectedKeys ? [...this.selectedKeys] : result.selectedKeys || [];
    }

    /**
     * 刷新
     * @param queryParam 查询参数
     */
    refresh( queryParam?: TreeQueryParameter ) {
        if ( queryParam ) {
            this.queryParam = queryParam;
            this.queryParamChange.emit( queryParam );
        }
        this.queryParam.order = null;
        this.query();
    }

    /**
     * 清空数据
     */
    clear() {
        this.dataSource = [];
    }

    /**
     * 单击事件处理
     */
    click( event ) {
        this.onClick.emit( event );
    }

    /**
     * 双击事件处理
     */
    dblClick( event ) {
        this.onDblClick.emit( event );
    }

    /**
     * 复选框变更事件
     */
    checkBoxChange( event ) {
        this.onCheckBoxChange.emit( event );
    }

    /**
     * 展开事件处理
     * @param event
     */
    expandChange( event ) {
        this.loadChildren( event );
        this.onExpand.emit( event );
    }

    /**
     * 加载子节点列表
     */
    private loadChildren( event: NzFormatEmitEvent ) {
        if ( !event )
            return;
        let node = event.node;
        if ( !node )
            return;
        let children = node.getChildren();
        if ( children && children.length > 0 )
            return;
        this.queryParam.operation = "LoadChild";
        this.queryParam.parentId = node.key;
        this.query( {
            ok: result => {
                if ( result && result.nodes && result.nodes.length > 0 ) {
                    node.addChildren( result.nodes );
                    return;
                }
                node.isLoading = false;
                node.isLeaf = true;
            },
            complete: () => {
                this.queryParam.operation = null;
                this.queryParam.parentId = null;
            }
        } );
    }

    /**
     * 获取树节点列表
     */
    getNodes() {
        return this.tree.getTreeNodes();
    }

    /**
     * 获取节点
     * @param id 标识
     */
    getNodeById( id: string ) {
        return this.tree.getTreeNodeByKey( id );
    }

    /**
     * 获取选中复选框的节点列表
     */
    getCheckedNodes() {
        return this.tree.getCheckedNodeList();
    }

    /**
     * 获取选中复选框的标识列表
     */
    getCheckedIds(): string {
        return this.getCheckedNodes().map( value => value.key ).join( "," );
    }

    /**
     * 获取选中的节点列表
     */
    getSelectedNodes() {
        return this.tree.getSelectedNodeList();
    }

    /**
     * 获取选中的标识列表
     */
    getSelectedIds(): string {
        return this.getSelectedNodes().map( value => value.key ).join( "," );
    }

    /**
     * 获取展开的节点列表
     */
    getExpandedNodes() {
        return this.tree.getExpandedNodeList();
    }

    /**
     * 获取展开的标识列表
     */
    getExpandedIds(): string {
        return this.getExpandedNodes().map( value => value.key ).join( "," );
    }
}