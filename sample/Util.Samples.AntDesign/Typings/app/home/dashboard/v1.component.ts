import { Component, OnInit } from '@angular/core';
import { env } from '../../env';
import { LineWrapperComponent } from "../../../util";

/**
 * Dashboard 默认页组件
 */
@Component({
    selector: 'app-dashboard-v1',
    templateUrl: !env.dev() ? './html/v1.component.html' : '/View/Home/Dashboard/V1',
})
export class DashboardV1Component implements OnInit {
    /**
     * 初始化
     */
    ngOnInit() {
    }
}