import { RouterModule } from '@angular/router'
import { AComponent } from "./app/a/a";
import { BComponent } from "./app/b/b";

//路由定义
let router = RouterModule.forRoot([
    { path: 'a', component: AComponent },
    { path: 'b', component: BComponent },
    { path: '**', redirectTo: '/' }
]);

//导出路由
export { router as Router }