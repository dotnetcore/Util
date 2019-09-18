//============== NgZorro单选按钮包装器===================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Component, Input, Output, EventEmitter, OnInit, Optional, ViewChild, AfterViewInit } from '@angular/core';
import { NgModel,NgForm } from '@angular/forms';
import { SelectList, SelectItem, SelectOption } from "../core/select-model";
import { WebApi as webapi } from '../common/webapi';

/**
 * NgZorro单选按钮包装器
 */
@Component({
    selector: 'x-radio',
    template:`
    <nz-form-control>
        <nz-radio-group #controlModel="ngModel" [name]="name" [nzName]="name" [ngModel]="model" (ngModelChange)="onModelChange($event)" 
            [nzDisabled]="disabled" [required]="required" [nzButtonStyle]="'solid'">
            <label nz-radio *ngFor="let item of dataSource" [nzValue]="item.value" [nzDisabled]="item.disabled" 
                   [ngStyle]="vertical?verticalStyle:''">
            {{ item.text }}
            </label>
        </nz-radio-group>
    </nz-form-control>
    `,
    styles: [`
    `]
})
export class Radio implements OnInit, AfterViewInit {
    /**
     * id
     */
    @Input() rawId: string;
    /**
     * 名称
     */
    @Input() name: string;
    /**
     * 是否垂直布局
     */
    @Input() vertical: boolean;
    /**
     * 风格样式，可选值：'outline' | 'solid'
     */
    @Input() buttonStyle: string;
    /**
     * 是否显示标签
     */
    @Input() showLabel: boolean;
    /**
     * 标签文本
     */
    @Input() label: string;
    /**
     * 禁用
     */
    @Input() disabled: boolean;
    /**
     * 必填项
     */
    @Input() required: boolean;
    /**
     * 数据源
     */
    @Input() dataSource: SelectOption[];
    /**
     * 请求地址
     */
    @Input() url: string;
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
     * 控件模型
     */
    @ViewChild( 'controlModel', { "static": false }) controlModel: NgModel;

    /**
     * 初始化单选按钮包装器
     */
    constructor( @Optional() private form: NgForm) {
        this.showLabel = true;
        this.buttonStyle = 'outline';
    }

    /**
     * 垂直样式
     */
    verticalStyle = {
        display: 'block',
        height: '30px',
        lineHeight: '30px'
    };

    /**
     * 组件初始化
     */
    ngOnInit() {
        if (this.dataSource)
            return;
        this.loadUrl();
    }

    /**
     * 加载数据
     * @param data 列表项集合
     */
    loadData(data?: SelectItem[]) {
        if (!data)
            return;
        let select = new SelectList(data);
        this.dataSource = select.toOptions();
    }

    /**
     * 从服务器加载
     * @param url 请求地址
     */
    loadUrl(url?: string) {
        url = url || this.url;
        if (!url)
            return;
        webapi.get<SelectItem[]>(url).handle({
            ok: result => {
                this.loadData(result);
            }
        });
    }

    /**
     * 视图加载完成
     */
    ngAfterViewInit(): void {
        this.form && this.form.addControl(this.controlModel);
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
}