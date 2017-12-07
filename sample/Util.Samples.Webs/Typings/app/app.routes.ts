import { ModuleWithProviders } from '@angular/core'
import { RouterModule, Routes } from '@angular/router'
import { AComponent } from "./a/a";
import { BComponent } from "./b/b";

//路由配置
let config: Routes = [
    { path: 'a', component: AComponent },
    { path: 'b', component: BComponent },
    { path: '**', redirectTo: '/' }
];

//导出路由
export let routes: ModuleWithProviders = RouterModule.forRoot(config);