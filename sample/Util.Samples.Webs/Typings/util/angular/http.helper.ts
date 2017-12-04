import { Http, Response } from '@angular/http'
import { IocHelper as ioc } from './ioc.helper'
import { Observable } from "rxjs";

/**
 * Http操作
 */
export class HttpHelper {
    /**
     * get请求
     * @param url
     */
    public static get(url: string): HttpHandler {
        let response = ioc.get(Http).get(url);
        return new HttpHandler(response);
    }
}

/**
 * Http响应处理器
 */
export class HttpHandler {
    /**
     * Http响应处理器
     * @param response 响应观察者
     */
    constructor(private response: Observable<Response>) {
    }

    /**
     * 处理响应
     * @param handler 响应处理函数
     */
    public handle(handler: (value: Response) => void) {
        this.response.subscribe(handler);
    }
}