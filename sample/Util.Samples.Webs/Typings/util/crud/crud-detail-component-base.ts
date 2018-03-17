//============== Crud详细页组件基类===============
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Injector, OnInit } from '@angular/core';
import { util, ViewModel } from '../index';

/**
 * Crud详细页组件基类
 */
export abstract class CrudDetailComponentBase<TViewModel extends ViewModel> implements OnInit {
    /**
     * 操作库
     */
    protected util = util;
    /**
     * 视图模型
     */
    protected model: TViewModel;

    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        util.ioc.componentInjector = injector;
    }

    /**
     * 初始化
     */
    ngOnInit() {
        this.loadDataById();
    }

    /**
     * 通过Id加载数据
     */
    private loadDataById() {
        let id = this.util.router.getParam("id");
        if (!id)
            return;
        this.util.webapi.get<TViewModel>(this.getUrl(id)).handle({
            handler: result => {
                this.model = result;
            }
        });
    }

    /**
     * 获取基地址
     */
    protected abstract getBaseUrl();

    /**
     * 获取数据地址
     * @param id 标识
     */
    protected getUrl(id) {
        return `/api/${this.getBaseUrl()}/${id}`;
    }

    /**
     * 返回
     */
    back() {
        this.util.router.back();
    }
}