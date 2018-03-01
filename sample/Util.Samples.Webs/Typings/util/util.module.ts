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
//Material模块
import {
    MatCommonModule, MatRippleModule, MatSortModule,
    MatFormFieldModule, MatSelectModule, MatInputModule, MatDatepickerModule, MatAutocompleteModule,
    MatCheckboxModule, MatSlideToggleModule, MatRadioModule,
    MatSnackBarModule, MatProgressBarModule, MatMenuModule, MatTableModule, MatTabsModule,
    MatSidenavModule, MatToolbarModule, MatCardModule, MatExpansionModule, MatGridListModule,
    MatListModule,
    MatProgressSpinnerModule, MatPaginatorModule, MatIconModule, MatButtonModule, MatTooltipModule,
    DateAdapter, MAT_DATE_LOCALE_PROVIDER, MAT_DATE_FORMATS, MAT_NATIVE_DATE_FORMATS, MAT_DATE_LOCALE
} from '@angular/material';
//PrimeNg模块
import {
    ButtonModule, GrowlModule, MessageModule, MessagesModule, ConfirmDialogModule, ConfirmationService,
    FileUploadModule, LightboxModule
} from 'primeng/primeng';
//Util组件
import { UtilDateAdapter } from './material/local/date-adapter';
import { MessageService } from 'primeng/components/common/messageservice';
import { TableWrapperComponent } from './material/table-wrapper.component';
import { SelectWrapperComponent } from './material/select-wrapper.component';
import { TextBoxWrapperComponent } from './material/textbox-wrapper.component';
import { TextareaWrapperComponent } from './material/textarea-wrapper.component';
import { DatePickerWrapperComponent } from './material/datepicker-wrapper.component';
import { ButtonWrapperComponent } from './material/button-wrapper.component';
import { RadioWrapperComponent } from './material/radio-wrapper.component';
import { FileUploadComponent } from './prime/file-upload.component';
import { SingleFileUploadComponent } from "./prime/single-file-upload.component";
/**
 * Util模块
 */
@NgModule({
    imports: [
        CommonModule, FormsModule, RouterModule, HttpClientModule,
        MatCommonModule, MatRippleModule, MatSortModule,
        MatFormFieldModule, MatSelectModule, MatInputModule, MatDatepickerModule, MatAutocompleteModule,
        MatCheckboxModule, MatSlideToggleModule, MatRadioModule,
        MatSnackBarModule, MatProgressBarModule, MatMenuModule, MatTableModule, MatTabsModule,
        MatSidenavModule, MatToolbarModule, MatCardModule, MatExpansionModule, MatGridListModule,
        MatListModule,
        MatProgressSpinnerModule, MatPaginatorModule, MatIconModule, MatButtonModule, MatTooltipModule,
        ButtonModule, GrowlModule, MessageModule, MessagesModule, ConfirmDialogModule, FileUploadModule, LightboxModule
    ],
    declarations: [
        TableWrapperComponent, SelectWrapperComponent, TextBoxWrapperComponent, TextareaWrapperComponent,
        DatePickerWrapperComponent, ButtonWrapperComponent, RadioWrapperComponent,
        FileUploadComponent, SingleFileUploadComponent
    ],
    exports: [
        CommonModule, FormsModule, RouterModule, HttpClientModule,
        MatCommonModule, MatRippleModule, MatSortModule,
        MatFormFieldModule, MatSelectModule, MatInputModule, MatDatepickerModule, MatAutocompleteModule,
        MatCheckboxModule, MatSlideToggleModule, MatRadioModule,
        MatSnackBarModule, MatProgressBarModule, MatMenuModule, MatTableModule, MatTabsModule,
        MatSidenavModule, MatToolbarModule, MatCardModule, MatExpansionModule, MatGridListModule,
        MatListModule,
        MatProgressSpinnerModule, MatPaginatorModule, MatIconModule, MatButtonModule, MatTooltipModule,
        ButtonModule, GrowlModule, MessageModule, MessagesModule, ConfirmDialogModule, FileUploadModule, LightboxModule,
        TableWrapperComponent, SelectWrapperComponent, TextBoxWrapperComponent, TextareaWrapperComponent,
        DatePickerWrapperComponent, ButtonWrapperComponent, RadioWrapperComponent,
        FileUploadComponent, SingleFileUploadComponent
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