//============== 确认消息框  =====================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';

/**
 * 确认消息框
 */
@Component({
    selector: 'mat-confirm-dialog',
    template: `
        <h2 mat-dialog-title>{{data.dialogTitle}}</h2>
        <mat-dialog-content>            
            <mat-icon>help</mat-icon><span>{{data.content}}</span>
        </mat-dialog-content>
        <mat-dialog-actions align="end">
          <button mat-icon-button mat-dialog-close="" matTooltip="取消"><mat-icon>clear</mat-icon></button>
          <button mat-icon-button mat-dialog-close="ok" matTooltip="确认"><mat-icon>done</mat-icon></button>
        </mat-dialog-actions>
  `, styles: [`
        .mat-dialog-content .mat-icon{
            margin-right:0.5em;
            vertical-align: middle;
        }
        .mat-dialog-content span{
            vertical-align: middle;
        }
    `]
})
export class ConfirmComponent {
    /**
     * 初始化确认消息框
     * @param data 数据
     */
    constructor( @Inject(MAT_DIALOG_DATA) public data) {
    }
}