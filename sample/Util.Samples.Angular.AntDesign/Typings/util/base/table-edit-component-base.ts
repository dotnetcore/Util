//================ 表格编辑基类 ==================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { Injector, ViewChild, forwardRef } from '@angular/core';
import { ViewModel, QueryParameter } from "../core/model";
import { EditTableDirective } from "../zorro/edit-table.directive";
import { TableQueryComponentBase } from "./table-query-component-base";

/**
 * 表格编辑基类
 */
export abstract class TableEditComponentBase<TViewModel extends ViewModel, TQuery extends QueryParameter> extends TableQueryComponentBase<TViewModel, TQuery> {
    /**
     * 编辑表格指令
     */
    @ViewChild( forwardRef( () => EditTableDirective ) ) protected editTable: EditTableDirective;

    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        super( injector );
    }

    /**
     * 添加行
     */
    add() {
        this.editTable.addRow( {
            row: this.createModel(),
            addBefore: row => this.addBefore( row )
        } );
    }

    /**
     * 创建参数
     */
    protected createModel(): TViewModel {
        return <TViewModel>{};
    }

    /**
     * 添加前操作，返回 false 阻止添加
     * @param row 行参数
     */
    addBefore( row ): boolean {
        return true;
    }

    /**
     * 编辑
     * @param id 行标识
     */
    edit( id ) {
        this.editTable.editRow( {
            rowId: id,
            editAfter: () => setTimeout( () => this.editTable.focusToFirst(), 0 )
        } );
    }

    /**
     * 删除
     * @param id 标识
     */
    delete( id?) {
        this.editTable.remove( id );
    }

    /**
     * 刷新
     * @param button 按钮
     * @param handler 刷新后回调函数
     */
    refresh( button?, handler?: ( data ) => void ) {
        super.refresh( button, handler );
        this.editTable.clear();
    }
}