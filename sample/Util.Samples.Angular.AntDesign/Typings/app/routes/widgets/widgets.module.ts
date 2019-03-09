import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/index';

import { WidgetsRoutingModule } from './widgets-routing.module';

import { WidgetsComponent } from './widgets/widgets.component';

const COMPONENTS = [
  WidgetsComponent
];

const COMPONENTS_NOROUNT = [];

@NgModule({
  imports: [SharedModule, WidgetsRoutingModule],
  declarations: [ ...COMPONENTS, ...COMPONENTS_NOROUNT ],
  entryComponents: COMPONENTS_NOROUNT,
})
export class WidgetsModule {}
