import { Component, Injector, OnInit } from '@angular/core';
import { ComponentBase,PagerList } from '../../../util';
import { RoleQuery } from './model/role-query';
import { RoleViewModel } from './model/role-view-model';
import { env } from '../../env';

/**
 * 角色首页
 */
@Component({
    selector: 'role-index',
    templateUrl: env.prod() ? './html/role-index.component.html' : '/view/systems/role'
})
export class RoleIndexComponent extends ComponentBase implements OnInit {
    /**
     * 角色列表
     */
    models: RoleViewModel[];
    /**
     * 角色查询参数
     */
    query: RoleQuery;
    /**
     * 选中的角色列表
     */
    selectedModels: RoleViewModel[];
    /**
     * 初始化角色首页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
        this.models = new Array<RoleViewModel>();
        this.query = new RoleQuery();
    }

    /**
     * 初始化
     */
    ngOnInit(): void {
    }

    /**
     * 创建查询参数
     */
    protected createQuery() {
        return new RoleQuery();
    }
}