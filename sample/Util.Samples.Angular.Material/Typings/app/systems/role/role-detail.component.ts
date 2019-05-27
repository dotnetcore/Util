import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { RoleViewModel } from './model/role-view-model';

/**
 * 角色详细
 */
@Component({
    selector: 'role-detail',
    templateUrl: env.prod() ? './html/role-detail.component.html' : '/view/systems/role/detail'
})
export class RoleDetailComponent extends EditComponentBase<RoleViewModel> {
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
        return new RoleViewModel();
    }

    /**
     * 获取基地址
     */
    protected getBaseUrl() {
        return "role";
    }
}