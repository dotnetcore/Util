import { Component, Injector } from '@angular/core';
import { env } from '../../../env';
import { TreeTableQueryComponentBase } from "../../../../util";
import { RoleViewModel } from "../model/role-view-model";
import { RoleQuery } from "../model/role-query";

/**
 * 角色选择框
 */
@Component({
    selector: 'select-role-dialog',
    templateUrl: env.prod() ? './../html/role-SelectRoleDialog.component.html' : '/view/systems/role/SelectRoleDialog'
})
export class SelectRoleDialogComponent extends TreeTableQueryComponentBase<RoleViewModel, RoleQuery>{
    /**
     * 初始化角色选择框
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 创建查询参数
     */
    createQuery(): RoleQuery {
        return new RoleQuery();
    }
}