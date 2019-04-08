import { Component, Injector } from '@angular/core';
import { NgForm } from '@angular/forms';
import { env } from '../../env';
import { ComponentBase } from '../../../util';
import { FormViewModel } from "./model/form-view-model";
import { NzMessageService, UploadFile } from 'ng-zorro-antd';
import { Observable, Observer } from 'rxjs';

/**
 * 表单组件
 */
@Component( {
    selector: 'app-components-form',
    templateUrl: !env.dev() ? './html/form.component.html' : '/View/Components/Forms/Form',
    styles: [`
      .avatar {
        width: 128px;
        height: 128px;
      }
      .upload-icon {
        font-size: 32px;
        color: #999;
      }
      .ant-upload-text {
        margin-top: 8px;
        color: #666;
      }
    `]
} )
export class FormComponent extends ComponentBase {
    /**
     * 视图模型
     */
    model: FormViewModel;

    /**
     * 初始化
     */
    constructor( public injector: Injector, private msg: NzMessageService ) {
        super( injector );
        this.model = new FormViewModel();
    }

    /**
     * 提交表单
     * @param form
     */
    submit( form: NgForm, btn ) {
        this.util.form.submit( {
            form: form,
            button: btn,
            url: "/api/form",
            data: this.model
        } );
    }
}
