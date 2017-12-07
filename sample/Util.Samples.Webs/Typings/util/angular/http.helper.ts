import { Http, Response } from '@angular/http'
import { IocHelper as ioc } from './ioc.helper'
import { Observable } from "rxjs";

/**
 * Http操作
 */
export class HttpHelper {
    /**
     * get请求
     * @param url 请求地址
     */
    public static get(url: string): HttpRequest {
        return new HttpRequest(url);
    }
}

/**
 * Http请求操作
 */
class HttpRequest {
    private _headers;

    private _response: Observable<Response>;

    /**
     * 初始化Http请求操作
     * @param url 请求地址
     */
    constructor(private url: string) {
        this._headers = new Headers({'Content-Type': 'application/x-www-form-urlencoded' });
    }

    private request() {
        if (this._response)
            return;
        this._response = ioc.get(Http).get(this.url, { headers: this._headers});
    }

    /**
     * 处理响应
     * @param handler 响应处理函数
     */
    public handle(handler: (value: Response) => void) {
        this.request();
        this._response.subscribe(handler);
    }
}

/**
 * Http内容类型
 */
export enum HttpContentType {
    /**
     * application/json
     */
    Json
}