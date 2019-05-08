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
}