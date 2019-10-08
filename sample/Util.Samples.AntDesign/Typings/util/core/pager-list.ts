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
     * @param page 页索引
     * @param pageSize 每页显示行数
     * @param totalCount 总行数
     * @param pageCount 总页数
     */
    constructor( list?, page?: number, pageSize?: number, totalCount?: number, pageCount?:number) {
        if ( !list )
            return;
        this.page = page || list.page || 1;
        this.pageSize = pageSize || list.pageSize || list.length;
        this.totalCount = totalCount || list.totalCount;
        this.pageCount = pageCount || list.pageCount;
        this.order = list.order;
        this.data = list.data || list;
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
    initLineNumbers() {
        if ( !this.data )
            return;
        for ( let i = 0; i < this.data.length; i++ ) {
            let line = ( this.page - 1 ) * this.pageSize + i + 1;
            this.data[i]["lineNumber"] = line;
        }
    }
}