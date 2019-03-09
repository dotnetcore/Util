import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/index';

import { ExtrasRoutingModule } from './extras-routing.module';

import { HelpCenterComponent } from './helpcenter/helpcenter.component';
import { ExtrasSettingsComponent } from './settings/settings.component';
import { ExtrasPoiComponent } from './poi/poi.component';
import { ExtrasPoiEditComponent } from './poi/edit/edit.component';

const COMPONENTS = [
  HelpCenterComponent,
  ExtrasSettingsComponent,
  ExtrasPoiComponent
];
const COMPONENTS_NOROUNT = [ExtrasPoiEditComponent];

@NgModule({
  imports: [SharedModule, ExtrasRoutingModule],
  declarations: [ ...COMPONENTS, ...COMPONENTS_NOROUNT ],
  entryComponents: COMPONENTS_NOROUNT,
})
export class ExtrasModule {}
