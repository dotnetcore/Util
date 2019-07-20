//============== NgZorro编辑行指令=======================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Directive, Input, OnInit, HostListener } from '@angular/core';
import { EditTableDirective } from "./edit-table.directive";
import { Util as util } from "../util";

/**
 * NgZorro编辑行指令
 */
@Directive( {
    selector: '[x-edit-row]',
    exportAs: 'utilEditRow'
} )
export class EditRowDirective implements OnInit {
    /**
     * 控件列表
     */
    controls: any[];
    /**
     * 行数据
     */
    @Input( 'x-edit-row' ) data;

    /**
     * 初始化编辑行指令
     * @param table 编辑表格指令
     */
    constructor( private table: EditTableDirective ) {
        this.controls = [];
    }

    /**
     * 初始化
     */
    ngOnInit() {
        if ( this.data )
            this.table && this.table.register( this.data.id, this );
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
     * 注销控件
     * @param control 控件
     */
    unRegister( control ) {
        if ( !control )
            return;
        util.helper.remove( this.controls, t => t === control );
    }

    /**
     * 处理行双击事件
     */
    @HostListener( 'dblclick', ['$event.target'] )
    handleDblClick( element ) {
        this.handleClick( element );
    }

    /**
     * 处理行点击事件
     */
    @HostListener( 'click', ['$event.target'] )
    handleClick( element ) {
        setTimeout( () => {
            if ( this.controls.length === 0 )
                return;
            let control = this.controls.find( t => element.contains( t.element.nativeElement ) );
            control && control.focus && control.focus();
        }, 100 );
    }

    /**
     * 是否有效
     */
    isValid() {
        return !this.controls.some( control => control && control.isValid && !control.isValid() );
    }

    /**
     * 设置焦点到验证失败的组件
     */
    focusToInvalid() {
        if ( this.controls.length === 0 )
            return;
        let control = this.controls.find( control => control && control.isValid && !control.isValid() );
        control && control.focus && control.focus();
    }

    /**
     * 设置焦点到第一个组件
     */
    focusToFirst() {
        if ( this.controls.length === 0 )
            return;
        let control = this.controls[0];
        control.focus && control.focus();
    }
}