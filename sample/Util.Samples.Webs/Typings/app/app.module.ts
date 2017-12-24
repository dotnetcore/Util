import { NgModule, Injector } from '@angular/core';
import { FrameworkModule } from './framework.module';
import { RoutingModule } from './routing.module';
import { util } from '../util';
import { AppComponent } from './app.component';

/**
 * 应用根模块
 */
@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        FrameworkModule, RoutingModule
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