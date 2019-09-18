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
    @ViewChild( forwardRef( () => EditTableDirective ), { "static": false } ) protected editTable: EditTableDirective;

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
            before: row => this.addBefore( row )
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
            after: () => setTimeout( () => this.editTable.focusToFirst(), 0 )
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

    /**
     * 保存
     * @param button 按钮
     */
    save( button?) {
        this.editTable.save( {
            button: button,
            confirm: this.getConfirm(),
            createData: data => this.createData( data ),
            isDirty: ( data ) => this.isDirty( data ),
            before: data => this.saveBefore( data ),
            ok: result => this.saveAfter( result ),
            url: this.getSaveUrl()
        } );
    }

    /**
     * 获取确认消息
     */
    protected getConfirm() {
        return null;
    }

    /**
     * 创建保存参数
     * @param data 保存参数
     */
    protected createData( data ) {
        return data;
    }

    /**
     * 是否已修改，返回 false 阻止添加
     * @param data 保存参数
     */
    protected isDirty( data ) {
        return false;
    }

    /**
     * 保存前操作，返回 false 阻止添加
     * @param data 保存参数
     */
    protected saveBefore( data ) {
        return true;
    }

    /**
     * 保存成功操作
     * @param result 结果
     */
    protected saveAfter( result ) {
    }

    /**
     * 获取保存地址
     */
    protected getSaveUrl() {
        return null;
    }
}