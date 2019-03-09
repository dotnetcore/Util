import {
  Component,
  ChangeDetectionStrategy,
  ChangeDetectorRef,
  OnInit,
} from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { _HttpClient } from '@delon/theme';

@Component({
  selector: 'app-widgets',
  templateUrl: './widgets.component.html',
  styleUrls: ['./widgets.component.less'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class WidgetsComponent implements OnInit {
  data = [];
  smallData = [];

  todoData: any[] = [
    {
      completed: true,
      avatar: '1',
      name: '苏先生',
      content: `请告诉我，我应该说点什么好？`,
    },
    {
      completed: false,
      avatar: '2',
      name: 'はなさき',
      content: `ハルカソラトキヘダツヒカリ`,
    },
    {
      completed: false,
      avatar: '3',
      name: 'cipchk',
      content: `this world was never meant for one as beautiful as you.`,
    },
    {
      completed: false,
      avatar: '4',
      name: 'Kent',
      content: `my heart is beating with hers`,
    },
    {
      completed: false,
      avatar: '5',
      name: 'Are you',
      content: `They always said that I love beautiful girl than my friends`,
    },
    {
      completed: false,
      avatar: '6',
      name: 'Forever',
      content: `Walking through green fields ，sunshine in my eyes.`,
    },
  ];

  like = false;

  dislike = false;

  constructor(
    public msg: NzMessageService,
    private http: _HttpClient,
    private cdr: ChangeDetectorRef,
  ) {}

  ngOnInit() {
    //this.http.get('/chart/visit').subscribe((res: any[]) => {
    //  this.data = res;
    //  this.smallData = res.slice(0, 6);
    //  this.cdr.detectChanges();
    //});
  }
}
