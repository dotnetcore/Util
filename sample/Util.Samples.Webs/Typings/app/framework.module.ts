import { NgModule } from '@angular/core';
//Util模块
import { UtilModule } from '../util';
//Material模块
import {
    MatButtonToggleModule,
     MatChipsModule,
    MatDialogModule, 
    MatListModule,  
     MatSliderModule, 
     MatStepperModule
} from '@angular/material';
@NgModule({
    exports: [
        UtilModule,
        MatButtonToggleModule,
        MatChipsModule,
        MatDialogModule, 
        MatListModule, 
        MatSliderModule, 
         MatStepperModule
    ]
})
export class FrameworkModule {
}