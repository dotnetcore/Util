import { Component, Input, ViewChild, OnInit, ContentChild } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatPaginatorIntl, MatSort } from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';
import { WebApi as webapi } from "../common/webapi";
import { Message as message } from "../common/message";
import { PagerList } from '../core/pager-list';
import { ViewModel } from '../core/view-model';
import { QueryParameter } from '../core/query-parameter';
import { MessageConfig as config } from "../config/message-config";

/**
 * 创建分页本地化提示
 */
function createMatPaginatorIntl() {
    let result = new MatPaginatorIntl();
    result.itemsPerPageLabel = "每页";
    result.nextPageLabel = "下一页";
    result.previousPageLabel = "上一页";
    result.getRangeLabel = (page: number, pageSize: number, length: number) => {
        if (length == 0 || pageSize == 0) { return `0`; }
        length = Math.max(length, 0);
        const startIndex = page * pageSize;
        const endIndex = startIndex < length ? Math.min(startIndex + pageSize, length) : startIndex + pageSize;
        return `当前：${startIndex + 1} - ${endIndex}，共: ${length}`;
    };
    return result;
}

/**
 * Mat表格包装器
 */
@Component({
    selector: 'table-wrapper',
    providers: [{ provide: MatPaginatorIntl, useFactory: createMatPaginatorIntl }],
    template: `  
        <div class="table-container mat-elevation-z8" [ngStyle]="getStyle()">
            <div class="table-loading-shade" *ngIf="loading">
                <mat-spinner></mat-spinner>
            </div>
            <ng-content></ng-content>
            <mat-paginator [length]="totalCount" [pageSizeOptions]="pageSizeItems"></mat-paginator>
        </div>
    `,
    styles: [`
        .table-container {
            display: flex;
            flex-direction: column;
            position: relative;
        }
        .table-loading-shade {
            position: absolute;
            top: 0;
            left: 0;
            bottom: 56px;
            right: 0;
            background: rgba(0, 0, 0, 0.15);
            z-index: 1;
            display: flex;
            align-items: center;
            justify-content: center;
        }
        ::ng-deep .mat-table {
            overflow: auto;
        }
        ::ng-deep .table-header {
            min-height: 64px;
            padding: 8px 24px 0;
            z-index: 100;
        }
        ::ng-deep .mat-form-field {
            width: 100%;
        }
    `]
})
export class TableWrapperComponent<T extends ViewModel> implements OnInit {
    /**
     * 显示进度条
     */
    private loading: boolean;
    /**
     * 总行数
     */
    private totalCount = 0;
    /**
     * 是否自动加载，默认在初始化时自动加载数据，设置成false则手工加载
     */
    @Input() autoLoad: boolean;
    /**
     * 最大高度
     */
    @Input() maxHeight: number;
    /**
     * 最小高度
     */
    @Input() minHeight: number;
    /**
     * 最小宽度
     */
    @Input() minWidth: number;
    /**
     * 宽度
     */
    @Input() width: number;
    /**
     * 分页长度列表
     */
    @Input() pageSizeItems: number[];
    /**
    * 基地址，基于该地址构建请求和删除地址，范例：传入test,则请求地址为/api/test,删除地址为/api/test/delete
    */
    @Input() baseUrl: string;
    /**
     * 请求地址，如果设置了基地址baseUrl，则可以省略该参数
     */
    @Input() url: string;
    /**
     * 查询参数
     */
    @Input() queryParam: QueryParameter;
    /**
     * 数据源
     */
    dataSource: MatTableDataSource<T>;
    /**
     * 选中列表
     */
    selection = new SelectionModel<T>(true, []);
    /**
     * 排序组件
     */
    @ContentChild(MatSort) sort: MatSort;
    /**
     * 分页组件
     */
    @ViewChild(MatPaginator) paginator: MatPaginator;

    /**
     * 初始化Mat表格包装器
     */
    constructor() {
        this.maxHeight = 500;
        this.minHeight = 300;
        this.minWidth = 300;
        this.pageSizeItems = [20, 50, 100, 200, 500];
        this.dataSource = new MatTableDataSource<T>();
        this.loading = false;
        this.autoLoad = true;
    }

    /**
     * 组件初始化
     */
    ngOnInit() {
        this.initPaginator();
        this.initSort();
        if (this.autoLoad)
            this.init();
    }

    /**
     * 初始化分页组件
     */
    private initPaginator() {
        this.paginator.page.subscribe(() => {
            this.queryParam.page = this.paginator.pageIndex + 1;
            this.queryParam.pageSize = this.paginator.pageSize;
            this.query();
        });
    }

    /**
    * 初始化排序组件
    */
    private initSort() {
        this.sort.sortChange.subscribe(() => {
            this.queryParam.order = `${this.sort.active} ${this.sort.direction}`;
            this.query();
        });
    }

    /**
     * 初始化
     */
    init() {
        this.queryParam.page = 1;
        if (this.pageSizeItems && this.pageSizeItems.length > 0)
            this.queryParam.pageSize = this.pageSizeItems[0];
        this.query();
    }

    /**
     * 刷新表格
     */
    refresh() {
        this.query();
    }

    /**
     * 发送查询请求
     */
    query() {
        let url = this.url || `/api/${this.baseUrl}`;
        webapi.get<PagerList<T>>(url).param(this.queryParam).handle({
            beforeHandler: () => { this.loading = true; return true; },
            handler: result => {
                result = new PagerList<T>(result);
                result.initLineNumbers();
                this.dataSource.data = result.data;
                this.paginator.pageIndex = result.page - 1;
                this.totalCount = result.totalCount;
                this.selection.clear();
            },
            completeHandler: () => this.loading = false
        });
    }

    /**
     * 获取样式
     */
    private getStyle() {
        return {
            'max-height': `${this.maxHeight}px`,
            'min-width': `${this.minWidth}px`,
            'width': this.width ? `${this.width}px` : null
        };
    }

    /**
     * 表头主复选框切换选中状态
     */
    masterToggle() {
        if (this.isMasterChecked()) {
            this.selection.clear();
            return;
        }
        this.dataSource.data.forEach(data => this.selection.select(data));
    }

    /**
     * 表头主复选框的选中状态
     */
    isMasterChecked() {
        return this.selection.hasValue() &&
            this.isAllSelected() &&
            this.selection.selected.length >= this.dataSource.data.length;
    }

    /**
     * 是否所有行复选框被选中
     */
    private isAllSelected() {
        return this.dataSource.data.every(data => this.selection.isSelected(data));
    }

    /**
     * 表头主复选框的确定状态
     */
    isMasterIndeterminate() {
        return this.selection.hasValue() && (!this.isAllSelected() || !this.dataSource.data.length);
    }

    /**
     * 获取被选中实体列表
     */
    getSelected(): T[] {
        return this.dataSource.data.filter(data => this.selection.isSelected(data));
    }

    /**
     * 获取被选中实体Id列表
     */
    getSelectedIds(): string {
        return this.getSelected().map((value) => value.id).join(",");
    }

    /**
     * 批量删除被选中实体
     * @param handler 删除成功回调函数
     * @param deleteUrl 服务端删除Api地址，如果设置了基地址baseUrl，则可以省略该参数
     */
    delete(handler?: () => {}, deleteUrl?: string) {
        let ids = this.getSelectedIds();
        if (!ids) {
            message.warn(config.deleteNotSelected);
            return;
        }
        message.confirm(config.deleteConfirm, () => {
            this.deleteRequest(ids, handler, deleteUrl);
        });
    }

    /**
     * 发送删除请求
     */
    private deleteRequest(ids: string, handler?: () => {}, deleteUrl?: string) {
        deleteUrl = deleteUrl || `/api/${this.baseUrl}/delete`;
        webapi.post(deleteUrl, ids).handle({
            handler: () => {
                if (handler) {
                    handler();
                    return;
                }
                message.success(config.deleteSuccessed);
                this.refresh();
            }
        });
    }
}