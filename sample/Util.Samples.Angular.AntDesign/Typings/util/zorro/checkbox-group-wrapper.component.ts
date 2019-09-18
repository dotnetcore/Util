//============== NgZorro复选框组包装器===================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Component, Input, Output, EventEmitter, OnInit, Optional, ViewChild, AfterViewInit } from '@angular/core';
import { NgModel, NgForm, ValidatorFn, AbstractControl } from '@angular/forms';
import { SelectItem } from "../core/select-model";
import { WebApi as webapi } from '../common/webapi';
import { MessageConfig } from '../config/message-config';

/**
 * NgZorro复选框组包装器
 */
@Component( {
    selector: 'x-checkbox-group',
    template: `
        <nz-form-control [nzValidateStatus]="(controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched))?'error':'success'">
            <nz-checkbox-group #control #controlModel="ngModel" [name]="name" [nzDisabled]="disabled"
                [ngModel]="dataSource" (ngModelChange)="onModelChange($event)"></nz-checkbox-group>
            <nz-form-explain *ngIf="controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched)">{{requiredMessage}}</nz-form-explain>
        </nz-form-control>
    `,
    styles: [`
    `]
} )
export class CheckboxGroup implements OnInit, AfterViewInit {
    /**
     * 组件不添加到FormGroup，独立存在，这样也无法基于NgForm进行表单验证
     */
    @Input() standalone: boolean;
    /**
     * id
     */
    @Input() rawId: string;
    /**
     * 名称
     */
    @Input() name: string;
    /**
     * 禁用
     */
    @Input() disabled: boolean;
    /**
     * 必填项
     */
    @Input() required: boolean;
    /**
     * 必填项验证消息
     */
    @Input() requiredMessage: string;
    /**
     * 数据源
     */
    @Input() dataSource: CheckboxOption[];
    /**
     * 请求地址
     */
    @Input() url: string;
    /**
     * 模型绑定的列表
     */
    items: any[];
    /**
     * 模型
     */
    @Input() get model(): any[] {
        return this.items;
    }
    set model( value: any[] ) {
        this.items = value;
        this.initDataSource();
    }
    /**
     * 模型变更事件,用于双向绑定
     */
    @Output() modelChange = new EventEmitter<any>();
    /**
     * 变更事件
     */
    @Output() onChange = new EventEmitter<any>();
    /**
     * 控件模型
     */
    @ViewChild( 'controlModel', { "static": false } ) controlModel: NgModel;

    /**
     * 初始化复选框组包装器
     */
    constructor( @Optional() private form: NgForm ) {
        this.requiredMessage = MessageConfig.groupRequiredMessage;
    }

    /**
     * 组件初始化
     */
    ngOnInit() {
        if ( this.dataSource )
            return;
        this.loadUrl();
    }

    /**
     * 从服务器加载
     * @param url 请求地址
     */
    loadUrl( url?: string ) {
        url = url || this.url;
        if ( !url )
            return;
        webapi.get<SelectItem[]>( url ).handle( {
            ok: result => {
                this.loadData( result );
            }
        } );
    }

    /**
     * 加载数据
     * @param data 列表项集合
     */
    loadData( data?: SelectItem[] ) {
        if ( !data )
            return;
        this.dataSource = data.map( value => new CheckboxOption( value ) );
        this.initDataSource();
    }

    /**
     * 初始化数据源
     */
    private initDataSource() {
        if ( !this.dataSource || !this.model )
            return;
        this.dataSource.forEach( t => {
            if ( this.model.some( item => item === t.value ) )
                t.checked = true;
        } );
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
        if ( this.required )
            this.controlModel.control.setValidators( requiredValidator( this.dataSource ) );
        this.form && this.form.addControl( this.controlModel );
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
        if ( this.standalone )
            return;
        this.form && this.form.removeControl( this.controlModel );
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
    onModelChange( data: CheckboxOption[] ) {
        if ( !data )
            return;
        let values = data.filter( t => t.checked ).map( t => t.value );
        this.modelChange.emit( values );
        this.onChange.emit( data );
    }
}

/**
 * 复选框数据项
 */
export class CheckboxOption {
    /**
     * 标签
     */
    label: string;
    /**
     * 值
     */
    value;
    /**
     * 是否选中
     */
    checked?: boolean;

    /**
     * 初始化
     * @param item 列表项
     */
    constructor( item: SelectItem ) {
        this.label = item.text;
        this.value = item.value;
    }
}

/**
 * 复选框组必填验证器
 */
export function requiredValidator( data: CheckboxOption[] ): ValidatorFn {
    return ( control: AbstractControl ): { [key: string]: any } | null => {
        let isValid = data.some( t => t.checked );
        return isValid ? null : { 'required': { value: control.value } };
    };
}