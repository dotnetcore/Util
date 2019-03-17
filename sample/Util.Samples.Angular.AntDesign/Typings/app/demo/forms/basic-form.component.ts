import { Component, OnInit, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd';
import { env } from '../../env';

@Component( {
    selector: 'app-basic-form',
    templateUrl: env.dev() ? '/View/Demo/Forms/BasicForm' : './html/basic-form.component.html',
    changeDetection: ChangeDetectionStrategy.OnPush
} )
export class BasicFormComponent implements OnInit {

    submitting = false;

    constructor( private msg: NzMessageService, private cdr: ChangeDetectorRef ) { }

    ngOnInit(): void {
       
    }

    submit() {
        this.submitting = true;
        setTimeout( () => {
            this.submitting = false;
            this.msg.success( `提交成功` );
            this.cdr.detectChanges();
        }, 1000 );
    }
}
