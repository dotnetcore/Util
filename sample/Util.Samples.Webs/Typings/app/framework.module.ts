import { NgModule } from '@angular/core';
//Util模块
import { UtilModule } from '../util';
//Material模块
import {
    MatButtonToggleModule,
    MatCardModule, MatChipsModule,
    MatDialogModule, MatGridListModule,
    MatListModule,  
    MatSidenavModule, MatSliderModule, MatSortModule,
    MatTableModule, MatTabsModule, MatToolbarModule,
    MatExpansionModule, MatStepperModule
} from '@angular/material';
@NgModule({
    exports: [
        UtilModule,
        MatButtonToggleModule,
        MatCardModule, MatChipsModule,
        MatDialogModule, MatGridListModule,
        MatListModule, 
        MatSidenavModule, MatSliderModule, MatSortModule,
        MatTableModule, MatTabsModule, MatToolbarModule,
        MatExpansionModule, MatStepperModule
    ]
})
export class FrameworkModule {
}