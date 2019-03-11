//============== 弹出层操作 ======================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { IocHelper as ioc } from '../angular/ioc-helper';
import { isNumber, toNumber } from './helper';

/**
 * 弹出层操作
 */
export class Dialog {
    /**
     * 打开弹出层
     * @param dialogOptions 弹出层配置
     */
    static openAsync(dialogOptions?: IDialogOption) {
        let options: IDialogOption = dialogOptions || {};
        if (options.beforeOpen && !options.beforeOpen())
            return null;
        Dialog.initOptions(options);
      
    }

    /**
     * 打开弹出层
     * @param dialogOptions 弹出层配置
     */
    static open(dialogOptions?: IDialogOption) {
        let options: IDialogOption = dialogOptions || {};
        if (options.beforeOpen && !options.beforeOpen())
            return;
        Dialog.initOptions(options);
       
    }

    /**
     * 初始化配置
     */
    private static initOptions(options: IDialogOption) {
        Dialog.initData(options);
        Dialog.initPosition(options);
        options.width = Dialog.getUnitValue(options.width);
        options.height = Dialog.getUnitValue(options.height);
        if (!options.autoFocus)
            options.autoFocus = false;
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
    static close<TResult>(result?: TResult, id?: string);
    static close<TResult>(result?: TResult, id?: string) {
       
    }

    /**
     * 获取数据，注意：必须在OnInit之后的事件调用，不能在构造函数中调用，可能获取不到值
     */
    static getData<T>() {
        
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
     * 数据
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
    afterClosed?: (result) => boolean,
    /**
     * 点击遮罩背景操作
     */
    backdropClick?: (event: MouseEvent) => void;
}