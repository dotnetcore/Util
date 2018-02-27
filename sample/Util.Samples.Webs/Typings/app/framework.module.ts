import { NgModule } from '@angular/core';
//Util模块
import { UtilModule } from '../util';
//Material模块
import {
    MatButtonToggleModule,
     MatChipsModule,
    MatDialogModule, MatGridListModule,
    MatListModule,  
     MatSliderModule, MatSortModule,
     MatStepperModule
} from '@angular/material';
@NgModule({
    exports: [
        UtilModule,
        MatButtonToggleModule,
        MatChipsModule,
        MatDialogModule, MatGridListModule,
        MatListModule, 
        MatSliderModule, MatSortModule,
         MatStepperModule
    ]
})
export class FrameworkModule {
}