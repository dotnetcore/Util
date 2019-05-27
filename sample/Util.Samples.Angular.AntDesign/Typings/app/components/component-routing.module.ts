import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//表单组件
import { FormComponent } from "./forms/form.component";
import { TextBoxComponent } from "./forms/textbox.component";

//数据展示组件
import { TableComponent } from "./data-display/table.component";

//路由配置
const routes: Routes = [
    {
        path: 'forms',
        children: [
            { path: 'form', component: FormComponent },
            { path: 'textbox', component: TextBoxComponent }
        ]
    },
    {
        path: 'data-display',
        children: [
            { path: 'table', component: TableComponent }
        ]
    }
];

/**
 * 组件路由配置模块
 */
@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ]
})
export class ComponentRoutingModule { }