import { HttpClient, HttpHeaders, HttpParams, HttpErrorResponse } from '@angular/common/http'
import { IocHelper as ioc } from './ioc-helper'
import { Observable } from "rxjs/Observable";

/**
 * Http操作
 */
export class HttpHelper {
    /**
     * get请求
     * @param url 请求地址
     */
    static get<T>(url: string): HttpRequest<T> {
        return new HttpRequest<T>(HttpMethod.Get, url);
    }

    /**
     * post请求
     * @param url 请求地址
     */
    static post<T>(url: string): HttpRequest<T> {
        return new HttpRequest<T>(HttpMethod.Post, url);
    }

    /**
     * put请求
     * @param url 请求地址
     */
    static put<T>(url: string): HttpRequest<T> {
        return new HttpRequest<T>(HttpMethod.Put, url);
    }

    /**
     * delete请求
     * @param url 请求地址
     */
    static delete<T>(url: string): HttpRequest<T> {
        return new HttpRequest<T>(HttpMethod.Delete, url);
    }
}

/**
 * Http请求操作
 */
export class HttpRequest<T> {
    /**
     * Http头集合
     */
    private headers: HttpHeaders;
    /**
     * 内容类型
     */
    private httpContentType: HttpContentType;
    /**
     * Http主体
     */
    private httpBody;
    /**
     * Http参数集合
     */
    private parameters: HttpParams;

    /**
     * 初始化Http请求操作
     * @param httpMethod Http方法
     * @param url 请求地址
     */
    constructor(private httpMethod: HttpMethod, private url: string) {
        this.headers = new HttpHeaders();
        this.parameters = new HttpParams();
    }

    /**
     * 添加Http头
     * @param name 名称
     * @param value 值
     */
    header(name: string, value: string): HttpRequest<T> {
        this.headers = this.headers.append(name, value);
        return this;
    }

    /**
     * 设置内容类型
     * @param contentType 内容类型
     */
    contentType(contentType: HttpContentType): HttpRequest<T> {
        this.httpContentType = contentType;
        return this;
    }

    /**
     * 添加Http主体
     * @param value 值
     */
    body(value): HttpRequest<T> {
        this.httpBody = value;
        return this;
    }

    /**
     * 添加字符串类型的Http主体
     * @param value 值
     */
    stringBody(value: string): HttpRequest<T> {
        return this.body(JSON.stringify(value));
    }

    /**
     * 添加Http参数,添加到url查询字符串
     * @param name 名称
     * @param value 值
     */
    param(name: string, value: string): HttpRequest<T> {
        this.parameters = this.parameters.append(name, value);
        return this;
    }

    /**
     * 添加Http参数,添加到url查询字符串
     * @param param 参数对象
     */
    data(param): HttpRequest<T> {
        for (let key in param) {
            if (param.hasOwnProperty(key))
                this.param(key, param[key]);
        }
        return this;
    }

    /**
     * 处理响应
     * @param handler 响应处理函数
     * @param errorHandler 错误处理函数
     * @param beforeHandler 发送前处理函数，返回false则取消发送
     * @param completeHandler 请求完成处理函数
     */
    handle(handler: (value: T) => void, errorHandler?: (error: HttpErrorResponse) => void, beforeHandler?: () => boolean, completeHandler?: () => void) {
        if (beforeHandler && beforeHandler() === false)
            return;
        this.request().subscribe(handler, errorHandler, completeHandler);
    }

    /**
     * 发送请求
     */
    private request(): Observable<T> {
        this.setContentType();
        let httpClient = ioc.get(HttpClient);
        let options = { headers: this.headers, params: this.parameters };
        switch (this.httpMethod) {
            case HttpMethod.Get:
                return httpClient.get<T>(this.url, options);
            case HttpMethod.Post:
                return httpClient.post<T>(this.url, this.httpBody, options);
            case HttpMethod.Put:
                return httpClient.put<T>(this.url, this.httpBody, options);
            case HttpMethod.Delete:
                return httpClient.delete<T>(this.url, options);
            default:
                return httpClient.get<T>(this.url, options);
        }
    }

    /**
     * 设置内容类型
     */
    private setContentType() {
        return this.header("Content-Type", this.getContentType(this.httpContentType));
    }

    /**
     * 获取内容类型
     * @param contentType
     */
    private getContentType(contentType: HttpContentType) {
        switch (contentType) {
        case HttpContentType.FormUrlEncoded:
            return "application/x-www-form-urlencoded";
        case HttpContentType.Json:
            return "application/json";
        default:
            return "application/json";
        }
    }
}

/**
 * Http方法
 */
enum HttpMethod {
    Get,
    Post,
    Put,
    Delete
}

/**
 * Http内容类型
 */
export enum HttpContentType {
    /**
     * application/x-www-form-urlencoded
     */
    FormUrlEncoded,
    /**
     * application/json
     */
    Json
}