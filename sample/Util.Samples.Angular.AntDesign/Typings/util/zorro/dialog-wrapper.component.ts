//============== 弹出层包装器  =====================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { Component, Inject } from '@angular/core';

/**
 * 弹出层包装器
 */
@Component({
    selector: 'mat-dialog-wrapper',
    template: `
       
  `
})
export class DialogWrapperComponent {
    /**
     * 请求地址
     */
    url: string;

    /**
     * 初始化弹出层包装器
     */
    constructor( ) {
        this.url = null;
    }

    /**
     * 获取内容区高度
     */
    getContentStyle() {
        return {
            "height": null
        };
    }
}
