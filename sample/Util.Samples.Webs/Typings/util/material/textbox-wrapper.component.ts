//============== 文本框包装器=====================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { WrapperComponentBase } from './base/wrapper-component-base';

/**
 * Mat文本框包装器
 */
@Component({
    selector: 'mat-textbox-wrapper',
    template: `
        <mat-form-field [floatPlaceholder]="floatPlaceholder">
            <input matInput [placeholder]="placeholder">
        </mat-form-field>
    `
})
export class TextBoxWrapperComponent extends WrapperComponentBase implements OnInit {
    /**
     * 组件初始化
     */
    ngOnInit() {
    }
}