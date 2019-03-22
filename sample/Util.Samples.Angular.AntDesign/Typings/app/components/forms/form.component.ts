import { Component, OnInit,Injector } from '@angular/core';
import { NgForm } from '@angular/forms';
import { env } from '../../env';
import { FormComponentBase } from '../../../util';

/**
 * 表单组件
 */
@Component( {
    selector: 'app-components-form',
    templateUrl: !env.dev() ? './html/form.component.html' : '/View/Components/Forms/Form',
} )
export class FormComponent extends FormComponentBase implements OnInit {
    /**
     * 视图模型
     */
    model;

    /**
     * 初始化
     */
    constructor( public injector: Injector ) {
        super( injector );
    }

    /**
     * 初始化
     */
    ngOnInit() {
        this.model = {};
    }

    /**
     * 提交表单
     * @param form
     */
    submit( form: NgForm ) {
        this.util.form.submit( {
            form: form,
            url: "/api/form",
            data: this.model,
            confirm: "Hello World"
        } );
    }

    info() {
        this.util.message.info("嘿嘿");
    }
}
