//============== NgZorro表格包装器=======================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Component, Input, Output,OnInit, AfterContentInit, EventEmitter } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { WebApi as webapi } from '../common/webapi';
import { Message as message } from '../common/message';
import { PagerList } from '../core/pager-list';
import { IKey, QueryParameter } from '../core/model';
import { MessageConfig as config } from '../config/message-config';

/**
 * NgZorro表格包装器
 */
@Component({
    selector: 'nz-table-wrapper',
    template: `
        <ng-content></ng-content>
    `
})
export class Table<T extends IKey> implements OnInit,AfterContentInit {
    /**
     * 查询延迟
     */
    timeout;
    /**
     * 查询延迟间隔，单位：毫秒，默认500
     */
    @Input() delay: number;
    /**
     * 显示进度条
     */
    @Input() loading: boolean;
    /**
     * 首次加载
     */
    firstLoad: boolean;
    /**
     * 总行数
     */
    totalCount = 0;
    /**
     * 数据源
     */
    @Input() dataSource: any[];
    /**
     * checkbox选中列表
     */
    checkedSelection: SelectionModel<T>;
    /**
     * 点击行选中列表
     */
    selectedSelection: SelectionModel<T>;
    /**
     * 初始化时是否自动加载数据，默认为true,设置成false则手工加载
     */
    @Input() autoLoad: boolean;
    /**
     * 是否显示分页
     */
    @Input() showPagination: boolean;
    /**
     * 分页长度列表
     */
    @Input() pageSizeOptions: number[];
    /**
    * 基地址，基于该地址构建加载地址和删除地址，范例：传入test,则加载地址为/api/test,删除地址为/api/test/delete
    */
    @Input() baseUrl: string;
    /**
     * 数据加载地址，范例：/api/test
     */
    @Input() url: string;
    /**
     * 删除地址，注意：由于支持批量删除，所以采用Post提交，范例：/api/test/delete
     */
    @Input() deleteUrl: string;
    /**
     * 查询参数
     */
    @Input() queryParam: QueryParameter;
    /**
     * 初始排序字段
     */
    @Input() sortKey: string;
    /**
     * 查询参数变更事件
     */
    @Output() queryParamChange = new EventEmitter<QueryParameter>();
    /**
     * 加载完成后事件
     */
    @Output() onLoad = new EventEmitter<any>();

    /**
     * 初始化表格包装器
     */
    constructor() {
        this.queryParam = new QueryParameter();
        this.pageSizeOptions = [];
        this.showPagination = true;
        this.dataSource = new Array<any>();
        this.checkedSelection = new SelectionModel<T>(true, []);
        this.selectedSelection = new SelectionModel<T>(false, []);
        this.firstLoad = true;
        this.loading = true;
        this.autoLoad = true;
        this.delay = 500;
    }

    /**
     * 初始化
     */
    ngOnInit() {
        this.initPage();
        this.initSort();
    }

    /**
     * 初始化分页参数
     */
    private initPage() {
        this.queryParam.page = 1;
        this.queryParam.pageSize = 10;
        if ( this.pageSizeOptions && this.pageSizeOptions.length > 0 )
            this.queryParam.pageSize = this.pageSizeOptions[0];
    }

    /**
    * 初始化排序
    */
    private initSort() {
        if ( !this.sortKey )
            return;
        this.queryParam.order = this.sortKey;
    }

    /**
     * 内容加载完成操作
     */
    ngAfterContentInit() {
        if (this.autoLoad)
            this.query();
    }

    /**
     * 页索引变更事件处理
     * @param pageIndex 页索引，第一页传入的是1
     */
    pageIndexChange( pageIndex: number ) {
        this.queryParam.page = pageIndex;
        this.query();
    }

    /**
     * 分页大小变更事件处理
     * @param pageSize 分页大小
     */
    pageSizeChange( pageSize: number ) {
        this.queryParam.pageSize = pageSize;
        this.query();
    }

    /**
     * 排序
     * @param sortParam 排序参数，key为列名，value为升降序
     */
    sort( sortParam: { key: string; value: string } ): void {
        this.queryParam.order = this.getSortKey(sortParam.key, sortParam.value);
        this.query();
    }

    /**
     * 获取排序字段
     */
    private getSortKey(sortKey, sortValue) {
        if (!sortValue)
            return this.sortKey;
        if (sortValue === 'ascend')
            return sortKey;
        return `${sortKey} desc`;
    }

    /**
     * 发送查询请求
     * @param button 按钮
     * @param url 查询请求地址
     * @param param 查询参数
     */
    query(button?, url: string = null, param = null) {
        url = url || this.url || (this.baseUrl && `/api/${this.baseUrl}`);
        if (!url)
            return;
        param = param || this.queryParam;
        webapi.get<any>(url).param(param).button(button).handle({
            before: () => {
                if (this.firstLoad) {
                    this.firstLoad = false;
                    return true;
                }
                this.loading = true;
                return true;
            },
            ok: result => {
                this.loadData(result);
                this.loadAfter(result);
                this.onLoad.emit(result);
            },
            complete: () => this.loading = false
        });
    }

    /**
     * 加载数据
     */
    protected loadData(result) {
        result = new PagerList<T>(result);
        result.initLineNumbers();
        this.dataSource = result.data || [];
        this.totalCount = result.totalCount;
        this.checkedSelection.clear();
        if ( !result.totalCount )
            this.showPagination = false;
    }

    /**
     * 加载完成后操作
     * @param result
     */
    loadAfter(result) {
    }

    /**
     * 延迟搜索
     * @param button 按钮
     * @param delay 查询延迟间隔，单位：毫秒，默认500
     * @param url 查询请求地址
     * @param param 查询参数
     */
    search(button?, delay?: number, url: string = null, param = null) {
        if (this.timeout)
            clearTimeout(this.timeout);
        this.timeout = setTimeout(() => {
            this.query(url, param, button);
        }, delay || this.delay);
    }

    /**
     * 刷新
     * @param queryParam 查询参数
     * @param button 按钮
     */
    refresh(queryParam, button?) {
        this.queryParam = queryParam;
        this.queryParamChange.emit(queryParam);
        this.initPage();
        this.queryParam.order = this.sortKey;
        this.query(button);
    }

    /**
     * 表头主复选框切换选中状态
     */
    masterToggle() {
        if (this.isMasterChecked()) {
            this.checkedSelection.clear();
            return;
        }
        this.dataSource.forEach(data => this.checkedSelection.select(data));
    }

    /**
     * 表头主复选框的选中状态
     */
    isMasterChecked() {
        return this.checkedSelection.hasValue() &&
            this.isAllChecked() &&
            this.checkedSelection.selected.length >= this.dataSource.length;
    }

    /**
     * 是否所有行复选框被选中
     */
    isAllChecked() {
        return this.dataSource.every(data => this.checkedSelection.isSelected(data));
    }

    /**
     * 表头主复选框的确定状态
     */
    isMasterIndeterminate() {
        return this.checkedSelection.hasValue() && (!this.isAllChecked() || !this.dataSource.length);
    }

    /**
     * 获取复选框被选中实体列表
     */
    getChecked(): T[] {
        return this.dataSource.filter(data => this.checkedSelection.isSelected(data));
    }

    /**
     * 获取复选框被选中实体Id列表
     */
    getCheckedIds(): string {
        return this.getChecked().map((value) => value.id).join(",");
    }

    /**
     * 批量删除被选中实体
     * @param button 按钮
     * @param ids 待删除的Id列表，多个Id用逗号分隔，范例：1,2,3
     * @param handler 删除成功回调函数
     * @param url 服务端删除Api地址，如果设置了基地址baseUrl，则可以省略该参数
     */
    delete(button?, ids?: string, handler?: () => void, url?: string) {
        ids = ids || this.getCheckedIds();
        if (!ids) {
            message.warn(config.deleteNotSelected);
            return;
        }
        message.confirm(config.deleteConfirm, () => {
            this.deleteRequest(button, ids, handler, url);
        });
    }

    /**
     * 发送删除请求
     */
    private deleteRequest(button?, ids?: string, handler?: () => void, url?: string) {
        url = url || this.deleteUrl || (this.baseUrl && `/api/${this.baseUrl}/delete`);
        if (!url) {
            console.log("表格deleteUrl未设置");
            return;
        }
        webapi.post(url, ids).button(button).handle({
            ok: () => {
                if (handler) {
                    handler();
                    return;
                }
                message.success(config.deleteSuccessed);
                this.query();
            }
        });
    }

    /**
     * 选中一行
     * @param row 行
     */
    checkRow(row) {
        this.checkedSelection.clear();
        this.checkedSelection.select(row);
    }

    /**
     * 清理
     */
    clear() {
        this.dataSource = [];
        this.queryParam.page = 1;
        this.totalCount = 0;
        this.checkedSelection.clear();
    }

    /**
     * 清空复选框
     */
    clearCheckboxs() {
        this.checkedSelection.clear();
    }
}