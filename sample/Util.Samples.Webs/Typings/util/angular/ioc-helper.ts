import { Injector, Type, InjectionToken } from '@angular/core'

/**
 * Ioc操作
 */
export class IocHelper {
    /**
     * 全局注入器
     */
    public static injector: Injector;
    /**
     * 当前组件注入器
     */
    public static componentInjector: Injector;

    /**
     * 获取实例，从全局注入器中获取
     * @param token 实例标记，一般为类或接口名称,范例：util.ioc.get(Http)
     */
    public static get<T>(token: Type<T> | InjectionToken<T>): T {
        return IocHelper.injector.get(token);
    }

    /**
     * 获取实例，从当前组件注入器中获取
     * @param token 实例标记，一般为类或接口名称,范例：util.ioc.get(Http)
     */
    public static getByComponent<T>(token: Type<T> | InjectionToken<T>): T {
        return IocHelper.componentInjector.get(token);
    }
}