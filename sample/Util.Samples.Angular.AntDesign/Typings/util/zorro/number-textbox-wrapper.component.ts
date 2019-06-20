//============== NgZorro数字文本框包装器=====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Component, Input, Optional } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FormControlWrapperBase } from './base/form-control-wrapper-base';

/**
 * NgZorro数字文本框包装器
 */
@Component({
    selector: 'x-number-textbox',
    template: `
        <nz-form-control [nzSpan]="span" [nzValidateStatus]="(controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched))?'error':'success'">
            <nz-input-number [name]="name" [nzPlaceHolder]="placeholder" [nzDisabled]="disabled"
                #control #controlModel="ngModel" [ngModel]="model" (ngModelChange)="onModelChange($event)"
                [nzAutoFocus]="autoFocus" [nzPrecision]="precision" [nzStep]="step"
                (nzBlur)="blur($event)" (nzFocus)="focus($event)" (keyup)="keyup($event)" (keydown)="keydown($event)"
                [required]="required" [nzMin]="min" [nzMax]="max"></nz-input-number>
            <nz-form-explain *ngIf="controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched)">{{requiredMessage}}</nz-form-explain>
        </nz-form-control>
    `
})
export class NumberTextBox extends FormControlWrapperBase {
    /**
     * 自动获取焦点
     */
    @Input() autoFocus?: boolean;
    /**
     * 最小值
     */
    @Input() min?: number;
    /**
     * 最大值
     */
    @Input() max?: number;
    /**
     * 精度
     */
    @Input() precision?: number;
    /**
     * 每次改变步数
     */
    @Input() step?: number | string;

    /**
     * 初始化数字文本框包装器
     * @param form 表单
     */
    constructor( @Optional() form: NgForm ) {
        super( form );
        this.precision = 6;
        this.step = 1;
    }
}