//============== 链接包装器=====================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Component, Input, Output, EventEmitter, ContentChild, TemplateRef} from '@angular/core';

/**
 * Mat链接包装器
 */
@Component({
    selector: 'mat-a-wrapper',
    template:`
        <ng-container [ngSwitch]="style">
            <a *ngSwitchCase="'mat-button'" mat-button [disabled]="disabled" [routerLink]="link"
                    [color]="color" [matTooltip]="tooltip" (click)="click($event)" >
                {{text}}
                <ng-container [ngTemplateOutlet]="template"></ng-container>
            </a>            
            <a *ngSwitchCase="'mat-icon-button'" mat-icon-button [disabled]="disabled" [routerLink]="link"
                    [color]="color" [matTooltip]="tooltip" (click)="click($event)">
                {{text}}
                <ng-container [ngTemplateOutlet]="template"></ng-container>
            </a>
            <a *ngSwitchCase="'mat-fab'" mat-fab [disabled]="disabled" [routerLink]="link"
                    [color]="color" [matTooltip]="tooltip" (click)="click($event)">
                {{text}}
                <ng-container [ngTemplateOutlet]="template"></ng-container>
            </a>
            <a *ngSwitchCase="'mat-mini-fab'" mat-mini-fab [disabled]="disabled" [routerLink]="link"
                    [color]="color" [matTooltip]="tooltip" (click)="click($event)">
                {{text}}
                <ng-container [ngTemplateOutlet]="template"></ng-container>
            </a>
            <a *ngSwitchDefault mat-raised-button [disabled]="disabled" [routerLink]="link"
                    [color]="color" [matTooltip]="tooltip" (click)="click($event)">
                {{text}}
                <ng-container [ngTemplateOutlet]="template"></ng-container>
            </a>
        </ng-container>
    `
})
export class AWrapperComponent {
    /**
     * 文本
     */
    @Input() text: string;
    /**
     * Mat按钮样式，可选值：mat-button,mat-raised-button,mat-icon-button,mat-fab,mat-mini-fab
     */
    @Input() style: string;
    /**
     * 颜色，可选值：primary,accent,warn
     */
    @Input() color: string;
    /**
     * 禁用
     */
    @Input() disabled: boolean;
    /**
     * 提示
     */
    @Input() tooltip: string;
    /**
     * 路由地址
     */
    @Input() link: string;
    /**
     * 单击事件
     */
    @Output() onClick = new EventEmitter<any>();
    /**
     * 模板，用来支持图标
     */
    @ContentChild(TemplateRef) template: TemplateRef<any>;

    /**
     * 单击事件
     */
    private click(event) {
        this.onClick.emit(event);
    }
}