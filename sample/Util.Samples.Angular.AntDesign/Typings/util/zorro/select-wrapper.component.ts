//============== NgZorro下拉列表包装器===================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Component, Input, OnInit, Host, Optional } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FormControlWrapperBase } from './base/form-control-wrapper-base';
import { SelectList, SelectItem, SelectOption, SelectOptionGroup } from "../core/select-model";
import { WebApi as webapi } from '../common/webapi';

/**
 * NgZorro下拉列表包装器
 */
@Component({
    selector: 'x-select',
    template: `
        <nz-form-control [nzValidateStatus]="(controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched))?'error':'success'">
            <nz-select #controlModel="ngModel" [name]="name" [ngModel]="model" (ngModelChange)="onModelChange($event)" 
                [nzPlaceHolder]="placeholder" [ngStyle]="getStyle()" 
                [nzMode]="multiple?'multiple':'default'" [nzMaxMultipleCount]="maxMultipleCount"
                [nzShowSearch]="showSearch" [nzAllowClear]="allowClear"
                (nzBlur)="blur($event)" (nzFocus)="focus($event)" (keyup)="keyup($event)" (keydown)="keydown($event)"
                [nzDisabled]="disabled" [required]="required">
                <nz-option *ngIf="defaultOptionText" [nzLabel]="defaultOptionText"></nz-option>
                <ng-container *ngIf="!isGroup">
                    <nz-option *ngFor="let item of options" [nzValue]="item.value" [nzLabel]="item.text" [nzDisabled]="item.disabled"></nz-option>
                </ng-container>
                <ng-container *ngIf="isGroup">
                    <nz-option-group *ngFor="let group of optionGroups" [nzLabel]="group.text">
                        <nz-option *ngFor="let item of group.value" [nzValue]="item.value" [nzLabel]="item.text" [nzDisabled]="item.disabled">
                        </nz-option>
                    </nz-option-group>
                </ng-container>
            </nz-select>
            <nz-form-explain *ngIf="controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched)">{{requiredMessage}}</nz-form-explain>
        </nz-form-control>
    `
})
export class Select extends FormControlWrapperBase implements OnInit {
    /**
     * 按组显示
     */
    isGroup: boolean;
    /**
     * 列表项集合
     */
    options: SelectOption[];
    /**
     * 列表组集合
     */
    optionGroups: SelectOptionGroup[];
    /**
     * 数据源
     */
    private data: SelectItem[];
    /**
     * 数据源
     */
    @Input() get dataSource(): SelectItem[] {
        return this.data;
    }
    set dataSource(value: SelectItem[]) {
        this.data = value;
        this.loadData();
    }
    /**
     * 请求地址
     */
    @Input() url: string;
    /**
     * 查询参数
     */
    @Input() queryParam;
    /**
     * 宽度
     */
    @Input() width?: string;
    /**
     * 多选
     */
    @Input() multiple: boolean;
    /**
     * 最多允许选中的数量
     */
    @Input() maxMultipleCount: number;
    /**
     * 默认项文本
     */
    @Input() defaultOptionText: string;
    /**
     * 显示清空按钮
     */
    @Input() allowClear: boolean;
    /**
     * 显示搜索框
     */
    @Input() showSearch: boolean;

    /**
     * 初始化下拉列表包装器
     */
    constructor(@Optional() @Host() form: NgForm) {
        super(form);
        this.allowClear = true;
        this.showSearch = true;
        this.maxMultipleCount = 9999;
    }

    /**
     * 获取样式
     */
    getStyle() {
        return {
            'width': this.width ? this.width : null
        };
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
        let select = new SelectList(data);
        if (select.isGroup()) {
            this.isGroup = true;
            this.optionGroups = select.toGroups();
            return;
        }
        this.isGroup = false;
        this.options = select.toOptions();
    }

    /**
     * 从服务器加载
     * @param url 请求地址
     * @param param 查询参数
     */
    loadUrl( url?: string, param = null) {
        url = url || this.url;
        if (!url)
            return;
        param = param || this.queryParam;
        webapi.get<SelectItem[]>(url).param(param).handle({
            ok: result => {
                this.loadData(result);
            }
        });
    }
}