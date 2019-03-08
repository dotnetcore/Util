//============== 选择列表包装器===================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Component, Input, Output, EventEmitter, ViewChild, Optional, Host, OnInit, AfterViewInit } from '@angular/core';
import { NgForm, NgModel } from '@angular/forms';
import { MatSelectionList } from '@angular/material';
import { Select, SelectItem, SelectOption } from '../core/select';
import { WebApi as webapi } from '../common/webapi';

/**
 * Mat选择列表包装器
 */
@Component({
    selector: 'mat-select-list-wrapper',
    template: `
        <mat-selection-list #controlModel="ngModel" [name]="name" [ngModel]="model" (ngModelChange)="onModelChange($event)"
                [disabled]="disabled" >
            <h3 mat-subheader *ngIf="label">{{label}}</h3>
            <mat-list-option *ngFor="let item of options" [value]="item.value" [disabled]="item.disabled" [checkboxPosition]="checkboxPosition">
                {{ item.text }}
            </mat-list-option>
        </mat-selection-list>
    `
})
export class SelectListWrapperComponent implements OnInit, AfterViewInit {
    /**
     * 列表项集合
     */
    options: SelectOption[];
    /**
     * 数据源
     */
    @Input() dataSource: SelectItem[];
    /**
     * 请求地址
     */
    @Input() url: string;
    /**
     * 名称
     */
    @Input() name: string;
    /**
     * 禁用
     */
    @Input() disabled: boolean;
    /**
     * 标题
     */
    @Input() label: string;
    /**
     * 复选框位置，可选值： 'before' , 'after'
     */
    @Input() checkboxPosition: string;
    /**
     * 模型，用于双向绑定
     */
    @Input() model: any[];
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
     * 选择列表
     */
    @ViewChild(MatSelectionList) list: MatSelectionList;

    /**
     * 初始化选择列表包装器
     */
    constructor( @Optional() @Host() private form: NgForm) {
        this.checkboxPosition = "after";
    }

    /**
     * 组件初始化
     */
    ngOnInit() {
        this.loadData();
        if (this.dataSource)
            return;
        this.loadUrl();
    }

    /**
     * 加载数据
     * @param data 列表项集合
     */
    loadData(data?: SelectItem[]) {
        data = data || this.dataSource;
        if (!data)
            return;
        let select = new Select(data);
        this.options = select.toOptions();
    }

    /**
     * 从服务器加载
     * @param url 请求地址
     */
    loadUrl(url?: string) {
        url = url || this.url;
        if (!url) {
            console.log("请设置选择列表Url");
            return;
        }
        webapi.get<SelectItem[]>(url).handle({
            handler: result => {
                this.loadData(result);
                this.selectOptions();
            }
        });
    }

    /**
     * 选中列表项
     */
    private selectOptions() {
        setTimeout(() => {
            this.list.options.forEach(t => t.selected = this.model && this.model.some(m => m === t.value));
        }, 0);
    }

    /**
     * 视图加载完成
     */
    ngAfterViewInit(): void {
        this.form && this.form.addControl(this.controlModel);
    }

    /**
     * 模型变更事件处理
     */
    onModelChange(value) {
        this.modelChange.emit(value);
        this.onChange.emit(value);
    }

    /**
     * 获取选中的值
     */
    getSelectedValues() {
        if (!this.list.options)
            return [];
        return this.list.options.filter(option => option.selected).map(option => option.value);
    }

    /**
     * 全部选中
     */
    selectAll() {
        this.list.selectAll();
    }

    /**
     * 全部取消选中
     */
    deselectAll() {
        this.list.deselectAll();
    }
}