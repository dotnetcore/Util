//============== NgZorro树形表格包装器=======================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Component, Input, Output, EventEmitter } from '@angular/core';
import { remove } from "../common/helper";
import { IKey } from '../core/model';
import { Table } from './table-wrapper.component';

/**
 * NgZorro树形表格包装器
 */
@Component( {
    selector: 'nz-tree-table-wrapper',
    template: `
        <ng-content></ng-content>
    `
} )
export class TreeTable<T extends IKey> extends Table<T> {
    /**
     * 是否展开所有节点,默认为false
     */
    @Input() expandAll: boolean;
    /**
     * 是否显示复选框,默认为true
     */
    @Input() showCheckbox: boolean;
    /**
     * 是否只能勾选叶节点,仅对单选框有效，默认为false
     */
    @Input() checkLeafOnly: boolean;
    /**
     * 展开事件
     */
    @Output() onExpand = new EventEmitter<any>();

    /**
     * 初始化树形表格包装器
     */
    constructor() {
        super();
        this.showCheckbox = true;
    }

    /**
     * 获取直接下级节点列表
     * @param node 节点
     */
    getChildren( node ) {
        if ( !node )
            return [];
        return this.dataSource.filter( t => t.parentId === node.id );
    }

    /**
     * 获取所有下级节点列表
     * @param node 节点
     */
    getAllChildren( node ) {
        if ( !node )
            return [];
        let result = [];
        this.addAllChildren( result, node );
        remove( result, item => item === node );
        return result;
    }

    /**
     * 添加所有下级节点
     */
    private addAllChildren( list, node ) {
        if ( !node )
            return;
        list.push( node );
        let children = this.getChildren( node );
        if ( !children || children.length === 0 )
            return;
        children.forEach( item => this.addAllChildren( list, item ) );
    }

    /**
     * 获取上级节点
     * @param node 节点
     */
    getParent( node ) {
        if ( !node )
            return null;
        return this.dataSource.find( t => t.id === node.parentId );
    }

    /**
     * 获取所有上级节点列表
     * @param node 节点
     */
    getParents( node ) {
        let result = [];
        this.addParents( result, node );
        return result;
    }

    /**
     * 添加所有上级节点
     */
    private addParents( list, node ) {
        if ( !node )
            return;
        let parent = this.getParent( node );
        if ( !parent )
            return;
        list.push( parent );
        this.addParents( list, parent );
    }

    /**
     * 展开操作
     * @param node 节点
     * @param expand 是否展开
     */
    collapse( node, expand ) {
        if ( !node )
            return;
        node.expanded = !!expand;
        this.onExpand.emit( { node: node, expand: expand } );
    }

    /**
     * 是否叶节点
     * @param node 节点
     */
    isLeaf( node ) {
        if ( !node )
            return false;
        return node.leaf;
    }

    /**
     * 是否展开
     * @param node 节点
     */
    isExpand( node ) {
        if ( !node )
            return false;
        return node.expanded;
    }

    /**
     * 是否显示行
     * @param node 节点
     */
    isShow( node ) {
        if ( !node )
            return false;
        if ( node.level === 1 )
            return true;
        let parent = this.getParent( node );
        if ( !parent )
            return false;
        if ( !parent.expanded )
            return false;
        return this.isShow( parent );
    }

    /**
     * 是否显示复选框
     */
    isShowCheckbox() {
        if ( !this.showCheckbox )
            return false;
        if ( this.multiple )
            return true;
        return false;
    }

    /**
     * 是否显示单选框
     * @param node 节点
     */
    isShowRadio( node ) {
        if ( !this.showCheckbox )
            return false;
        if ( this.multiple )
            return false;
        if ( !this.checkLeafOnly )
            return true;
        if ( this.isLeaf( node ) )
            return true;
        return false;
    }

    /**
     * 是否显示文本
     */
    isShowText( node ) {
        if ( !this.showCheckbox )
            return true;
        if ( !this.multiple && this.checkLeafOnly && !this.isLeaf( node ) )
            return true;
        return false;
    }

    /**
     * 节点复选框切换选中状态
     * @param node 节点
     */
    toggle( node ) {
        this.checkedSelection.toggle( node );
        this.toggleAllChildren( node );
        this.toggleParents( node );
    }

    /**
     * 切换所有下级节点的选中状态
     */
    private toggleAllChildren( node ) {
        let isChecked = this.isChecked( node );
        let nodes = this.getAllChildren( node );
        if ( isChecked ) {
            nodes.forEach( item => this.checkedSelection.select( item ) );
            return;
        }
        nodes.forEach( item => this.checkedSelection.deselect( item ) );
    }

    /**
     * 切换所有父节点选中状态
     */
    private toggleParents( node ) {
        let parent = this.getParent( node );
        if ( !parent )
            return;
        let isAllChecked = this.isChildrenAllChecked( parent );
        if ( isAllChecked )
            this.checkedSelection.select( parent );
        else
            this.checkedSelection.deselect( parent );
        this.toggleParents( parent );
    }

    /**
     * 是否直接下级所有节点被选中
     */
    private isChildrenAllChecked( node ) {
        let children = this.getChildren( node );
        if ( !children || children.length === 0 )
            return false;
        return children.every( item => this.checkedSelection.isSelected( item ) );
    }

    /**
     * 节点复选框的确定状态
     * @param node 节点
     */
    isIndeterminate( node ) {
        let children = this.getAllChildren( node );
        if ( !children || children.length === 0 )
            return false;
        let isChecked = children.some( item => this.checkedSelection.isSelected( item ) );
        let isAllChecked = children.every( item => this.checkedSelection.isSelected( item ) );
        return isChecked && !isAllChecked;
    }

    /**
     * 节点复选框的选中状态
     * @param node 节点
     */
    isChecked( node ) {
        return this.checkedSelection.isSelected( node );
    }

    /**
     * 加载数据
     */
    protected loadData( result ) {
        super.loadData( result );
        if ( this.expandAll )
            this.dataSource.forEach( item => item.expanded = true );
    }
}