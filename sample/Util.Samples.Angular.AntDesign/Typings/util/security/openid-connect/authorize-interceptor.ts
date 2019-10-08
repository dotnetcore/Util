//============== OpenId Connect授权拦截器 ========
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { Injectable } from '@angular/core';
import { HttpRequest, HttpInterceptor, HttpHandler } from '@angular/common/http';
import { AuthorizeService } from './authorize-service';
import { from, throwError } from 'rxjs';
import { map, mergeMap, catchError } from "rxjs/operators";

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
        return from(this.auth.getUser()).pipe(
            map(user => {
                if (!user || !user.access_token)
                    return request;
                return request.clone({
                    setHeaders: { Authorization: `${user.token_type} ${user.access_token}` }
                });
            }),
            mergeMap(authRequest => next.handle(authRequest)),
            catchError(res => {
                if (res.status === 401)
                    this.auth.login();
                return throwError(res);
            })
        );
    }
}