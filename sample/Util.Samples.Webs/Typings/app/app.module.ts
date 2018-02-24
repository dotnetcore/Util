//Angular模块
import { NgModule, Injector } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

//框架模块
import { FrameworkModule } from './framework.module';
import { util } from '../util';

//根组件
import { AppComponent } from './app.component';

//路由模块
import { AppRoutingModule } from './app.routing.module';

/**
 * 应用根模块
 */
@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserAnimationsModule,FrameworkModule, AppRoutingModule
    ],
    bootstrap: [AppComponent]
})
export class AppModule {
    /**
     * 初始化应用根模块
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        util.ioc.injector = injector;
    }
}