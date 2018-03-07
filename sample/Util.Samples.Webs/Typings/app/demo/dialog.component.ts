import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import {util} from "../../util"

/**
 * 弹出层样例
 */
@Component({
    selector: 'dialog-demo',
    templateUrl:'/home/dialog'
})
export class DialogComponent {
    /**
     * 初始化
     * @param data 数据
     */
    constructor( @Inject(MAT_DIALOG_DATA) private data) {
    }

    onclick() {
        util.dialog.open({
            hasBackdrop: false,
            title:"测试",
            url: "http://www.bing.com",
            minWidth: 1200,
            height:"600"
        });
    }
}
