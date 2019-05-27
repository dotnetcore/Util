import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//表单组件
import { BasicFormComponent } from "./forms/basic-form.component";

//列表组件
import { TableListComponent } from "./list/table-list.component";

//树组件
import { TreeComponent } from "./trees/tree.component";

//路由配置
const routes: Routes = [
    {
        path: 'form',
        children: [
            { path: 'basic-form', component: BasicFormComponent }
        ]
    },
    {
        path: 'list',
            children: [
                { path: 'table-list', component: TableListComponent }
        ]
    },
    {
        path: 'trees',
        children: [
            { path: 'tree', component: TreeComponent }
        ]
    }
];

/**
 * Demo路由配置模块
 */
@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ]
})
export class DemoRoutingModule { }