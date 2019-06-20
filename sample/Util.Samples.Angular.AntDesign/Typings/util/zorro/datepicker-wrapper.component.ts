//============== NgZorro日期选择包装器=====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=========================================================
import { Component, Input, Optional, Output, EventEmitter } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NzDatePickerI18nInterface } from "ng-zorro-antd";
import { FormControlWrapperBase } from './base/form-control-wrapper-base';
import { util } from "../index";

/**
 * NgZorro日期选择包装器
 */
@Component( {
    selector: 'x-date-picker',
    template: `
        <nz-form-control [nzSpan]="span" [nzValidateStatus]="(controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched))?'error':'success'">
            <ng-container [ngSwitch]="type">
                <ng-container *ngSwitchCase="'date'">
                    <nz-date-picker
                        [name]="name" [nzPlaceHolder]="placeholder" [nzDisabled]="disabled" [nzFormat]="format"
                        #controlModel="ngModel" [ngModel]="model" (ngModelChange)="onModelChange($event)"
                        (blur)="blur($event)" (focus)="focus($event)" (keyup)="keyup($event)" (keydown)="keydown($event)"
                        [nzShowTime]="showTime" [required]="required" [nzAllowClear]="allowClear" [nzAutoFocus]="autoFocus"
                        [nzShowToday]="showToday"
                        [nzClassName]="className" [nzDateRender]="dateRender" [nzDisabledDate]="disableDate" 
                        [nzLocale]="locale" (nzOnOpenChange)="openChange($event)">
                    </nz-date-picker>            
                    <nz-form-explain *ngIf="controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched)">{{requiredMessage}}</nz-form-explain>
                </ng-container>
                <ng-container *ngSwitchCase="'range'">
                    <nz-range-picker
                        [name]="name" [nzPlaceHolder]="placeholder" [nzDisabled]="disabled"
                        #controlModel="ngModel" [ngModel]="model" (ngModelChange)="onModelChange($event)"  [nzFormat]="format"
                        (blur)="blur($event)" (focus)="focus($event)" (keyup)="keyup($event)" (keydown)="keydown($event)"
                        [nzShowTime]="showTime" [required]="required" [nzAllowClear]="allowClear" [nzAutoFocus]="autoFocus"
                        [nzClassName]="className" [nzDateRender]="dateRender" [nzDisabledDate]="disableDate"
                        (nzOnOpenChange)="openChange($event)">
                    </nz-range-picker>
                    <nz-form-explain *ngIf="controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched)">{{requiredMessage}}</nz-form-explain>
                </ng-container>
                <ng-container *ngSwitchCase="'year'">
                    <nz-year-picker
                         [name]="name" [nzPlaceHolder]="placeholder" [nzDisabled]="disabled"
                         #controlModel="ngModel" [ngModel]="model" (ngModelChange)="onModelChange($event)"  [nzFormat]="format"
                         (blur)="blur($event)" (focus)="focus($event)" (keyup)="keyup($event)" (keydown)="keydown($event)"
                         [required]="required" [nzAllowClear]="allowClear" [nzAutoFocus]="autoFocus"
                         [nzClassName]="className" [nzDisabledDate]="disableDate" [nzLocale]="locale"
                         (nzOnOpenChange)="openChange($event)">
                    </nz-year-picker>
                    <nz-form-explain *ngIf="controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched)">{{requiredMessage}}</nz-form-explain>
                </ng-container>
                <ng-container *ngSwitchCase="'month'">
                    <nz-month-picker
                        [name]="name" [nzPlaceHolder]="placeholder" [nzDisabled]="disabled"
                        #controlModel="ngModel" [ngModel]="model" (ngModelChange)="onModelChange($event)"  [nzFormat]="format"
                        (blur)="blur($event)" (focus)="focus($event)" (keyup)="keyup($event)" (keydown)="keydown($event)"
                        [required]="required" [nzAllowClear]="allowClear" [nzAutoFocus]="autoFocus"
                        [nzClassName]="className" [nzDisabledDate]="disableDate" [nzLocale]="locale"
                        (nzOnOpenChange)="openChange($event)">
                    </nz-month-picker>
                    <nz-form-explain *ngIf="controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched)">{{requiredMessage}}</nz-form-explain>
                </ng-container>
                <ng-container *ngSwitchCase="'week'">
                    <nz-week-picker
                         [name]="name" [nzPlaceHolder]="placeholder" [nzDisabled]="disabled"
                         #controlModel="ngModel" [ngModel]="model" (ngModelChange)="onModelChange($event)"  [nzFormat]="format"
                         (blur)="blur($event)" (focus)="focus($event)" (keyup)="keyup($event)" (keydown)="keydown($event)"
                         [nzShowTime]="showTime" [required]="required" [nzAllowClear]="allowClear" [nzAutoFocus]="autoFocus"
                         [nzClassName]="className" [nzDateRender]="dateRender" [nzDisabledDate]="disableDate"
                         [nzLocale]="locale" (nzOnOpenChange)="openChange($event)">
                    </nz-week-picker>
                    <nz-form-explain *ngIf="controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched)">{{requiredMessage}}</nz-form-explain>
                </ng-container>
            </ng-container>
        </nz-form-control>
    `
} )
export class DatePicker extends FormControlWrapperBase {
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
     * 是否显示清除按钮
     */
    @Input() allowClear: boolean;
    /**
     * 是否自动获取焦点
     */
    @Input() autoFocus: boolean;
    /**
     * css类选择器
     */
    @Input() className: string;
    /**
     * 是否显示“今天”按钮
     */
    @Input() showToday: boolean;
    /**
     * 自定义日期单元格内容
     */
    @Input() dateRender;
    /**
     * 禁用日期函数
     */
    @Input() disabledDateFunc: ( value: Date ) => boolean;
    /**
     * 禁用今天之前的日期
     */
    @Input() disabledBeforeToday: boolean;
    /**
     * 禁用明天之前的日期
     */
    @Input() disabledBeforeTomorrow: boolean;
    /**
     * 国际化配置
     */
    @Input() locale: NzDatePickerI18nInterface;
    /**
     * 弹出和关闭日历事件
     */
    @Output() onOpenChange: EventEmitter<any> = new EventEmitter<any>();

    /**
     * 初始化日期选择包装器
     * @param form 表单
     */
    constructor( @Optional() form: NgForm ) {
        super( form );
        this.type = 'date';
        this.allowClear = true;
        this.showToday = true;
    }

    /**
     * 设置禁用日期
     */
    disableDate = ( value: Date ): boolean => {
        if ( this.disabledDateFunc )
            return this.disabledDateFunc( value );
        if ( this.disabledBeforeToday )
            return util.helper.isBeforeToday( value );
        if ( this.disabledBeforeTomorrow )
            return this.disableBeforeTomorrow( value );
        return false;
    }

    /**
     * 禁用明天之前的日期
     */
    private disableBeforeTomorrow( value: Date ) {
        if ( util.helper.isBeforeTomorrow( value ) ) {
            this.showToday = false;
            return true;
        }
        return false;
    }

    /**
     * 弹出和关闭日历事件处理
     */
    openChange = ( value ) => {
        this.onOpenChange.emit( value );
    }
}