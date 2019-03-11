//============== util模块=========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { NgModule, Injector } from '@angular/core';
//Angular模块
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";

//Ant Design模块
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { ViserModule } from 'viser-ng';

//Util组件


//Util指令
import { MinValidator } from './directives/min-validator.directive';
import { MaxValidator } from './directives/max-validator.directive';

//Util管道
import { SafeUrlPipe } from './pipes/safe-url.pipe';

//Util服务
import { DicService } from './services/dic.service';
import { SaveGuard } from './services/save-guard';
import { Session } from './security/session';

//授权
import { Authorize as OidcAuthorize } from './security/openid-connect/authorize';
import { AuthorizeService as OidcAuthorizeService } from './security/openid-connect/authorize-service';
import { AuthorizeConfig as OidcAuthorizeConfig } from './security/openid-connect/authorize-config';
import { AuthorizeInterceptor } from "./security/openid-connect/authorize-interceptor";

//导入导出模块
const modules = [
    CommonModule, FormsModule, RouterModule, HttpClientModule,
    NgZorroAntdModule, ViserModule
];

/**
 * Util模块
 */
@NgModule({
    imports: [
        modules
    ],
    declarations: [
        MinValidator, MaxValidator, SafeUrlPipe
    ],
    exports: [
        modules,
        MinValidator, MaxValidator, SafeUrlPipe
    ],
    providers: [
        DicService, Session, SaveGuard
    ]
})
export class UtilModule {
}

/**
 * 创建OpenId Connect服务DI配置
 */
export function createOidcProviders() {
    return [
        { provide: OidcAuthorizeService, useClass: OidcAuthorizeService, deps: [OidcAuthorizeConfig] },
        { provide: OidcAuthorize, useClass: OidcAuthorize, deps: [Injector, Session, OidcAuthorizeService] },
        { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, deps: [OidcAuthorizeService], multi: true }
    ];
}