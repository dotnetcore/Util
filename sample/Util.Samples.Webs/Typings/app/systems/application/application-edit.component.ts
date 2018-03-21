import { Component, Injector } from '@angular/core';
import { CrudEditComponentBase } from '../../../util';
import { ApplicationViewModel } from './application-view-model';
import { env } from '../../env';

/**
 * 应用程序编辑页
 */
@Component({
    selector: 'application-edit',
    templateUrl: env.prod ? './application-edit.component.html' : '/view/systems/application/edit'
})
export class ApplicationEditComponent extends CrudEditComponentBase<ApplicationViewModel> {
    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 创建视图模型
     */
    protected createModel() {
        let model = new ApplicationViewModel();
        model.enabled = true;
        model.registerEnabled = true;
        return model;
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "application";
    }
}