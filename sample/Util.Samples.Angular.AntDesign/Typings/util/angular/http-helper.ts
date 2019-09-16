//============== Http操作=========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { HttpClient, HttpHeaders, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { IocHelper as ioc } from './ioc-helper';
import { formatDate } from '../common/helper';

/**
 * Http操作
 */
export class HttpHelper {
    /**
     * 发送请求
     * @param url 请求地址
     * @param httpMethod http方法
     * @param data 数据
     */
    static send<T>( url: string, httpMethod: HttpMethod, data?): HttpRequest<T> {
        switch ( httpMethod ) {
            case HttpMethod.Get:
                return this.get<T>( url ).param( data );
            case HttpMethod.Post:
                return this.post<T>( url, data );
            case HttpMethod.Put:
                return this.put<T>( url, data );
            case HttpMethod.Delete:
                return this.delete<T>( url ).param( data );
            default:
                return this.get<T>( url ).param( data );
        }
    }

    /**
     * get请求
     * @param url 请求地址
     */
    static get<T>( url: string ): HttpRequest<T> {
        return new HttpRequest<T>( HttpMethod.Get, url );
    }

    /**
     * post请求
     * @param url 请求地址
     * @param body Http主体
     */
    static post<T>( url: string, body?): HttpRequest<T> {
        return new HttpRequest<T>( HttpMethod.Post, url, body );
    }

    /**
     * put请求
     * @param url 请求地址
     * @param body Http主体
     */
    static put<T>( url: string, body?): HttpRequest<T> {
        return new HttpRequest<T>( HttpMethod.Put, url, body );
    }

    /**
     * delete请求
     * @param url 请求地址
     */
    static delete<T>( url: string ): HttpRequest<T> {
        return new HttpRequest<T>( HttpMethod.Delete, url );
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
     * Http参数集合
     */
    private parameters: HttpParams;
    /**
     * 响应类型
     */
    private httpResponseType;

    /**
     * 初始化Http请求操作
     * @param httpMethod Http方法
     * @param url 请求地址
     * @param body Http主体
     */
    constructor( private httpMethod: HttpMethod, private url: string, private body?) {
        this.headers = new HttpHeaders();
        this.parameters = new HttpParams();
    }

    /**
     * 添加Http头
     * @param name 名称
     * @param value 值
     */
    header( name: string, value ): HttpRequest<T> {
        let stringValue = "";
        if ( value !== undefined && value !== null )
            stringValue = String( value );
        this.headers = this.headers.append( name, stringValue );
        return this;
    }

    /**
     * 设置内容类型
     * @param contentType 内容类型
     */
    contentType( contentType: HttpContentType ): HttpRequest<T> {
        this.httpContentType = contentType;
        return this;
    }

    /**
     * 设置响应类型
     * @param responseType 响应类型
     */
    responseType( responseType ): HttpRequest<T>{
        this.httpResponseType = responseType;
        return this;
    }

    /**
    * 添加Http参数,添加到url查询字符串
    * @param data 参数对象
    */
    param( data ): HttpRequest<T>;
    /**
     * 添加Http参数,添加到url查询字符串
     * @param name 名称
     * @param value 值
     */
    param( name: string, value: string ): HttpRequest<T>;
    param( data, value?: string ): HttpRequest<T> {
        if ( typeof data === "object" ) {
            this.paramByObject( data );
            return this;
        }
        if ( typeof data === "string" && value )
            this.parameters = this.parameters.append( data, value );
        return this;
    }

    /**
     * 添加Http参数
     */
    private paramByObject( data ) {
        for ( let key in data ) {
            if ( data.hasOwnProperty( key ) ) {
                let value = this.getValue( data[key] );
                if ( value == null )
                    value = "";
                this.parameters = this.parameters.append( key, value );
            }
        }
    }

    /**
     * 获取值
     */
    private getValue( item ): string {
        if ( !item )
            return item;
        if ( item instanceof Date )
            return formatDate( item );
        return item;
    }

    /**
     * 处理响应
     * @param handler 响应处理函数
     * @param errorHandler 错误处理函数
     * @param beforeHandler 发送前处理函数，返回false则取消发送
     * @param completeHandler 请求完成处理函数
     */
    handle( handler: ( value: T ) => void, errorHandler?: ( error: HttpErrorResponse ) => void, beforeHandler?: () => boolean, completeHandler?: () => void ) {
        if ( beforeHandler && beforeHandler() === false )
            return;
        this.request().subscribe( handler, errorHandler, completeHandler );
    }

    /**
     * 处理响应
     * @param handler 响应处理函数
     * @param errorHandler 错误处理函数
     * @param beforeHandler 发送前处理函数，返回false则取消发送
     * @param completeHandler 请求完成处理函数
     */
    async handleAsync( handler: ( value: T ) => void, errorHandler?: ( error: HttpErrorResponse ) => void, beforeHandler?: () => boolean, completeHandler?: () => void ): Promise<void> {
        if ( beforeHandler && beforeHandler() === false )
            return;
        return await this.request().toPromise().then( handler ).catch( errorHandler ).then( completeHandler );
    }

    /**
     * 发送请求
     */
    private request() {
        this.setContentType();
        let httpClient = ioc.get<HttpClient>( HttpClient );
        let options = { headers: this.headers, params: this.parameters, responseType: this.httpResponseType };
        switch ( this.httpMethod ) {
            case HttpMethod.Get:
                return httpClient.get<T>( this.url, options );
            case HttpMethod.Post:
                return httpClient.post<T>(this.url, this.getBody(), options );
            case HttpMethod.Put:
                return httpClient.put<T>( this.url, this.getBody(), options );
            case HttpMethod.Delete:
                return httpClient.delete<T>( this.url, options );
            default:
                return httpClient.get<T>( this.url, options );
        }
    }

    /**
     * 获取body
     */
    private getBody() {
        if ( typeof this.body === "string" )
            return JSON.stringify( this.body );
        this.processBody();
        return this.body;
    }

    /**
     * 对body进行处理
     */
    private processBody() {
        for ( let key in this.body ) {
            if ( !this.body.hasOwnProperty( key ) )
                continue;;
            let value = this.getValue( this.body[key] );
            if ( value === undefined || value === null || value === '' ) {
                delete this.body[key];
                continue;;
            }
            this.body[key] = this.getValue( this.body[key] );
        }
    }

    /**
     * 设置内容类型
     */
    private setContentType() {
        return this.header( "Content-Type", this.getContentType( this.httpContentType ) );
    }

    /**
     * 获取内容类型
     * @param contentType
     */
    private getContentType( contentType: HttpContentType ) {
        switch ( contentType ) {
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
export enum HttpMethod {
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