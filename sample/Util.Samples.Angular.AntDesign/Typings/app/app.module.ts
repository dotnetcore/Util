import { NgModule, Injector, APP_INITIALIZER, LOCALE_ID } from '@angular/core';

//Angular模块
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from "@angular/common/http";

//Ant Design模块
import { AlainThemeModule } from '@delon/theme';

//语言设置
import { default as ngLang } from '@angular/common/locales/zh';
import { registerLocaleData } from '@angular/common';
registerLocaleData( ngLang, "zh" );

//框架模块
import { FrameworkModule } from './framework.module';
import { util } from '../util';

//路由模块
import { AppRoutingModule } from './app-routing.module';

//主界面模块
import { HomeModule } from "./home/home.module";

//根组件
import { AppComponent } from './app.component';

//启动服务
import { StartupService } from "./home/startup/startup.service";

//启动服务工厂
export function startupServiceFactory( startupService: StartupService ) {
    return () => startupService.load();
}

/**
 * 应用根模块
 */
@NgModule( {
    declarations: [AppComponent],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        HttpClientModule,
        AlainThemeModule.forRoot(),
        FrameworkModule,
        HomeModule,
        AppRoutingModule
    ],
    providers: [
        StartupService,
        {
            provide: APP_INITIALIZER,
            useFactory: startupServiceFactory,
            deps: [StartupService],
            multi: true,
        }
    ],
    bootstrap: [AppComponent],
} )
export class AppModule {
    /**
     * 初始化应用根模块
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        util.ioc.injector = injector;
    }
}
