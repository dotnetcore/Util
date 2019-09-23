//============== NgZorro表格包装器=======================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Component, Input, Output, OnInit, EventEmitter } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { Util as util } from "../util";
import { QueryParameter, IKey } from "../core/model";
import { PagerList } from "../core/pager-list";
import { MessageConfig as config } from '../config/message-config';

/**
 * NgZorro表格包装器
 */
@Component( {
    selector: 'nz-table-wrapper',
    template: `
        <ng-content></ng-content>
    `
} )
export class Table<T extends IKey> implements OnInit {
    /**
     * 总行数
     */
    totalCount = 0;
    /**
     * checkbox选中列表
     */
    checkedSelection: SelectionModel<T>;
    /**
     * 点击行选中列表
     */
    selectedSelection: SelectionModel<T>;
    /**
     * 是否多选，以复选框进行多选，否则以单选框选择，默认为true
     */
    @Input() multiple;
    /**
     * 查询延迟
     */
    @Input() timeout;
    /**
     * 查询延迟间隔，单位：毫秒，默认500
     */
    @Input() delay: number;
    /**
     * 显示进度条
     */
    @Input() loading: boolean;
    /**
     * 数据源
     */
    @Input() dataSource: any[];
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
     * 复选框选中的标识列表
     */
    @Input() checkedKeys: string | string[];
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
        this.dataSource = new Array<any>();
        this.checkedSelection = new SelectionModel<T>( true, [] );
        this.selectedSelection = new SelectionModel<T>( false, [] );
        this.pageSizeOptions = [];
        this.showPagination = true;
        this.autoLoad = true;
        this.multiple = true;
        this.delay = 500;
    }

    /**
     * 初始化
     */
    ngOnInit() {
        this.initPage();
        this.initSort();
        if ( this.autoLoad )
            this.query();
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
     * 发送查询请求
     * @param options 配置
     */
    query( options?: {
        /**
         * 按钮
         */
        button?,
        /**
         * 请求地址
         */
        url?: string,
        /**
         * 查询参数
         */
        param?,
        /**
         * 页数
         */
        pageIndex?,
        /**
         * 成功回调函数
         */
        handler?: ( result ) => void;
    } ) {
        options = options || {};
        let url = options.url || this.url || util.helper.getUrl( this.baseUrl );
        if ( !url )
            return;
        let param = options.param || this.queryParam;
        if ( options.pageIndex )
            param.page = options.pageIndex;
        util.webapi.get<any>( url ).param( param ).button( options.button ).handle( {
            before: () => {
                this.loading = true;
                return true;
            },
            ok: result => {
                this.loadData( result );
                options.handler && options.handler( result );
                this.loadAfter( result );
                this.onLoad.emit( result );
            },
            complete: () => this.loading = false
        } );
    }

    /**
     * 加载数据
     */
    protected loadData( result ) {
        result = new PagerList<T>( result );
        result.initLineNumbers();
        this.dataSource = result.data || [];
        this.totalCount = result.totalCount;
        this.checkedSelection.clear();
        this.checkIds( this.checkedKeys );
    }

    /**
     * 加载完成后操作
     * @param result
     */
    loadAfter( result ) {
    }

    /**
     * 延迟搜索
     * @param options 配置
     */
    search( options?: {
        /**
         * 按钮
         */
        button?,
        /**
         * 查询延迟间隔，单位：毫秒，默认500
         */
        delay?: number,
        /**
         * 请求地址
         */
        url?: string,
        /**
         * 查询参数
         */
        param?: null;
    } ) {
        options = options || {};
        let delay = options.delay || this.delay;
        if ( this.timeout )
            clearTimeout( this.timeout );
        this.timeout = setTimeout( () => {
            this.query( {
                button: options.button,
                url: options.url,
                param: options.param
            } );
        }, delay );
    }

    /**
     * 刷新
     * @param queryParam 查询参数
     * @param button 按钮
     * @param handler 刷新成功回调函数
     */
    refresh( queryParam, button?, handler?: ( result ) => void ) {
        this.clear();
        this.queryParam = queryParam;
        this.queryParamChange.emit( queryParam );
        this.initPage();
        this.queryParam.order = this.sortKey;
        this.query( {
            button: button,
            handler: handler
        } );
    }

    /**
     * 批量删除被选中实体
     * @param options 参数
     */
    delete( options?: {
        /**
         * 按钮
         */
        button?,
        /**
         * 待删除的Id列表，多个Id用逗号分隔，范例：1,2,3
         */
        ids?: string,
        /**
         * 服务端删除Api地址
         */
        url?: string,
        /**
         * 删除成功回调函数
         */
        handler?: () => void;
    } ) {
        options = options || {};
        let ids = options.ids || this.getCheckedIds();
        if ( !ids ) {
            util.message.warn( config.deleteNotSelected );
            return;
        }
        util.message.confirm( config.deleteConfirm, () => {
            this.deleteRequest( options.button, ids, options.handler, options.url );
        } );
    }

    /**
     * 发送删除请求
     */
    private deleteRequest( button?, ids?: string, handler?: () => void, url?: string ) {
        url = url || this.deleteUrl || util.helper.getUrl( this.baseUrl,"delete" );
        if ( !url ) {
            console.log( "表格deleteUrl未设置" );
            return;
        }
        util.webapi.post( url, ids ).button( button ).handle( {
            ok: () => {
                util.message.success( config.deleteSuccessed );
                this.query( {
                    handler: result => {
                        if ( result.page <= 1 ) {
                            handler && handler();
                            return;
                        }
                        if ( result.page > result.pageCount ) {
                            this.query( {
                                pageIndex: result.page - 1,
                                handler: () => {
                                    handler && handler();
                                }
                            } );
                            return;
                        }
                        handler && handler();
                    }
                } );
            }
        } );
    }

    /**
     * 获取勾选的实体列表
     */
    getChecked(): T[] {
        return this.dataSource.filter( data => this.checkedSelection.isSelected( data ) );
    }

    /**
     * 获取勾选的实体列表
     */
    getCheckedNodes(): T[] {
        return this.getChecked();
    }

    /**
     * 获取勾选的实体列表长度
     */
    getCheckedLength(): number {
        return this.getChecked().length;
    }

    /**
     * 获取勾选的实体标识列表
     */
    getCheckedIds(): string {
        return this.getChecked().map( value => value.id ).join( "," );
    }

    /**
     * 获取勾选的单个节点
     */
    getCheckedNode(): T {
        let list = this.getChecked();
        if ( !list || list.length === 0 )
            return null;
        return list[0];
    }

    /**
     * 通过标识列表查找
     * @param ids 标识列表
     */
    getByIds( ids: string[] ): T[] {
        if ( !ids || ids.length === 0 )
            return [];
        return this.dataSource.filter( item => ids.some( id => id === item.id ) );
    }

    /**
     * 通过标识查找
     * @param id 标识
     */
    getById( id: string ): T {
        if ( !id )
            return null;
        return this.dataSource.find( data => data.id === id );
    }

    /**
     * 仅勾选一行
     */
    checkRowOnly( row ) {
        this.clearChecked();
        this.checkRow( row );
    }

    /**
     * 勾选一行
     */
    checkRow( row ) {
        this.checkedSelection.select( row );
    }

    /**
     * 切换勾选状态
     */
    toggleRow( row ) {
        this.checkedSelection.toggle( row );
    }

    /**
     * 勾选标识列表
     */
    checkIds( ids ) {
        if ( !ids )
            return;
        if ( !ids.some ) {
            let item = this.dataSource.find( data => data.id === ids );
            this.checkedSelection.select( item );
            return;
        }
        let list = this.dataSource.filter( data => ids.indexOf( data.id ) > -1 );
        list.forEach( item => {
            if ( this.checkedSelection.isSelected( item ) )
                return;
            this.checkedSelection.select( item );
        } );
    }

    /**
     * 清空勾选的行
     */
    clearChecked() {
        this.checkedSelection.clear();
    }

    /**
     * 仅选中一行
     */
    selectRowOnly( row ) {
        this.clearSelected();
        this.selectRow( row );
    }

    /**
     * 单击选中一行
     */
    selectRow( row ) {
        this.selectedSelection.select( row );
    }

    /**
     * 清空选中的行
     */
    clearSelected() {
        this.selectedSelection.clear();
    }

    /**
     * 是否被选中
     * @param row 行
     */
    isSelected( row ) {
        return this.selectedSelection.isSelected( row );
    }

    /**
     * 清理
     */
    clear() {
        this.dataSource = [];
        this.queryParam.page = 1;
        this.totalCount = 0;
        this.checkedSelection.clear();
        this.selectedSelection.clear();
        this.checkedKeys = null;
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
    sort( sortParam: { key: string; value: string } ) {
        this.queryParam.order = this.getSortKey( sortParam.key, sortParam.value );
        this.query();
    }

    /**
     * 获取排序字段
     */
    private getSortKey( sortKey, sortValue ) {
        if ( !sortValue )
            return this.sortKey;
        if ( sortValue === 'ascend' )
            return sortKey;
        return `${sortKey} desc`;
    }

    /**
     * 表头主复选框切换选中状态
     */
    masterToggle() {
        if ( this.isMasterChecked() ) {
            this.checkedSelection.clear();
            return;
        }
        this.dataSource.forEach( data => this.checkedSelection.select( data ) );
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
        return this.dataSource.every( data => this.checkedSelection.isSelected( data ) );
    }

    /**
     * 表头主复选框的确定状态
     */
    isMasterIndeterminate() {
        return this.checkedSelection.hasValue() && ( !this.isAllChecked() || !this.dataSource.length );
    }

    /**
     * 添加行
     * @param row 行
     */
    addRow( row ) {
        if ( !row )
            return;
        if ( this.dataSource.some( t => t.id === row.id ) )
            return;
        this.dataSource = [row, ...this.dataSource];
        this.totalCount = this.totalCount + 1;
        this.initLineNumbers( this.dataSource );
    }

    /**
     * 初始化行号
     */
    private initLineNumbers( data ) {
        let result = new PagerList<T>( data, this.queryParam.page, this.queryParam.pageSize );
        result.initLineNumbers();
    }

    /**
     * 移除行
     * @param ids 行标识列表
     */
    removeRows( ids?: string[] ) {
        if ( !ids || ids.length === 0 )
            ids = this.getChecked().map( value => value.id );
        if ( !ids || ids.length === 0 ) {
            util.message.warn( config.deleteNotSelected );
            return null;
        }
        let result = util.helper.remove( this.dataSource, row => ids.findIndex( id => row.id === id ) > -1 );
        this.dataSource = [...this.dataSource];
        this.totalCount = this.totalCount - result.length;
        this.initLineNumbers( this.dataSource );
        this.checkedSelection.deselect( ...result );
        return result;
    }
}