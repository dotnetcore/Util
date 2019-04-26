//============== NgZorro日期选择包装器=====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=========================================================
import { Component, Input, Host, Optional } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FormControlWrapperBase } from './base/form-control-wrapper-base';

/**
 * NgZorro日期选择包装器
 */
@Component({
    selector: 'x-date-picker',
    template: `
        <nz-form-control [nzValidateStatus]="(controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched))?'error':'success'">
            <ng-container [ngSwitch]="type">
                <ng-container *ngSwitchCase="'date'">
                    <nz-date-picker 
                        [name]="name" [nzPlaceHolder]="placeholder" [nzDisabled]="disabled" [nzFormat]="format"
                        #controlModel="ngModel" [ngModel]="model" (ngModelChange)="onModelChange($event)"
                        (blur)="blur($event)" (focus)="focus($event)" (keyup)="keyup($event)" (keydown)="keydown($event)"
                        [nzShowTime]="showTime" [required]="required">
                    </nz-date-picker>            
                    <nz-form-explain *ngIf="controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched)">{{requiredMessage}}</nz-form-explain>
                </ng-container>
                <ng-container *ngSwitchCase="'range'">
                    <nz-range-picker
                        [name]="name" [nzPlaceHolder]="placeholder" [nzDisabled]="disabled"
                        #controlModel="ngModel" [ngModel]="model" (ngModelChange)="onModelChange($event)"  [nzFormat]="format"
                        (blur)="blur($event)" (focus)="focus($event)" (keyup)="keyup($event)" (keydown)="keydown($event)"
                        [nzShowTime]="showTime" [required]="required">
                    </nz-range-picker>
                    <nz-form-explain *ngIf="controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched)">{{requiredMessage}}</nz-form-explain>
                </ng-container>
                <ng-container *ngSwitchCase="'year'">
                    <nz-year-picker
                         [name]="name" [nzPlaceHolder]="placeholder" [nzDisabled]="disabled"
                         #controlModel="ngModel" [ngModel]="model" (ngModelChange)="onModelChange($event)"  [nzFormat]="format"
                         (blur)="blur($event)" (focus)="focus($event)" (keyup)="keyup($event)" (keydown)="keydown($event)"
                         [required]="required">
                    </nz-year-picker>
                    <nz-form-explain *ngIf="controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched)">{{requiredMessage}}</nz-form-explain>
                </ng-container>
                <ng-container *ngSwitchCase="'month'">
                    <nz-month-picker
                        [name]="name" [nzPlaceHolder]="placeholder" [nzDisabled]="disabled"
                        #controlModel="ngModel" [ngModel]="model" (ngModelChange)="onModelChange($event)"  [nzFormat]="format"
                        (blur)="blur($event)" (focus)="focus($event)" (keyup)="keyup($event)" (keydown)="keydown($event)"
                        [required]="required">
                    </nz-month-picker>
                    <nz-form-explain *ngIf="controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched)">{{requiredMessage}}</nz-form-explain>
                </ng-container>
                <ng-container *ngSwitchCase="'week'">
                    <nz-week-picker
                         [name]="name" [nzPlaceHolder]="placeholder" [nzDisabled]="disabled"
                         #controlModel="ngModel" [ngModel]="model" (ngModelChange)="onModelChange($event)"  [nzFormat]="format"
                         (blur)="blur($event)" (focus)="focus($event)" (keyup)="keyup($event)" (keydown)="keydown($event)"
                         [nzShowTime]="showTime" [required]="required">
                    </nz-week-picker>
                    <nz-form-explain *ngIf="controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched)">{{requiredMessage}}</nz-form-explain>
                </ng-container>
            </ng-container>
        </nz-form-control>
    `
})
export class DatePicker extends FormControlWrapperBase {
    /**
     * 只读
     */
    @Input() readonly: boolean;
    /**
     * 宽度
     */
    @Input() width: number | undefined;
    /**
     * 类型，可选值：date,range,year,month,week
     */
    @Input() type: string;
    /**
     * 日期格式化
     */
    @Input() format: string;
    /**
     * 显示时间
     */
    @Input() showTime: boolean;

    /**
     * 初始化日期选择包装器
     * @param form 表单
     */
    constructor( @Optional() @Host() form: NgForm) {
        super( form );
        this.type = 'date';
    }
}