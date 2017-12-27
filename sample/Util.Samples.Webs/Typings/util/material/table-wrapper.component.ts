import { Component, Input, ViewChild, OnInit,ContentChild } from '@angular/core';
import { Util as util } from '../util';
import { QueryParameter } from "../core/query-parameter";
import { PagerList } from '../core/pager-list';
import { MatTableDataSource, MatPaginator, MatPaginatorIntl ,MatSort} from '@angular/material';

/**
 * 创建分页本地化提示
 */
function createMatPaginatorIntl() {
    let result = new MatPaginatorIntl();
    result.itemsPerPageLabel = "每页显示";
    result.nextPageLabel = "下一页";
    result.previousPageLabel = "上一页";
    result.getRangeLabel = (page: number, pageSize: number, length: number) => {
        if (length == 0 || pageSize == 0) { return `0`; }
        length = Math.max(length, 0);
        const startIndex = page * pageSize;
        const endIndex = startIndex < length ? Math.min(startIndex + pageSize, length) : startIndex + pageSize;
        return `当前显示：${startIndex + 1} - ${endIndex}，总数: ${length}`;
    };
    return result;
}

/**
 * Mat表格包装器
 */
@Component({
    selector: 'table-wrapper',
    providers: [{ provide: MatPaginatorIntl, useFactory: createMatPaginatorIntl }],
    template:`
        <style>
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
        </style>
        <div class="table-container mat-elevation-z8" [ngStyle]="getStyle()">
            <div class="table-loading-shade" *ngIf="loading">
                <mat-spinner></mat-spinner>
            </div>
            <ng-content></ng-content>
            <mat-paginator [length]="totalCount" [pageSizeOptions]="pageSizeItems"></mat-paginator>
        </div>
    `
})
export class TableWrapperComponent<T> implements OnInit {
    /**
     * 数据源
     */
    public dataSource: MatTableDataSource<T>;
    /**
     * 显示进度条
     */
    private loading: boolean;
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
     * 请求地址
     */
    @Input() url: string;
    /**
     * 查询参数
     */
    @Input() queryParam: QueryParameter;
    /**
     * 分页组件
     */
    @ViewChild(MatPaginator) paginator: MatPaginator;
    /**
     * 总行
     */
    private totalCount = 0;

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
     * 组件初始化
     */
    ngOnInit() {
        this.initPaginator();
        this.initSort();
        this.initTable();
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
     * 初始化表格
     */
    private initTable() {
        if (this.pageSizeItems && this.pageSizeItems.length > 0)
            this.queryParam.pageSize = this.pageSizeItems[0];
        this.query();
    }

    /**
     * 发送查询请求
     */
    query() {
        util.webapi.get<PagerList<T>>(this.url).data(this.queryParam).handle({
            beforeHandler: () => { this.loading = true; return true; },
            handler: result => {
                //行号
                for (var i = 0; i < result.data.data.length; i++) {
                    let line = ((((result.data.page - 1) * result.data.pageSize)) + i + 1);
                    result.data.data[i]["lineNumber"] = line;
                }
                this.dataSource.data = result.data.data;
                this.totalCount = result.data.totalCount;
            },
            completeHandler: () => this.loading = false
        });
    }

    //排序
    @ContentChild(MatSort) sort: MatSort;
    /**
    * 初始化排序组件
    */
    private initSort() {
        this.sort.sortChange.subscribe(() => {
            this.queryParam.order = `${this.sort.active} ${this.sort.direction}`;
            this.query();
        });
    }

    isAllSelected() {
        //const numSelected = this.selection.selected.length;
        //const numRows = this.dataSource.data.length;
        //return numSelected === numRows;
    }

    /** Selects all rows if they are not all selected; otherwise clear selection. */
    masterToggle() {
        //this.isAllSelected() ?
        //    this.selection.clear() :
        //    this.dataSource.data.forEach(row => this.selection.select(row));
    }
}