import { Component } from '@angular/core';

@Component({
  selector: 'layout-fullscreen',
  templateUrl: './fullscreen.component.html',
  host: {
    '[class.alain-fullscreen]': 'true',
  },
})
export class LayoutFullScreenComponent {}
