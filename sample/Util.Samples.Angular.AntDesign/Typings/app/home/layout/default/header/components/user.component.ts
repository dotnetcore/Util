import { Component, Inject, ChangeDetectionStrategy } from '@angular/core';
import { Router } from '@angular/router';
import { SettingsService } from '@delon/theme';
import { DA_SERVICE_TOKEN, ITokenService } from '@delon/auth';

@Component({
  selector: 'header-user',
  template: `
  <nz-dropdown-menu nzPlacement="bottomRight">
    <div class="alain-default__nav-item d-flex align-items-center px-sm" nz-dropdown>
      <nz-avatar [nzSrc]="settings.user.avatar" nzSize="small" class="mr-sm"></nz-avatar>
      {{settings.user.name}}
    </div>
    <div nz-menu class="width-sm">
      <div nz-menu-item routerLink="/pro/account/center"><i nz-icon nzType="user" class="mr-sm"></i>
        {{ 'menu.account.center' }}
      </div>
      <div nz-menu-item routerLink="/pro/account/settings"><i nz-icon nzType="setting" class="mr-sm"></i>
        {{ 'menu.account.settings' }}
      </div>
      <div nz-menu-item routerLink="/exception/trigger"><i nz-icon nzType="close-circle" class="mr-sm"></i>
        {{ 'menu.account.trigger' }}
      </div>
      <li nz-menu-divider></li>
      <div nz-menu-item (click)="logout()"><i nz-icon nzType="logout" class="mr-sm"></i>
        {{ 'menu.account.logout' }}
      </div>
    </div>
  </nz-dropdown-menu>
  `,
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeaderUserComponent {
  constructor(
    public settings: SettingsService,
    private router: Router,
    @Inject(DA_SERVICE_TOKEN) private tokenService: ITokenService,
  ) {}

  logout() {
    this.tokenService.clear();
    this.router.navigateByUrl(this.tokenService.login_url);
  }
}
