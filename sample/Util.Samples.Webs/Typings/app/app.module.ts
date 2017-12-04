import { NgModule, Injector } from '@angular/core'
import { HttpModule } from "@angular/http";
import * as util from "../util";
import { FrameworkModule } from "./framework.module";
import { AppComponent } from "./app.component"
import { AppService, AppService2 } from './app.service'

/**
 * 应用根模块
 */
@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        FrameworkModule,HttpModule
    ],
    providers: [
        { provide: AppService, useClass: AppService, deps: [AppService2] },
        AppService2
    ],
    bootstrap: [AppComponent]
})
export class AppModule{
    /**
     * 初始化应用根模块
     * @param injector 注入器
     */
    constructor(private injector: Injector) {
        util.ioc.injector = this.injector;
    }
}