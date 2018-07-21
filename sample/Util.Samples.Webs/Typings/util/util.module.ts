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

//flex布局模块
import { FlexLayoutModule } from '@angular/flex-layout';

//Material模块
import {
    MatCommonModule, MatRippleModule, MatSortModule, MatPaginatorIntl,
    MatFormFieldModule, MatSelectModule, MatInputModule, MatDatepickerModule, MatAutocompleteModule,
    MatCheckboxModule, MatSlideToggleModule, MatRadioModule,
    MatSnackBarModule, MatProgressBarModule, MatMenuModule, MatTableModule, MatTabsModule,
    MatSidenavModule, MatToolbarModule, MatCardModule, MatExpansionModule, MatGridListModule,
    MatListModule, MatDialogModule,
    MatProgressSpinnerModule, MatPaginatorModule, MatIconModule, MatButtonModule, MatTooltipModule,
    DateAdapter, MAT_DATE_LOCALE_PROVIDER, MAT_DATE_FORMATS, MAT_NATIVE_DATE_FORMATS, MAT_DATE_LOCALE
} from '@angular/material';

//PrimeNg模块
import { MessageService } from 'primeng/components/common/messageservice';
import {
    GrowlModule, LightboxModule, ColorPickerModule
} from 'primeng/primeng';

//CKEditor模块
import { CKEditorModule } from 'ng2-ckeditor';

//Echarts图表模块
import { EchartsNg2Module } from 'echarts-ng2';

//Util Material组件
import { UtilDateAdapter } from './material/local/date-adapter';
import { TableWrapperComponent } from './material/table-wrapper.component';
import { SelectWrapperComponent } from './material/select-wrapper.component';
import { TextBoxWrapperComponent } from './material/textbox-wrapper.component';
import { TextareaWrapperComponent } from './material/textarea-wrapper.component';
import { DatePickerWrapperComponent } from './material/datepicker-wrapper.component';
import { ButtonWrapperComponent } from './material/button-wrapper.component';
import { RadioWrapperComponent } from './material/radio-wrapper.component';
import { SelectListWrapperComponent } from './material/select-list-wrapper.component';
import { DialogWrapperComponent } from './material/dialog-wrapper.component';
import { ConfirmComponent } from './material/confirm.component';
import { LoadingComponent } from "./material/loading.component";

//Util Prime组件
import { TreeTableModule } from './prime/treetable.component';

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

/**
 * Util模块
 */
@NgModule({
    imports: [
        CommonModule, FormsModule, RouterModule, HttpClientModule, FlexLayoutModule,
        MatCommonModule, MatRippleModule, MatSortModule,
        MatFormFieldModule, MatSelectModule, MatInputModule, MatDatepickerModule, MatAutocompleteModule,
        MatCheckboxModule, MatSlideToggleModule, MatRadioModule,
        MatSnackBarModule, MatProgressBarModule, MatMenuModule, MatTableModule, MatTabsModule,
        MatSidenavModule, MatToolbarModule, MatCardModule, MatExpansionModule, MatGridListModule,
        MatListModule, MatDialogModule,
        MatProgressSpinnerModule, MatPaginatorModule, MatIconModule, MatButtonModule, MatTooltipModule,
        GrowlModule, LightboxModule, ColorPickerModule,
        TreeTableModule, CKEditorModule, EchartsNg2Module
    ],
    declarations: [
        TableWrapperComponent, SelectWrapperComponent, TextBoxWrapperComponent, TextareaWrapperComponent,
        DatePickerWrapperComponent, ButtonWrapperComponent, RadioWrapperComponent, SelectListWrapperComponent,
        DialogWrapperComponent, ConfirmComponent, LoadingComponent,
        MinValidator, MaxValidator, SafeUrlPipe
    ],
    exports: [
        CommonModule, FormsModule, RouterModule, HttpClientModule, FlexLayoutModule,
        MatCommonModule, MatRippleModule, MatSortModule,
        MatFormFieldModule, MatSelectModule, MatInputModule, MatDatepickerModule, MatAutocompleteModule,
        MatCheckboxModule, MatSlideToggleModule, MatRadioModule,
        MatSnackBarModule, MatProgressBarModule, MatMenuModule, MatTableModule, MatTabsModule,
        MatSidenavModule, MatToolbarModule, MatCardModule, MatExpansionModule, MatGridListModule,
        MatListModule, MatDialogModule,
        MatProgressSpinnerModule, MatPaginatorModule, MatIconModule, MatButtonModule, MatTooltipModule,
        GrowlModule, LightboxModule, ColorPickerModule,
        TableWrapperComponent, SelectWrapperComponent, TextBoxWrapperComponent, TextareaWrapperComponent,
        DatePickerWrapperComponent, ButtonWrapperComponent, RadioWrapperComponent, SelectListWrapperComponent,
        TreeTableModule, CKEditorModule, EchartsNg2Module,
        MinValidator, MaxValidator, SafeUrlPipe
    ],
    entryComponents: [
        DialogWrapperComponent, ConfirmComponent, LoadingComponent
    ],
    providers: [
        MessageService, MAT_DATE_LOCALE_PROVIDER,
        { provide: MatPaginatorIntl, useFactory: createMatPaginatorIntl },
        { provide: MAT_DATE_LOCALE, useValue: 'zh-cn' },
        { provide: DateAdapter, useClass: UtilDateAdapter },
        { provide: MAT_DATE_FORMATS, useValue: MAT_NATIVE_DATE_FORMATS },
        DicService, Session, SaveGuard
    ]
})
export class UtilModule {
}

/**
 * 创建分页本地化提示
 */
export function createMatPaginatorIntl() {
    let result = new MatPaginatorIntl();
    result.itemsPerPageLabel = "每页";
    result.nextPageLabel = "下页";
    result.previousPageLabel = "上页";
    result.getRangeLabel = (page: number, pageSize: number, length: number) => {
        if (length == 0 || pageSize == 0) { return `0`; }
        length = Math.max(length, 0);
        const startIndex = page * pageSize;
        const endIndex = startIndex < length ? Math.min(startIndex + pageSize, length) : startIndex + pageSize;
        return `当前：${startIndex + 1} - ${endIndex}，共: ${length}`;
    };
    return result;
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