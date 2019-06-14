//============== util模块=========================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { NgModule, Injector } from '@angular/core';

//Angular模块
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HTTP_INTERCEPTORS } from "@angular/common/http";

//Ant Design模块
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { ViserModule } from 'viser-ng';

//Util服务
import { DicService } from './services/dic.service';
import { Session } from './security/session';

//Util管道
import { SafeUrlPipe } from './pipes/safe-url.pipe';
import { TruncatePipe } from "./pipes/truncate.pipe";
import { IsTruncatePipe } from "./pipes/is-truncate.pipe";

//授权
import { Authorize as OidcAuthorize } from './security/openid-connect/authorize';
import { AuthorizeService as OidcAuthorizeService } from './security/openid-connect/authorize-service';
import { AuthorizeConfig as OidcAuthorizeConfig } from './security/openid-connect/authorize-config';
import { AuthorizeInterceptor } from "./security/openid-connect/authorize-interceptor";

//Util图表组件
import { LineWrapperComponent } from "./viser/line-wrapper.component";
import { ColumnWrapperComponent } from "./viser/column-wrapper.component";
import { BarWrapperComponent } from "./viser/bar-wrapper.component";
import { AreaWrapperComponent } from "./viser/area-wrapper.component";
import { PieWrapperComponent } from "./viser/pie-wrapper.component";
import { RosePieWrapperComponent } from "./viser/rose-pie-wrapper.component";

//Util组件
import { Button } from "./zorro/button-wrapper.component";
import { TextBox } from "./zorro/textbox-wrapper.component";
import { DatePicker } from "./zorro/datepicker-wrapper.component";
import { TextArea } from "./zorro/textarea-wrapper.component";
import { NumberTextBox } from "./zorro/number-textbox-wrapper.component";
import { Select } from "./zorro/select-wrapper.component";
import { Radio } from "./zorro/radio-wrapper.component";
import { CheckboxGroup } from "./zorro/checkbox-group-wrapper.component";
import { Table } from "./zorro/table-wrapper.component";
import { Upload } from "./zorro/upload-wrapper.component";
import { SingleUpload } from "./zorro/single-upload-wrapper.component";
import { Tree } from "./zorro/tree-wrapper.component";
import { TreeSelect } from "./zorro/tree-select-wrapper.component";
import { TreeTable } from "./zorro/tree-table-wrapper.component";

//导入模块集合
const importModules = [
    NgZorroAntdModule, ViserModule
];

//组件集合
const components = [
    SafeUrlPipe, TruncatePipe, IsTruncatePipe,
    LineWrapperComponent, ColumnWrapperComponent, BarWrapperComponent, AreaWrapperComponent,
    PieWrapperComponent, RosePieWrapperComponent,
    Button, TextBox, DatePicker, TextArea, NumberTextBox,
    Select, Radio, CheckboxGroup,
    Table, Upload, SingleUpload,
    Tree, TreeSelect, TreeTable
];

/**
 * Util模块
 */
@NgModule( {
    imports: [
        CommonModule, FormsModule, RouterModule,
        importModules
    ],
    declarations: [
        components
    ],
    exports: [
        components
    ],
    providers: [
        DicService, Session
    ]
} )
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