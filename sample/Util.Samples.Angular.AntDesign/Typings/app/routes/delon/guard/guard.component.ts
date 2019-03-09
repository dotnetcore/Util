import { MenuService } from '@delon/theme';
import { Router } from '@angular/router';
import { Component } from '@angular/core';
import { ACLService } from '@delon/acl';

@Component({
  selector: 'app-guard',
  templateUrl: './guard.component.html',
})
export class GuardComponent {
  constructor(
    public aclSrv: ACLService,
    private menuSrv: MenuService,
    private router: Router,
  ) {}

  setRole(value: string | boolean) {
    this.aclSrv.setFull(typeof value === 'boolean' ? value : false);
    this.aclSrv.set({ role: [value as string] });
    this.menuSrv.resume();
    this.router.navigate(['/delon/guard']);
  }
}
