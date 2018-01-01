import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatProgressSpinnerModule, MatPaginatorModule, MatSelectModule } from '@angular/material';
import { MessageService } from 'primeng/components/common/messageservice';
import { ConfirmationService } from 'primeng/primeng';
import { TableWrapperComponent } from './material/table-wrapper.component';
import { SelectWrapperComponent } from './material/select-wrapper.component';

/**
 * Util模块
 */
@NgModule({
    imports: [CommonModule, MatProgressSpinnerModule, MatPaginatorModule, MatSelectModule],
    declarations: [TableWrapperComponent, SelectWrapperComponent],
    exports: [TableWrapperComponent, SelectWrapperComponent],
    providers: [
        MessageService, ConfirmationService
    ]
})
export class UtilModule {
}