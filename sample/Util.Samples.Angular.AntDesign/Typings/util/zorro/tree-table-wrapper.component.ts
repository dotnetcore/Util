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
@Component( {
    selector: 'nz-tree-table-wrapper',
    template: `
        <ng-content></ng-content>
    `
} )
export class TreeTable<T extends IKey> extends Table<T> {
    /**
     * 初始化树形表格包装器
     */
    constructor() {
        super();
    }

    /**
     * 表头主复选框切换选中状态
     */
    masterToggle() {
        if ( this.isMasterChecked() ) {
            this.checkedSelection.clear();
            return;
        }
        this.dataSource.forEach( data => this.checkedSelection.select( data ) );
    }

    

    /**
     * 表头主复选框的选中状态
     */
    isMasterChecked() {
        return this.checkedSelection.hasValue() &&
            this.isAllChecked() &&
            this.checkedSelection.selected.length >= this.dataSource.length;
    }

    /**
     * 是否所有行复选框被选中
     */
    isAllChecked() {
        return this.dataSource.every( data => this.checkedSelection.isSelected( data ) );
    }

    /**
     * 表头主复选框的确定状态
     */
    isMasterIndeterminate() {
        return this.checkedSelection.hasValue() && ( !this.isAllChecked() || !this.dataSource.length );
    }
}