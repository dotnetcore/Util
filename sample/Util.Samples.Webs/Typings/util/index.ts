/**
 * 公共操作库
 * @license MIT
 * Copyright 何镇汐
 */

//导出公共操作
import * as Helper from "./common/helper"
export { Helper as helper }

//导出Ioc操作
export { IocHelper as ioc } from "./angular/ioc_helper"

//导出Http操作
export { HttpHelper as http } from "./angular/http_helper"