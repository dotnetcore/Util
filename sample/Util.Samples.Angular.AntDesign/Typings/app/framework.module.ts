import { NgModule } from '@angular/core';
//Angular模块
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

//Ant Design模块
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { ViserModule } from 'viser-ng';

//ng-alain模块
import { AlainThemeModule } from '@delon/theme';
import { DelonABCModule } from '@delon/abc';

//Util模块
import { UtilModule } from '../util';

@NgModule({
    exports: [
        CommonModule,
        FormsModule,
        RouterModule, 
        ReactiveFormsModule,
        NgZorroAntdModule,
        ViserModule,
        AlainThemeModule,
        DelonABCModule,
        UtilModule
    ]
})
export class FrameworkModule {
}