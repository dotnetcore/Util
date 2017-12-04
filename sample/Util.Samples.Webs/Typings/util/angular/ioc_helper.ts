import { Injector, Type, InjectionToken } from '@angular/core'

/**
 * Ioc操作
 */
export class IocHelper {
    /**
     * 注入器
     */
    public static injector: Injector;

    /**
     * 获取实例
     * @param token 实例标记，一般为类或接口名称,范例：util.ioc.get(Http)
     */
    public static get<T>(token: Type<T> | InjectionToken<T>): T {
        return IocHelper.injector.get(token);
    }
}