import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { TreeTableQueryComponentBase, TreeTable } from '../../../util';
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
export class RoleIndexComponent extends TreeTableQueryComponentBase<RoleViewModel, RoleQuery> implements OnInit {
    /**
     * 角色查询参数
     */
    queryParam: RoleQuery;
    /**
     * 表格组件
     */
    @ViewChild(TreeTable) protected table: TreeTable<RoleViewModel>;

    /**
     * 初始化角色首页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
        this.queryParam = new RoleQuery();
    }

    /**
     * 创建查询参数
     */
    protected createQuery() {
        return new RoleQuery();
    }
}