import { Component, Injector } from '@angular/core';
import { env } from '../../env';
import { EditComponentBase } from '../../../util';
import { FormViewModel } from "./model/form-view-model";
import { DialogComponent } from "./dialog.component";

/**
 * 表单组件
 */
@Component( {
    selector: 'app-components-form',
    templateUrl: !env.dev() ? './html/form.component.html' : '/View/Components/Forms/Form'
} )
export class FormComponent extends EditComponentBase<any> {
    /**
     * 上传参数
     */
    data;

    /**
     * 初始化
     */
    constructor( public injector: Injector ) {
        super( injector );
        this.data = { code: "a", name: "b" };
    }

    /**
     * 获取基地址
     */
    getBaseUrl() {
        return "form";
    }

    test() {
        this.util.dialog.open( {
            title: "Util应用框架 - 新增",
            width: 800,
            disableClose: true,
            component: DialogComponent,
            data: { test: "a" },
            onOk: instance => {
                instance.ok2();
            },
            onBeforeClose: ( result ) => {
                if ( result === "b" )
                    return false;
                return true;
            },
            onClose: ( result ) => {
                this.util.message.success( result );
            }
        } );
    }
}
