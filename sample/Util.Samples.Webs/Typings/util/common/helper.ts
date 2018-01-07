//============== 公共操作=========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { UUID } from './uuid';

/**
 * 是否未定义
 * @param value 值
 */
export let isUndefined = (value): boolean => {
    return typeof value === 'undefined';
}

/**
 * 是否字符串
 * @param value 值
 */
export let isString = (value): boolean => {
    return typeof value === 'string';
}

/**
 * 是否空值，当值为undefined、null、空字符串、空Guid时返回true，其余返回false
 * @param value 值
 */
export let isEmpty = (value): boolean => {
    if (isUndefined(value))
        return true;
    if (value === null)
        return true;
    if (!isString(value))
        return false;
    if (value && value.trim)
        value = value.trim();
    if (!value)
        return true;
    if (value === "00000000-0000-0000-0000-000000000000")
        return true;
    return false;
}

/**
 * 是否数字，字符串"1"返回true
 * @param value 值
 */
export let isNumber = (value): boolean => {
    return !isNaN(parseFloat(value)) && isFinite(value);
}

/**
 * 转换为数值
 * @param value 输入值
 * @param precision 数值精度，即小数位数，可选值为0-20
 * @param isTruncate 是否截断，传入true，则按精度截断，否则四舍五入
 */
export let toNumber = (value, precision?, isTruncate?: boolean) => {
    if (!isNumber(value))
        return 0;
    value = value.toString();
    if (isEmpty(precision))
        return parseFloat(value);
    if (isTruncate)
        return parseFloat(value.substring(0, value.indexOf(".") + parseInt(precision) + 1));
    return parseFloat(parseFloat(value).toFixed(precision));
}

/**
 * 是否数组
 * @param value 值
 */
export let isArray = (value): boolean => {
    return Array.isArray(value);
}

/**
 * 是否空数组,undefined和null返回false,[]返回true
 * @param value 值
 */
export let isEmptyArray = (value): boolean => {
    return isArray(value) && value.length === 0;
}

/**
 * 转换为json字符串
 * @param value 值
 */
export let toJson = (value): string => {
    return JSON.stringify(value);
}

/**
 * 创建唯一标识
 */
export let uuid = (): string => {
    return UUID.UUID();
}

/**
 * 转换为日期
 * @param date 日期，无效则返回当前日期
 */
export let toDate = (date: Date | string | undefined): Date => {
    if (!date)
        return new Date();
    if (typeof date === 'string')
        return new Date(Date.parse(date));
    return date;
}

/**
 *  格式化日期
 * @param datetime 日期
 * @param format 格式化字符串，范例：yyyy-MM-dd,可选值：
 * (1) y : 年
 * (2) M : 月
 * (3) d : 日
 * (4) H : 时
 * (5) m : 分
 * (6) s : 秒
 * (7) S : 毫秒
 */
export let formatDate = (datetime: Date | string | undefined, format: string): string => {
    if (!datetime)
        return "";
    let date: Date = toDate(datetime);
    let options = {
        "M+": date.getMonth() + 1,
        "d+": date.getDate(),
        "H+": date.getHours(),
        "m+": date.getMinutes(),
        "s+": date.getSeconds(),
        "S": date.getMilliseconds()
    };
    if (/(y+)/.test(format))
        format = format.replace(RegExp.$1, `${date.getFullYear()}`.substr(4 - RegExp.$1.length));
    for (let option in options) {
        let regex = new RegExp(`(${option})`);
        if (regex.test(format)) {
            let value = options[option];
            format = format.replace(RegExp.$1, (RegExp.$1.length === 1) ? value : `00${value}`.substr(`${value}`.length));
        }
    }
    return format;
}