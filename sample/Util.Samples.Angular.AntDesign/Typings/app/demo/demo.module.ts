import { NgModule } from '@angular/core';

//框架模块
import { FrameworkModule } from '../framework.module';

//路由模块
import { DemoRoutingModule } from './demo-routing.module';

//表单组件
import { BasicFormComponent } from "./forms/basic-form.component";

/**
 * Demo模块
 */
@NgModule( {
    imports: [FrameworkModule, DemoRoutingModule],
    declarations: [
        BasicFormComponent
    ]
} )
export class DemoModule { }
