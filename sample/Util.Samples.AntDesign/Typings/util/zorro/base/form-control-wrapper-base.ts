//============== 表单控件包装器===========================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { Input, Output, EventEmitter, ViewChild, AfterViewInit, OnDestroy, ElementRef, forwardRef } from '@angular/core';
import { NgModel, NgForm } from '@angular/forms';
import { MessageConfig } from '../../config/message-config';
import { EditRowDirective } from "../../zorro/edit-row.directive";

/**
 * 表单控件包装器
 */
export class FormControlWrapperBase implements AfterViewInit, OnDestroy {
    /**
     * id
     */
    @Input() rawId: string;
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
     * 占位提示
     */
    @Input() placeholder?: string;
    /**
     * 必填项
     */
    @Input() required: boolean;
    /**
     * 必填项验证消息
     */
    @Input() requiredMessage: string;
    /**
     * 模型，用于双向绑定
     */
    @Input() model;
    /**
     * 编辑行
     */
    @Input() row: EditRowDirective;
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
    @ViewChild( 'controlModel', { "static": false } ) controlModel: NgModel;
    /**
     * 组件元素
     */
    @ViewChild( forwardRef( () => 'control' ), { "static": false } ) element: ElementRef;

    /**
     * 表单控件包装器
     * @param form 表单
     */
    constructor( private form: NgForm ) {
        this.requiredMessage = MessageConfig.requiredMessage;
        this.placeholder = '';
    }

    /**
     * 初始化
     */
    ngOnInit() {
        this.registerToRow();
    }

    /**
     * 注册到编辑行
     */
    registerToRow() {
        if ( this.row )
            this.row.register( this );
    }

    /**
     * 视图加载完成
     */
    ngAfterViewInit() {
        this.addControl();
    }

    /**
     * 将控件添加到FormGroup
     */
    private addControl() {
        if ( this.standalone )
            return;
        this.form && this.form.addControl( this.controlModel );
    }

    /**
     * 组件销毁
     */
    ngOnDestroy() {
        this.removeControl();
        this.unRegisterFromRow();
    }

    /**
     * 将控件移除FormGroup
     */
    private removeControl() {
        if ( this.standalone )
            return;
        this.form && this.form.removeControl( this.controlModel );
    }

    /**
     * 从编辑行注销
     */
    unRegisterFromRow() {
        if ( this.row )
            this.row.unRegister( this );
    }

    /**
     * 获取值
     */
    get value() {
        return this.controlModel.value;
    }

    /**
     * 是否有效
     */
    isValid() {
        if ( !this.controlModel )
            return false;
        return !this.controlModel.invalid;
    }

    /**
     * 设置焦点
     */
    focus() {
        setTimeout( () => {
            let element = this.getNativeElement();
            element && element.focus();
        }, 0 );
    }

    /**
     * 获取html元素
     */
    getNativeElement() {
        if ( this.element )
            return this.element.nativeElement;
        return null;
    }

    /**
     * 模型变更事件处理
     */
    onModelChange( value ) {
        this.modelChange.emit( value );
        this.onChange.emit( value );
    }

    /**
     * 获得焦点事件
     */
    handleFocus( event: FocusEvent ) {
        this.onFocus.emit( event );
    }

    /**
     * 失去焦点事件
     */
    handleBlur( event: FocusEvent ) {
        this.onBlur.emit( event );
    }

    /**
     * 键盘按键事件
     */
    handleKeyup( event: KeyboardEvent ) {
        this.onKeyup.emit( event );
    }

    /**
     * 键盘按下事件
     */
    handleKeydown( event: KeyboardEvent ) {
        this.onKeydown.emit( event );
    }
}