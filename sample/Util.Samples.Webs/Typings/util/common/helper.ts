//============== 公共操作=========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { UUID } from './internal/uuid';
import * as moment from 'moment';

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
 * 是否有效日期
 * @param date 日期
 */
export let isValidDate = (date): boolean => {
    return moment(getValidDate(date)).isValid();
}

/**
 * *获取有效的日期字符串，对无效日期补全前导0，不支持毫秒,
 * 范例：2000-1-1 1：2：3，返回2000-01-01 01:02:03
 * @param date 日期
 */
export let getValidDate = (date) => {
    if (!date)
        return date;
    if (typeof date !== "string")
        return date;
    if (date.indexOf("-") <= 0)
        return date;
    let regex = /(\d{4})-(\d{1,2})-(\d{1,2})(?:(?:\s+)(\d{1,2}):(\d{1,2}):?(\d{1,2})?)?/;
    if (!regex.test(date))
        return date;
    let dateSegment = date.match(regex);
    if (!dateSegment)
        return date;
    let year = dateSegment[1];
    let month = dateSegment[2];
    let day = dateSegment[3];
    let hour = dateSegment[4];
    let minute = dateSegment[5];
    let second = dateSegment[6];
    month = month.length === 1 ? `0${month}` : month;
    day = day.length === 1 ? `0${day}` : day;
    let result = `${year}-${month}-${day}`;
    if (hour && minute) {
        hour = hour.length === 1 ? `0${hour}` : hour;
        minute = minute.length === 1 ? `0${minute}` : minute;
        result += ` ${hour}:${minute}`;
    }
    if (second) {
        second = second.length === 1 ? `0${second}` : second;
        result += `:${second}`;
    }
    return result;
}

/**
 * 转换为日期
 * @param date 日期，字符串日期范例：2001-01-01
 */
export let toDate = (date): Date => {
    return moment(getValidDate(date)).toDate();
}

/**
 *  格式化日期
 * @param datetime 日期
 * @param format 格式化字符串，范例：YYYY-MM-DD,可选值：(注意：区分大小写)
 * (1) 年: YYYY
 * (2) 月: MM
 * (3) 日: DD
 * (4) 时: HH
 * (5) 分: mm
 * (6) 秒: ss
 * (7) 毫秒: SSS
 */
export let formatDate = (datetime, format: string): string => {
    let date = moment(getValidDate(datetime));
    if (!date.isValid())
        return "";
    return date.format(format);
}