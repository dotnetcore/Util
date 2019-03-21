//============== NgZorro日期选择包装器=====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=========================================================
import { Component, Input, Host, Optional } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FormControlWrapperBase } from './base/form-control-wrapper-base';
import { MessageConfig } from '../config/message-config';
import { toDate } from '../common/helper';

/**
 * NgZorro日期选择包装器
 */
@Component({
    selector: 'x-date-picker',
    template: `
        <nz-form-control [nzValidateStatus]="(controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched))?'error':'success'">
            <nz-date-picker  [name]="name" 
                [nzPlaceHolder]="placeholder" [nzDisabled]="disabled"
                #controlModel="ngModel" [ngModel]="model" (ngModelChange)="onModelChange($event)"
                (blur)="blur($event)" (focus)="focus($event)" (keyup)="keyup($event)" (keydown)="keydown($event)"
                [required]="required"
            >
        </nz-date-picker>
            <nz-form-explain *ngIf="controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched)">{{requiredMessage}}</nz-form-explain>
        </nz-form-control>
    `
})
export class DatePickerWrapperComponent extends FormControlWrapperBase {
    /**
     * 只读
     */
    @Input() readonly: boolean;
    /**
     * 宽度
     */
    @Input() width: number|undefined;

    /**
     * 初始化日期选择包装器
     * @param form 表单
     */
    constructor( @Optional() @Host() form: NgForm) {
        super(form);
    }
}