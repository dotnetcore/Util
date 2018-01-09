//============== util模块=========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { NgModule } from '@angular/core';
//Angular模块
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";
//Material模块
import {
    MatFormFieldModule, MatSelectModule, MatInputModule, MatDatepickerModule, MatAutocompleteModule,
    MatProgressSpinnerModule, MatPaginatorModule, MatIconModule, MatButtonModule, MatTooltipModule, 
    DateAdapter, MAT_DATE_LOCALE_PROVIDER, MAT_DATE_FORMATS, MAT_NATIVE_DATE_FORMATS, MAT_DATE_LOCALE
} from '@angular/material';
//PrimeNg模块
import {
     ButtonModule, GrowlModule, MessageModule, MessagesModule, ConfirmDialogModule, ConfirmationService
} from 'primeng/primeng';
//Util组件
import { UtilDateAdapter } from './material/local/date-adapter';
import { MessageService } from 'primeng/components/common/messageservice';
import { TableWrapperComponent } from './material/table-wrapper.component';
import { SelectWrapperComponent } from './material/select-wrapper.component';
import { TextBoxWrapperComponent } from './material/textbox-wrapper.component';
import { TextareaWrapperComponent } from './material/textarea-wrapper.component';
import { DatePickerWrapperComponent } from './material/datepicker-wrapper.component';

/**
 * Util模块
 */
@NgModule({
    imports: [
        CommonModule, FormsModule, HttpClientModule,
        MatFormFieldModule, MatSelectModule, MatInputModule, MatDatepickerModule, MatAutocompleteModule,
        MatProgressSpinnerModule, MatPaginatorModule, MatIconModule, MatButtonModule, MatTooltipModule,
        ButtonModule, GrowlModule, MessageModule, MessagesModule, ConfirmDialogModule
    ],
    declarations: [
        TableWrapperComponent, SelectWrapperComponent, TextBoxWrapperComponent, TextareaWrapperComponent,
        DatePickerWrapperComponent
    ],
    exports: [
        CommonModule, FormsModule, HttpClientModule,
        MatFormFieldModule, MatSelectModule, MatInputModule, MatDatepickerModule, MatAutocompleteModule,
        MatProgressSpinnerModule, MatPaginatorModule, MatIconModule, MatButtonModule, MatTooltipModule, 
        ButtonModule, GrowlModule, MessageModule, MessagesModule, ConfirmDialogModule,
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