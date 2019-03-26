import { Component } from '@angular/core';
import { env } from '../../env';

/**
 * 表格数据展示
 */
@Component( {
    selector: 'app-components-table',
    templateUrl: !env.dev() ? './html/textbox.component.html' : '/View/Components/DataDisplay/Table',
} )
export class TableComponent {


}
