//============== NgZorro表格编辑控件指令=================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Directive, Input, OnInit, OnDestroy, ElementRef, Self, Optional } from '@angular/core';
import { NgControl } from '@angular/forms';
import { EditRowDirective } from "./edit-row.directive";

/**
 * NgZorro表格编辑控件指令
 */
@Directive( {
    selector: '[x-edit-control]',
    exportAs: 'utilEditControl'
} )
export class EditControlDirective implements OnInit, OnDestroy {
    /**
     * 编辑行
     */
    @Input() row: EditRowDirective;

    /**
     * 初始化表格编辑控件指令
     * @param element 元素
     * @param control 组件
     */
    constructor( @Self() private element: ElementRef, @Optional() @Self() private control: NgControl ) {
    }

    /**
     * 初始化
     */
    ngOnInit() {
        if ( this.row )
            this.row.register( this );
    }

    /**
     * 组件销毁
     */
    ngOnDestroy() {
        if ( this.row )
            this.row.unRegister( this );
    }

    /**
     * 是否有效
     */
    isValid() {
        if ( !this.control )
            return false;
        return !this.control.invalid;
    }

    /**
     * 设置焦点
     */
    focus() {
        setTimeout( () => {
            if ( this.element && this.element.nativeElement )
                this.element.nativeElement.focus();
        }, 0 );
    }

    /**
     * 获取html元素
     */
    getNativeElement() {
        if ( this.element )
            return this.element.nativeElement;
        return null;
    }
}