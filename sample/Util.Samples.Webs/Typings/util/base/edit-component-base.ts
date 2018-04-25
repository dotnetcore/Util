//============== Crud编辑页组件基类===============
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Injector, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { util, ViewModel } from '../index';

/**
 * Crud编辑页组件基类
 */
export abstract class EditComponentBase<TViewModel extends ViewModel> implements OnInit {
    /**
     * 操作库
     */
    protected util = util;
    /**
     * 视图模型
     */
    model: TViewModel;

    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        util.ioc.componentInjector = injector;
        this.model = this.createModel();
    }

    /**
     * 创建视图模型
     */
    protected abstract createModel(): TViewModel;

    /**
     * 初始化
     */
    ngOnInit() {
        this.loadById();
    }

    /**
     * 通过Id加载数据
     */
    private loadById() {
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
     * 提交表单
     * @param form 表单
     * @param button 按钮
     */
    submit(form?: NgForm, button?) {
        this.util.form.submit({
            url: this.getSubmitUrl(),
            data: this.model,
            form: form,
            button: button,
            back: true
        });
    }

    /**
     * 获取提交地址
     * @param id 标识
     */
    protected getSubmitUrl() {
        return `/api/${this.getBaseUrl()}`;
    }

    /**
     * 返回
     */
    back() {
        this.util.router.back();
    }
}