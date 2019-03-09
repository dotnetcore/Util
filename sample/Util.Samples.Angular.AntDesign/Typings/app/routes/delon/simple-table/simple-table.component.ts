import { Component, OnInit } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { STColumn } from '@delon/abc';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'app-simple-table',
  templateUrl: './simple-table.component.html',
})
export class SimpleTableComponent implements OnInit {
  ps = 20;
  total = 200; // mock total
  args: any = { _allow_anonymous: true };
  url = `https://api.randomuser.me/?results=20`;
  events: any[] = [];
  scroll = { y: '230px' };
  columns: STColumn[] = [
    { title: 'id', index: 'id.value', type: 'checkbox' },
    { title: 'Avatar', index: 'picture.thumbnail', type: 'img', width: '80px' },
    {
      title: 'Name',
      index: 'name.first',
      width: '150px',
      format: (item: any) => `${item.name.first} ${item.name.last}`,
      type: 'link',
      click: (item: any) => this.message.info(`${item.name.first}`),
    },
    { title: 'Email', index: 'email' },
    {
      title: 'Gender',
      index: 'gender',
      type: 'yn',
      ynTruth: 'female',
      ynYes: '男',
      ynNo: '女',
      width: '120px',
    },
    { title: 'Events', render: 'events', width: '90px' },
    { title: 'Registered', index: 'registered', type: 'date', width: '150px' },
    {
      title: 'Actions',
      width: '120px',
      buttons: [
        {
          text: 'Edit',
          click: (item: any) => this.message.info(`edit [${item.id.value}]`),
          if: (item: any) => item.gender === 'female',
        },
        {
          text: 'Delete',
          type: 'del',
          click: (item: any) => this.message.info(`deleted [${item.id.value}]`),
        },
      ],
    },
  ];

  constructor(public http: _HttpClient, private message: NzMessageService) {}

  ngOnInit(): void {
    //this.http
    //  .get('/chart/visit')
    //  .subscribe((res: any[]) => (this.events = res.slice(0, 8)));
  }

  fullChange(val: boolean) {
    this.scroll = val ? { y: '350px' } : { y: '230px' };
  }
}
