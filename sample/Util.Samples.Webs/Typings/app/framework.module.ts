import { NgModule } from '@angular/core';
//Util模块
import { UtilModule } from '../util';
//Angular模块
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
//Material模块
import {
    MatAutocompleteModule, MatButtonModule, MatButtonToggleModule, MatPaginatorModule,
    MatCardModule, MatCheckboxModule, MatChipsModule, MatDatepickerModule,
    MatDialogModule, MatGridListModule, MatIconModule, MatInputModule,
    MatListModule, MatMenuModule, MatProgressBarModule, MatProgressSpinnerModule,
    MatRadioModule, MatSelectModule, MatSidenavModule, MatSliderModule, MatSortModule,
    MatSlideToggleModule, MatSnackBarModule, MatTableModule, MatTabsModule, MatToolbarModule,
    MatTooltipModule, MatFormFieldModule, MatExpansionModule, MatStepperModule
} from '@angular/material';
//PrimeNg模块
import { ButtonModule, GrowlModule, MessageModule, MessagesModule } from 'primeng/primeng';

@NgModule({
    exports: [
        UtilModule,BrowserAnimationsModule, CommonModule, HttpClientModule, FormsModule, ReactiveFormsModule, 
        MatAutocompleteModule, MatButtonModule, MatButtonToggleModule, MatPaginatorModule,
        MatCardModule, MatCheckboxModule, MatChipsModule, MatDatepickerModule,
        MatDialogModule, MatGridListModule, MatIconModule, MatInputModule,
        MatListModule, MatMenuModule, MatProgressBarModule, MatProgressSpinnerModule,
        MatRadioModule, MatSelectModule, MatSidenavModule, MatSliderModule, MatSortModule,
        MatSlideToggleModule, MatSnackBarModule, MatTableModule, MatTabsModule, MatToolbarModule,
        MatTooltipModule, MatFormFieldModule, MatExpansionModule, MatStepperModule,
        ButtonModule,GrowlModule, MessageModule, MessagesModule
    ]
})
export class FrameworkModule {
}