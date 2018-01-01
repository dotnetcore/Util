//============== 服务端结果约定格式===============
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { HttpErrorResponse } from '@angular/common/http';

/**
 * 服务端返回的标准结果
 */
export class Result<T> {
    /**
     * 状态码
     */
    code: StateCode;
    /**
     * 消息
     */
    message: string;
    /**
     * 数据
     */
    data: T;
}

/**
 * 错误结果
 */
export class FailResult {
    /**
     * 
     * @param result 结果
     * @param errorResponse Http错误响应
     */
    constructor(result?: Result<any>, public errorResponse?: HttpErrorResponse) {
        if (result) {
            this.code = result.code;
            this.message = result.message;
        }        
    }
    /**
     * 状态码
     */
    code: StateCode;
    /**
     * 消息
     */
    message: string;
}

/**
 * 状态码
 */
export enum StateCode {
    /**
     * 成功
     */
    Ok = 1,
    /**
     * 失败
     */
    Fail = 2
}