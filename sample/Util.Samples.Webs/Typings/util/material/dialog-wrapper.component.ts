//============== 弹出层包装器  =====================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';

/**
 * 弹出层包装器
 */
@Component({
    selector: 'mat-dialog-wrapper',
    template: `
        <h2 mat-dialog-title>{{data.dialogTitle}}</h2>
        <mat-dialog-content [ngStyle]="getContentStyle()">
            <iframe *ngIf="url" [src]="url | safeUrl" frameborder="0" style="width:100%;height:96%"></iframe>
        </mat-dialog-content>
        <mat-dialog-actions align="end">
          <button mat-raised-button color="primary" mat-dialog-close>关 闭</button>
        </mat-dialog-actions>
  `
})
export class DialogWrapperComponent {
    /**
     * 请求地址
     */
    url: string;

    /**
     * 初始化弹出层包装器
     * @param data 数据
     */
    constructor( @Inject(MAT_DIALOG_DATA) public data) {
        this.url = data.dialogUrl;
    }

    /**
     * 获取内容区高度
     */
    getContentStyle() {
        return {
            "height": this.data.dialogHeight
        };
    }
}
