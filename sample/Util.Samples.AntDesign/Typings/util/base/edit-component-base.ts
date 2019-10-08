//============== Crud编辑组件基类===============
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { Injector, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { util, ViewModel } from '../index';
import { FormComponentBase } from './form-component-base';

/**
 * Crud编辑组件基类
 */
export abstract class EditComponentBase<TViewModel extends ViewModel> extends FormComponentBase implements OnInit {
    /**
     * 操作库
     */
    protected util = util;
    /**
     * 参数
     */
    model: TViewModel;
    /**
     * 是否创建
     */
    isNew: boolean;
    /**
     * 标识
     */
    @Input() id;
    /**
     * 数据
     */
    @Input() data;

    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        super( injector );
        this.isNew = true;
        this.model = this.createModel();
    }

    /**
     * 创建参数
     */
    protected createModel(): TViewModel {
        return <TViewModel>{};
    }

    /**
     * 初始化
     */
    ngOnInit() {
        this.loadById();
    }

    /**
     * 通过标识加载
     */
    protected loadById( id = null ) {
        if ( this.isRequestLoad() === false && this.data ) {
            this.loadModel( this.data );
            return;
        }
        id = id || this.id || this.util.router.getParam( "id" );
        if ( !id )
            return;
        this.util.webapi.get<TViewModel>( this.getByIdUrl( id ) ).handle( {
            ok: result => {
                this.loadModel( result );
            }
        } );
    }

    /**
     * 加载模型
     */
    private loadModel( data ) {
        let result = this.loadBefore( data );
        this.isNew = false;
        this.model = result;
        this.loadAfter( result );
    }

    /**
     * 是否发送请求进行加载
     */
    protected isRequestLoad() {
        return true;
    }

    /**
     * 加载完成前操作
     */
    protected loadBefore( result ) {
        return result;
    }

    /**
     * 加载完成后操作
     */
    protected loadAfter( result ) {
    }

    /**
     * 获取基地址
     */
    protected abstract getBaseUrl();

    /**
     * 获取单个实体地址
     * @param id 标识
     */
    protected getByIdUrl( id ) {
        return util.helper.getUrl( this.getBaseUrl(), id );
    }

    /**
     * 提交表单
     * @param form 表单
     * @param button 按钮
     */
    submit( form?: NgForm, button?) {
        this.util.form.submit( {
            url: this.getSubmitUrl(),
            data: this.model,
            form: form,
            button: button,
            back: true
        } );
    }

    /**
     * 获取提交地址
     */
    protected getSubmitUrl() {
        return util.helper.getUrl( this.getBaseUrl() );
    }

    /**
     * 返回
     */
    back() {
        this.util.router.back();
    }

    /**
     * 关闭弹出框
     */
    close() {
        this.util.dialog.close();
    }
}