//============== 弹出层操作 ======================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { TemplateRef } from '@angular/core';
import { NzModalService, ModalOptionsForService, NzModalRef, ModalButtonOptions } from "ng-zorro-antd";
import { IocHelper as ioc } from '../angular/ioc-helper';
import { isNumber, toNumber, isUndefined } from './helper';

/**
 * 弹出层操作
 */
export class Dialog {
    /**
     * 打开弹出层
     * @param dialogOptions 弹出层配置
     */
    static openAsync( dialogOptions?: IDialogOptions ) {
        let options: IDialogOptions = dialogOptions || {};
        if ( options.onBeforeOpen && !options.onBeforeOpen() )
            return null;
        Dialog.initOptions( options );
        let dialog = Dialog.getModalService();
        let dialogRef: NzModalRef = dialog.create( this.toOptions( options ) );
        dialogRef.afterOpen.subscribe( () => options.onAfterOpen && options.onAfterOpen() );
        return dialogRef.afterClose.map( ( result ) => options.onAfterClose && options.onAfterClose( result ) );
    }

    /**
     * 获取模态窗服务
     */
    private static getModalService() {
        return ioc.injector.get( NzModalService );
    }

    /**
     * 打开弹出层
     * @param options 弹出层配置
     */
    static open( options?: IDialogOptions ) {
        options = options || {};
        if ( options.onBeforeOpen && !options.onBeforeOpen() )
            return;
        Dialog.initOptions( options );
        let dialog = Dialog.getModalService();
        let dialogRef: NzModalRef = dialog.create( this.toOptions( options ) );
        dialogRef.afterOpen.subscribe( () => options.onAfterOpen && options.onAfterOpen() );
        dialogRef.afterClose.subscribe( ( result ) => options.onAfterClose && options.onAfterClose( result ) );
    }

    /**
     * 初始化配置
     */
    private static initOptions( options: IDialogOptions ) {
        Dialog.initData( options );
        Dialog.initPosition( options );
        options.width = Dialog.getUnitValue( options.width );
        options.height = Dialog.getUnitValue( options.height );
        if ( !options.autoFocus )
            options.autoFocus = false;
    }

    /**
     * 初始化数据
     * @param options
     */
    private static initData( options: IDialogOptions ) {
        if ( !options.data )
            options.data = {};
        if ( options.title )
            options.data["dialogTitle"] = options.title;
        if ( options.url )
            options.data["dialogUrl"] = options.url;
        let height = Dialog.getContentHeight( options );
        if ( height )
            options.data["dialogHeight"] = height;
    }

    /**
     * 获取内容高度
     */
    private static getContentHeight( options: IDialogOptions ) {
        let height = options.height ? options.height : options.minHeight && options.minHeight.toString();
        if ( !height )
            return null;
        if ( height.lastIndexOf( "px" ) > 0 )
            height = height.substr( 0, height.length - 2 );
        return Dialog.getUnitValue( toNumber( height ) - 140 );
    }

    /**
     * 初始化位置
     * @param options
     */
    private static initPosition( options: IDialogOptions ) {
        if ( !options.position )
            return;
        options.position.top = Dialog.getUnitValue( options.position.top );
        options.position.bottom = Dialog.getUnitValue( options.position.bottom );
        options.position.left = Dialog.getUnitValue( options.position.left );
        options.position.right = Dialog.getUnitValue( options.position.right );
    }

    /**
     * 附加像素单位
     */
    private static getUnitValue( value ) {
        return isNumber( value ) ? `${value}px` : value;
    }

    /**
     * 转换配置
     * @param options
     */
    private static toOptions( options: IDialogOptions ): ModalOptionsForService {
        return {
            nzTitle: options.title,
            nzContent: options.content || options.dialogComponent,
            nzComponentParams: options.data,
            nzClosable: isUndefined( options.closable ) ? true : options.closable,
            nzMask: isUndefined( options.mask ) ? true : options.mask,
            nzFooter: options.footer,
            nzOnOk: options.onOk,
            nzOnCancel: options.onCancel || options.onBeforeClose
        };
    }

    /**
     * 关闭所有弹出层
     */
    static closeAll() {
        let dialog = Dialog.getModalService();
        dialog.closeAll();
    }

    /**
     * 关闭弹出层
     * @param result 返回结果
     */
    static close( result?) {
        let dialog = Dialog.getModalService();
        if ( !dialog.openModals || dialog.openModals.length === 0 )
            return;
        let dialogRef = dialog.openModals[dialog.openModals.length - 1];
        dialogRef && dialogRef.close( result );
    }
}

/**
 * 弹出层配置
 */
export interface IDialogOptions {
    /**
     * 弹出层组件，该组件应添加到模块 NgModule 装饰器的 entryComponents 配置节
     */
    dialogComponent?,
    /**
     * 标题
     */
    title?: string,
    /**
     * 内容
     */
    content?: string,
    /**
     * 数据
     */
    data?,
    /**
     * 将该地址加载到iframe中
     */
    url?: string,
    /**
     * 是否显示右上角的关闭按钮，默认为 true
     */
    closable?: boolean,
    /**
     * 是否显示遮罩，默认为 true
     */
    mask?: boolean,
    /**
     * 是否禁用按下ESC键或点击屏幕关闭遮罩，默认false
     */
    disableClose?: boolean,
    /**
     * 是否自动将焦点放在控件上,默认false
     */
    autoFocus?: boolean,
    /**
     * 点击历史导航前进或后退时是否关闭弹出层，默认true
     */
    closeOnNavigation?: boolean,
    /**
     * 弹出层位置，范例：{ top: "100px", left:"100px" }
     */
    position?,
    /**
     * 宽度
     */
    width?: string,
    /**
     * 高度
     */
    height?: string,
    /**
     * 最小宽度
     */
    minWidth?: number | string,
    /**
     * 最小高度
     */
    minHeight?: number | string,
    /**
     * 最大宽度
     */
    maxWidth?: number | string,
    /**
     * 最大高度
     */
    maxHeight?: number | string,
    /**
     * 底部内容
     */
    footer?: string | TemplateRef<{}> | Array<ModalButtonOptions>;
    /**
     * 点击确定按钮事件，返回false则阻止关闭弹出框
     */
    onOk?: ( instance ) => ( false | void | {} ) | Promise<false | void | {}>,
    /**
     * 关闭弹出层事件，点击遮罩层，点击右上角关闭按钮，点击取消按钮都可触发，返回false则阻止关闭弹出框
     */
    onCancel?: ( instance ) => ( false | void | {} ) | Promise<false | void | {}>,
    /**
     * 打开前事件，返回false则取消
     */
    onBeforeOpen?: () => boolean,
    /**
     * 打开后事件
     */
    onAfterOpen?: () => void,
    /**
     * 关闭前事件，返回false则阻止关闭弹出框
     */
    onBeforeClose?: ( instance ) => ( false | void | {} ) | Promise<false | void | {}>,
    /**
     * 关闭后事件
     * @param result 返回结果
     */
    onAfterClose?: ( result ) => void;
}