import { Component } from '@angular/core';
import { NzMessageService, NzModalRef } from 'ng-zorro-antd';
import { SFSchema } from '@delon/form';

@Component({
  selector: 'app-basic-list-edit',
  templateUrl: './edit.component.html',
})
export class ProBasicListEditComponent {
  record: any = {};
  schema: SFSchema = {
    properties: {
      title: { type: 'string', title: '任务名称', maxLength: 50 },
      createdAt: { type: 'string', title: '开始时间', format: 'date' },
      owner: {
        type: 'string',
        title: '任务负责人',
        enum: [
          { value: 'asdf', label: 'asdf' },
          { value: '卡色', label: '卡色' },
          { value: 'cipchk', label: 'cipchk' },
        ],
      },
      subDescription: {
        type: 'string',
        title: '产品描述',
        ui: {
          widget: 'textarea',
          autosize: { minRows: 2, maxRows: 6 },
        },
      },
    },
    required: ['title', 'createdAt', 'owner'],
    ui: {
      spanLabelFixed: 150,
      grid: { span: 24 },
    },
  };

  constructor(private modal: NzModalRef, private msgSrv: NzMessageService) {}

  save(value: any) {
    this.msgSrv.success('保存成功');
    this.modal.close(value);
  }

  close() {
    this.modal.destroy();
  }
}
