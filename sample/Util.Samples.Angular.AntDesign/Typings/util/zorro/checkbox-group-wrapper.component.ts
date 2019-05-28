//============== NgZorro复选框组包装器===================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Component, Input, Output, EventEmitter, OnInit, Host, Optional, ViewChild, AfterViewInit } from '@angular/core';
import { NgModel, NgForm } from '@angular/forms';
import { SelectItem } from "../core/select-model";
import { WebApi as webapi } from '../common/webapi';

/**
 * NgZorro复选框组包装器
 */
@Component( {
    selector: 'x-checkbox-group',
    template: `
        <nz-form-control [nzValidateStatus]="(!isValid && (controlModel?.dirty || controlModel.touched))?'error':'success'">
            <nz-checkbox-group #control #controlModel="ngModel" [name]="name" [nzDisabled]="disabled"
                [ngModel]="dataSource" (ngModelChange)="onModelChange($event)" [required]="required"></nz-checkbox-group>
            <nz-form-explain *ngIf="!isValid && (controlModel?.dirty || controlModel.touched)">{{requiredMessage}}</nz-form-explain>
        </nz-form-control>
    `,
    styles: [`
    `]
} )
export class CheckboxGroup implements OnInit, AfterViewInit {
    /**
     * 是否验证有效
     */
    isValid:boolean;
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
    items:any[];
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
    @ViewChild( 'controlModel' ) controlModel: NgModel;

    /**
     * 初始化复选框组包装器
     */
    constructor( @Optional() @Host() private form: NgForm ) {
        this.isValid = true;
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
     * 视图加载完成
     */
    ngAfterViewInit(): void {
        this.form && this.form.addControl( this.controlModel );
        this.validate();
    }

    /**
     * 验证
     */
    private validate() {
        if ( !this.required )
            return;
        if ( this.dataSource.some( t => t.checked ) ) {
            this.isValid = true;
            return;
        }
        this.isValid = false;
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
        this.validate();
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