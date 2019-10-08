//============== WebApi操作=========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { HttpErrorResponse } from '@angular/common/http';
import { Result, FailResult, StateCode } from '../core/result';
import { HttpHelper, HttpRequest, HttpContentType, HttpMethod } from '../angular/http-helper';
import { Message } from './message';

/**
 * WebApi操作,与服务端返回的标准result对象交互
 */
export class WebApi {
    /**
     * 发送请求
     * @param url 请求地址
     * @param httpMethod http方法
     * @param data 数据
     */
    static send<T>(url: string, httpMethod: HttpMethod, data?): WebApiRequest<T> {
        switch (httpMethod) {
            case HttpMethod.Get:
                return this.get<T>(url).param(data);
            case HttpMethod.Post:
                return this.post<T>(url, data);
            case HttpMethod.Put:
                return this.put<T>(url, data);
            case HttpMethod.Delete:
                return this.delete<T>(url).param(data);
            default:
                return this.get<T>(url).param(data);
        }
    }

    /**
     * get请求
     * @param url 请求地址
     */
    static get<T>(url: string): WebApiRequest<T> {
        return new WebApiRequest<T>(HttpHelper.get<Result<T>>(url));
    }

    /**
     * post请求
     * @param url 请求地址
     * @param body Http主体
     */
    static post<T>(url: string, body?): WebApiRequest<T> {
        return new WebApiRequest<T>(HttpHelper.post<Result<T>>(url, body));
    }

    /**
     * put请求
     * @param url 请求地址
     * @param body Http主体
     */
    static put<T>(url: string, body?): WebApiRequest<T> {
        return new WebApiRequest<T>(HttpHelper.put<Result<T>>(url, body));
    }

    /**
     * delete请求
     * @param url 请求地址
     */
    static delete<T>(url: string): WebApiRequest<T> {
        return new WebApiRequest<T>(HttpHelper.delete<Result<T>>(url));
    }
}

/**
 * WebApi请求操作
 */
export class WebApiRequest<T> {
    /**
     * 按钮
     */
    private btn;
    /**
     * 是否显示进度条
     */
    private isShowLoading?: boolean;

    /**
     * 初始化WebApi请求操作
     * @param request Http请求操作
     */
    constructor(private request: HttpRequest<Result<T>>) {
    }

    /**
     * 添加Http头
     * @param headers Http头集合
     */
    header(headers?: { name: string, value }[]): WebApiRequest<T>;
    /**
     * 添加Http头
     * @param name 名称
     * @param value 值
     */
    header(name: string, value): WebApiRequest<T>;
    header(name, value?): WebApiRequest<T> {
        if (typeof name === "object")
            this.addHeaders(name);
        else if (typeof name === "string")
            this.request.header(name, value);
        return this;
    }

    /**
     * 添加Http头
     */
    private addHeaders(param) {
        let headers = param as { name: string, value }[];
        if (!headers)
            return;
        headers.forEach(item => {
            this.request.header(item.name, item.value);
        });
    }

    /**
     * 设置响应类型
     * @param responseType 响应类型
     */
    responseType( responseType ): WebApiRequest<T>  {
        this.request.responseType(responseType);
        return this;
    }

    /**
     * 设置内容类型
     * @param contentType 内容类型
     */
    contentType(contentType: HttpContentType): WebApiRequest<T> {
        this.request.contentType(contentType);
        return this;
    }

    /**
     * 添加Http参数,添加到url查询字符串
     * @param data 参数对象
     */
    param(data): WebApiRequest<T>;
    /**
     * 添加Http参数,添加到url查询字符串
     * @param name 名称
     * @param value 值
     */
    param(name: string, value: string): WebApiRequest<T>;
    param(data, value?: string): WebApiRequest<T> {
        if (typeof data === "object") {
            this.request.param(data);
            return this;
        }
        if (typeof data === "string" && value)
            this.request.param(data, value);
        return this;
    }

    /**
     * 设置按钮
     * @param btn 按钮实例
     */
    button(btn): WebApiRequest<T> {
        this.btn = btn;
        return this;
    }

    /**
     * 请求时显示进度条
     */
    loading(isShowLoading?: boolean): WebApiRequest<T> {
        this.isShowLoading = isShowLoading === undefined ? true : isShowLoading;
        return this;
    }

    /**
     * 处理响应
     * @param options 响应处理器配置
     */
    handle(options: WebApiHandleOptions<T>) {
        if (!options)
            return;
        this.request.handle(
            (result: Result<T>) => this.handleOk(options, result),
            (error: HttpErrorResponse) => this.handleFail(options, undefined, error),
            () => this.handleBefore(options),
            () => this.handleComplete(options)
        );
    }

    /**
     * 处理响应
     * @param options 响应处理器配置
     */
    async handleAsync(options: WebApiHandleOptions<T>): Promise<void> {
        if (!options)
            return;
        return await this.request.handleAsync(
            (result: Result<T>) => this.handleOk(options, result),
            (error: HttpErrorResponse) => this.handleFail(options, undefined, error),
            () => this.handleBefore(options),
            () => this.handleComplete(options)
        );
    }

    /**
     * 处理成功响应
     */
    private handleOk(options: WebApiHandleOptions<T>, result: Result<T>) {
        if (!result)
            return;
        if (result.code === StateCode.Ok) {
            options.ok && options.ok(result.data);
            return;
        }
        this.handleFail(options, result);
    }

    /**
     * 处理失败响应
     */
    private handleFail(options: WebApiHandleOptions<T>, result?: Result<T>, errorResponse?: HttpErrorResponse) {
        let failResult = new FailResult(result, errorResponse);
        this.handleHttpException(options, failResult);
        if (options.fail) {
            options.fail(failResult);
            return;
        }
        if (result) {
            this.handleBusinessException(result);
            return;
        }
    }

    /**
     * 处理Http异常
     */
    private handleHttpException(options: WebApiHandleOptions<T>, failResult: FailResult) {
        if (failResult.errorResponse)
            console.log(this.getHttpExceptionMessage(failResult));
        if (options.complete)
            options.complete();
    }

    /**
     * 获取Http异常消息
     */
    private getHttpExceptionMessage(failResult: FailResult) {
        if (!failResult.errorResponse)
            return "";
        let error = failResult.errorResponse;
        if (!error)
            return "";
        return `Http请求异常：\nUrl:${error.url}\n状态码:${error.status},${error.statusText}\n`
            + `错误消息:${error.message}\n错误响应:\n ${error.error && error.error.text}\n`;
    }

    /**
     * 处理业务异常
     */
    private handleBusinessException(result: Result<T>) {
        if (result.code === StateCode.Fail) {
            Message.error(result.message);
            console.log(`业务异常:\n${result.message}`);
        }
    }

    /**
     * 发送前操作
     */
    private handleBefore(options: WebApiHandleOptions<T>): boolean {
        let result = options && options.before && options.before();
        if (result === false)
            return false;
        this.showLoading();
        return true;
    }

    /**
     * 显示加载状态
     */
    private showLoading() {
        if ( this.btn )
            this.btn.loading = true;
    }

    /**
     * 完成操作
     */
    private handleComplete(options: WebApiHandleOptions<T>) {
        options && options.complete && options.complete();
        this.closeLoading();
    }

    /**
     * 关闭加载状态
     */
    private closeLoading() {
        if ( this.btn )
            this.btn.loading = false;
    }
}

/**
 * WebApi响应处理器
 */
export class WebApiHandleOptions<T> {
    /**
     * 发送前处理函数，返回false则取消发送
     */
    before?: () => boolean;
    /**
     * 成功处理函数
     */
    ok: (value: T) => void;
    /**
     * 失败处理函数
     */
    fail?: (result: FailResult) => void;
    /**
     * 请求完成处理函数
     */
    complete?: () => void;
}