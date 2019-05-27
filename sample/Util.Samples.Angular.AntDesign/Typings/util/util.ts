//============== util操作库=======================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import * as helper from './common/helper';
import { IocHelper } from './angular/ioc-helper';
import { HttpHelper } from './angular/http-helper';
import { RouterHelper } from './angular/router-helper';
import { EventHelper } from "./angular/event-helper";
import { WebApi } from './common/webapi';
import { Message } from './common/message';
import { Form } from './common/form';
import { Dialog } from './common/dialog';

/**
 * 操作库
 */
export class Util {
    /**
     * 公共操作
     */
    static helper = helper;
    /**
     * Ioc操作
     */
    static ioc = IocHelper;
    /**
     * Http操作
     */
    static http = HttpHelper;
    /**
     * 事件操作
     */
    static event = EventHelper;
    /**
     * WebApi操作,与服务端返回的标准result对象交互
     */
    static webapi = WebApi;
    /**
     * 路由操作
     */
    static router = RouterHelper;
    /**
     * 消息操作
     */
    static message = Message;
    /**
     * 表单操作
     */
    static form = new Form();
    /**
     * 弹出层操作
     */
    static dialog = Dialog;
}