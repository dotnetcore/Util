import { Component, OnInit } from '@angular/core';
import { env } from '../../../env';
import { util } from '../../../../util';
import { DataSet } from '@antv/data-set';

@Component({
    selector: 'app-dashboard-v1',
    templateUrl: env.prod() ? './v1.component.html' : '/View/Dashboard/V1',
})
export class DashboardV1Component implements OnInit {

    ngOnInit() {
    }
}


