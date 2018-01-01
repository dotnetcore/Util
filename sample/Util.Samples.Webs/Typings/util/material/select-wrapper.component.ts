import { Component, Input, OnInit } from '@angular/core';
import { SelectOption, SelectOptionGroup } from '../core/select-option';

/**
 * Mat下拉列表包装器
 */
@Component({
    selector: 'mat-select-wrapper',
    template:`
        <mat-form-field>
            <mat-select [placeholder]="placeholder" [multiple]="multiple">
                <mat-option *ngIf="!multiple">{{resetOptionText}}</mat-option>
                <mat-option *ngIf="!dataSource.isGroup" *ngFor="let item of dataSource" [value]="item.value" [disabled]="item.disabled">
                    {{ item.text }}
                </mat-option>
                <mat-optgroup *ngIf="dataSource.isGroup" *ngFor="let group of dataSource" [label]="group.text" [disabled]="group.disabled">
                    <mat-option *ngFor="let item of group.value" [value]="item.value" [disabled]="item.disabled">
                        {{ item.text }}
                    </mat-option>
                </mat-optgroup>
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
     * 初始化Mat下拉列表包装器
     */
    constructor() {
        this.multiple = false;
    }

    /**
     * 组件初始化
     */
    ngOnInit() {
    }
}