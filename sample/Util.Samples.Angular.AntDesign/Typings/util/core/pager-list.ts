//============== 分页集合=========================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
/**
 * 分页列表
 */
export class PagerList<T> {
    /**
     * 初始化分页列表
     * @param list 列表
     */
    constructor( list?) {
        if ( !list )
            return;
        if ( !list.totalCount && !list.pageSize ) {
            this.page = 1;
            this.pageSize = list.length;
            this.data = list;
            return;
        }
        this.page = list.page;
        this.pageSize = list.pageSize;
        this.totalCount = list.totalCount;
        this.pageCount = list.pageCount;
        this.order = list.order;
        this.data = list.data;
    }

    /**
     * 页索引，即第几页
     */
    page: number;
    /**
     * 每页显示行数
     */
    pageSize: number;
    /**
     * 总行数
     */
    totalCount: number;
    /**
     * 总页数
     */
    pageCount: number;
    /**
     * 排序条件
     */
    order: string;
    /**
     * 数据
     */
    data: T[];

    /**
     * 初始化行号
     */
    initLineNumbers(): void {
        if ( !this.data )
            return;
        for ( let i = 0; i < this.data.length; i++ ) {
            let line = ( this.page - 1 ) * this.pageSize + i + 1;
            this.data[i]["lineNumber"] = line;
        }
    }
}