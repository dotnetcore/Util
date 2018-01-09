import { NgModule } from '@angular/core';
//Util模块
import { UtilModule } from '../util';
//Angular模块
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
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
        UtilModule,BrowserAnimationsModule,
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