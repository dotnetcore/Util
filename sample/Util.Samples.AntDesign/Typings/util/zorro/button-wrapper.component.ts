//============== NgZorro按钮包装器=====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=====================================================
import { Component, Input, Output, EventEmitter, Optional, ContentChild, TemplateRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Util } from "../util";
import { MessageConfig } from '../config/message-config';

/**
 * NgZorro按钮包装器
 */
@Component( {
    selector: 'x-button',
    template: `
        <button nz-button [nzType]="color" [disabled]="isDisabled()" (click)="click($event)"
                nz-tooltip [nzTitle]="tooltip" [nzSize]="size" [nzShape]="shape" [nzLoading]="loading"
                [nzBlock]="block" [nzGhost]="ghost">
        <ng-container [ngTemplateOutlet]="template"></ng-container>
        {{getText()}}
        </button>
    `
} )
export class Button {
    /**
     * 文本
     */
    @Input() text?: string;
    /**
     * 是否验证表单
     */
    @Input() validateForm?: boolean;
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
     * 按钮尺寸，可选值：default,small,large
     */
    @Input() size?: string;
    /**
     * 按钮形状，可选值：circle,round
     */
    @Input() shape?: string;
    /**
     * 设置加载状态
     */
    @Input() loading?: boolean;
    /**
     * 将按钮宽度调整为其父宽度
     */
    @Input() block?: boolean;
    /**
     * 设置为透明背景
     */
    @Input() ghost?: boolean;
    /**
     * 单击事件
     */
    @Output() onClick = new EventEmitter<any>();
    /**
     * 模板，用来支持图标
     */
    @ContentChild( TemplateRef, { "static": false } ) template: TemplateRef<any>;

    /**
     * 初始化按钮包装器
     * @param form 表单
     */
    constructor( @Optional() private form: NgForm ) {
    }

    /**
     * 是否禁用
     */
    isDisabled() {
        if ( this.disabled !== undefined )
            return this.disabled;
        return this.validateForm && this.form && !this.form.valid;
    }

    /**
     * 获取文本
     */
    getText() {
        if ( this.shape === "circle" )
            return null;
        if ( !Util.helper.isUndefined( this.text ) )
            return this.text;
        return MessageConfig.ok;
    }

    /**
     * 单击事件
     */
    click( event ) {
        this.onClick.emit( event );
    }
}