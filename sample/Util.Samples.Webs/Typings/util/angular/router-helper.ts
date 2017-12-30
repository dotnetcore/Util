import { Router, ActivatedRoute, NavigationExtras } from '@angular/router';
import { Location } from '@angular/common';
import { IocHelper as ioc } from './ioc-helper';

/**
 * 路由操作
 */
export class RouterHelper {
    /**
     * 返回上一次视图
     */
    static back(): void {
        let location: Location = ioc.get(Location);
        location.back();
    }

    /**
     * 导航
     * @param commands 导航参数，范例: ['team', 33, 'user', 11]，表示 /team/33/user/11
     * @param extras 附加参数，范例: {relativeTo: route}
     */
    static navigate(commands: any[], extras?: NavigationExtras): Promise<boolean> {
        let router = ioc.get(Router);
        return router.navigate(commands);
    }

    /**
     * 获取当前路由参数值,从路由快照中获取参数
     * @param paramName 参数名
     */
    static getParam(paramName: string): string | null {
        let route = ioc.getByComponent(ActivatedRoute);
        return route.snapshot.paramMap.get(paramName);
    }
}