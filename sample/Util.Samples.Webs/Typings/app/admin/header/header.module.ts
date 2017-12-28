import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { HeaderComponent } from './header.component';

import { ToolbarNotificationComponent } from './notification/notification.component';



@NgModule({
  declarations: [
    HeaderComponent, ToolbarNotificationComponent
  ],
  imports: [
    RouterModule
  ]
})
export class HeaderModule {
}
