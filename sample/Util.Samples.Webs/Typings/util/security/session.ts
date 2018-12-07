//============== 用户会话 ========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Injectable } from '@angular/core';
import { uuid } from '../common/helper';

/**
 * 用户会话
 */
@Injectable()
export class Session {
    /**
     * 初始化
     */
    constructor() {
        this.sessionId = uuid();
    }
    /**
     * 会话标识
     */
    sessionId;
    /**
     * 是否认证
     */
    isAuthenticated;
    /**
     * 用户标识
     */
    userId;
    /**
     * 用户名称
     */
    name;
}