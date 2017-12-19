import { Router } from '@angular/router'
import { IocHelper as ioc } from './ioc.helper'

/**
 * 路由操作
 */
export class RouterHelper {
    /**
     * 导航
     * @param commands 导航参数
     */
    public static navigate(commands: any[]): void {
        var router = ioc.get(Router);
        router.navigate(commands);
    }
}