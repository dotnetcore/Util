﻿//============== 表单控件包装器===========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Input, Output, EventEmitter, ViewChild, Optional, Host, AfterViewInit, OnDestroy } from '@angular/core';
import { NgModel, NgForm } from '@angular/forms';
import { MessageConfig } from '../../config/message-config';

/**
 * 表单控件包装器
 */
export class FormControlWrapperBase implements AfterViewInit, OnDestroy {
    /**
     * 名称
     */
    @Input() name: string;
    /**
     * 组件不添加到FormGroup，独立存在，这样也无法基于NgForm进行表单验证
     */
    @Input() standalone: boolean;
    /**
     * 禁用
     */
    @Input() disabled: boolean;
    /**
     * 占位提示符
     */
    @Input() placeholder: string;
    /**
     * 占位提示符浮动位置，可选值：auto,never,always
     */
    @Input() floatPlaceholder: string;
    /**
     * 起始提示，显示在控件左下方
     */
    @Input() startHint: string;
    /**
     * 结束提示，显示在控件右下方
     */
    @Input() endHint: string;
    /**
     * 前缀文本
     */
    @Input() prefixText: string;
    /**
     * 后缀文本
     */
    @Input() suffixText: string;
    /**
     * 后缀FontAwesome图标
     */
    @Input() suffixFontAwesomeIcon: string;
    /**
     * 后缀Material图标
     */
    @Input() suffixMaterialIcon: string;
    /**
     * 必填项
     */
    @Input() required: boolean;
    /**
     * 必填项验证消息
     */
    @Input() requiredMessage: string;
    /**
     * 后缀图标单击事件
     */
    @Output() onSuffixIconClick = new EventEmitter<any>();
    /**
     * 模型，用于双向绑定
     */
    @Input() model;
    /**
     * 模型变更事件,用于双向绑定
     */
    @Output() modelChange = new EventEmitter<any>();
    /**
     * 变更事件
     */
    @Output() onChange = new EventEmitter<any>();
    /**
     * 获得焦点事件
     */
    @Output() onFocus = new EventEmitter<FocusEvent>();
    /**
     * 失去焦点事件
     */
    @Output() onBlur = new EventEmitter<FocusEvent>();
    /**
     * 键盘按键事件
     */
    @Output() onKeyup = new EventEmitter<KeyboardEvent>();
    /**
     * 键盘按下事件
     */
    @Output() onKeydown = new EventEmitter<KeyboardEvent>();
    /**
     * 控件模型
     */
    @ViewChild('controlModel') controlModel: NgModel;

    /**
     * 表单控件包装器
     * @param form 表单
     */
    constructor( @Optional() @Host() private form: NgForm) {
        this.floatPlaceholder = "auto";
        this.requiredMessage = MessageConfig.requiredMessage;
    }

    /**
     * 视图加载完成
     */
    ngAfterViewInit(): void {
        this.addControl();
    }

    /**
     * 将控件添加到FormGroup
     */
    private addControl() {
        if (this.standalone)
            return;
        this.form && this.form.addControl(this.controlModel);
    }

    /**
     * 组件销毁
     */
    ngOnDestroy() {
        this.removeControl();
    }

    /**
     * 将控件移除FormGroup
     */
    private removeControl() {
        if (this.standalone)
            return;
        this.form && this.form.removeControl(this.controlModel);
    }

    /**
     * 获取值
     */
    get value() {
        return this.controlModel.value;
    }

    /**
     * 模型变更事件处理
     */
    onModelChange(value) {
        this.modelChange.emit(value);
        this.onChange.emit(value);
    }

    /**
     * 后缀图标单击事件
     */
    suffixIconClick() {
        this.onSuffixIconClick.emit();
    }

    /**
     * 获得焦点事件
     */
    focus(event: FocusEvent) {
        this.onFocus.emit(event);
    }

    /**
     * 失去焦点事件
     */
    blur(event: FocusEvent) {
        this.onBlur.emit(event);
    }

    /**
     * 键盘按键事件
     */
    keyup(event: KeyboardEvent) {
        this.onKeyup.emit(event);
    }

    /**
     * 键盘按下事件
     */
    keydown(event: KeyboardEvent) {
        this.onKeydown.emit(event);
    }
}