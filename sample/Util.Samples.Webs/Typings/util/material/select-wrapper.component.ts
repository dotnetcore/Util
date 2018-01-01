import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { SelectOption, SelectOptionGroup } from '../core/select-option';

/**
 * Mat下拉列表包装器
 */
@Component({
    selector: 'mat-select-wrapper',
    template:`
        <mat-form-field>
            <mat-select [placeholder]="placeholder" [multiple]="multiple" [ngModel]="model" (ngModelChange)="onChange($event)">
                <mat-option *ngIf="!multiple">{{resetOptionText}}</mat-option>
                <ng-container *ngIf="!isGroup">
                    <mat-option *ngFor="let item of dataSource" [value]="item.value" [disabled]="item.disabled">
                        {{ item.text }}
                    </mat-option>
                </ng-container>
                <ng-container *ngIf="isGroup">
                    <mat-optgroup *ngFor="let group of dataSource" [label]="group.text" [disabled]="group.disabled">
                        <mat-option *ngFor="let item of group.value" [value]="item.value" [disabled]="item.disabled">
                            {{ item.text }}
                        </mat-option>
                    </mat-optgroup>
                </ng-container>
            </mat-select>
        </mat-form-field>
    `,
    styles: [`
    `]
})
export class SelectWrapperComponent implements OnInit {
    /**
     * 数据源
     */
    @Input() dataSource: SelectOption[] | SelectOptionGroup[];
    /**
     * 按组显示
     */
    @Input() isGroup: boolean;
    /**
     * 多选
     */
    @Input() multiple: boolean;
    /**
     * 占位提示
     */
    @Input() placeholder: string;
    /**
     * 重置项文本
     */
    @Input() resetOptionText: string;
    /**
     * 双向绑定模型
     */
    @Input() model;
    /**
     * 模型变更事件
     */
    @Output() modelChange = new EventEmitter<any>();

    /**
     * 初始化Mat下拉列表包装器
     */
    constructor() {
        this.multiple = false;
        this.isGroup = false;
    }

    /**
     * 组件初始化
     */
    ngOnInit() {
    }

    /**
     * 下拉列表变更事件处理
     */
    private onChange(value) {
        this.modelChange.emit(value);
    }
}