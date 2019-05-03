import { Component, Injector } from '@angular/core';
import { ComponentBase } from '../../../util';
import { env } from '../../env';
import { RoleQuery } from './model/role-query';

@Component({
    selector: 'app-table-list',
    templateUrl: !env.dev() ? './html/tree.component.html' : '/View/Demo/Trees/Tree',
})
export class TreeComponent extends ComponentBase {
    /**
     * 查询参数
     */
    queryParam: RoleQuery;

    /**
     * 初始化
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        super( injector );
        this.queryParam = this.createQuery();
    }

    /**
     * 创建查询参数
     */
    protected createQuery() {
        return new RoleQuery();
    }
}
