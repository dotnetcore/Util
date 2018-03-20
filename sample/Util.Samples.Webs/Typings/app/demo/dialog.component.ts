import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import {util} from "../../util"
import { env } from "../env"

/**
 * 弹出层样例
 */
@Component({
    selector: 'dialog-demo',
    templateUrl: env.prod ? './dialog.html' :'/home/dialog'
})
export class DialogComponent {
    /**
     * 初始化
     * @param data 数据
     */
    constructor( @Inject(MAT_DIALOG_DATA) public data) {
    }

    onclick() {
        util.dialog.open({
            title:"测试",
            url: "http://www.bing.com",
            minWidth: 1200,
            height:"600"
        });
    }
}
