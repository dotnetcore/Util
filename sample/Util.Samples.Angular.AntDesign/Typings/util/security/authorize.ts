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
    static loginUrl: string = "/login";
    /**
     * 获取用户会话地址，默认值 "/api/security/session"
     */
    static sessionUrl: string = "/api/security/session";

    /**
     * 初始化
     * @param session 用户会话
     */
    constructor(injector: Injector, private session: Session) {
        util.ioc.componentInjector = injector;
    }

    /**
     * 是否激活组件
     */
    async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean> {
        if (this.session && this.session.isAuthenticated)
            return true;
        await this.loadSessionAsync();
        if (this.session && this.session.isAuthenticated)
            return true;
        util.router.navigateByQuery([Authorize.loginUrl], { returnUrl: state.url });
        return false;
    }

    /**
     * 加载用户会话
     */
    private async loadSessionAsync() {
        await util.webapi.get(Authorize.sessionUrl).handleAsync({
            ok: (result: any) => {
                if (!result)
                    return;
                this.session.isAuthenticated = result.isAuthenticated;
                this.session.userId = result.userId;
            }
        });
    }
}