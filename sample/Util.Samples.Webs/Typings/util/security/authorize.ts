//============== 授权 =============================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Injector, Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { util, Session } from '../index';

/**
 * 授权
 */
@Injectable()
export class Authorize implements CanActivate {
    /**
     * 登录地址，默认值 "/login"
     */
    static loginUrl: string;

    /**
     * 初始化
     * @param session 用户会话
     */
    constructor(injector: Injector) {
        util.ioc.injector = injector;
        Authorize.loginUrl = "/login";
    }

    /**
     * 是否激活组件
     */
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        let session = util.ioc.get(Session);
        if (session.isAuthenticated)
            return true;
        util.router.navigateByQuery([Authorize.loginUrl], { returnUrl: state.url });
        return false;
    }
}