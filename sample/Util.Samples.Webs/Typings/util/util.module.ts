//============== util模块=========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { NgModule } from '@angular/core';
//Angular模块
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from "@angular/common/http";

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
     GrowlModule, LightboxModule
} from 'primeng/primeng';

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
import { LoadingComponent  } from "./material/loading.component";

//Util Prime组件
import { TreeTableModule } from './prime/treetable.component';

//Util管道
import { SafeUrlPipe } from './pipes/safe-url.pipe';

//Util服务
import { DicService } from './services/dic.service';

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
        GrowlModule, LightboxModule,
        TreeTableModule
    ],
    declarations: [
        TableWrapperComponent, SelectWrapperComponent, TextBoxWrapperComponent, TextareaWrapperComponent,
        DatePickerWrapperComponent, ButtonWrapperComponent, RadioWrapperComponent, SelectListWrapperComponent,
        DialogWrapperComponent, ConfirmComponent, LoadingComponent,
        SafeUrlPipe
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
        GrowlModule,  LightboxModule,
        TableWrapperComponent, SelectWrapperComponent, TextBoxWrapperComponent, TextareaWrapperComponent,
        DatePickerWrapperComponent, ButtonWrapperComponent, RadioWrapperComponent, SelectListWrapperComponent,
        TreeTableModule,
        SafeUrlPipe
    ],
    entryComponents: [
        DialogWrapperComponent, ConfirmComponent, LoadingComponent
    ],
    providers: [
        MessageService, MAT_DATE_LOCALE_PROVIDER, DicService,
        { provide: MatPaginatorIntl, useFactory: createMatPaginatorIntl },
        { provide: MAT_DATE_LOCALE, useValue: 'zh-cn' },
        { provide: DateAdapter, useClass: UtilDateAdapter },
        { provide: MAT_DATE_FORMATS, useValue: MAT_NATIVE_DATE_FORMATS }
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