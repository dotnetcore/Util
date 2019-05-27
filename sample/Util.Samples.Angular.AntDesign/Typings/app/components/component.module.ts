import { NgModule } from '@angular/core';

//框架模块
import { FrameworkModule } from '../framework.module';

//路由模块
import { ComponentRoutingModule } from './component-routing.module';

//表单组件
import { FormComponent } from "./forms/form.component";
import { TextBoxComponent } from "./forms/textbox.component";

//数据展示组件
import { TableComponent } from "./data-display/table.component";

/**
 * 组件模块
 */
@NgModule( {
    imports: [FrameworkModule, ComponentRoutingModule],
    declarations: [
        FormComponent, TextBoxComponent,
        TableComponent
    ]
} )
export class ComponentModule { }
