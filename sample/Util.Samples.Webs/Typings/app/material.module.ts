import { NgModule } from '@angular/core'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
    MatAutocompleteModule, MatButtonModule, MatButtonToggleModule, MatPaginatorModule,
    MatCardModule, MatCheckboxModule, MatChipsModule, MatDatepickerModule,
    MatDialogModule, MatGridListModule, MatIconModule, MatInputModule,
    MatListModule, MatMenuModule, MatProgressBarModule, MatProgressSpinnerModule,
    MatRadioModule, MatSelectModule, MatSidenavModule, MatSliderModule, MatSortModule,
    MatSlideToggleModule, MatSnackBarModule, MatTableModule, MatTabsModule, MatToolbarModule,
    MatTooltipModule, MatFormFieldModule, MatExpansionModule, MatStepperModule  } from '@angular/material';

@NgModule({
    exports: [
        BrowserAnimationsModule, MatAutocompleteModule, MatButtonModule, MatButtonToggleModule, MatPaginatorModule,
        MatCardModule, MatCheckboxModule, MatChipsModule, MatDatepickerModule,
        MatDialogModule, MatGridListModule, MatIconModule, MatInputModule,
        MatListModule, MatMenuModule, MatProgressBarModule, MatProgressSpinnerModule,
        MatRadioModule, MatSelectModule, MatSidenavModule, MatSliderModule, MatSortModule,
        MatSlideToggleModule, MatSnackBarModule, MatTableModule, MatTabsModule, MatToolbarModule,
        MatTooltipModule, MatFormFieldModule, MatExpansionModule, MatStepperModule 
    ]
})
export class MaterialModule {
}