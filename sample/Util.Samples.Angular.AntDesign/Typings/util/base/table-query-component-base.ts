//================ 表格查询基类 ==================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { Injector, ViewChild, forwardRef } from '@angular/core';
import { util, ViewModel, QueryParameter, TableWrapperComponent } from '../index';

/**
 * 表格查询基类
 */
export abstract class TableQueryComponentBase<TViewModel extends ViewModel, TQuery extends QueryParameter> {
    /**
     * 操作库
     */
    protected util = util;
    /**
     * 查询参数
     */
    queryParam: TQuery;
    /**
     * 表格组件
     */
    @ViewChild( forwardRef( () => TableWrapperComponent ) ) protected table: TableWrapperComponent<TViewModel>;

    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        util.ioc.componentInjector = injector;
        this.queryParam = this.createQuery();
    }

    /**
     * 创建查询参数
     */
    protected abstract createQuery(): TQuery;

    /**
     * 查询
     * @param button 按钮
     */
    query( button ) {
        this.table.query( button );
    }

    /**
     * 延迟搜索
     * @param button 按钮
     */
    search( button ) {
        this.table.search( button, this.getDelay() );
    }

    /**
     * 获取查询延迟间隔，单位：毫秒，默认500
     */
    protected getDelay() {
        return 500;
    }

    /**
     * 删除
     * @param button 按钮
     * @param id 标识
     */
    delete( button?, id?) {
        this.table.delete( button, id );
    }

    /**
     * 刷新
     * @param button 按钮
     */
    refresh( button? ) {
        this.queryParam = this.createQuery();
        this.table.refresh( this.queryParam, button );
    }

    /**
     * 获取选中项列表
     */
    getChecked() {
        return this.table.getChecked();
    }

    /**
     * 获取选中项标识列表
     */
    getCheckedIds() {
        return this.table.getCheckedIds();
    }

    /**
     * 选中实体
     */
    select() {
        let selection = this.getChecked();
        if ( !selection || selection.length === 0 ) {
            this.util.dialog.close( new ViewModel() );
            return;
        }
        if ( selection.length === 1 ) {
            this.util.dialog.close( selection[0] );
            return;
        }
        this.util.dialog.close( selection );
    }
}