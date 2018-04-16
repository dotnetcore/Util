import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { ComponentBase, PagerList, TreeTable } from '../../../util';
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
    queryParam: RoleQuery;
    /**
     * 选中的角色列表
     */
    selectedModels: RoleViewModel[];
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
        this.models = new Array<RoleViewModel>();
        this.queryParam = new RoleQuery();
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

    /**
     * 延迟搜索
     */
    search() {
        this.table.search();
    }

    /**
     * 删除
     * @param id 标识
     */
    delete(id?: string | undefined) {
        this.table.delete(id);
    }

    /**
     * 刷新
     */
    refresh() {
        this.queryParam = this.createQuery();
        this.table.refresh(this.queryParam);
    }

    /**
     * 还原查询参数
     */
    restoreQueryParam(query: RoleQuery) {
        this.queryParam = query;
    }
}