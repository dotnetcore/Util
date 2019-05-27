//============== OpenId Connect授权拦截器 ========
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Injectable } from '@angular/core';
import { HttpRequest, HttpInterceptor, HttpHandler } from '@angular/common/http';
import { AuthorizeService } from './authorize-service';
import { Observable } from 'rxjs';
import 'rxjs-compat/add/observable/fromPromise';
import "rxjs-compat/add/operator/map";
import "rxjs-compat/add/operator/mergeMap";

/**
 * OpenId Connect授权拦截器
 */
@Injectable()
export class AuthorizeInterceptor implements HttpInterceptor {
    /**
     * 初始化
     * @param auth 授权服务
     */
    constructor( private auth: AuthorizeService ) {
    }

    /**
     * 拦截请求
     * @param request http请求
     * @param next Http处理器
     */
    intercept( request: HttpRequest<any>, next: HttpHandler ) {
        return Observable.fromPromise( this.auth.getUser() ).map( user => {
            if ( !user || !user.access_token )
                return request;
            return request.clone( {
                setHeaders: { Authorization: `${user.token_type} ${user.access_token}` }
            } );
        } ).mergeMap( authRequest => next.handle( authRequest ) );
    }
}