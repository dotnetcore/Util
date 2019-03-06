//Angular模块
import { NgModule, Injector } from '@angular/core';

//根组件
import { AppComponent } from './app.component';

//根路由模块
import { AppRoutingModule } from './app-routing.module';

/**
 * 应用根模块
 */
@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        AppRoutingModule
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
    /**
     * 初始化应用根模块
     * @param injector 注入器
     */
    constructor(injector: Injector) {
    }
}