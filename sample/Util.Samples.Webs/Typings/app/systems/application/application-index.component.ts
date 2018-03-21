import { Component, Injector } from '@angular/core';
import { CrudIndexComponentBase } from '../../../util';
import { ApplicationQuery } from './application-query';
import { ApplicationViewModel } from './application-view-model';
import { env } from '../../env';

/**
 * 应用程序首页
 */
@Component({
    selector: 'application-index',
    templateUrl: env.prod ? './application-index.component.html' : '/view/systems/application'
})
export class ApplicationIndexComponent extends CrudIndexComponentBase<ApplicationViewModel, ApplicationQuery>  {
    /**
     * 初始化应用程序首页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 创建查询参数
     */
    protected createQuery() {
        return new ApplicationQuery();
    }
}