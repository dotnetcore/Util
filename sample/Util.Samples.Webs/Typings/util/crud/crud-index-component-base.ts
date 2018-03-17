//============== Crud列表页组件基类===============
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Injector, ViewChild, AfterViewInit } from '@angular/core';
import { util, ViewModel, QueryParameter, TableWrapperComponent } from '../index';

/**
 * Crud列表页组件基类
 */
export abstract class CrudIndexComponentBase<TViewModel extends ViewModel, TQuery extends QueryParameter> implements AfterViewInit {
    /**
     * 操作库
     */
    protected util = util;
    /**
     * 查询参数
     */
    protected queryParam: TQuery;
    /**
     * 查询延迟
     */
    private timeout;
    /**
     * 表格组件
     */
    @ViewChild(TableWrapperComponent) protected table: TableWrapperComponent<ViewModel>;

    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        util.ioc.componentInjector = injector;
        this.queryParam = this.createQuery();
    }

    /**
     * 创建查询参数
     */
    protected abstract createQuery(): TQuery;

    /**
     * 初始化
     */
    ngAfterViewInit() {
        this.query();
    }

    /**
     * 查询
     */
    query() {
        this.table.query();
    }

    /**
     * 延迟搜索
     */
    search() {
        if (this.timeout)
            clearTimeout(this.timeout);
        this.timeout = setTimeout(() => {
            this.query();
        }, this.getDelay());
    }

    /**
     * 获取查询延迟间隔，单位：毫秒，默认500
     */
    protected getDelay() {
        return 500;
    }

    /**
     * 删除
     * @param id 标识
     */
    delete(id: string | undefined) {
        this.table.delete(id);
    }

    /**
     * 刷新
     */
    refresh() {
        this.queryParam = this.createQuery();
        this.table.refresh(this.queryParam);
    }
}