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
     * @param options 弹出层配置
     */
    static open( options?: IDialogOptions ):NzModalRef {
        options = options || {};
        if ( options.onBeforeOpen && options.onBeforeOpen() === false )
            return null;
        Dialog.initOptions( options );
        let dialog: NzModalService = Dialog.getModalService();
        let dialogRef: NzModalRef = dialog.create( this.toOptions( options ) );
        dialogRef.afterOpen.subscribe( () => options.onOpen && options.onOpen() );
        dialogRef.afterClose.subscribe( ( result ) => options.onClose && options.onClose( result ) );
        return dialogRef;
    }

    /**
     * 获取模态窗服务
     */
    private static getModalService() {
        return ioc.get( NzModalService );
    }

    /**
     * 初始化配置
     */
    private static initOptions( options: IDialogOptions ) {
        if ( !options.data )
            options.data = {};
    }

    /**
     * 转换配置
     */
    private static toOptions( options: IDialogOptions ): ModalOptionsForService {
        return {
            nzTitle: options.title,
            nzContent: options.component || options.content,
            nzComponentParams: options.data,
            nzCancelText: this.getCancelText( options ),
            nzOkText: this.getOkText( options ),
            nzOkType: options.okType,
            nzClosable: isUndefined( options.showClose ) ? true : options.showClose,
            nzMask: isUndefined( options.showMask ) ? true : options.showMask,
            nzFooter: this.getFooter( options ),
            nzWidth: options.width,
            nzMaskClosable: !options.disableClose,
            nzKeyboard: !options.disableClose,
            nzOnOk: options.onOk,
            nzOnCancel: data => {
                if ( data.tag === true ) {
                    options.onBeforeClose && options.onBeforeClose( data.result );
                    return;
                }
                options.onBeforeClose && options.onBeforeClose( null );
            }
        };
    }

    /**
     * 获取取消按钮文本
     */
    private static getCancelText( options: IDialogOptions ) {
        if ( options.showCancel === false )
            return null;
        return options.cancelText;
    }

    /**
     * 获取确定按钮文本
     */
    private static getOkText( options: IDialogOptions ) {
        if ( options.showOk === false )
            return null;
        return options.okText;
    }

    /**
     * 获取页脚
     */
    private static getFooter( options: IDialogOptions ) {
        if ( options.showFooter === false )
            return null;
        return options.footer;
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
        let dialog: NzModalService = Dialog.getModalService();
        if ( !dialog.openModals || dialog.openModals.length === 0 )
            return;
        let dialogRef: NzModalRef = dialog.openModals[dialog.openModals.length - 1];
        if ( !dialogRef )
            return;
        let content = dialogRef.getContentComponent();
        if ( !content && dialog.openModals.length > 1 )
            dialogRef = dialog.openModals[dialog.openModals.length - 2];
        if ( dialogRef["nzOnCancel"]( { result: result, tag: true } ) === false )
            return;
        dialogRef.close( result );
    }
}

/**
 * 弹出层配置
 */
export interface IDialogOptions {
    /**
     * 弹出层组件，该组件应添加到当前模块 NgModule 的 entryComponents
     */
    component?,
    /**
     * 传入弹出层组件中的参数
     */
    data?,
    /**
     * 标题
     */
    title?: string | TemplateRef<any>,
    /**
     * 内容
     */
    content?: string | TemplateRef<any>,
    /**
     * 是否显示页脚，默认为 true
     */
    showFooter?: boolean,
    /**
     * 页脚
     */
    footer?: string | TemplateRef<any> | Array<ModalButtonOptions>;
    /**
     * 是否显示右上角的关闭按钮，默认为 true
     */
    showClose?: boolean,
    /**
     * 是否显示底部取消按钮，默认为 true
     */
    showCancel?: boolean,
    /**
     * 底部取消按钮的文字
     */
    cancelText?: string,
    /**
     * 是否显示底部确定按钮，默认为 true
     */
    showOk?: boolean,
    /**
     * 底部确定按钮的文字
     */
    okText?: string,
    /**
     * 底部确定按钮的颜色, 可选值: default,primary,dashed,danger
     */
    okType?: string,
    /**
     * 是否显示遮罩，默认为 true
     */
    showMask?: boolean,
    /**
     * 是否禁用按下ESC键或点击屏幕关闭遮罩，默认 false
     */
    disableClose?: boolean,
    /**
     * 宽度
     */
    width?: string | number,
    /**
     * 点击确定按钮事件，返回 false 阻止关闭
     * @param instance 弹出层组件实例
     */
    onOk?: ( instance ) => ( false | void | {} ) | Promise<false | void | {}>,
    /**
     * 打开前事件，返回 false 阻止弹出
     */
    onBeforeOpen?: () => boolean,
    /**
     * 打开后事件
     */
    onOpen?: () => void,
    /**
     * 关闭前事件，返回 false 阻止关闭
     */
    onBeforeClose?: ( result ) => ( false | void | {} ) | Promise<false | void | {}>,
    /**
     * 关闭后事件
     * @param result 返回结果
     */
    onClose?: ( result ) => void;
}