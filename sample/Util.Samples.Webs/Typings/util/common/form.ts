//============== 表单操作 ========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { FailResult } from '../core/result';
import { ViewModel } from '../core/view-model';
import { HttpMethod } from '../angular/http-helper';
import { WebApi } from './webapi';
import { RouterHelper } from "../angular/router-helper";
import { Message } from './message';
import { MessageConfig } from '../config/message-config';

/**
 * 表单操作
 */
export class Form {
    /**
     * 提交表单
     * @param options 表单提交参数
     */
    submit(options: FormSubmitOptions): void {
        if (!this.validateSubmit(options))
            return;
        if (!this.submitBefore(options))
            return;
        if (!options.confirm) {
            this.submitForm(options);
            return;
        }
        Message.confirm({
            title: options.confirmTitle,
            message: options.confirm,
            ok: () => this.submitForm(options),
            cancel: options.completeHandler
        });
    }

    /**
     * 提交表单验证
     */
    private validateSubmit(options: FormSubmitOptions) {
        if (!options) {
            console.log("表单参数[options: FormSubmitOptions]不能为空");
            return false;
        }
        if (!options.data) {
            Message.error("表单参数不能为空");
            return false;
        }
        return true;
    }

    /**
     * 提交前操作
     */
    private submitBefore(options: FormSubmitOptions) {
        if (!options.beforeHandler)
            return true;
        return options.beforeHandler();
    }

    /**
     * 提交表单
     */
    private submitForm(options: FormSubmitOptions) {
        if (!options.url) {
            Message.error("表单Url未设置");
            options.completeHandler && options.completeHandler();
            return;
        }
        if (!options.httpMethod) {
            options.httpMethod = options.data.id ? HttpMethod.Put : HttpMethod.Post;
        }
        WebApi.send(options.url, options.httpMethod, options.data).handle({
            handler: result => {
                this.submitHandler(options, result);
            },
            failHandler: result => {
                options.failHandler && options.failHandler(result);
            },
            completeHandler: options.completeHandler
        });
    }

    /**
     * 提交表单成功处理函数
     */
    private submitHandler(options: FormSubmitOptions, result) {
        if (options.handler) {
            options.handler(result);
            return;
        }
        Message.success(MessageConfig.successed);
        if (!options.isDialog)
            RouterHelper.back();
    }
}

/**
 * 表单提交参数
 */
export class FormSubmitOptions {
    /**
     * 请求地址
     */
    url?: string;
    /**
     * Http方法
     */
    httpMethod?: HttpMethod;
    /**
     * 提交数据
     */
    data: ViewModel;
    /**
     * 提交前是否需要确认,确认消息
     */
    confirm?: string;
    /**
     * 确认标题
     */
    confirmTitle?: string;
    /**
     * 是否弹出层编辑方式，默认为否，在操作成功后，返回上一个视图，如果设为true,则关闭弹出层
     */
    isDialog?:boolean;
    /**
     * 提交前处理函数，返回false则取消提交
     */
    beforeHandler?: () => boolean;
    /**
     * 提交成功处理函数
     */
    handler?: (result) => void;
    /**
     * 提交失败处理函数
     */
    failHandler?: (result: FailResult) => void;
    /**
     * 操作完成处理函数
     */
    completeHandler?: () => void;
}