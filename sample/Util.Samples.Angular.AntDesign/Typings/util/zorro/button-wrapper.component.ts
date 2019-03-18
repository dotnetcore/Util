//============== NgZorro按钮包装器=====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=====================================================
import { Component, Input, Output, EventEmitter, Host, Optional } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MessageConfig } from '../config/message-config';

/**
 * NgZorro按钮包装器
 */
@Component({
    selector: 'x-button',
    template: `
        <button nz-button [nzType]="color" [disabled]="isDisabled()" (click)="click($event)"
                nz-tooltip [nzTitle]="tooltip"
        >{{getText()}}</button>
    `
})
export class ButtonWrapperComponent {
    /**
     * 文本
     */
    @Input() text?: string;
    /**
     * 是否提交按钮
     */
    @Input() isSubmit?: boolean;
    /**
     * 颜色，可选值：default,primary,dashed,danger
     */
    @Input() color?: string;
    /**
     * 禁用
     */
    @Input() disabled?: string;
    /**
     * 提示
     */
    @Input() tooltip: string;
    /**
     * 单击事件
     */
    @Output() onClick = new EventEmitter<any>();

    /**
     * 初始化按钮包装器
     * @param form 表单
     */
    constructor(@Optional() @Host() private form: NgForm) {
    }

    /**
     * 是否禁用
     */
    private isDisabled() {
        if (this.disabled !== undefined)
            return this.disabled;
        return this.isSubmit && this.form && !this.form.valid;
    }

    /**
     * 获取文本
     */
    private getText() {
        if (this.text !== undefined)
            return this.text;
        if ( this.isSubmit )
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
    }

    /**
     * 禁用
     */
    disable() {
        this.disabled = "true";
    }
}