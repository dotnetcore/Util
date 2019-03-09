import {
  Component,
  ChangeDetectionStrategy,
  ChangeDetectorRef,
} from '@angular/core';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'app-account-center-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ProAccountCenterProjectsComponent {
  listLoading = true;
  list: any[] = [];
  constructor(private http: _HttpClient, private cdr: ChangeDetectorRef) {
    this.http.get('/api/list', { count: 8 }).subscribe((res: any) => {
      this.list = res;
      this.listLoading = false;
      this.cdr.detectChanges();
    });
  }
}
