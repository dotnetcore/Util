//============== 按钮包装器=====================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Component, Input, Output, EventEmitter, Host, Optional, ContentChild, TemplateRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MessageConfig } from '../config/message-config';

/**
 * Mat按钮包装器
 */
@Component({
    selector: 'mat-button-wrapper',
    template: `
        <ng-container [ngSwitch]="style">
            <button *ngSwitchCase="'mat-button'" mat-button [type]="type" [disabled]="isDisabled()"
                    [color]="color" [matTooltip]="tooltip" (click)="click($event)" >
                <ng-container *ngIf="!isWaiting">
                    {{getText()}}
                    <ng-container [ngTemplateOutlet]="template"></ng-container>
                </ng-container>
                <ng-container *ngIf="isWaiting">
                    <mat-icon class="fa-spin">{{waitingMatIcon}}</mat-icon>&nbsp;&nbsp;{{waitingText}}
                </ng-container>
            </button>            
            <button *ngSwitchCase="'mat-icon-button'" mat-icon-button [type]="type" [disabled]="isDisabled()"
                    [color]="color" [matTooltip]="tooltip" (click)="click($event)">
                <ng-container *ngIf="!isWaiting">
                    {{getText()}}
                    <ng-container [ngTemplateOutlet]="template"></ng-container>
                </ng-container>
                <ng-container *ngIf="isWaiting">
                    <mat-icon class="fa-spin">{{waitingMatIcon}}</mat-icon>
                </ng-container>
            </button>
            <button *ngSwitchCase="'mat-fab'" mat-fab [type]="type" [disabled]="isDisabled()"
                    [color]="color" [matTooltip]="tooltip" (click)="click($event)">
                <ng-container *ngIf="!isWaiting">
                    {{getText()}}
                    <ng-container [ngTemplateOutlet]="template"></ng-container>
                </ng-container>
                <ng-container *ngIf="isWaiting">
                    <mat-icon class="fa-spin">{{waitingMatIcon}}</mat-icon>
                </ng-container>
            </button>
            <button *ngSwitchCase="'mat-mini-fab'" mat-mini-fab [type]="type" [disabled]="isDisabled()"
                    [color]="color" [matTooltip]="tooltip" (click)="click($event)">
                <ng-container *ngIf="!isWaiting">
                    {{getText()}}
                    <ng-container [ngTemplateOutlet]="template"></ng-container>
                </ng-container>
                <ng-container *ngIf="isWaiting">
                    <mat-icon class="fa-spin">{{waitingMatIcon}}</mat-icon>
                </ng-container>
            </button>
            <button *ngSwitchDefault mat-raised-button [type]="type" [disabled]="isDisabled()"
                    [color]="color" [matTooltip]="tooltip" (click)="click($event)">
                <ng-container *ngIf="!isWaiting">
                    {{getText()}}
                    <ng-container [ngTemplateOutlet]="template"></ng-container>
                </ng-container>
                <ng-container *ngIf="isWaiting">
                    <mat-icon class="fa-spin">{{waitingMatIcon}}</mat-icon>&nbsp;&nbsp;{{waitingText}}
                </ng-container>
            </button>
        </ng-container>
    `
})
export class ButtonWrapperComponent {
    /**
     * 文本
     */
    @Input() text: string;
    /**
     * 类型，可选值：button,reset,submit
     */
    @Input() type: string;
    /**
     * Mat按钮样式，可选值：mat-button,mat-raised-button,mat-icon-button,mat-fab,mat-mini-fab
     */
    @Input() style: string;
    /**
     * 颜色，可选值：primary,accent,warn
     */
    @Input() color: string;
    /**
     * 禁用
     */
    @Input() disabled: string;
    /**
     * 等待
     */
    isWaiting: boolean;
    /**
     * 等待时显示的文本
     */
    @Input() waitingText: string;
    /**
     * 等待时显示的Material图标
     */
    @Input() waitingMatIcon: string;
    /**
     * 提示
     */
    @Input() tooltip: string;
    /**
     * 单击事件
     */
    @Output() onClick = new EventEmitter<any>();
    /**
     * 模板，用来支持图标
     */
    @ContentChild(TemplateRef) template: TemplateRef<any>;

    /**
     * 初始化Mat按钮包装器
     * @param form 表单
     */
    constructor(@Optional() @Host() private form: NgForm) {
        this.type = "button";
        this.waitingText = MessageConfig.loading;
        this.waitingMatIcon = "donut_large";
    }

    /**
     * 是否禁用
     */
    private isDisabled() {
        if (this.disabled !== undefined)
            return this.disabled;
        return this.type === 'submit' && this.form && !this.form.valid;
    }

    /**
     * 获取文本
     */
    private getText() {
        if (this.text !== undefined)
            return this.text;
        if (this.template)
            return null;
        if (this.type === 'reset')
            return MessageConfig.reset;
        if (this.type === 'submit')
            return MessageConfig.submit;
        return null;
    }

    /**
     * 单击事件
     */
    private click(event) {
        this.onClick.emit(event);
    }

    /**
     * 启用
     */
    enable() {
        this.disabled = undefined;
        this.isWaiting = false;
    }

    /**
     * 禁用
     */
    disable() {
        this.disabled = "true";
        this.isWaiting = true;
    }
}