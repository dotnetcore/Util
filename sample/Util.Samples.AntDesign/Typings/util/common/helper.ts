//============== 公共操作=========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { UUID } from './internal/uuid';
import * as moment from 'moment';
import * as _ from "lodash";
import { Dictionary } from 'lodash';

/**
 * 是否未定义
 * @param value 值
 */
export let isUndefined = ( value ): boolean => {
    return typeof value === 'undefined';
}

/**
 * 是否字符串
 * @param value 值
 */
export let isString = ( value ): boolean => {
    return typeof value === 'string';
}

/**
 * 是否空值，当值为undefined、null、空对象,空字符串、空Guid时返回true，其余返回false
 * @param value 值
 */
export let isEmpty = ( value ): boolean => {
    if ( typeof value === "number" )
        return false;
    if ( value && value.trim )
        value = value.trim();
    if ( !value )
        return true;
    if ( value === "00000000-0000-0000-0000-000000000000" )
        return true;
    return _.isEmpty( value );
}

/**
 * 是否数字，字符串"1"返回true
 * @param value 值
 */
export let isNumber = ( value ): boolean => {
    return !isNaN( parseFloat( value ) ) && isFinite( value );
}

/**
 * 转换为数值
 * @param value 输入值
 * @param precision 数值精度，即小数位数，可选值为0-20
 * @param isTruncate 是否截断，传入true，则按精度截断，否则四舍五入
 */
export let toNumber = ( value, precision?, isTruncate?: boolean ) => {
    if ( !isNumber( value ) )
        return 0;
    value = value.toString();
    if ( isEmpty( precision ) )
        return parseFloat( value );
    if ( isTruncate )
        return parseFloat( value.substring( 0, value.indexOf( "." ) + parseInt( precision ) + 1 ) );
    return parseFloat( parseFloat( value ).toFixed( precision ) );
}

/**
 * 转换为字符串
 * @param value 输入值
 */
export let toString = ( value ): string => {
    return _.toString( value ).trim();
}

/**
 * 转换为布尔值
 * @param value 输入值
 */
export let toBool = ( value ): boolean => {
    if ( value === true )
        return true;
    let strValue = toString( value ).toLowerCase();
    if ( strValue === "1" )
        return true;
    if ( strValue === "true" )
        return true;
    if ( strValue === "是" )
        return true;
    if ( strValue === "yes" )
        return true;
    if ( strValue === "ok" )
        return true;
    return false;
}

/**
 * 是否数组
 * @param value 值
 */
export let isArray = ( value ): boolean => {
    return Array.isArray( value );
}

/**
 * 是否空数组,undefined和null返回false,[]返回true
 * @param value 值
 */
export let isEmptyArray = ( value ): boolean => {
    return isArray( value ) && value.length === 0;
}

/**
 * 获取数组中第一个
 * @param array 数组
 */
export let first = <T>( array ): T => {
    return _.first<T>( array );
}

/**
 * 获取数组中最后一个
 * @param array 数组
 */
export let last = <T>( array ): T => {
    return _.last<T>( array );
}

/**
 * 转换为json字符串
 * @param value 值
 */
export let toJson = ( value ): string => {
    return JSON.stringify( value );
}

/**
 * json字符串转换为对象
 * @param json json字符串
 */
export let toObjectFromJson = <T>( json: string ): T => {
    return JSON.parse( json );
}

/**
 * 复制对象
 * @param obj 对象
 */
export let clone = <T>( obj: T ): T => {
    return JSON.parse( JSON.stringify( obj ) );
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
export let isValidDate = ( date ): boolean => {
    return moment( getValidDate( date ) ).isValid();
}

/**
 * *获取有效的日期字符串，对无效日期补全前导0，不支持毫秒,
 * 范例：2000-1-1 1：2：3，返回2000-01-01 01:02:03
 * @param date 日期
 */
export let getValidDate = ( date ) => {
    if ( !date )
        return date;
    if ( typeof date !== "string" )
        return date;
    if ( date.indexOf( "-" ) <= 0 )
        return date;
    let regex = /(\d{4})-(\d{1,2})-(\d{1,2})(?:(?:\s+)(\d{1,2}):(\d{1,2}):?(\d{1,2})?)?/;
    if ( !regex.test( date ) )
        return date;
    let dateSegment = date.match( regex );
    if ( !dateSegment )
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
    if ( hour && minute ) {
        hour = hour.length === 1 ? `0${hour}` : hour;
        minute = minute.length === 1 ? `0${minute}` : minute;
        result += ` ${hour}:${minute}`;
    }
    if ( second ) {
        second = second.length === 1 ? `0${second}` : second;
        result += `:${second}`;
    }
    return result;
}

/**
 * 转换为日期
 * @param date 日期，字符串日期范例：2001-01-01
 */
export let toDate = ( date ): Date => {
    return moment( getValidDate( date ) ).toDate();
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
export let formatDate = ( datetime, format: string = 'YYYY-MM-DD HH:mm:ss' ): string => {
    let date = moment( getValidDate( datetime ) );
    if ( !date.isValid() )
        return "";
    return date.format( format );
}

/**
 * 通用泛型转换
 * @param value 值
 */
export let to = <T>( value ): T => {
    return <T>value;
}

/**
 * 从数组中移除子集
 * @param source 源数组
 * @param predicate 条件
 */
export let remove = <T>( source: Array<T>, predicate: ( value: T ) => boolean ): Array<T> => {
    return _.remove( source, t => predicate( t ) );
}

/**
 * 添加项到数组
 * @param source 源数组
 * @param items 项
 */
export let addToArray = <T>( source: Array<T>, items ): Array<T> => {
    if ( isEmpty( items ) )
        return source;
    if ( !items.length ) {
        source.push( items );
        return source;
    }
    items.forEach( item => {
        if ( isEmpty( item ) )
            return;
        source.push( item );
    } );
    return source;
}

/**
 * 清空数组
 * @param array 数组
 */
export let clear = ( array ): void => {
    if ( array && array.length )
        array.length = 0;
}

/**
 * 泛型集合转换
 * @param input 以逗号分隔的元素集合字符串，范例: 1,2
 */
export let toList = <T>( input: string ): T[] => {
    var result = new Array<T>();
    if ( !input )
        return result;
    var array = input.split( ',' );
    array.forEach( value => {
        if ( !value )
            return;
        result.push( to<T>( value ) );
    } );
    return result;
}

/**
 * 获取差集
 * @param source 源集合
 * @param target 目标集合
 * @param property 比较属性
 */
export let except = <T>( source: T[], target: T[], property?: ( t: T ) => any ): T[] => {
    return _.differenceBy( getArray( source ), getArray( target ), property );
}

/**
 * 获取差集
 * @param source 源集合
 * @param target 目标集合
 * @param comparator 比较器
 */
export let exceptWith = <T>( source: T[], target: T[], comparator?: ( s, t ) => boolean ): T[] => {
    return _.differenceWith( getArray( source ), getArray( target ), comparator );
}

/**
 * 获取集合
 */
function getArray<T>( array ): T[] {
    let list = new Array<T>();
    if ( array.length === undefined ) {
        list.push( array );
        return list;
    }
    return <T[]>array;
}

/**
 * 合并集合
 * @param source 源集合
 * @param target 目标集合
 */
export let concat = <T>( source: T[], target: T[] ) => {
    return _.concat( source, target );
}

/**
 * 分组
 * @param source 集合
 * @param property 分组属性
 */
export let groupBy = <T>( source: T[], property?: ( t: T ) => any ): Map<string, T[]> => {
    let groups = _.groupBy( source, property );
    let result = new Map<string, T[]>();
    for ( var key in groups ) {
        if ( !key )
            continue;
        result.set( key, groups[key].map( t => <T><any>t ) );
    }
    return result;
}

/**
 * 去重复
 * @param source 源集合
 * @param property 属性
 */
export let distinct = <T>( source: T[], property?: ( t: T ) => any ) => {
    return _.uniqBy( source, property );
}

/**
 * 截断字符串,范例：原始字符串为abcd,保留长度传入2，则返回 ab...
 * @param input 原始字符串
 * @param length 截断后保留的长度
 */
export function truncate( input: string, length?: number ) {
    return _.truncate( input, { length: length + 3 } );
}

/**
 * 插入到数组
 * @param source 数组
 * @param item 项
 * @param index 索引
 */
export function insert( source: any[], item, index?: number ) {
    if ( isUndefined( source ) || source == null )
        return [];
    if ( isUndefined( index ) ) {
        source.push( item );
        return source;
    }
    source.splice( index, 0, item );
    return source;
}

/**
 * 获取文件扩展名,范例:a.jpg,返回.jpg
 * @param name 文件名
 */
export function getExtension( name: string ) {
    if ( !name )
        return null;
    return `.${name.replace( /.+\./, "" )}`;
}

/**
 * 获取本年初日期
 */
export function getStartOfYear() {
    return moment().startOf( 'year' );
}

/**
 * 获取本年末日期
 */
export function getEndOfYear() {
    return moment().endOf( 'year' );
}

/**
 * 获取本月初日期
 */
export function getStartOfMonth() {
    return moment().startOf( 'month' );
}

/**
 * 获取本月末日期
 */
export function getEndOfMonth() {
    return moment().endOf( 'month' );
}

/**
 * 获取本周初日期
 */
export function getStartOfWeek() {
    return moment().startOf( 'week' ).add( 1, 'day' );
}

/**
 * 获取本周末日期
 */
export function getEndOfWeek() {
    return moment().endOf( 'week' ).add( 1, 'day' );
}

/**
 * 日期是否在今天之前
 * @param value 日期值
 */
export function isBeforeToday( value: Date ) {
    let date = formatDate( value );
    let today = formatDate( new Date() );
    return moment( date ).isBefore( today );
}

/**
 * 日期是否在明天之前
 * @param value 日期值
 */
export function isBeforeTomorrow( value: Date ) {
    let date = formatDate( value );
    let tomorrow = moment().add( 1, 'day' ).format( "YYYY-MM-DD" );
    return moment( date ).isBefore( tomorrow );
}

/**
 * 是否图片
 * @param name 文件名称
 */
export function isImage( name: string ) {
    let extension = getExtension( name );
    switch ( extension ) {
        case ".jpg":
        case ".jpeg":
        case ".png":
        case ".gif":
        case ".bmp":
            return true;
        default:
            return false;
    }
}

/**
 * 获取标识列表
 */
export function getIds( data ) {
    if ( !data )
        return null;
    if ( !data.map )
        return data.id;
    return data.map( t => t.id );
}

/**
 * 获取基地址
 * @param baseUrl 基地址
 */
export function getBaseUrl( baseUrl: string ) {
    if ( !baseUrl )
        return null;
    if ( !baseUrl.startsWith( "http" ) )
        baseUrl = `/api/${baseUrl}`;
    return _.trimEnd( baseUrl , "/" );
}

/**
 * 获取完整地址
 * @param baseUrl 基地址
 * @param path 路径
 */
export function getUrl( baseUrl: string, path?: string ) {
    baseUrl = getBaseUrl( baseUrl );
    if ( !baseUrl )
        return null;
    if ( !path )
        return baseUrl;
    return `${baseUrl}/${path}`;
}