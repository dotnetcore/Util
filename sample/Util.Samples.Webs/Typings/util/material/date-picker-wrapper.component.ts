//============== 文本框包装器=====================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Component, Input } from '@angular/core';
import { FormControlWrapperBase } from './base/form-control-wrapper-base';
import { MessageConfig } from '../config/message-config';

/**
 * Mat文本框包装器
 */
@Component({
    selector: 'mat-date-picker-wrapper',
    template:`
        <mat-form-field [floatPlaceholder]="floatPlaceholder">
            <input  matInput [matDatepicker]="picker"  [name]="name" [style.cursor]="'pointer'"
                [placeholder]="placeholder" [disabled]="disabled" [readonly]="readonly"
                #inputModel="ngModel" [ngModel]="model" (ngModelChange)="onModelChange($event)"
                (blur)="blur($event)" (focus)="focus($event)" (keydown)="keydown($event)"
                (click)="picker.open()" [required]="required" 
            />            
            <mat-datepicker #picker></mat-datepicker>
            <mat-hint *ngIf="startHint" align="start">{{startHint}}</mat-hint>
            <mat-hint *ngIf="endHint" align="end">{{endHint}}</mat-hint>
            <span *ngIf="prefixText" matPrefix>{{prefixText}}&nbsp;</span>
            <button *ngIf="showClearButton&&model" matSuffix mat-button mat-icon-button  (click)="inputModel.reset()" [matTooltip]="clearButtonTooltip">
                <mat-icon >close</mat-icon>
            </button>
            <mat-datepicker-toggle matSuffix [for]="picker"></mat-datepicker-toggle>
            <mat-icon *ngIf="suffixMaterialIcon" matSuffix [style.cursor]="'pointer'" (click)="$event.stopPropagation();suffixIconClick()">{{suffixMaterialIcon}}</mat-icon>
            <i *ngIf="suffixFontAwesomeIcon" matSuffix class="fa fa-lg {{suffixFontAwesomeIcon}}" [style.cursor]="'pointer'" (click)="$event.stopPropagation();suffixIconClick()"></i>
            <span *ngIf="suffixText" matSuffix>{{suffixText}}</span>            
            <mat-error *ngIf="inputModel?.hasError( 'required' )">{{requiredMessage}}</mat-error>
        </mat-form-field>
    `
})
export class DatePickerWrapperComponent extends FormControlWrapperBase {
    /**
     * 清除按钮提示
     */
    private clearButtonTooltip: string;
    /**
     * 是否显示清除按钮
     */
    @Input() showClearButton: boolean;
    /**
     * 只读
     */
    @Input() readonly: boolean;

    /**
     * 初始化Mat文本框包装器
     */
    constructor() {
        super();
        this.readonly = true;
        this.clearButtonTooltip = MessageConfig.clear;
        this.showClearButton = true;
    }
}