//================ 表格查询基类 ==================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { Injector, ViewChild, forwardRef, AfterViewInit } from '@angular/core';
import { ViewModel, QueryParameter, Table } from '../index';
import { QueryComponentBase } from "./query-component-base";

/**
 * 表格查询基类
 */
export abstract class TableQueryComponentBase<TViewModel extends ViewModel, TQuery extends QueryParameter> extends QueryComponentBase implements AfterViewInit {
    /**
     * 查询参数
     */
    queryParam: TQuery;
    /**
     * 表格组件
     */
    @ViewChild( forwardRef( () => Table ) ) protected table: Table<TViewModel>;

    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        super( injector );
        this.queryParam = this.createQuery();
    }

    /**
     * 创建查询参数
     */
    protected createQuery(): TQuery {
        return <TQuery>{};
    }

    /**
     * 视图加载完成
     */
    ngAfterViewInit() {
        if ( !this.table )
            return;
        this.table.loadAfter = result => {
            this.loadAfter( result );
        }
    }

    /**
     * 数据加载完成操作
     * @param result
     */
    loadAfter( result ) {
    }

    /**
     * 查询
     * @param button 按钮
     */
    query( button?) {
        this.table.query( {
            button: button
        } );
    }

    /**
     * 延迟搜索
     * @param button 按钮
     */
    search( button?) {
        this.table.search( {
            button: button,
            delay: this.getDelay()
        } );
    }

    /**
     * 删除
     * @param button 按钮
     * @param id 标识
     */
    delete( button?, id?) {
        this.table.delete( {
            button: button,
            ids: id
        } );
    }

    /**
     * 刷新
     * @param button 按钮
     */
    refresh( button?) {
        this.queryParam = this.createQuery();
        this.table.refresh( this.queryParam, button );
    }

    /**
     * 清空复选框
     */
    clearCheckboxs() {
        this.table.clearChecked();
    }

    /**
     * 获取勾选的实体列表
     */
    getCheckedNodes() {
        return this.table.getChecked();
    }

    /**
     * 获取勾选的实体列表长度
     */
    getCheckedLength(): number {
        return this.table.getCheckedLength();
    }

    /**
     * 获取勾选的实体标识列表
     */
    getCheckedIds() {
        return this.table.getCheckedIds();
    }

    /**
     * 获取勾选的单个节点
     */
    getCheckedNode() {
        return this.table.getCheckedNode();
    }
}