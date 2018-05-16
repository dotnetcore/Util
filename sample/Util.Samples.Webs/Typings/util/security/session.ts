//============== 用户会话 ========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Injectable } from '@angular/core';

/**
 * 用户会话
 */
@Injectable()
export class Session {
    /**
     * 初始化
     */
    constructor() {
        this.isAuthenticated = false;
    }

    /**
     * 是否认证
     */
    isAuthenticated: boolean;
    /**
     * 用户标识
     */
    userId: string;
}