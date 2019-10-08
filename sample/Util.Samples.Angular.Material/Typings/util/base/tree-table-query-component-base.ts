//=============== 树型表格查询基类================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Injector, ViewChild, OnInit,forwardRef } from '@angular/core';
import { MessageConfig } from '../config/message-config';
import { util, TreeViewModel, TreeQueryParameter, TreeTable, HttpMethod, PagerList } from '../index';

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
    @ViewChild(forwardRef(() => TreeTable)) protected table: TreeTable<TViewModel>;

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
        this.data = util.dialog.getData();
        if (!this.data)
            return;
        if (this.isLoadSelection())
            this.addToSelection(this.getSelection(this.data));
        this.queryParam = this.createQuery(this.data);
        this.init(this.data);
    }

    /**
     * 是否从弹出框数据中加载选中项
     */
    protected isLoadSelection() {
        return true;
    }

    /**
     * 从弹出框数据中获取选中项
     * @param data 传入弹出框的数据
     */
    protected getSelection(data) {
        return data;
    }

    /**
     * 获取标识列表
     * @param nodes 节点列表
     */
    protected getIds(nodes: TViewModel[]) {
        return this.table.getIds(nodes);
    }

    /**
     * 添加到选中项列表
     */
    protected addToSelection(selection: TViewModel[]) {
        if (!selection)
            return;
        let ids = this.getIds(selection);
        let nodes = this.table.getByIds(ids);
        let except = this.util.helper.exceptWith(selection, nodes, (s, t) => this.compare(s, t));
        selection = this.util.helper.concat(nodes, except);
        this.util.helper.clear(this.selection);
        this.util.helper.addToArray(this.selection, selection);
        this.table.distinctSelection();
    }

    /**
     * 比较
     */
    private compare(s, t) {
        if (!s || !t)
            return false;
        if (s.id === t.id)
            return true;
        if (s.id === (t.data && t.data.id))
            return true;
        if ((s.data && s.data.id) === t.id)
            return true;
        if ((s.data && s.data.id) === (t.data && t.data.id))
            return true;
        return false;
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
    query(button?, handler?: (data: PagerList<TViewModel>) => void) {
        handler = handler || this.queryAfter;
        this.table.query(button, handler);
    }

    /**
     * 查询完成后操作
     * @param data 数据
     */
    protected queryAfter = (data: PagerList<TViewModel>) => {
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
     * @param button 按钮
     */
    delete(id?, button?) {
        id = this.table.getId(id);
        this.table.delete(id, null, null, button);
    }

    /**
     * 刷新
     * @param button 按钮
     * @param handler 刷新后回调函数
     */
    refresh(button?, handler?: (data: PagerList<TViewModel>) => void) {
        handler = handler || this.refreshAfter;
        this.queryParam = this.createQuery(this.data);
        this.table.refresh(this.queryParam, button, handler);
    }

    /**
     * 刷新完成后操作
     * @param data 数据
     */
    protected refreshAfter = (data: PagerList<TViewModel>) => {
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

    /**
     * 选中行
     * @param node 节点
     * @param event 事件
     */
    selectRow(node, event?) {
        this.table.selectRow(node);
        event && event.stopPropagation();
    }

    /**
     * 是否首行
     * @param node 节点
     */
    isFirst(node) {
        return this.table.isFirst(node);
    }

    /**
     * 是否尾行
     * @param node 节点
     */
    isLast(node) {
        return this.table.isLast(node);
    }

    /**
     * 上移
     * @param node 节点
     * @param button 按钮
     * @param event 事件
     */
    moveUp(node, button?, event?) {
        this.table.moveUp(node, button);
        this.selectRow(node, event);
    }

    /**
     * 下移
     * @param node 节点
     * @param button 按钮
     * @param event 事件
     */
    moveDown(node, button?, event?) {
        this.table.moveDown(node, button);
        this.selectRow(node, event);
    }

    /**
     * 启用
     * @param node 节点
     * @param button 按钮
     * @param url 启用服务端Url
     */
    enable(node?, button?, url?: string) {
        this.enableNode(true, node, button, url);
    }

    /**
     * 禁用
     * @param node 节点
     * @param button 按钮
     * @param url 禁用服务端Url
     */
    disable(node?, button?, url?: string) {
        this.enableNode(false, node, button, url);
    }

    /**
     * 启用禁用
     */
    private enableNode(enabled: boolean, node?, btn?, url?: string) {
        let list = this.getSelectedNodes(node);
        if (!list || list.length === 0) {
            util.message.warn(MessageConfig.notSelected);
            return;
        }
        url = url || `/api/${this.table.baseUrl}/${enabled ? 'enable' : 'disable'}`;
        this.util.form.submit({
            url: url,
            data: this.table.getCheckedIds(list),
            httpMethod: HttpMethod.Post,
            button: btn,
            confirm: this.getEnableConfirmMessage(enabled),
            handler: (result: any[]) => {
                if (!result || result.length === 0)
                    return;
                result.forEach(value => {
                    if (!value)
                        return;
                    let item = list.find(t => t.data.id === value.id);
                    if (!item)
                        return;
                    item.data.enabled = value.enabled;
                    item.data.version = value.version;
                });
            }
        });
    }

    /**
     * 获取选中列表
     */
    private getSelectedNodes(node): any[] {
        let list = new Array();
        if (node && node.data) {
            list.push(node);
            return list;
        }
        return this.table.getChecked();
    }

    /**
     * 获取启用确认消息
     */
    private getEnableConfirmMessage(enabled: boolean) {
        return enabled ? MessageConfig.enableConfirm : MessageConfig.disableConfirm;
    }

    /**
     * 获取选中标识列表
     */
    getCheckedIds() {
        return this.table.getCheckedIds();
    }
}