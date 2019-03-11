//============== Ioc操作=========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Injector, Type, InjectionToken } from '@angular/core';

/**
 * Ioc操作
 */
export class IocHelper {
    /**
     * 全局注入器
     */
    static injector: Injector;
    /**
     * 当前组件注入器
     */
    static componentInjector: Injector;

    /**
     * 获取实例
     * @param token 实例标记，一般为类或接口名称,范例：util.ioc.get(Http)
     */
    static get<T>(token: Type<T> | InjectionToken<T>): T;
    static get(token: any): any;
    static get(token: any): any {
        if (IocHelper.componentInjector)
            return IocHelper.componentInjector.get(token);
        return IocHelper.injector.get(token);
    }
}