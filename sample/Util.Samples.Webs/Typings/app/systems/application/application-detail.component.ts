import { Component, Injector } from '@angular/core';
import { EditComponentBase } from '../../../util';
import { ApplicationViewModel } from './model/application-view-model';
import { env } from '../../env';

/**
 * 应用程序详细页
 */
@Component({
    selector: 'application-detail',
    templateUrl: env.prod() ? './html/application-detail.component.html' : '/view/systems/application/detail'
})
export class ApplicationDetailComponent extends EditComponentBase<ApplicationViewModel> {
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