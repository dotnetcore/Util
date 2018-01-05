//============== 文本框包装器=====================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { FormControlWrapperBase } from './base/form-control-wrapper-base';

/**
 * Mat文本框包装器
 */
@Component({
    selector: 'mat-textbox-wrapper',
    template:`
        <mat-form-field [floatPlaceholder]="floatPlaceholder">
            <input matInput #inputModel="ngModel" [name]="name" [type]="type" *ngIf="!multiple"
                [placeholder]="placeholder" [ngModel]="model" (ngModelChange)="onModelChange($event)" 
                 [required]="required" [minlength]="minLength" />
            <textarea matInput #inputModel="ngModel" [name]="name" [type]="type" *ngIf="multiple"
                    [rows]="rows" [placeholder]="placeholder" [ngModel]="model" (ngModelChange)="onModelChange($event)" 
                    [required]="required" [minlength]="minLength" ></textarea>
            <mat-hint *ngIf="startHint" align="start">{{startHint}}</mat-hint>
            <mat-hint *ngIf="endHint" align="end">{{endHint}}</mat-hint>
            <span matPrefix *ngIf="prefixText">{{prefixText}}&nbsp;</span>
            <mat-icon matSuffix [style.cursor]="'pointer'" (click)="$event.stopPropagation();suffixIconClick()" *ngIf="suffixMaterialIcon">{{suffixMaterialIcon}}</mat-icon>
            <i matSuffix class="fa fa-lg {{suffixFontAwesomeIcon}}" [style.cursor]="'pointer'" (click)="$event.stopPropagation();suffixIconClick()" *ngIf="suffixFontAwesomeIcon"></i>
            <span matSuffix *ngIf="suffixText">{{suffixText}}</span>
            <mat-error *ngIf="inputModel?.hasError( 'required' )">{{requiredMessage}}</mat-error>
            <mat-error *ngIf="inputModel?.hasError( 'minlength' )">{{minLengthMessage}}</mat-error>
        </mat-form-field>
    `
})
export class TextBoxWrapperComponent extends FormControlWrapperBase implements OnInit {
    /**
     * 文本框类型，可选值：text,password,number
     */
    @Input() type: string;
    /**
     * 最小长度
     */
    @Input() minLength: number;
    /**
     * 最小长度验证消息
     */
    @Input() minLengthMessage: string;
    /**
     * 多行文本区
     */
    @Input() multiple: boolean;
    /**
     * 多行文本区行数
     */
    @Input() rows: number;

    /**
     * 初始化Mat文本框包装器
     */
    constructor() {
        super();
        this.rows = 8;
    }

    /**
     * 组件初始化
     */
    ngOnInit() {
    }
}