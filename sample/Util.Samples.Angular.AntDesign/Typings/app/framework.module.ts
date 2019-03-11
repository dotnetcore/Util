import { NgModule } from '@angular/core';
//Angular模块
import { ReactiveFormsModule } from '@angular/forms';

//Util模块
import { UtilModule } from '../util';

//ng-alain模块
import { AlainThemeModule } from '@delon/theme';
import { DelonABCModule } from '@delon/abc';
import { DelonACLModule } from '@delon/acl';
import { DelonFormModule } from '@delon/form';

@NgModule({
    exports: [
        UtilModule,
        ReactiveFormsModule,
        AlainThemeModule,
        DelonABCModule,
        DelonACLModule,
        DelonFormModule
    ]
})
export class FrameworkModule {
}