//============== NgZorro编辑行指令=======================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Directive } from '@angular/core';

/**
 * NgZorro编辑行指令
 */
@Directive( {
    selector: '[x-edit-row]',
    exportAs: 'utilEditRow'
} )
export class EditRowDirective {
    /**
     * 控件列表
     */
    controls: any[];

    /**
     * 初始化编辑行指令
     */
    constructor() {
        this.controls = [];
    }

    /**
     * 注册控件
     * @param control 控件
     */
    register( control ) {
        if ( !control )
            return;
        this.controls.push( control );
    }

    /**
     * 是否有效
     */
    isValid() {
        return !this.controls.some( control => control && control.isValid && !control.isValid() );
    }

    /**
     * 设置焦点
     */
    focus() {
        if ( this.controls.length === 0 )
            return;
        let control = this.controls.find( control => control && control.isValid && !control.isValid() );
        control && control.focus && control.focus();
    }
}