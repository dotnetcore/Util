import { Component } from '@angular/core';
import { ColorService } from '../color.service';
import { copy } from '@delon/util';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-colors',
  templateUrl: './colors.component.html',
  styleUrls: ['./colors.component.less'],
})
export class ColorsComponent {
  nums = Array(10)
    .fill(1)
    .map((v, i) => v + i);
  constructor(public c: ColorService, private msg: NzMessageService) {}

  onCopy(str: string) {
    copy(str).then(() => this.msg.success(`Copied Success!`));
  }
}
