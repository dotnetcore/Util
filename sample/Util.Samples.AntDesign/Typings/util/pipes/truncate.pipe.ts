//============== 字符串截断管道 =======================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=====================================================
import { Pipe, PipeTransform } from '@angular/core';
import { truncate } from "../common/helper";

/**
 * 字符串截断管道
 */
@Pipe( {
    name: 'truncate'
} )
export class TruncatePipe implements PipeTransform {
    /**
     * 转换
     * @param value 值
     * @param length 截断后保留的长度,范例：原始字符串为abcd,保留长度传入2，则返回 ab...
     */
    transform( value, length ) {
        return truncate( value, length );
    }
}