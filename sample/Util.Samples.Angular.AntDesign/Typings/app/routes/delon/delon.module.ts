import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/index';

import { DelonRoutingModule } from './delon-routing.module';

import { SimpleTableComponent } from './simple-table/simple-table.component';
import { UtilComponent } from './util/util.component';
import { PrintComponent } from './print/print.component';
import { ACLComponent } from './acl/acl.component';
import { CanLeaveProvide } from './guard/can-leave.provide';
import { GuardComponent } from './guard/guard.component';
import { GuardLeaveComponent } from './guard/leave.component';
import { GuardAdminComponent } from './guard/admin.component';
import { GuardAuthComponent } from './guard/auth.component';
import { CacheComponent } from './cache/cache.component';
import { DownFileComponent } from './downfile/downfile.component';
import { XlsxComponent } from './xlsx/xlsx.component';
import { ZipComponent } from './zip/zip.component';
import { DelonFormComponent } from './form/form.component';
import { QRComponent } from './qr/qr.component';

const COMPONENTS = [
  SimpleTableComponent,
  UtilComponent,
  PrintComponent,
  ACLComponent,
  GuardComponent,
  GuardLeaveComponent,
  GuardAdminComponent,
  GuardAuthComponent,
  CacheComponent,
  DownFileComponent,
  XlsxComponent,
  ZipComponent,
  DelonFormComponent,
  QRComponent,
];

const COMPONENTS_NOROUNT = [];

@NgModule({
  imports: [CommonModule, SharedModule, DelonRoutingModule],
  providers: [CanLeaveProvide],
  declarations: [ ...COMPONENTS, ...COMPONENTS_NOROUNT ],
  entryComponents: COMPONENTS_NOROUNT,
})
export class DelonModule {}
