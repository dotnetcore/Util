import { Component, OnInit, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { NzMessageService, NzTabChangeEvent } from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';
import { STColumn } from '@delon/abc';

@Component({
  selector: 'app-profile-advanced',
  templateUrl: './advanced.component.html',
  styleUrls: ['./advanced.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProProfileAdvancedComponent implements OnInit {
  list: any[] = [];

  data = {
    advancedOperation1: [],
    advancedOperation2: [],
    advancedOperation3: [],
  };

  opColumns: STColumn[] = [
    { title: '操作类型', index: 'type' },
    { title: '操作人', index: 'name' },
    { title: '执行结果', index: 'status', render: 'status' },
    { title: '操作时间', index: 'updatedAt', type: 'date' },
    { title: '备注', index: 'memo', default: '-' },
  ];

  constructor(public msg: NzMessageService, private http: _HttpClient, private cdr: ChangeDetectorRef) {}

  ngOnInit() {
    this.http.get('/profile/advanced').subscribe((res: any) => {
      this.data = res;
      this.change({ index: 0, tab: null });
      this.cdr.detectChanges();
    });
  }

  change(args: NzTabChangeEvent) {
    this.list = this.data[`advancedOperation${args.index + 1}`];
  }
}
