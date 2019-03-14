import { NgModule, Injector, LOCALE_ID, APP_INITIALIZER } from '@angular/core';

//Angular模块
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";

//框架模块
import { FrameworkModule } from './framework.module';
import { util } from '../util';

// #region Startup Service
import { StartupService } from './core/index';
export function StartupServiceFactory(
  startupService: StartupService,
): Function {
  return () => startupService.load();
}
const APPINIT_PROVIDES = [
  StartupService,
  {
    provide: APP_INITIALIZER,
    useFactory: StartupServiceFactory,
    deps: [StartupService],
    multi: true,
  }
];

import { DelonModule } from './delon.module';
import { CoreModule } from './core/core.module';
import { AppComponent } from './app.component';
import { LayoutModule } from './home/layout/layout.module';

import { AppRoutingModule } from './app-routing.module';
import { NotFoundComponent } from './home/not-found.component';
import { DashboardV1Component } from './home/dashboard/v1/v1.component';

/**
 * 应用根模块
 */
@NgModule({
    declarations: [AppComponent, DashboardV1Component, NotFoundComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    DelonModule.forRoot(),
    CoreModule,
    FrameworkModule,
    LayoutModule,
    AppRoutingModule
  ],
  providers: [
    ...APPINIT_PROVIDES
  ],
  bootstrap: [AppComponent],
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
