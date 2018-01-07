import { NgModule } from '@angular/core';
//Util模块
import { UtilModule } from '../util';
//Angular模块
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from "@angular/common/http";
//Material模块
import {
    MatAutocompleteModule, MatButtonToggleModule,
    MatCardModule, MatCheckboxModule, MatChipsModule,
    MatDialogModule, MatGridListModule,
    MatListModule, MatMenuModule, MatProgressBarModule,
    MatRadioModule, MatSidenavModule, MatSliderModule, MatSortModule,
    MatSlideToggleModule, MatSnackBarModule, MatTableModule, MatTabsModule, MatToolbarModule,
    MatFormFieldModule, MatExpansionModule, MatStepperModule
} from '@angular/material';
//PrimeNg模块
import { ButtonModule, GrowlModule, MessageModule, MessagesModule, ConfirmDialogModule } from 'primeng/primeng';

@NgModule({
    exports: [
        UtilModule,BrowserAnimationsModule, HttpClientModule,
        MatAutocompleteModule, MatButtonToggleModule,
        MatCardModule, MatCheckboxModule, MatChipsModule,
        MatDialogModule, MatGridListModule,
        MatListModule, MatMenuModule, MatProgressBarModule,
        MatRadioModule, MatSidenavModule, MatSliderModule, MatSortModule,
        MatSlideToggleModule, MatSnackBarModule, MatTableModule, MatTabsModule, MatToolbarModule,
        MatFormFieldModule, MatExpansionModule, MatStepperModule,
        ButtonModule, GrowlModule, MessageModule, MessagesModule, ConfirmDialogModule
    ]
})
export class FrameworkModule {
}