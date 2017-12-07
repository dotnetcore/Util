import { NgModule, Injector } from '@angular/core'
import { FrameworkModule } from './framework.module'
import { routes as Routes } from './app.routes'
import { util } from '../util'
import { AppComponent } from './app.component'
import { AComponent } from "./a/a";
import { BComponent } from "./b/b";

/**
 * 应用根模块
 */
@NgModule({
    declarations: [
        AppComponent, AComponent, BComponent
    ],
    imports: [
        FrameworkModule, Routes
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {
    /**
     * 初始化应用根模块
     * @param injector 注入器
     */
    constructor(private injector: Injector) {
        util.ioc.injector = this.injector;
    }
}