import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { ApplicationViewModel } from '../list/model/application-view-model';

/**
 * ������
 */
@Component( {
    selector: 'app-basic-form',
    templateUrl: !env.dev() ? './html/basic-form.component.html' : '/View/Demo/Forms/BasicForm'
} )
export class BasicFormComponent extends EditComponentBase<ApplicationViewModel> {
    /**
     * ��ʼ�����
     * @param injector ע����
     */
    constructor( injector: Injector ) {
        super( injector );
    }

    /**
     * ����ģ��
     */
    createModel() {
        let result = new ApplicationViewModel();
        result.enabled = true;
        result.registerEnabled = true;
        return result;
    }

    /**
     * ��ȡ����ַ
     */
    protected getBaseUrl() {
        return "application";
    }
}