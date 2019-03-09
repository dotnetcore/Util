import { Component, OnInit, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { _HttpClient, ModalHelper } from '@delon/theme';
import { ProBasicListEditComponent } from './edit/edit.component';

@Component({
  selector: 'app-basic-list',
  templateUrl: './basic-list.component.html',
  styleUrls: ['./basic-list.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProBasicListComponent implements OnInit {
  q: any = {
    status: 'all',
  };
  loading = false;
  data: any[] = [];

  constructor(
    private http: _HttpClient,
    public msg: NzMessageService,
    private modal: ModalHelper,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit() {
    this.getData();
  }

  getData() {
    this.loading = true;
    this.http.get('/api/list', { count: 5 }).subscribe((res: any) => {
      this.data = res;
      this.loading = false;
      this.cdr.detectChanges();
    });
  }

  openEdit(record: any = {}) {
    this.modal
      .create(ProBasicListEditComponent, { record }, { size: 'md' })
      .subscribe(res => {
        if (record.id) {
          record = Object.assign(record, { id: 'mock_id', percent: 0 }, res);
        } else {
          this.data.splice(0, 0, res);
          this.data = [...this.data];
        }
        this.cdr.detectChanges();
      });
  }
}
