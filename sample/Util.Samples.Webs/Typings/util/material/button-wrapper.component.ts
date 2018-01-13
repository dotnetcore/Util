//============== 按钮包装器=====================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Component, Input, Host, Optional } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MessageConfig } from '../config/message-config';

/**
 * Mat按钮包装器
 */
@Component({
    selector: 'mat-button-wrapper',
    template:`
        <ng-container [ngSwitch]="isAnchor">            
            <ng-container *ngSwitchCase="true" [ngSwitch]="category">
                <a *ngSwitchCase="'mat-button'" mat-button [type]="type" [disabled]="isDisabled()"
                    [color]="color">{{text}}</a>
                <a *ngSwitchDefault mat-raised-button [type]="type" [disabled]="isDisabled()"
                   [color]="color">{{text}}</a>
            </ng-container>
            <ng-container *ngSwitchDefault [ngSwitch]="category">
                <button *ngSwitchCase="'mat-button'" mat-button [type]="type" [disabled]="isDisabled()"
                    [color]="color">{{text}}</button>
                <button *ngSwitchDefault mat-raised-button [type]="type" [disabled]="isDisabled()"
                    [color]="color">{{text}}</button>
            </ng-container>
        </ng-container>
    `
})
export class ButtonWrapperComponent {
    /**
     * 是否a标签，默认为button
     */
    @Input() isAnchor: boolean;
    /**
     * 按钮文本
     */
    @Input() text: string;
    /**
     * 功能类型，可选值：button,reset,submit
     */
    @Input() type: string;
    /**
     * Mat按钮样式种类，可选值：mat-button,mat-raised-button,mat-icon-button,mat-fab,mat-mini-fab
     */
    @Input() category: string;
    /**
     * 颜色，可选值：primary,accent,warn
     */
    @Input() color: string;
    
    /**
     * 初始化Mat按钮包装器
     * @param form 表单
     */
    constructor( @Optional() @Host() private form: NgForm) {
    }

    /**
     * 是否禁用
     */
    private isDisabled() {
        return this.type === 'submit' && this.form && (!this.form.valid || this.form.submitted);
    }
}