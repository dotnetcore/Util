import { Component } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { copy, format } from '@delon/util';
import { yuan } from '../../../shared/index';

@Component({
  selector: 'app-util',
  templateUrl: './util.component.html',
})
export class UtilComponent {
  constructor(public messageSrv: NzMessageService) {}

  // region: string

  format_str = 'this is ${name}';
  format_res = '';
  format_obj = JSON.stringify({ name: 'asdf' });
  onFormat() {
    let obj = null;
    try {
      obj = JSON.parse(this.format_obj);
    } catch {
      this.messageSrv.error(`无法使用 JSON.parse 转换`);
      return;
    }
    this.format_res = format(this.format_str, obj, true);
  }

  // yuan
  yuan_str: any;
  yuan_res: string;
  onYuan(value: string) {
    this.yuan_res = yuan(value);
  }

  // endregion

  // region: other

  content = `time ${+new Date()}

    中文！@#￥%……&*`;
  onCopy() {
    copy(`time ${+new Date()}`).then(() => this.messageSrv.success(`success`));
  }

  // endregion
}
