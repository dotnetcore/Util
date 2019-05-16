//============== NgZorro树形表格包装器=======================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Component, Input, Output, AfterContentInit, EventEmitter } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { WebApi as webapi } from '../common/webapi';
import { Message as message } from '../common/message';
import { PagerList } from '../core/pager-list';
import { IKey, QueryParameter } from '../core/model';
import { MessageConfig as config } from '../config/message-config';
import { Table } from './table-wrapper.component';

/**
 * NgZorro树形表格包装器
 */
@Component({
    selector: 'nz-tree-table-wrapper',
    template: `
        <ng-content></ng-content>
    `
})
export class TreeTable<T extends IKey> extends Table<T> {
    /**
     * 初始化树形表格包装器
     */
    constructor() {
        super();
    }

    /**
     * 展开操作
     * @param node 节点
     * @param expand 是否展开
     */
    collapse(node, expand) {
        if (!node)
            return;
        node.expanded = !!expand;
    }

    /**
     * 是否叶节点
     * @param node 节点
     */
    isLeaf(node) {
        if (!node)
            return false;
        return node.leaf;
    }

    /**
     * 是否展开
     * @param node 节点
     */
    isExpand(node) {
        if (!node)
            return false;
        return node.expanded;
    }

    /**
     * 是否显示行
     * @param node 节点
     */
    isShow(node) {
        if (!node)
            return false;
        if (node.level === 1)
            return true;
        let parent = this.dataSource.find(t => t.id === node.parentId);
        if (!parent)
            return false;
        if (!parent.expanded)
            return false;
        return this.isShow(parent);
    }

    /**
     * 行复选框切换选中状态
     * @param node 节点
     */
    rowToggle(node) {
        this.checkedSelection.toggle(node);

    }
}