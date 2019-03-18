import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//组件
import { FormComponent } from "./forms/form.component";
import { TextBoxComponent } from "./forms/textbox.component";

//路由配置
const routes: Routes = [
    {
        path: 'forms',
        children: [
            { path: 'form', component: FormComponent },
            { path: 'textbox', component: TextBoxComponent }
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