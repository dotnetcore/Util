import { NgModule } from '@angular/core';
import { FrameworkModule } from '../framework.module';
import { SystemRoutingModule } from './system-routing.module';
import { ApplicationIndexComponent } from './application/application-index.component';
import { ApplicationEditComponent } from './application/application-edit.component';
import { ApplicationDetailComponent } from './application/application-detail.component';
import { RoleIndexComponent } from './role/role-index.component';
import { RoleEditComponent } from "./role/role-edit.component";
import { RoleDetailComponent } from './role/role-detail.component';
import { SelectRoleDialogComponent } from "./role/dialogs/select-role-dialog.component";

/**
 * systems模块
 */
@NgModule({
    declarations: [
        ApplicationIndexComponent, ApplicationEditComponent, ApplicationDetailComponent,
        RoleIndexComponent, RoleEditComponent, RoleDetailComponent, SelectRoleDialogComponent
    ],
    imports: [
        FrameworkModule, SystemRoutingModule
    ],
    entryComponents: [SelectRoleDialogComponent]
})
export class SystemModule {
}