//============== Crud弹出层编辑组件基类===============
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { Injector, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ViewModel } from "../core/model";
import { EditComponentBase } from "./edit-component-base";

/**
 * Crud弹出层编辑组件基类
 */
export abstract class DialogEditComponentBase<TViewModel extends ViewModel> extends EditComponentBase<TViewModel> implements OnInit {
    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        super( injector );
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
            closeDialog: true,
            before: data => this.submitBefore( data ),
            ok: result => this.submitAfter( result )
        } );
    }

    /**
     * 提交前操作
     * @param data 参数
     */
    protected submitBefore( data ) {
        return true;
    }

    /**
     * 提交后操作
     * @param result 结果
     */
    protected submitAfter( result ) {
    }
}