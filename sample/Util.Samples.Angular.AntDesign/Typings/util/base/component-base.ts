//============== 组件基类=========================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { Injector } from '@angular/core';
import { util } from '../index';

/**
 * 组件
 */
export class ComponentBase {
    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        util.ioc.componentInjector = injector;
    }

    /**
     * 操作库
     */
    protected util = util;
}