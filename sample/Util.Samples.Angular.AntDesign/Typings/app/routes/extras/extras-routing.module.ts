import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HelpCenterComponent } from './helpcenter/helpcenter.component';
import { ExtrasSettingsComponent } from './settings/settings.component';
import { ExtrasPoiComponent } from './poi/poi.component';

const routes: Routes = [
  { path: 'helpcenter', component: HelpCenterComponent },
  { path: 'settings', component: ExtrasSettingsComponent },
  { path: 'poi', component: ExtrasPoiComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ExtrasRoutingModule {}
