//============== 消息操作=========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { MatSnackBar } from '@angular/material';
import { MessageService } from 'primeng/components/common/messageservice';
import { ConfirmationService } from 'primeng/primeng';
import { IocHelper as ioc } from '../angular/ioc-helper';

/**
 * 消息操作
 */
export class Message {
    /**
     * 成功消息
     * @param message 消息
     * @param title 标题
     */
    static success(message: string, title?: string): void {
        var service = ioc.get(MessageService);
        service.add({ severity: 'success', summary: title || "成功", detail: message });
    }

    /**
     * 信息消息
     * @param message 消息
     * @param title 标题
     */
    static info(message: string, title?: string): void {
        var service = ioc.get(MessageService);
        service.add({ severity: 'info', summary: title || "信息", detail: message });
    }

    /**
     * 警告消息
     * @param message 消息
     * @param title 标题
     */
    static warn(message: string, title?: string): void {
        var service = ioc.get(MessageService);
        service.add({ severity: 'warn', summary: title || "警告", detail: message });
    }

    /**
     * 错误消息
     * @param message 消息
     * @param title 标题
     */
    static error(message: string, title?: string): void {
        var service = ioc.get(MessageService);
        service.add({ severity: 'error', summary: title || "错误", detail: message });
    }

    /**
     * 确认
     * @param options 配置
     */
    static confirm(options: {
        /**
         * 消息
         */
        message: string,
        /**
         * 确认回调函数
         */
        ok: () => void,
        /**
         * 取消回调函数
         */
        cancel?: () => void,
        /**
         * 标题
         */
        title?: string;
    }): void;
    /**
     * 确认
     * @param message 消息
     * @param ok 确认回调函数
     */
    static confirm(message: string, ok?: () => void): void;
    static confirm(options, ok?): void {
        let service = ioc.get(ConfirmationService);
        let message = "";
        let title = "";
        let cancel = () => { };
        if (typeof options === "object") {
            message = options["message"];
            title = options["title"];
            ok = options["ok"];
            cancel = options["cancel"];
        }
        else if (typeof options === "string") {
            message = options;
        }
        service.confirm({
            message: message,
            accept: ok,
            reject: cancel,
            header: title || "确认"
        });
    }

    /**
     * 小提示
     * @param options
     */
    static snack(options: {
        /**
         * 消息
         */
        message: string;
        /**
         * 持续时间，单位：毫秒，默认值：2000
         */
        duration?: number;
        /**
         * 操作文本
         */
        actionLabel?: string;
        /**
         * 操作
         */
        action?: () => void;
    });
    /**
     * 小提示
     * @param message 消息
     */
    static snack(message: string);
    static snack(options) {
        let bar = ioc.get(MatSnackBar);
        let message = "";
        let actionLabel = "";
        let action;
        let duration;
        if (typeof options === "object") {
            message = options["message"];
            actionLabel = options["actionLabel"];
            action = options["action"];
            duration = options["duration"];
        }
        else if (typeof options === "string") {
            message = options;
        }
        let ref = bar.open(message, actionLabel || "关闭", {
            duration: duration || 2000
        });
        if (action)
            ref.onAction().subscribe(action);
    }
}