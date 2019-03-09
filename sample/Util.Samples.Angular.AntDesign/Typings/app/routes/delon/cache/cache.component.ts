import { Component, OnInit } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { CacheService } from '@delon/cache';

@Component({
  selector: 'app-cache',
  templateUrl: './cache.component.html',
  styles: [],
})
export class CacheComponent implements OnInit {
  KEY = 'user';

  constructor(public cache: CacheService, public msg: NzMessageService) {}

  ngOnInit() {}

  set() {
    this.cache.set(this.KEY, +new Date());
  }

  get() {
    this.msg.success(this.cache.getNone(this.KEY));
  }
}
