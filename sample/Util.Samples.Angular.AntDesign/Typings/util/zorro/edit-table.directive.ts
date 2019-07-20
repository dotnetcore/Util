//============== NgZorro编辑表格指令 ====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Directive, HostListener, Input } from '@angular/core';
import { Table } from "./table-wrapper.component";
import { EditRowDirective } from "./edit-row.directive";
import { Util as util } from "../util";

/**
 * NgZorro编辑表格指令
 */
@Directive( {
    selector: '[x-edit-table]',
    exportAs: 'utilEditTable'
} )
export class EditTableDirective {
    /**
     * 编辑行标识
     */
    editId;
    /**
     * 当前编辑行
     */
    currentEditRow: EditRowDirective;
    /**
     * 编辑行指令字典
     */
    editRows: Map<string, EditRowDirective>;
    /**
     * 创建标识列表
     */
    creationIds: string[];
    /**
     * 移除行列表
     */
    removeRows: any[];
    /**
     * 双击启动行编辑
     */
    @Input() dblClickStartEdit: boolean;

    /**
     * 初始化编辑表格指令
     * @param table 表格包装器组件
     */
    constructor( private table: Table<any> ) {
        this.dblClickStartEdit = true;
        this.editRows = new Map<string, EditRowDirective>();
        this.creationIds = [];
        this.removeRows = [];
    }

    /**
     * 注册编辑行
     * @param rowId 行标识
     * @param row 编辑行
     */
    register( rowId, row: EditRowDirective ) {
        if ( !rowId || !row )
            return;
        if ( this.editRows.has( rowId ) )
            return;
        this.editRows.set( rowId, row );
    }

    /**
     * 处理全局点击事件
     */
    @HostListener( 'document:click' )
    handleClick() {
        if ( !this.validate() )
            return;
        this.clearEditRow();
    }

    /**
     * 验证
     */
    validate() {
        if ( this.isValid() )
            return true;
        this.currentEditRow.focusToInvalid();
        return false;
    }

    /**
     * 是否验证通过
     */
    isValid() {
        if ( !this.currentEditRow )
            return true;
        return this.currentEditRow.isValid();
    }

    /**
     * 添加行
     * @param options 参数
     */
    addRow( options: {
        /**
         * 行数据
         */
        row,
        /**
         * 添加前操作，返回 false 阻止添加
         */
        addBefore?: ( row ) => boolean,
    } ) {
        event && event.stopPropagation();
        if ( !options )
            return;
        if ( !this.validate() )
            return;
        let row = options.row;
        if ( !row )
            return;
        this.initRow( row );
        if ( options.addBefore && !options.addBefore( row ) )
            return;
        if ( this.creationIds.some( id => id === row.id ) )
            return;
        this.creationIds.push( row.id );
        this.table.addRow( row );
        setTimeout( () => this.editRow( {
            rowId: row.id,
            editAfter: () => setTimeout( () => this.focusToFirst(), 0 )
        } ), 0 );
    }

    /**
     * 初始化行
     * @param row 行
     */
    protected initRow( row ) {
        if ( row.id )
            return;
        row.id = util.helper.uuid();
    }

    /**
     * 设置焦点到第一个组件
     */
    focusToFirst() {
        if ( !this.currentEditRow )
            return;
        this.currentEditRow.focusToFirst();
    }

    /**
     * 编辑行
     * @param options 参数
     */
    editRow( options: {
        /**
         * 行标识
         */
        rowId,
        /**
         * 编辑前操作，返回 false 阻止编辑
         */
        editBefore?: ( row ) => boolean,
        /**
         * 编辑后操作
         */
        editAfter?: ( row ) => void,
    } ) {
        if ( !options )
            return;
        event && event.preventDefault();
        event && event.stopPropagation();
        let rowId = options.rowId || options;
        if ( !rowId )
            return;
        if ( !this.editRows.has( rowId ) )
            return;
        let row = this.editRows.get( rowId );
        if ( options.editBefore && !options.editBefore( row ) )
            return;
        if ( !this.validate() )
            return;
        this.editId = rowId;
        this.currentEditRow = row;
        options.editAfter && options.editAfter( row );
    }

    /**
     * 单击编辑
     * @param id 行标识
     */
    clickEdit( id ) {
        if ( this.dblClickStartEdit && !this.currentEditRow )
            return;
        this.editRow( id );
    }

    /**
     * 双击编辑
     * @param id 行标识
     */
    dblClickEdit( id ) {
        this.editRow( id );
    }
    
    /**
     * 移除行
     * @param id 行标识
     */
    remove( id? ) {
        let ids = [];
        if ( id )
            ids.push( id );
        let result = this.table.removeRows( ids );
        this.removeRows.push( result );
    }

    /**
     * 清理
     */
    clear() {
        this.clearEditRow();
        this.editRows.clear();
        this.creationIds = [];
        this.removeRows = [];
    }

    /**
     * 清空编辑行
     */
    clearEditRow() {
        this.editId = null;
        this.currentEditRow = null;
    }
}