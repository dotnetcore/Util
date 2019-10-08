//============== 是否截断字符串管道 ===================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=====================================================
import { Pipe, PipeTransform } from '@angular/core';

/**
 * 是否截断字符串管道
 */
@Pipe( {
    name: 'isTruncate'
} )
export class IsTruncatePipe implements PipeTransform {
    /**
     * 转换
     * @param value 值
     * @param length 保留长度
     */
    transform( value, length ) {
        if ( !value )
            return false;
        return value.length > length;
    }
}