import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { TreeEditComponentBase } from '../../../util';
import { RoleViewModel } from "./model/role-view-model";
import { SelectRoleDialogComponent } from "./dialogs/select-role-dialog.component";

/**
 * 角色编辑页
 */
@Component({
    selector: 'role-edit',
    templateUrl: env.prod() ? './html/role-edit.component.html' : '/view/systems/role/edit'
})
export class RoleEditComponent extends TreeEditComponentBase<RoleViewModel> {
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
        let model = new RoleViewModel();
        model.enabled = true;
        return model;
    }

    /**
     * 获取基地址
     */
    getBaseUrl() {
        return "role";
    }

    /**
     * 打开角色选择框
     */
    openRolesDialog() {
        this.util.dialog.open({
            dialogComponent: SelectRoleDialogComponent,
            maxWidth: 900,
            maxHeight: 800,
            data: this.parent,
            beforeClose: result => {
                this.setParent(result);
            }
        });
    }
}