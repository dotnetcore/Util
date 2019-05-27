import { Component, Injector } from '@angular/core';
import { TableQueryComponentBase } from '../../../util';
import { env } from '../../env';
import { ApplicationQuery } from './model/application-query';
import { ApplicationViewModel } from './model/application-view-model';

@Component({
    selector: 'app-table-list',
    templateUrl: !env.dev() ? './html/table-list.component.html' : '/View/Demo/List/TableList',
})
export class TableListComponent extends TableQueryComponentBase<ApplicationViewModel, ApplicationQuery> {
    /**
     * 初始化
     * @param injector 注入器
     */
    constructor( injector: Injector ) {
        super( injector );
    }

    expandForm;

    /**
     * 创建查询参数
     */
    protected createQuery() {
        return new ApplicationQuery();
    }
}
