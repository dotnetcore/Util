import { Component } from '@angular/core';
import { ColorService } from '../color.service';

@Component({
  selector: 'app-typography',
  templateUrl: './typography.component.html',
})
export class TypographyComponent {
  constructor(public c: ColorService) {}
}
