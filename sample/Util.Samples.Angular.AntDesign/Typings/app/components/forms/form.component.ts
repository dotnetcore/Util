import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd';
import { env } from '../../env';
import { util } from '../../../util';

/**
 * 表单组件
 */
@Component( {
    selector: 'app-components-form',
    templateUrl: !env.dev() ? './html/form.component.html' : '/View/Components/Forms/Form',
} )
export class FormComponent implements OnInit {
    /**
     * 视图模型
     */
    model;

    /**
     * 初始化
     */
    constructor( private msg: NzMessageService ) { }

    /**
     * 初始化
     */
    ngOnInit(): void {
        this.model = {};
    }

    /**
     * 提交表单
     * @param form
     */
    submit( form: NgForm ) {
        util.form.submit( {
            form: form,
            url: "/api/form",
            data: this.model,
            ok: (data) => {
                this.msg.success( `提交成功,${data.value}` );
            }
        } );
    }
}
