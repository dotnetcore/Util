//============== 包装器===========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Input, Output, EventEmitter } from '@angular/core';
/**
 * 包装器
 */
export class WrapperComponentBase {
    /**
     * 占位提示符
     */
    @Input() placeholder: string;
    /**
     * 占位提示符浮动位置，可选值：auto,never,always
     */
    @Input() floatPlaceholder: string;
}