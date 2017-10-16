import { NgModule } from '@angular/core'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import {
    MatAutocompleteModule, MatButtonModule, MatButtonToggleModule, MatPaginatorModule,
    MatCardModule, MatCheckboxModule, MatChipsModule, MatDatepickerModule,
    MatDialogModule, MatGridListModule, MatIconModule, MatInputModule,
    MatListModule, MatMenuModule, MatProgressBarModule, MatProgressSpinnerModule,
    MatRadioModule, MatSelectModule, MatSidenavModule, MatSliderModule, MatSortModule,
    MatSlideToggleModule, MatSnackBarModule, MatTableModule, MatTabsModule, MatToolbarModule,
    MatTooltipModule, MatFormFieldModule, MatExpansionModule, MatStepperModule  
} from '@angular/material';

@NgModule({
    exports: [
        BrowserAnimationsModule, CommonModule, FormsModule, ReactiveFormsModule,
        MatAutocompleteModule, MatButtonModule, MatButtonToggleModule, MatPaginatorModule,
        MatCardModule, MatCheckboxModule, MatChipsModule, MatDatepickerModule,
        MatDialogModule, MatGridListModule, MatIconModule, MatInputModule,
        MatListModule, MatMenuModule, MatProgressBarModule, MatProgressSpinnerModule,
        MatRadioModule, MatSelectModule, MatSidenavModule, MatSliderModule, MatSortModule,
        MatSlideToggleModule, MatSnackBarModule, MatTableModule, MatTabsModule, MatToolbarModule,
        MatTooltipModule, MatFormFieldModule, MatExpansionModule, MatStepperModule 
    ]
})
export class FrameworkModule {
}