import { Component } from '@angular/core';
import { ACLService } from '@delon/acl';
import { MenuService } from '@delon/theme';

@Component({
  selector: 'app-acl',
  templateUrl: './acl.component.html',
})
export class ACLComponent {
  full = true;
  roleA = '';
  roleB = '';

  constructor(public aclSrv: ACLService, private menuSrv: MenuService) {}

  private reMenu() {
    this.menuSrv.resume();
  }

  toggleFull() {
    this.full = !this.full;
    this.aclSrv.setFull(this.full);
    this.reMenu();
  }

  toggleRoleA() {
    this.full = false;
    this.roleA = this.roleA === 'role-a' ? '' : 'role-a';
    this.aclSrv.setFull(this.full);
    this.aclSrv.setRole([this.roleA]);
    this.reMenu();
  }

  toggleRoleB() {
    this.full = false;
    this.roleB = this.roleB === 'role-b' ? '' : 'role-b';
    this.aclSrv.setFull(this.full);
    this.aclSrv.setRole([this.roleB]);
    this.reMenu();
  }
}
