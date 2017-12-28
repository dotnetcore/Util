import * as helper from './common/helper';
import { IocHelper } from './angular/ioc-helper';
import { HttpHelper } from './angular/http-helper';
import { WebApi } from './common/webapi';
import { RouterHelper } from './angular/router-helper';
import { Message } from "./common/message";

/**
 * 公共操作库
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
}