import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { FormViewModel } from "./model/form-view-model";

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
export class FormComponent extends EditComponentBase<FormViewModel> {
    /**
     * 初始化
     */
    constructor( public injector: Injector ) {
        super( injector );
    }

    /**
     * 创建模型
     */
    createModel() {
        return new FormViewModel();
    }

    /**
     * 获取基地址
     */
    getBaseUrl() {
        return "form";
    }
}
