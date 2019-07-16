//============== NgZorro编辑表格指令 ====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Directive, HostListener,Input } from '@angular/core';
import { EditRowDirective } from "./edit-row.directive";

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
     * 编辑行
     */
    editRow: EditRowDirective;
    /**
     * 编辑行
     */
    @Input() dblClickStartEdit: boolean;

    /**
     * 初始化编辑表格指令
     */
    constructor() {
        this.dblClickStartEdit = true;
    }

    /**
     * 处理全局点击事件
     */
    @HostListener( 'document:click' )
    handleClick() {
        if ( !this.editRow )
            return;
        if ( !this.isEditRowValid() ) {
            this.editRow.focus();
            return;
        }
        this.clearEditRow();
    }

    /**
     * 单击编辑
     * @param rowId 行标识
     * @param row 行
     */
    clickEdit( rowId, row ) {
        if ( this.dblClickStartEdit && !this.editRow )
            return;
        this.dblClickEdit( rowId , row );
    }

    /**
     * 双击编辑
     * @param rowId 行标识
     * @param row 行
     */
    dblClickEdit( rowId, row ) {
        event.preventDefault();
        event.stopPropagation();
        if ( this.editRow && !this.isEditRowValid() ) {
            this.editRow.focus();
            return;
        }
        this.editId = rowId;
        this.editRow = row;
    }

    /**
     * 编辑行是否验证通过
     */
    isEditRowValid() {
        if ( !this.editRow )
            return true;
        return this.editRow.isValid();
    }

    /**
     * 清空编辑行
     */
    clearEditRow() {
        this.editId = null;
        this.editRow = null;
    }
}