import { Component, Input, ViewChild, OnInit } from '@angular/core';
import { Util as util } from '../util';
import { Pager } from '../core/pager';
import { MatTableDataSource, MatPaginator, MatPaginatorIntl } from '@angular/material';

/**
 * 创建分页本地化提示
 */
function createMatPaginatorIntl() {
    var result = new MatPaginatorIntl();
    result.itemsPerPageLabel = "每页显示";
    result.nextPageLabel = "下一页";
    result.previousPageLabel = "上一页";
    result.getRangeLabel = (page: number, pageSize: number, length: number) => {
        if (length == 0 || pageSize == 0) { return `0`; }
        length = Math.max(length, 0);
        const startIndex = page * pageSize;
        const endIndex = startIndex < length ? Math.min(startIndex + pageSize, length) : startIndex + pageSize;
        return `当前显示：${startIndex + 1} - ${endIndex}，总行数: ${length}`;
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
        <div class="table-container mat-elevation-z8">
            <div class="table-loading-shade" *ngIf="loading">
                <mat-spinner *ngIf="loading"></mat-spinner>
                <div class="example-rate-limit-reached" *ngIf="loading"></div>
            </div>
            <ng-content></ng-content>
            <mat-paginator [length]="totalCount" [pageSizeOptions]="[10,20,50,100,200,500]"></mat-paginator>
        </div>
    `,
    styles: [`
        .table-container {
          display: flex;
          flex-direction: column;
          max-height: 500px;
          min-width: 300px;
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
        .example-rate-limit-reached {
          color: #980000;
          max-width: 360px;
          text-align: center;
        }
    `]
})
export class TableWrapperComponent implements OnInit {
    /**
     * 数据源
     */
    public dataSource: MatTableDataSource<any>;
    /**
     * 显示进度条
     */
    private loading: boolean;
    /**
     * 请求地址
     */
    @Input() url: string;
    /**
     * 查询参数
     */
    @Input() queryParam: Pager;
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
        this.dataSource = new MatTableDataSource();
        this.loading = false;
    }
    /**
     * 
     */
    ngOnInit() {
        this.initPaginator();
        this.query();
    }

    /**
     * 初始化分页组件
     */
    private initPaginator() {
        this.paginator.pageSize = this.queryParam.pageSize;
        this.paginator.page.subscribe(() => {
            this.queryParam.page = this.paginator.pageIndex + 1;
            this.queryParam.pageSize = this.paginator.pageSize;
            this.query();
        });
    }

    /**
     * 发送查询请求
     */
    query() {
        util.http.post<any>(this.url).body(this.queryParam)
            .handle(t => {
                this.dataSource.data = t.data.data;
                this.totalCount = t.data.totalCount;

            }, e => {

            }, () => {
                this.loading = true;
                return true;
            }, () => {
                this.loading = false;
            });
    }
}