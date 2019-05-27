import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { FormViewModel } from "./model/form-view-model";

/**
 * 表单组件
 */
@Component( {
    selector: 'app-components-form',
    templateUrl: !env.dev() ? './html/form.component.html' : '/View/Components/Forms/Form'
} )
export class FormComponent extends EditComponentBase<any> {
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
        return {};
    }

    /**
     * 获取基地址
     */
    getBaseUrl() {
        return "form";
    }
}
