//============== 单选按钮包装器===================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Component, Input, Output, EventEmitter, OnInit, Host, Optional, ViewChild, AfterViewInit, ViewEncapsulation } from '@angular/core';
import { NgModel,NgForm } from '@angular/forms';
import { Select, SelectItem, SelectOption } from '../core/select';
import { WebApi as webapi } from '../common/webapi';

/**
 * Mat单选按钮包装器
 */
@Component({
    selector: 'mat-radio-wrapper',
    template:`
        <div class="radio-layout-vertical">
            <label *ngIf="showLabel&&label" class="radio-label">{{label}}
                <ng-container *ngIf="required">
                    <span [class.radio-required]="controlModel?.hasError( 'required' )">*</span>
                </ng-container>
            </label>
            <mat-radio-group #controlModel="ngModel" [name]="name" [ngModel]="model" (ngModelChange)="onModelChange($event)" 
                    [disabled]="disabled" [required]="required" [labelPosition]="labelPosition" 
                    [class.radio-layout-vertical]="vertical">
                <mat-radio-button *ngFor="let item of dataSource" [value]="item.value" [disabled]="item.disabled" 
                    [ngClass]="vertical?'radio-button-vertical':'radio-button-horizontal'">
                    {{ item.text }}
                </mat-radio-button>
            </mat-radio-group>
        </div>
    `,
    styles: [`
        .radio-layout-vertical {
            display: inline-flex;
            flex-direction: column;
        }
        .radio-label{
            margin-bottom: 8px;
            color:rgba(0,0,0,.54);
        }
        .radio-required{
            color: red;
        }
        .radio-button-horizontal  {
            margin-right: 12px;
        }
        .radio-button-vertical {
            margin-bottom: 5px;
        }
    `]
})
export class RadioWrapperComponent implements OnInit, AfterViewInit {
    /**
     * 名称
     */
    @Input() name: string;
    /**
     * 是否垂直布局
     */
    @Input() vertical: boolean;
    /**
     * 是否显示标签
     */
    @Input() showLabel: boolean;
    /**
     * 标签文本
     */
    @Input() label: string;
    /**
     * 标签文本位置,可选值：'before', 'after'
     */
    @Input() labelPosition: string;
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
    @ViewChild('controlModel') controlModel: NgModel;

    /**
     * 初始化Mat单选按钮包装器
     */
    constructor( @Optional() @Host() private form: NgForm) {
        this.showLabel = true;
    }

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
        let select = new Select(data);
        this.dataSource = select.toOptions();
    }

    /**
     * 从服务器加载
     * @param url 请求地址
     */
    loadUrl(url?: string) {
        url = url || this.url;
        if (!url) {
            console.log("请设置单选按钮Url");
            return;
        }
        webapi.get<SelectItem[]>(url).handle({
            handler: result => {
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