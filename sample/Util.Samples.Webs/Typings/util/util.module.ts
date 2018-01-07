//============== util模块=========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import {
    MatProgressSpinnerModule, MatPaginatorModule, MatSelectModule, MatInputModule,
    MatIconModule, MatButtonModule, MatTooltipModule, MatDatepickerModule,
    DateAdapter, MAT_DATE_LOCALE_PROVIDER, MAT_DATE_FORMATS, MAT_NATIVE_DATE_FORMATS, MAT_DATE_LOCALE
} from '@angular/material';
import { ConfirmationService } from 'primeng/primeng';
import { UtilDateAdapter } from './material/local/date-adapter';
import { MessageService } from 'primeng/components/common/messageservice';
import { TableWrapperComponent } from './material/table-wrapper.component';
import { SelectWrapperComponent } from './material/select-wrapper.component';
import { TextBoxWrapperComponent } from './material/text-box-wrapper.component';
import { TextareaWrapperComponent } from './material/textarea.wrapper.component';
import { DatePickerWrapperComponent } from './material/date-picker-wrapper.component';

/**
 * Util模块
 */
@NgModule({
    imports: [
        CommonModule, FormsModule, MatProgressSpinnerModule, MatPaginatorModule, MatSelectModule,
        MatInputModule, MatIconModule, MatButtonModule, MatTooltipModule, MatDatepickerModule
    ],
    declarations: [
        TableWrapperComponent, SelectWrapperComponent, TextBoxWrapperComponent, TextareaWrapperComponent,
        DatePickerWrapperComponent
    ],
    exports: [
        CommonModule, FormsModule, MatProgressSpinnerModule, MatPaginatorModule, MatSelectModule,
        MatInputModule, MatIconModule, MatButtonModule, MatTooltipModule, MatDatepickerModule,
        TableWrapperComponent, SelectWrapperComponent, TextBoxWrapperComponent, TextareaWrapperComponent,
        DatePickerWrapperComponent
    ],
    providers: [
        MessageService, ConfirmationService, MAT_DATE_LOCALE_PROVIDER,
        { provide: MAT_DATE_LOCALE, useValue: 'zh-cn' },
        { provide: DateAdapter, useClass: UtilDateAdapter },
        { provide: MAT_DATE_FORMATS, useValue: MAT_NATIVE_DATE_FORMATS }
    ]
})
export class UtilModule {
}