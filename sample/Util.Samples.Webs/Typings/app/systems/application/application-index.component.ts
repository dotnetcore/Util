import { Component, Injector } from '@angular/core';
import { TableQueryComponentBase } from '../../../util';
import { ApplicationQuery } from './model/application-query';
import { ApplicationViewModel } from './model/application-view-model';
import { env } from '../../env';

/**
 * 应用程序首页
 */
@Component({
    selector: 'application-index',
    templateUrl: env.prod() ? './html/application-index.component.html' : '/view/systems/application'
})
export class ApplicationIndexComponent extends TableQueryComponentBase<ApplicationViewModel, ApplicationQuery>  {
    /**
     * 初始化应用程序首页
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
        
    }

    /**
     * 创建查询参数
     */
    protected createQuery() {
        return new ApplicationQuery();
    }

    test(btn) {
        this.util.webapi.get("/api/application").button(btn).loading().handle({
            handler: () => {
            }
        });
    }

    test2() {
        this.util.dialog.open({
            url: "http://www.bing.com",
            hasBackdrop: true,
            minWidth: 1200,
            minHeight: 600,
            disableClose:true
        });
    }

    option = {
        title: {
            text: 'ECharts 入门示例'
        },
        tooltip: {},
        legend: {
            data: ['销量']
        },
        xAxis: {
            data: ["衬衫", "羊毛衫", "雪纺衫", "裤子", "高跟鞋", "袜子"]
        },
        yAxis: {},
        series: [{
            name: '销量',
            type: 'bar',
            data: [5, 20, 36, 10, 10, 20]
        }]
    };
}