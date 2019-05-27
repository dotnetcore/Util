import { NgModule } from '@angular/core';
//Util模块
import { UtilModule } from '../util';
//Material模块
import {
    MatButtonToggleModule,
     MatChipsModule,
     MatSliderModule, 
    MatStepperModule
} from '@angular/material';

@NgModule({
    exports: [
        UtilModule,
        MatButtonToggleModule,
        MatChipsModule,
        MatSliderModule, 
        MatStepperModule
    ]
})
export class FrameworkModule {
}