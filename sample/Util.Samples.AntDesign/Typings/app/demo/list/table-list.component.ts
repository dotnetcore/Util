import { Component, Injector } from '@angular/core';
import { TableEditComponentBase } from '../../../util';
import { env } from '../../env';
import { ApplicationQuery } from './model/application-query';
import { ApplicationViewModel } from './model/application-view-model';

/**
 * �����б�
 */
@Component( {
    selector: 'app-table-list',
    templateUrl: !env.dev() ? './html/table-list.component.html' : '/View/Demo/List/TableList',
} )
export class TableListComponent extends TableEditComponentBase<ApplicationViewModel, ApplicationQuery> {
    /**
     * ��ʼ��
     * @param injector ע����
     */
    constructor( injector: Injector ) {
        super( injector );
    }
}
