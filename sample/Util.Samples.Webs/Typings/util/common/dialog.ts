//============== 弹出层操作 ======================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { MatDialog, DialogPosition } from '@angular/material';
import { IocHelper as ioc } from '../angular/ioc-helper';
import { isNumber, toNumber } from './helper';
import { DialogWrapperComponent } from '../material/dialog-wrapper.component';

/**
 * 弹出层操作
 */
export class Dialog {
    /**
     * 打开弹出层
     * @param dialogOptions 弹出层配置
     */
    static open(dialogOptions?: IDialogOption) {
        let options: IDialogOption = dialogOptions || {};
        if (options.beforeOpen && !options.beforeOpen())
            return;
        Dialog.initOptions(options);
        let dialog = ioc.getByComponent(MatDialog);
        let dialogRef = dialog.open(options.dialogComponent, options);
        dialogRef.afterOpen().subscribe(() => options.afterOpen && options.afterOpen());
        dialogRef.beforeClose().subscribe((result) => options.beforeClose && options.beforeClose(result));
        dialogRef.afterClosed().subscribe((result) => options.afterClosed && options.afterClosed(result));
        dialogRef.backdropClick().subscribe(event => options.backdropClick && options.backdropClick(event));
    }

    /**
     * 初始化配置
     */
    private static initOptions(options: IDialogOption) {
        options.dialogComponent = options.dialogComponent || DialogWrapperComponent;
        Dialog.initData(options);
        Dialog.initPosition(options);
        options.width = Dialog.getUnitValue(options.width);
        options.height = Dialog.getUnitValue(options.height);
    }

    /**
     * 初始化数据
     * @param options
     */
    private static initData(options: IDialogOption) {
        if (!options.data)
            options.data = {};
        if (options.title)
            options.data["dialogTitle"] = options.title;
        if (options.url)
            options.data["dialogUrl"] = options.url;
        let height = Dialog.getContentHeight(options);
        if (height)
            options.data["dialogHeight"] = height;
    }

    /**
     * 获取内容高度
     */
    private static getContentHeight(options: IDialogOption) {
        let height = options.height ? options.height : options.minHeight && options.minHeight.toString();
        if (!height)
            return null;
        if (height.lastIndexOf("px") > 0)
            height = height.substr(0, height.length - 2);
        return Dialog.getUnitValue(toNumber(height) - 140);
    }

    /**
     * 初始化位置
     * @param options
     */
    private static initPosition(options: IDialogOption) {
        if (!options.position)
            return;
        options.position.top = Dialog.getUnitValue(options.position.top);
        options.position.bottom = Dialog.getUnitValue(options.position.bottom);
        options.position.left = Dialog.getUnitValue(options.position.left);
        options.position.right = Dialog.getUnitValue(options.position.right);
    }

    /**
     * 附加像素单位
     */
    private static getUnitValue(value) {
        return isNumber(value) ? `${value}px` : value;
    }

    /**
     * 关闭所有弹出层
     */
    static closeAll() {
        let dialog = ioc.getByComponent(MatDialog);
        dialog.closeAll();
    }

    /**
     * 关闭弹出层
     * @param result 返回结果
     */
    static close<TResult>(result?: TResult);
    /**
     * 关闭弹出层
     * @param result 返回结果
     * @param id 弹出层标识
     */
    static close<TResult>(result?: TResult,id?: string);
    static close<TResult>(result?: TResult,id?: string) {
        let dialog = ioc.getByComponent(MatDialog);
        let dialogRef;
        if (id)
            dialogRef = dialog.getDialogById(id);
        else {
            if (dialog.openDialogs.length === 0)
                return;
            dialogRef = dialog.openDialogs[dialog.openDialogs.length - 1];
        }
        dialogRef && dialogRef.close(result);
    }
}

/**
 * 弹出层配置
 */
export interface IDialogOption {
    /**
     * 弹出层组件，该组件应添加到模块 NgModule 装饰器的 entryComponents 配置节，默认使用 DialogWrapperComponent，
     */
    dialogComponent?,
    /**
     * 弹出层标识
     */
    id?: string,
    /**
     * 弹出层标题
     */
    title?: string,
    /**
     * 自定义数据，使用 MAT_DIALOG_DATA 标记注入到弹出层组件构造函数中
     */
    data?,
    /**
     * 将该地址加载到iframe中
     */
    url?: string,
    /**
     * 是否显示遮罩背景
     */
    hasBackdrop?: boolean,
    /**
     * 是否禁用按下ESC键或点击屏幕关闭遮罩，默认false
     */
    disableClose?: boolean,
    /**
     * 是否自动将焦点放在控件上,默认true
     */
    autoFocus?: boolean,
    /**
     * 点击历史导航前进或后退时是否关闭弹出层，默认true
     */
    closeOnNavigation?: boolean,
    /**
     * 弹出层位置，范例：{ top: "100px", left:"100px" }
     */
    position?: DialogPosition,
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
     * 遮罩背景自定义样式类
     */
    backdropClass?: string,
    /**
     * 面板自定义样式类
     */
    panelClass?: string,
    /**
     * 打开前操作，返回false则取消
     */
    beforeOpen?: () => boolean,
    /**
     * 打开后操作
     */
    afterOpen?: () => void,
    /**
     * 关闭前操作
     * @param result 返回结果
     */
    beforeClose?: (result) => void,
    /**
     * 关闭后操作
     * @param result 返回结果
     */
    afterClosed?: (result) => void,
    /**
     * 点击遮罩背景操作
     */
    backdropClick?: (event:MouseEvent) => void,
}