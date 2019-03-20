//============== 消息操作=========================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { Observable } from 'rxjs';
import { NzMessageService, NzModalService } from 'ng-zorro-antd';
import { IocHelper as ioc } from '../angular/ioc-helper';

/**
 * 消息操作
 */
export class Message {
    /**
     * 成功消息
     * @param message 消息
     */
    static success( message: string ): void {
        let service = ioc.injector.get( NzMessageService );
        service.success( message );
    }

    /**
     * 信息消息
     * @param message 消息
     */
    static info( message: string ): void {
        let service = ioc.injector.get( NzMessageService );
        service.info( message );
    }

    /**
     * 警告消息
     * @param message 消息
     */
    static warn( message: string ): void {
        let service = ioc.injector.get( NzMessageService );
        service.warning( message );
    }

    /**
     * 错误消息
     * @param message 消息
     */
    static error( message: string ): void {
        let service = ioc.injector.get( NzMessageService );
        service.error( message );
    }

    /**
     * 确认
     * @param options 配置
     */
    static confirm( options: {
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
    } ): void;
    /**
     * 确认
     * @param message 消息
     * @param ok 确认回调函数
     */
    static confirm( message: string, ok?: () => void ): void;
    static confirm( options, ok?): void {
        let message = "";
        let title = "";
        let cancel: () => void;
        if ( typeof options === "object" ) {
            message = options["message"];
            title = options["title"];
            ok = options["ok"];
            cancel = options["cancel"];
        }
        else if ( typeof options === "string" ) {
            message = options;
        }
        let service = ioc.injector.get( NzModalService );
        service.confirm( {
            nzTitle: title || "提示",
            nzContent: message,
            nzOnOk: ok,
            nzOnCancel: cancel
        } );
    }
}