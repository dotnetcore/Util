import { Input,Component, Injector } from '@angular/core';
import { env } from '../../env';
import { ComponentBase } from '../../../util';

/**
 * 弹出层组件
 */
@Component( {
    selector: 'app-components-dialog',
    templateUrl: !env.dev() ? './html/dialog.component.html' : '/View/Components/Forms/Dialog'
} )
export class DialogComponent extends ComponentBase {
    model;
    @Input() test: string;

    /**
     * 初始化
     */
    constructor( public injector: Injector ) {
        super( injector );
    }

    ok() {
        this.util.dialog.close( this.test );
    }

    ok2() {
        this.util.dialog.close( this.model );
    }
}
