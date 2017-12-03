import { Injectable } from '@angular/core'
import * as Helper from "./common/helper"
import {HttpHelper} from "./angular/http-helper";

@Injectable()
export class Util {
    /**
     * 公共操作
     */
    public helper = Helper;
    /**
     * 公共操作
     */
    public static helper = Helper;

    /**
     * 
     * @param http Http操作
     */
    constructor(public http: HttpHelper) {
    }
}