import { NzMessageService, NzModalRef } from 'ng-zorro-antd';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'app-extras-poi-edit',
  templateUrl: './edit.component.html',
})
export class ExtrasPoiEditComponent implements OnInit {
  i: any;
  cat: string[] = ['美食', '美食,粤菜', '美食,粤菜,湛江菜'];

  constructor(
    private modal: NzModalRef,
    public msgSrv: NzMessageService,
    public http: _HttpClient,
  ) {}

  ngOnInit() {
    if (this.i.id > 0) {
      this.http.get('/pois').subscribe((res: any) => (this.i = res.list[0]));
    }
  }

  save() {
    this.http.get('/pois').subscribe(() => {
      this.msgSrv.success('保存成功，只是模拟，实际未变更');
      this.modal.close(true);
      this.close();
    });
  }

  close() {
    this.modal.destroy();
  }
}
