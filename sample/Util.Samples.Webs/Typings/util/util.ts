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
    public static helper = helper;
    /**
     * Ioc操作
     */
    public static ioc = IocHelper;
    /**
     * Http操作
     */
    public static http = HttpHelper;
    /**
     * WebApi操作,与服务端返回的标准result对象交互
     */
    public static webapi = WebApi;
    /**
     * 路由操作
     */
    public static router = RouterHelper;
    /**
     * 消息操作
     */
    public static message = Message;
}