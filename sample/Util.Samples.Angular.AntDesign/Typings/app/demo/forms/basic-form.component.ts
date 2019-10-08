import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { ApplicationViewModel } from '../list/model/application-view-model';

/**
 * 基础表单
 */
@Component( {
    selector: 'app-basic-form',
    templateUrl: !env.dev() ? './html/basic-form.component.html' : '/View/Demo/Forms/BasicForm'
} )
export class BasicFormComponent extends EditComponentBase<ApplicationViewModel> {
    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        super( injector );
    }

    /**
     * 创建模型
     */
    createModel() {
        let result = new ApplicationViewModel();
        result.enabled = true;
        result.registerEnabled = true;
        return result;
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "application";
    }
}