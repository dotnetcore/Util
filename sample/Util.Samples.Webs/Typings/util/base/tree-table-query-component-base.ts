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
     * 传入弹出框的数据
     */
    data;
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
     * @param data 传入弹出框的数据
     */
    protected abstract createQuery(data?): TQuery;

    /**
     * 初始化
     */
    ngOnInit() {
        this.initDialogData();
    }

    /**
     * 加载弹出框数据
     */
    private initDialogData() {
        this.data = util.dialog.getData();
        if (!this.data)
            return;
        this.addToSelections(this.getSelectionFromData(this.data));
        this.queryParam = this.createQuery(this.data);
        this.init(this.data);
    }

    /**
     * 从弹出框数据中获取选中项
     * @param data 传入弹出框的数据
     */
    protected getSelectionFromData(data) {
        return data;
    }

    /**
     * 添加到选中项列表
     */
    private addToSelections(selection) {
        this.util.helper.addToArray(this.selection, selection);
    }

    /**
     * 初始化
     * @param data 传入弹出框的数据
     */
    protected init(data) {
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
        this.queryParam = this.createQuery(this.data);
        this.table.refresh(this.queryParam);
    }

    /**
     * 选中实体
     */
    select() {
        let selection = this.selection;
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