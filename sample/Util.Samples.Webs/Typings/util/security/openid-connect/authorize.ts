//============== OpenId Connect授权 ==============
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Injector, Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { util, Session } from '../../index';
import { AuthorizeService } from "./authorize-service";

/**
 * OpenId Connect授权
 */
@Injectable()
export class Authorize implements CanActivate {
    /**
     * 初始化
     * @param injector 注入器
     * @param session 用户会话
     * @param authService OpenId Connect授权服务
     */
    constructor(injector: Injector, private session: Session, private authService: AuthorizeService) {
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
        this.authService.login();
        return false;
    }

    /**
     * 加载用户会话
     */
    private async loadSessionAsync() {
        let user = await this.authService.getUser();
        if (!this.authService.isAuthenticated(user))
            return;
        this.session.isAuthenticated = true;
        this.session.userId = user.profile["sub"];
        this.session.name = user.profile["name"];
    }
}