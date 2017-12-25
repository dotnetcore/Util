import { HttpErrorResponse } from '@angular/common/http'
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
        return new WebApiRequest<T>(HttpHelper.get<T>(url));
    }

    /**
     * post请求
     * @param url 请求地址
     */
    public static post<T>(url: string): WebApiRequest<T> {
        return new WebApiRequest<T>(HttpHelper.post<T>(url));
    }

    /**
     * put请求
     * @param url 请求地址
     */
    public static put<T>(url: string): WebApiRequest<T> {
        return new WebApiRequest<T>(HttpHelper.put<T>(url));
    }

    /**
     * delete请求
     * @param url 请求地址
     */
    public static delete<T>(url: string): WebApiRequest<T> {
        return new WebApiRequest<T>(HttpHelper.delete<T>(url));
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
    constructor(private request: HttpRequest<T>) {
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
        this.request.handle(options.handler);
    }
}

/**
 * WebApi响应处理器配置
 */
export class WebApiHandleOptions<T> {
    /**
     * 发送前处理函数，返回false则取消发送
     */
    beforeHandler? : () => boolean;
    /**
     * 响应处理函数
     */
    handler: (value: T) => void;
    /**
     * 错误处理函数
     */
    errorHandler? : (error: HttpErrorResponse) => void;
    /**
     * 请求完成处理函数
     */
    completeHandler? : () => void;
}