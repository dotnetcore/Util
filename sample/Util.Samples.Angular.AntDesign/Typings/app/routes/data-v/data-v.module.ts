import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/index';

import { DataVRoutingModule } from './data-v-routing.module';
import { RelationComponent } from './relation/relation.component';

const COMPONENTS = [ RelationComponent ];
const COMPONENTS_NOROUNT = [];

@NgModule({
  imports: [SharedModule, DataVRoutingModule],
  declarations: [ ...COMPONENTS, ...COMPONENTS_NOROUNT ],
  entryComponents: COMPONENTS_NOROUNT,
})
export class DataVModule {}
