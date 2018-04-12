import { Component, Injector } from '@angular/core';
import { CrudEditComponentBase } from '../../../util';
import { ApplicationViewModel } from './model/application-view-model';
import { env } from '../../env';

/**
 * 应用程序编辑页
 */
@Component({
    selector: 'application-edit',
    templateUrl: env.prod() ? './html/application-edit.component.html' : '/view/systems/application/edit'
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
        return new ApplicationViewModel();
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "application";
    }
}