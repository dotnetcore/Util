//============== 表单编辑组件基类 ===============
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { ViewChild, forwardRef, Injector } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Util as util } from "../util";

/**
 * 表单编辑组件基类
 */
export abstract class FormComponentBase {
    /**
     * 操作库
     */
    protected util = util;
    /**
     * 表单
     */
    @ViewChild( forwardRef( () => NgForm ), { "static": false } ) protected form: NgForm;

    /**
     * 初始化
     * @param injector 注入器
     */
    constructor( public injector: Injector ) {
        util.ioc.componentInjector = injector;
    }
}