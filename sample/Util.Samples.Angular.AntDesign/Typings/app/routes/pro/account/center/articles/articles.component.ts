import {
  Component,
  ChangeDetectionStrategy,
  ChangeDetectorRef,
} from '@angular/core';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'app-account-center-articles',
  templateUrl: './articles.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ProAccountCenterArticlesComponent {
  list: any[];
  constructor(private http: _HttpClient, private cdr: ChangeDetectorRef) {
    this.http.get('/api/list', { count: 8 }).subscribe((res: any) => {
      this.list = res;
      this.cdr.detectChanges();
    });
  }
}
