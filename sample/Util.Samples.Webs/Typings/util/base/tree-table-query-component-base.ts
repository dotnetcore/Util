//=============== 树型表格查询基类================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Injector, ViewChild, OnInit } from '@angular/core';
import { util, TreeViewModel, TreeQueryParameter, TreeTable } from '../index';

/**
 * 树型表格查询基类
 */
export abstract class TreeTableQueryComponentBase<TViewModel extends TreeViewModel, TQuery extends TreeQueryParameter> implements OnInit {
    /**
     * 操作库
     */
    protected util = util;
    /**
     * 查询参数
     */
    queryParam: TQuery;
    /**
     * 选中列表
     */
    selection: TViewModel[];
    /**
     * 表格组件
     */
    @ViewChild(TreeTable) protected table: TreeTable<TViewModel>;

    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        util.ioc.componentInjector = injector;
        this.queryParam = this.createQuery();
        this.selection = new Array<TViewModel>();
    }

    /**
     * 创建查询参数
     */
    protected abstract createQuery(): TQuery;

    /**
     * 初始化
     */
    ngOnInit() {
        this.initSelection();
    }

    /**
     * 初始化选中项
     */
    private initSelection() {
        let selectedNodes = util.dialog.getData<TViewModel>();
        if (selectedNodes)
            this.selection.push(selectedNodes);
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
        this.table.search(this.getDelay());
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
    delete(id?: string | undefined) {
        this.table.delete(id);
    }

    /**
     * 刷新
     */
    refresh() {
        this.queryParam = this.createQuery();
        this.table.refresh(this.queryParam);
    }

    /**
     * 获取选中的实体列表
     */
    getChecked(): TViewModel[] {
        return this.table.getChecked();
    }

    /**
     * 选中实体
     */
    select() {
        let selection = this.getChecked();
        if (!selection || selection.length === 0) {
            this.util.dialog.close(new TreeViewModel());
            return;
        }
        if (selection.length === 1) {
            this.util.dialog.close(selection[0]);
            return;
        }
        this.util.dialog.close(selection);
    }
}