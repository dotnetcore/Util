import { NgModule } from '@angular/core';

//框架模块
import { FrameworkModule } from '../framework.module';

//路由模块
import { ComponentRoutingModule } from './component-routing.module';

//组件
import { FormComponent } from "./forms/form.component";
import { TextBoxComponent } from "./forms/textbox.component";

/**
 * 组件模块
 */
@NgModule( {
    imports: [FrameworkModule, ComponentRoutingModule],
    declarations: [
        FormComponent, TextBoxComponent
    ]
} )
export class ComponentModule { }
