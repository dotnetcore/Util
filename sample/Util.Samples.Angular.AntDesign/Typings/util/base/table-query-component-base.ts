//================ 表格查询基类 ==================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { Injector, ViewChild, forwardRef, AfterViewInit } from '@angular/core';
import { util, ViewModel, QueryParameter, Table } from '../index';

/**
 * 表格查询基类
 */
export abstract class TableQueryComponentBase<TViewModel extends ViewModel, TQuery extends QueryParameter> implements AfterViewInit {
    /**
     * 操作库
     */
    protected util = util;
    /**
     * 查询参数
     */
    queryParam: TQuery;
    /**
     * 是否展开
     */
    expand;
    /**
     * 表格组件
     */
    @ViewChild( forwardRef( () => Table ) ) protected table: Table<TViewModel>;

    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        util.ioc.componentInjector = injector;
        this.queryParam = this.createQuery();
    }

    /**
     * 创建查询参数
     */
    protected createQuery(): TQuery {
        return <TQuery>{};
    }

    /**
     * 视图加载完成
     */
    ngAfterViewInit() {
        if ( !this.table )
            return;
        this.table.loadAfter = result => {
            this.loadAfter( result );
        }
    }

    /**
     * 数据加载完成操作
     * @param result
     */
    loadAfter( result ) {
    }

    /**
     * 查询
     * @param button 按钮
     */
    query( button?) {
        this.table.query( {
            button: button
        } );
    }

    /**
     * 延迟搜索
     * @param button 按钮
     */
    search( button?) {
        this.table.search( {
            button: button,
            delay: this.getDelay()
        } );
    }

    /**
     * 获取查询延迟间隔，单位：毫秒，默认500
     */
    protected getDelay() {
        return 500;
    }

    /**
     * 清空复选框
     */
    clearCheckboxs() {
        this.table.clearChecked();
    }

    /**
     * 删除
     * @param button 按钮
     * @param id 标识
     */
    delete( button?, id?) {
        this.table.delete( {
            button: button,
            ids: id
        } );
    }

    /**
     * 刷新
     * @param button 按钮
     */
    refresh( button?) {
        this.queryParam = this.createQuery();
        this.table.refresh( this.queryParam, button );
    }

    /**
     * 获取勾选的实体列表
     */
    getChecked() {
        return this.table.getChecked();
    }

    /**
     * 获取勾选的实体列表长度
     */
    getCheckedLength(): number {
        return this.table.getCheckedLength();
    }

    /**
     * 获取勾选的实体标识列表
     */
    getCheckedIds() {
        return this.table.getCheckedIds();
    }

    /**
     * 选中实体
     */
    select() {
        let selection = this.getChecked();
        if ( !selection || selection.length === 0 ) {
            this.util.dialog.close( new ViewModel() );
            return;
        }
        if ( selection.length === 1 ) {
            this.util.dialog.close( selection[0] );
            return;
        }
        this.util.dialog.close( selection );
    }

    /**
     * 打开创建页面弹出框
     */
    openCreateDialog() {
        this.util.dialog.open( {
            component: this.getCreateDialogComponent(),
            data: this.getCreateDialogData(),
            width: this.getCreateDialogWidth(),
            disableClose: true,
            showFooter: false,
            onBeforeClose: result => {
                return this.onCreateBeforeClose( result );
            },
            onClose: result => {
                this.onCreateClose( result );
            }
        } );
    }

    /**
     * 获取创建弹出框组件
     */
    protected getCreateDialogComponent(): any {
        return {};
    }

    /**
     * 获取创建弹出框数据
     */
    protected getCreateDialogData() {
        return {};
    }

    /**
     * 获取创建弹出框宽度
     */
    protected getCreateDialogWidth() {
        return this.getDialogWidth();
    }

    /**
     * 获取弹出框宽度，默认值：60%
     */
    protected getDialogWidth() {
        return "60%";
    }

    /**
     * 创建弹出框关闭前回调函数，返回 false 阻止关闭
     * @param result 返回结果
     */
    protected onCreateBeforeClose( result ) {
        return true;
    }

    /**
     * 创建弹出框关闭回调函数
     * @param result 返回结果
     */
    protected onCreateClose( result ) {
        this.query();
    }

    /**
     * 打开修改页面弹出框
     * @param id 标识
     */
    openEditDialog( id ) {
        this.util.dialog.open( {
            component: this.getEditDialogComponent(),
            data: this.getEditDialogData( id ),
            width: this.getEditDialogWidth(),
            disableClose: true,
            showFooter: false,
            onBeforeClose: result => {
                return this.onEditBeforeClose( result );
            },
            onClose: result => {
                this.onEditClose( result );
            }
        } );
    }

    /**
     * 获取更新弹出框组件
     */
    protected getEditDialogComponent(): any {
        return this.getCreateDialogComponent();
    }

    /**
     * 获取更新弹出框数据
     */
    protected getEditDialogData( id ) {
        return { id: id };
    }

    /**
     * 获取编辑弹出框宽度
     */
    protected getEditDialogWidth() {
        return this.getDialogWidth();
    }

    /**
     * 更新弹出框关闭前回调函数，返回 false 阻止关闭
     * @param result 返回结果
     */
    protected onEditBeforeClose( result ) {
        return true;
    }

    /**
     * 更新弹出框关闭回调函数
     * @param result 返回结果
     */
    protected onEditClose( result ) {
        this.query();
    }

    /**
     * 打开详情页面弹出框
     * @param id 标识
     */
    openDetailDialog( id ) {
        this.util.dialog.open( {
            component: this.getDetailDialogComponent(),
            data: this.getDetailDialogData( id ),
            width: this.getDetailDialogWidth(),
            showOk:false
        } );
    }

    /**
     * 获取详情弹出框组件
     */
    protected getDetailDialogComponent(): any {
        return {};
    }

    /**
     * 获取详情弹出框数据
     */
    protected getDetailDialogData( id ) {
        return this.getEditDialogData( id );
    }

    /**
     * 获取详情弹出框宽度
     */
    protected getDetailDialogWidth() {
        return this.getDialogWidth();
    }
}