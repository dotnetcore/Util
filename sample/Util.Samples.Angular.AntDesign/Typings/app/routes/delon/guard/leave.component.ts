import { Component } from '@angular/core';

@Component({
  selector: 'app-guard-leave',
  template: `
    <p>离开时需要确认</p>
    <button nz-button [nzType]="'primary'" [routerLink]="['/logics/guard']">
      <span>我要离开</span>
    </button>
    `,
})
export class GuardLeaveComponent {}
