import { HttpErrorResponse } from '@angular/common/http'
import { Result, FailResult, StateCode } from '../core/result';
import { toJson } from '../common/helper';
import { HttpHelper, HttpRequest } from '../angular/http-helper';

/**
 * WebApi操作,与服务端返回的标准result对象交互
 */
export class WebApi {
    /**
     * get请求
     * @param url 请求地址
     */
    public static get<T>(url: string): WebApiRequest<T> {
        return new WebApiRequest<T>(HttpHelper.get<Result<T>>(url));
    }

    /**
     * post请求
     * @param url 请求地址
     */
    public static post<T>(url: string): WebApiRequest<T> {
        return new WebApiRequest<T>(HttpHelper.post<Result<T>>(url));
    }

    /**
     * put请求
     * @param url 请求地址
     */
    public static put<T>(url: string): WebApiRequest<T> {
        return new WebApiRequest<T>(HttpHelper.put<Result<T>>(url));
    }

    /**
     * delete请求
     * @param url 请求地址
     */
    public static delete<T>(url: string): WebApiRequest<T> {
        return new WebApiRequest<T>(HttpHelper.delete<Result<T>>(url));
    }
}

/**
 * WebApi请求操作
 */
export class WebApiRequest<T> {
    /**
     * 初始化WebApi请求操作
     * @param request Http请求操作
     */
    constructor(private request: HttpRequest<Result<T>>) {
    }

    /**
     * 添加Http头
     * @param name 名称
     * @param value 值
     */
    public header(name: string, value: string): WebApiRequest<T> {
        this.request.header(name, value);
        return this;
    }

    /**
     * 添加Http主体
     * @param value 值
     */
    public body(value): WebApiRequest<T> {
        this.request.body(value);
        return this;
    }

    /**
     * 添加Http参数,添加到url查询字符串
     * @param name 名称
     * @param value 值
     */
    public param(name: string, value: string): WebApiRequest<T> {
        this.request.param(name, value);
        return this;
    }

    /**
     * 处理响应
     * @param options 响应处理器配置
     */
    public handle(options: WebApiHandleOptions<T>) {
        if (!options)
            return;
        this.request.handle(
            (result: Result<T>) => this.handleOk(options, result),
            (error: HttpErrorResponse) => this.handleFail(options, undefined, error),
            options.beforeHandler,
            options.completeHandler
        )
    }

    /**
     * 处理成功响应
     */
    private handleOk(options: WebApiHandleOptions<T>, result: Result<T>) {
        if (!result)
            return;
        if (result.code === StateCode.Ok) {
            options.handler && options.handler(result)
            return;
        }
        this.handleFail(options, result);
    }

    /**
     * 处理失败响应
     */
    private handleFail(options: WebApiHandleOptions<T>, result?: Result<T>, errorResponse?: HttpErrorResponse) {
        let failResult = new FailResult(result, errorResponse);
        if (options.failHandler) {
            options.failHandler(failResult);
            return;
        }
        this.handleHttpError(options, failResult);
    }

    /**
     * 处理Http异常
     */
    private handleHttpError(options: WebApiHandleOptions<T>, failResult: FailResult) {
        if (failResult.errorResponse)
            console.log(`发送请求失败：${toJson(failResult.errorResponse)}`);
        if (options.completeHandler)
            options.completeHandler();
    }
}

/**
 * WebApi响应处理器
 */
export class WebApiHandleOptions<T> {
    /**
     * 发送前处理函数，返回false则取消发送
     */
    beforeHandler?: () => boolean;
    /**
     * 成功处理函数
     */
    handler: (value: Result<T>) => void;
    /**
     * 失败处理函数
     */
    failHandler?: (result: FailResult) => void;
    /**
     * 请求完成处理函数
     */
    completeHandler?: () => void;
}

