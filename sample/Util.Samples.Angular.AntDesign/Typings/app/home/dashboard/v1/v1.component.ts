import { Component, OnInit } from '@angular/core';
import { env } from '../../../env';

@Component({
    selector: 'app-dashboard-v1',
    templateUrl: env.dev() ? '/View/Home/Dashboard/V1' : './v1.component.html',
})
export class DashboardV1Component implements OnInit {
    ngOnInit() {
    }
}