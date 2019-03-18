import { Component, OnInit } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd';
import { env } from '../../env';

@Component( {
    selector: 'app-components-form',
    templateUrl: !env.dev() ? './html/form.component.html' : '/View/Components/Forms/Form',
} )
export class FormComponent implements OnInit {

    model;

    constructor( private msg: NzMessageService ) { }

    ngOnInit(): void {
        this.model = {};
    }

    submit() {
        setTimeout( () => {
            this.msg.success( `提交成功` );
        }, 1000 );
    }
}
