//============== 表单编辑组件基类 ===============
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Injector, ViewChild, forwardRef, AfterViewInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';
import { util } from '../index';
import { IFormChange } from '../services/save-guard';

/**
 * 表单编辑组件基类
 */
export abstract class FormComponentBase implements IFormChange, AfterViewInit {
    /**
     * 是否修改
     */
    private dirty: boolean;
    /**
     * 表单组件值列表
     */
    private values: Map<string, string>;
    /**
     * 操作库
     */
    protected util = util;
    /**
     * 表单
     */
    @ViewChild(forwardRef(() => NgForm)) protected form: NgForm;

    /**
     * 初始化
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        util.ioc.componentInjector = injector;
        this.values = new Map<string, string>();
    }

    /**
     * 初始化
     */
    ngAfterViewInit() {
        this.registerValueChanges();
    }

    /**
     * 注册表单值变更处理器
     */
    protected registerValueChanges() {
        this.values.clear();
        let now = Date.now();
        this.form.valueChanges.subscribe(values => {
            this.dirty = false;
            let expire = this.expire(now);
            for (let name in values) {
                if (values.hasOwnProperty(name)) {
                    let value = (values[name] === undefined || values[name] === null || values[name] === false) ? "" : util.helper.toString(values[name]);
                    this.change(name, value, expire );
                }
            }
        });
    }

    /**
     * 是否在设置初始值有效期
     */
    private expire(time): boolean {
        return Date.now() - time < this.delayCheckTime();
    }

    /**
     * 初始值延迟检测时间,单位：毫秒
     */
    protected delayCheckTime() {
        return 800;
    }

    /**
     * 组件变更处理
     */
    private change(name, value, expire) {
        if (expire) {
            this.loadInitValues(name, value);
            return;
        }
        if (!this.values.has(name)) {
            if (value !== "")
                this.dirty = true;
            return;
        }
        if (this.values.get(name) !== value) {
            this.dirty = true;
        }
    }

    /**
     * 加载表单初始值
     */
    private loadInitValues(name, value) {
        if (this.values.has(name))
            this.values.delete(name);
        this.values.set(name, value);
    }

    /**
     * 是否已修改
     */
    isChange(): Observable<boolean> | Promise<boolean> | boolean {
        if (this.form.submitted)
            return false;
        return this.dirty;
    }
}