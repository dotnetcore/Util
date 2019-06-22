//============== NgZorro多行文本框包装器=================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Component, Input, Optional } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FormControlWrapperBase } from './base/form-control-wrapper-base';
import { MessageConfig } from '../config/message-config';

/**
 * NgZorro多行文本框包装器
 */
@Component({
    selector: 'x-textarea',
    template:`
        <nz-form-control [nzValidateStatus]="(controlModel?.invalid && (controlModel?.dirty || controlModel.touched))?'error':'success'">
            <textarea nz-input [id]="rawId" [name]="name" [placeholder]="placeholder" [disabled]="disabled" [readonly]="readonly"
                   #control #controlModel="ngModel" [ngModel]="model" (ngModelChange)="onModelChange($event)"
                   [nzAutosize]="{ minRows: minRows, maxRows: maxRows }"
                   (blur)="blur($event)" (focus)="focus($event)" (keyup)="keyup($event)" (keydown)="keydown($event)"
                   [required]="required" [minlength]="minLength" [maxlength]="maxLength"
            ></textarea>
            <nz-form-explain *ngIf="controlModel?.invalid && (controlModel?.dirty || controlModel.touched)">{{getErrorMessage()}}</nz-form-explain>
        </nz-form-control>
    `
})
export class TextArea extends FormControlWrapperBase {
    /**
     * 是否显示清除按钮
     */
    @Input() showClearButton: boolean;
    /**
     * 最小行数
     */
    @Input() minRows: number;
    /**
     * 最大行数
     */
    @Input() maxRows: number;
    /**
     * 只读
     */
    @Input() readonly: boolean;
    /**
     * 最小长度
     */
    @Input() minLength: number;
    /**
     * 最小长度验证消息
     */
    @Input() minLengthMessage: string;
    /**
     * 最大长度
     */
    @Input() maxLength: number;
    /**
     * 正则表达式
     */
    @Input() pattern: string;
    /**
     * 正则表达式验证消息
     */
    @Input() patterMessage: string;

    /**
     * 初始化多行文本框包装器
     * @param form 表单
     */
    constructor( @Optional() form: NgForm ) {
        super(form);
        this.minRows = 3;
    }

    /**
     * 获取错误消息
     */
    getErrorMessage(): string {
        if (!this.controlModel)
            return "";
        if (this.controlModel.hasError('required'))
            return this.requiredMessage;
        if (this.controlModel.hasError('minlength'))
            return this.minLengthMessage || MessageConfig.minLengthMessage.replace(/\{0\}/, String(this.minLength));
        if (this.controlModel.hasError('pattern'))
            return this.patterMessage;
        return "";
    }
}