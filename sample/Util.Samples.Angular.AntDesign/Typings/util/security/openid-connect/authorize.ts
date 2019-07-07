//============== OpenId Connect授权 ==============
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { Injector, Injectable } from '@angular/core';
import { CanActivate, CanActivateChild, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { util, Session } from '../../index';
import { AuthorizeService } from "./authorize-service";

/**
 * OpenId Connect授权
 */
@Injectable()
export class Authorize implements CanActivate, CanActivateChild {
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
    async canActivate( route: ActivatedRouteSnapshot, state: RouterStateSnapshot ): Promise<boolean> {
        if (this.session && this.session.isAuthenticated)
            return true;
        await this.loadSessionAsync();
        if (this.session && this.session.isAuthenticated)
            return true;
        this.authService.login(state.url);
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

    /**
     * 是否激活子组件
     */
    async canActivateChild( route: ActivatedRouteSnapshot, state: RouterStateSnapshot ): Promise<boolean> {
        return await this.canActivate( route , state );
    }
}