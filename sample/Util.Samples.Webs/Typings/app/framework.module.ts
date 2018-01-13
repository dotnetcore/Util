import { NgModule } from '@angular/core';
//Util模块
import { UtilModule } from '../util';
//Material模块
import {
    MatButtonToggleModule,
    MatCardModule, MatCheckboxModule, MatChipsModule,
    MatDialogModule, MatGridListModule,
    MatListModule, MatMenuModule, MatProgressBarModule,
    MatRadioModule, MatSidenavModule, MatSliderModule, MatSortModule,
    MatSlideToggleModule, MatSnackBarModule, MatTableModule, MatTabsModule, MatToolbarModule,
    MatExpansionModule, MatStepperModule
} from '@angular/material';

@NgModule({
    exports: [
        UtilModule,
        MatButtonToggleModule,
        MatCardModule, MatCheckboxModule, MatChipsModule,
        MatDialogModule, MatGridListModule,
        MatListModule, MatMenuModule, MatProgressBarModule,
        MatRadioModule, MatSidenavModule, MatSliderModule, MatSortModule,
        MatSlideToggleModule, MatSnackBarModule, MatTableModule, MatTabsModule, MatToolbarModule,
        MatExpansionModule, MatStepperModule
    ]
})
export class FrameworkModule {
}