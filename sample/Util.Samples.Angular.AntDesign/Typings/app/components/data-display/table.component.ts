import { Component } from '@angular/core';
import { env } from '../../env';

/**
 * 表格数据展示
 */
@Component( {
    selector: 'app-components-table',
    templateUrl: !env.dev() ? './html/table.component.html' : '/View/Components/DataDisplay/Table'
} )
export class TableComponent {
    /**
     * 查询对象
     */
    queryParam;

    /**
     * 初始化
     */
    constructor() {
        this.queryParam = {};
    }
}
