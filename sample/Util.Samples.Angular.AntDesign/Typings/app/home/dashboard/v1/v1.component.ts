import {
    Component,
    OnInit,
    ChangeDetectionStrategy,
    ChangeDetectorRef,
} from '@angular/core';
import * as G2 from '@antv/g2';
import { _HttpClient } from '@delon/theme';
import { env } from '../../../env';

import { data, scale } from './data'
const DataSet = require('@antv/data-set');

const ds: any = new DataSet();
const dv = ds.createView().source(data);
dv.transform({
    type: 'percent',
    field: 'value',
    dimension: 'country',
    groupBy: ['year'],
    as: 'percent'
});

const filter = [{
    dataKey: 'country',
    callback: (ev) => {
        return ev === 'Europe';
    }
}];

@Component({
    selector: 'app-dashboard-v1',
    templateUrl: env.prod() ? './v1.component.html' : '/View/Dashboard/V1',
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DashboardV1Component implements OnInit {
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

    webSite: any[];
    salesData: any[];
    offlineChartData: any[];

    constructor(private http: _HttpClient, private cdr: ChangeDetectorRef) { }

    ngOnInit() {
       

        //this.http.get('/chart').subscribe((res: any) => {
        //    this.webSite = res.visitData.slice(0, 10);
        //    this.salesData = res.salesData;
        //    this.offlineChartData = res.offlineChartData;
        //    this.cdr.detectChanges();
        //});
    }

    forceFit: boolean = true;
    height: number = 400;
    data = dv.rows;
    scale = scale;
    fields = ['cut', 'clarity'];
    filter = filter;
}
