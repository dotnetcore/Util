//============== 多行文本框包装器=================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Component, Input, Host, Optional } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FormControlWrapperBase } from './base/form-control-wrapper-base';
import { MessageConfig } from '../config/message-config';

/**
 * Mat多行文本框包装器
 */
@Component({
    selector: 'mat-textarea-wrapper',
    template:`
        <mat-form-field [floatLabel]="floatPlaceholder">
            <textarea  matInput [name]="name" [placeholder]="placeholder" [disabled]="disabled" [readonly]="readonly"
				matTextareaAutosize [matAutosizeMinRows]="minRows" [matAutosizeMaxRows]="maxRows"
                #control #controlModel="ngModel" [ngModel]="model" (ngModelChange)="onModelChange($event)" 
                (blur)="blur($event)" (focus)="focus($event)" (keyup)="keyup($event)" (keydown)="keydown($event)"
                [required]="required" [minlength]="minLength" [maxlength]="maxLength" [pattern]="pattern" ></textarea>
            <mat-hint *ngIf="startHint" align="start">{{startHint}}</mat-hint>
            <mat-hint *ngIf="endHint" align="end">{{endHint}}</mat-hint>
            <span *ngIf="prefixText" matPrefix>{{prefixText}}&nbsp;</span>
            <button *ngIf="showClearButton&&model" matSuffix mat-button mat-icon-button  (click)="controlModel.reset()" [matTooltip]="clearButtonTooltip" tabindex="-100">
                <mat-icon>close</mat-icon>
            </button>
            <mat-icon *ngIf="suffixMaterialIcon" matSuffix [style.cursor]="'pointer'" (click)="$event.stopPropagation();suffixIconClick()">{{suffixMaterialIcon}}</mat-icon>
            <i *ngIf="suffixFontAwesomeIcon" matSuffix class="fa fa-lg {{suffixFontAwesomeIcon}}" [style.cursor]="'pointer'" (click)="$event.stopPropagation();suffixIconClick()"></i>
            <span *ngIf="suffixText" matSuffix>{{suffixText}}</span>            
            <mat-error *ngIf="controlModel?.invalid">{{getErrorMessage()}}</mat-error>
        </mat-form-field>
    `
})
export class TextareaWrapperComponent extends FormControlWrapperBase {
    /**
     * 清除按钮提示
     */
    clearButtonTooltip: string;
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
     * 初始化Mat多行文本框包装器
     * @param form 表单
     */
    constructor( @Optional() @Host() form: NgForm ) {
        super(form);
        this.showClearButton = true;
        this.clearButtonTooltip = MessageConfig.clear;
        this.minRows = 1;
        this.maxRows = 8;
    }

    /**
     * 获取错误消息
     */
    private getErrorMessage(): string {
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