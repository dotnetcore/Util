import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatProgressSpinnerModule, MatPaginatorModule } from '@angular/material';
import { TableWrapperComponent } from './material/table-wrapper.component';

/**
 * Util模块
 */
@NgModule({
    imports: [CommonModule, MatProgressSpinnerModule, MatPaginatorModule],
    declarations: [TableWrapperComponent],
    exports: [TableWrapperComponent]
})
export class UtilModule {
}