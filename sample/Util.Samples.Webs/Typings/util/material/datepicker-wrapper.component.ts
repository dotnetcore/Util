//============== 日期选择包装器=====================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Component, Input, Host, Optional } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FormControlWrapperBase } from './base/form-control-wrapper-base';
import { MessageConfig } from '../config/message-config';
import { toDate } from '../common/helper';

/**
 * Mat日期选择包装器
 */
@Component({
    selector: 'mat-datepicker-wrapper',
    template: `
        <mat-form-field [floatLabel]="floatPlaceholder" [style.width]="width?width+'px':null">
            <input  matInput [matDatepicker]="picker"  [name]="name" [style.cursor]="'pointer'"
                [placeholder]="placeholder" [disabled]="disabled" [readonly]="readonly"
                #control #controlModel="ngModel" [ngModel]="model" (ngModelChange)="onModelChange($event)"
                (blur)="blur($event)" (focus)="focus($event)" (keyup)="keyup($event)" (keydown)="keydown($event)"
                (click)="picker.open()" [required]="required" [min]="minDate" [max]="maxDate"
            />            
            <mat-datepicker #picker [startView]="startView" [touchUi]="touchUi"></mat-datepicker>
            <mat-hint *ngIf="startHint" align="start">{{startHint}}</mat-hint>
            <mat-hint *ngIf="endHint" align="end">{{endHint}}</mat-hint>
            <span *ngIf="prefixText" matPrefix>{{prefixText}}&nbsp;</span>
            <button *ngIf="showClearButton&&model" matSuffix mat-button mat-icon-button  (click)="controlModel.reset()" [matTooltip]="clearButtonTooltip" tabindex="-100">
                <mat-icon >close</mat-icon>
            </button>
            <mat-datepicker-toggle matSuffix [for]="picker"></mat-datepicker-toggle>
            <mat-icon *ngIf="suffixMaterialIcon" matSuffix [style.cursor]="'pointer'" (click)="$event.stopPropagation();suffixIconClick()">{{suffixMaterialIcon}}</mat-icon>
            <i *ngIf="suffixFontAwesomeIcon" matSuffix class="fa fa-lg {{suffixFontAwesomeIcon}}" [style.cursor]="'pointer'" (click)="$event.stopPropagation();suffixIconClick()"></i>
            <span *ngIf="suffixText" matSuffix>{{suffixText}}</span>            
            <mat-error *ngIf="controlModel?.hasError( 'required' )">{{requiredMessage}}</mat-error>
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
     * 起始视图，可选值：year,month
     */
    @Input() startView: string;
    /**
     * 触摸模式
     */
    @Input() touchUi: boolean;
    /**
     * 宽度
     */
    @Input() width: number|undefined;
    /**
     * 最小日期
     */
    private min: string | Date;
    /**
     * 最小日期
     */
    @Input()
    get minDate(): string | Date {
        return this.min;
    }
    set minDate(value: string | Date) {
        this.min = toDate(value);
    }
    /**
     * 最大日期
     */
    private max: string | Date;
    /**
     * 最大日期
     */
    @Input()
    get maxDate(): string | Date {
        return this.max;
    }
    set maxDate(value: string | Date) {
        this.max = toDate(value);
    }

    /**
     * 初始化Mat日期选择包装器
     * @param form 表单
     */
    constructor( @Optional() @Host() form: NgForm) {
        super(form);
        this.startView = 'month';
        this.readonly = true;
        this.clearButtonTooltip = MessageConfig.clear;
        this.showClearButton = true;
    }
}