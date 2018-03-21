import { NgModule } from '@angular/core';
import { FrameworkModule } from '../framework.module';
import { SystemRoutingModule } from './system-routing.module';
import { ApplicationIndexComponent } from './application/application-index.component';
import { ApplicationEditComponent } from './application/application-edit.component';
import { ApplicationDetailComponent } from './application/application-detail.component';

/**
 * systems模块
 */
@NgModule({
    declarations: [
        ApplicationIndexComponent, ApplicationEditComponent, ApplicationDetailComponent
    ],
    imports: [
        FrameworkModule, SystemRoutingModule
    ],
    exports: [
        ApplicationIndexComponent, ApplicationEditComponent, ApplicationDetailComponent
    ]
})
export class SystemModule {
}