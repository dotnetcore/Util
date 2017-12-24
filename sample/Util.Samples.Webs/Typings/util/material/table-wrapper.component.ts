import { Component, Input, ViewChild } from '@angular/core'
import { Util as util } from '../util'
import { Pager } from '../core/pager'
import { MatTableDataSource, MatPaginator } from "@angular/material";

/**
 * Mat表格包装器
 */
@Component({
    selector: 'table-wrapper',
    template: `
    <div class="example-container mat-elevation-z8">
        <div class="example-loading-shade" *ngIf="loading">
            <mat-spinner *ngIf="loading"></mat-spinner>
            <div class="example-rate-limit-reached" *ngIf="loading"></div>
        </div>
        <ng-content></ng-content>
        <mat-paginator [length]="totalCount" [pageSizeOptions]="[10,20,50,100,200,500]"></mat-paginator>
    </div>
`,
    styles: [`
/* Structure */
.example-container {
  display: flex;
  flex-direction: column;
  max-height: 500px;
  min-width: 300px;
  position: relative;
}
.example-loading-shade {
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
export class TableWrapperComponent {
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
        this.paginator.pageSize = this.queryParam.pageSize;
        this.paginator.page.subscribe(() => {
            this.queryParam.page = this.paginator.pageIndex + 1;
            this.queryParam.pageSize = this.paginator.pageSize;
            this.query();
        });
        this.query();
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