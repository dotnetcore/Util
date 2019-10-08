import { NgModule, Injector, APP_INITIALIZER } from '@angular/core';

//Angular模块
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from "@angular/common/http";

//Ant Design模块
import { AlainThemeModule } from '@delon/theme';

//语言设置
import { default as ngLang } from '@angular/common/locales/zh';
import { registerLocaleData } from '@angular/common';
registerLocaleData(ngLang, "zh_CN");

//图标设置
import { NZ_ICONS } from 'ng-zorro-antd';
import { IconDefinition } from '@ant-design/icons-angular';
import * as AllIcons from '@ant-design/icons-angular/icons';
const icons: IconDefinition[] = Object.keys(AllIcons).map(key => AllIcons[key]);

//框架模块
import { FrameworkModule } from './framework.module';
import { util,UploadService } from '../util';

//通用服务
import { TestUploadService } from "../common/services/test-upload.service";

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
        },
        { provide: NZ_ICONS, useValue: icons },
        { provide: UploadService, useClass: TestUploadService }
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