import { MessageService } from 'primeng/components/common/messageservice';
import { IocHelper as ioc } from "../angular/ioc-helper";

/**
 * 消息操作
 */
export class Message {
    /**
     * 成功消息
     * @param message 消息
     * @param title 标题
     */
    public static success(message: string, title?: string): void {
        var messageService = ioc.get(MessageService);
        messageService.add({ severity: 'success', summary: title || "成功", detail: message });
    }

    /**
     * 信息消息
     * @param message 消息
     * @param title 标题
     */
    public static info(message: string, title?: string): void {
        var messageService = ioc.get(MessageService);
        messageService.add({ severity: 'info', summary: title || "信息", detail: message });
    }

    /**
     * 警告消息
     * @param message 消息
     * @param title 标题
     */
    public static warn(message: string, title?: string): void {
        var messageService = ioc.get(MessageService);
        messageService.add({ severity: 'warn', summary: title || "警告", detail: message });
    }

    /**
     * 错误消息
     * @param message 消息
     * @param title 标题
     */
    public static error(message: string, title?: string): void {
        var messageService = ioc.get(MessageService);
        messageService.add({ severity: 'error', summary: title || "错误", detail: message });
    }
}