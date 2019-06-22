//============== NgZorro文本框包装器=====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Component, Input, OnInit, Optional } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FormControlWrapperBase } from './base/form-control-wrapper-base';
import { MessageConfig } from '../config/message-config';

/**
 * NgZorro文本框包装器
 */
@Component({
    selector: 'x-textbox',
    template: `
        <nz-form-control [nzValidateStatus]="(controlModel?.invalid && (controlModel?.dirty || controlModel.touched))?'error':'success'">
            <input nz-input [id]="rawId" [name]="name" [type]="type" [placeholder]="placeholder" [disabled]="disabled" [readonly]="readonly"
                #control #controlModel="ngModel" [ngModel]="model" (ngModelChange)="onModelChange($event)"
                (blur)="blur($event)" (focus)="focus($event)" (keyup)="keyup($event)" (keydown)="keydown($event)"
                [required]="required" [email]="type==='email'" [pattern]="pattern"
                [minlength]="minLength" [maxlength]="maxLength"
            />
            <nz-form-explain *ngIf="controlModel?.invalid && (controlModel?.dirty || controlModel.touched)">{{getErrorMessage()}}</nz-form-explain>
        </nz-form-control>
    `
})
export class TextBox extends FormControlWrapperBase implements OnInit {
    /**
     * 是否密码框
     */
    isPassword: boolean;
    /**
     * 密码显示隐藏开关
     */
    hide: boolean;
    /**
     * 清除按钮提示
     */
    clearButtonTooltip: string;
    /**
     * 是否显示清除按钮
     */
    @Input() showClearButton: boolean;
    /**
     * 文本框类型，可选值：text,password,number,email,date
     */
    @Input() type: string;
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
     * 电子邮件验证消息
     */
    @Input() emailMessage: string;
    /**
     * 正则表达式验证
     */
    @Input() pattern: string;
    /**
     * 正则表达式验证消息
     */
    @Input() patterMessage: string;

    /**
     * 初始化文本框包装器
     * @param form 表单
     */
    constructor( @Optional() form: NgForm ) {
        super(form);
        this.clearButtonTooltip = MessageConfig.clear;
        this.showClearButton = true;
    }

    /**
     * 组件初始化
     */
    ngOnInit() {
        this.initPassword();
    }

    /**
     * 初始化密码框
     */
    private initPassword() {
        if (this.type !== "password")
            return;
        this.isPassword = true;
        this.hide = true;
        this.togglePassword();
    }

    /**
     * 切换密码显示状态
     */
    private togglePassword() {
        this.type = this.hide ? 'password' : 'text';
        this.hide = !this.hide;
    }

    /**
     * 获取错误消息
     */
    getErrorMessage() {
        if (!this.controlModel)
            return "";
        if (this.controlModel.hasError('required'))
            return this.requiredMessage;
        if (this.controlModel.hasError('minlength'))
            return this.replace( this.minLengthMessage || MessageConfig.minLengthMessage, this.minLength );
        if (this.controlModel.hasError('email'))
            return this.emailMessage || MessageConfig.emailMessage;
        if (this.controlModel.hasError('pattern'))
            return this.patterMessage;
        return "";
    }

    /**
     * 替换{0}
     */
    private replace( message, value ) {
        return message.replace( /\{0\}/, String( value ) );
    }
}