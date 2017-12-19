import * as helper from "./common/helper"
import { IocHelper } from "./angular/ioc.helper"
import { HttpHelper } from "./angular/http.helper"
import { RouterHelper } from './angular/router.helper'

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
     * 路由操作
     */
    public static router = RouterHelper;
}