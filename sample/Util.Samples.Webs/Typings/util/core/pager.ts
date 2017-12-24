/**
 * 分页参数
 */
export class Pager {
    /**
     * 页索引，即第几页
     */
    public page: number;
    /**
     * 每页显示行数
     */
    public pageSize: number;
    /**
     * 排序条件
     */
    public order: string;

    /**
     * 初始化分页参数
     */
    constructor() {
        this.page = 1;
        this.pageSize = 20;
    }
}