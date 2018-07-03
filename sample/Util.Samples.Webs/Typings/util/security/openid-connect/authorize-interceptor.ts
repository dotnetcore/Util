//============== 授权 =============================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Injectable } from '@angular/core';
import { HttpRequest, HttpInterceptor, HttpHandler } from '@angular/common/http';
import { AuthorizeService } from './authorize-service';
import "rxjs/add/operator/mergeMap";

/**
 * OpenId Connect授权拦截器
 */
@Injectable()
export class AuthorizeInterceptor implements HttpInterceptor {
    /**
     * 初始化
     * @param auth 授权服务
     */
    constructor(private auth: AuthorizeService) {
    }

    /**
     * 拦截请求
     * @param request http请求
     * @param next Http处理器
     */
    intercept(request: HttpRequest<any>, next: HttpHandler) {
        return this.auth.getToken().map(token => {
            if (!token)
                return request;
            return request.clone({
                setHeaders: { Authorization: `Bearer ${token}` }
            });
        }).mergeMap(authRequest => next.handle(authRequest));
    }
}