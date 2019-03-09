import {
  Component,
  ChangeDetectionStrategy,
  OnInit,
  ChangeDetectorRef,
} from '@angular/core';
import { _HttpClient } from '@delon/theme';
import { zip } from 'rxjs';
import { NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-account-settings-base',
  templateUrl: './base.component.html',
  styleUrls: ['./base.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ProAccountSettingsBaseComponent implements OnInit {
  avatar = '';
  userLoading = true;
  user: any;

  constructor(
    private http: _HttpClient,
    private cdr: ChangeDetectorRef,
    private msg: NzMessageService,
  ) {}

  ngOnInit(): void {
    zip(
      this.http.get('/user/current'),
      this.http.get('/geo/province'),
    ).subscribe(([user, province]: any) => {
      this.userLoading = false;
      this.user = user;
      this.provinces = province;
      this.choProvince(user.geographic.province.key, false);
      this.cdr.detectChanges();
    });
  }

  // #region geo

  provinces: any[] = [];
  cities: any[] = [];

  choProvince(pid: string, cleanCity = true) {
    this.http.get(`/geo/${pid}`).subscribe((res: any) => {
      this.cities = res;
      if (cleanCity) this.user.geographic.city.key = '';
      this.cdr.detectChanges();
    });
  }

  // #endregion

  save() {
    this.msg.success(JSON.stringify(this.user));
    return false;
  }
}
