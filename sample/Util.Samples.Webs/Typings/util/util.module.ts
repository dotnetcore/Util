//============== util模块=========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import {
    MatProgressSpinnerModule, MatPaginatorModule, MatSelectModule, MatInputModule,
    MatIconModule, MatButtonModule, MatTooltipModule
} from '@angular/material';
import { MessageService } from 'primeng/components/common/messageservice';
import { ConfirmationService } from 'primeng/primeng';
import { TableWrapperComponent } from './material/table-wrapper.component';
import { SelectWrapperComponent } from './material/select-wrapper.component';
import { TextBoxWrapperComponent } from './material/text-box-wrapper.component';
import { TextareaWrapperComponent } from './material/textarea.wrapper.component';

/**
 * Util模块
 */
@NgModule({
    imports: [
        CommonModule, FormsModule, MatProgressSpinnerModule, MatPaginatorModule, MatSelectModule,
        MatInputModule, MatIconModule, MatButtonModule, MatTooltipModule
    ],
    declarations: [TableWrapperComponent, SelectWrapperComponent, TextBoxWrapperComponent, TextareaWrapperComponent],
    exports: [TableWrapperComponent, SelectWrapperComponent, TextBoxWrapperComponent, TextareaWrapperComponent],
    providers: [
        MessageService, ConfirmationService
    ]
})
export class UtilModule {
}