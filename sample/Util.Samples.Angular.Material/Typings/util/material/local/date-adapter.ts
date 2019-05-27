/**
 * @license
 * Copyright Google LLC All Rights Reserved.
 * 汉化：何镇汐
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://angular.io/license
 */

import { Inject, Injectable, Optional } from '@angular/core';
import { DateAdapter, MAT_DATE_LOCALE } from '@angular/material';
import { formatDate, toDate } from "../../common/helper"

/** The default month names to use if Intl API is not available. */
const DEFAULT_MONTH_NAMES = {
    'long': [
        '一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月',
        '十月', '十一月', '十二月'
    ],
    'short': ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月'],
    'narrow': ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月']
};


/** The default date names to use if Intl API is not available. */
const DEFAULT_DATE_NAMES = range(31, i => String(i + 1));


/** The default day of the week names to use if Intl API is not available. */
const DEFAULT_DAY_OF_WEEK_NAMES = {
    'long': ['星期日', '星期一', '星期二', '星期三', '星期四', '星期五', '星期六'],
    'short': ['星期日', '星期一', '星期二', '星期三', '星期四', '星期五', '星期六'],
    'narrow': ['日', '一', '二', '三', '四', '五', '六']
};


/**
 * Matches strings that have the form of a valid RFC 3339 string
 * (https://tools.ietf.org/html/rfc3339). Note that the string may not actually be a valid date
 * because the regex will match strings an with out of bounds month, date, etc.
 */
const ISO_8601_REGEX =
    /^\d{4}-\d{2}-\d{2}(?:T\d{2}:\d{2}:\d{2}(?:\.\d+)?(?:Z|(?:(?:\+|-)\d{2}:\d{2}))?)?$/;


/** Creates an array and fills it with values. */
function range<T>(length: number, valueFunction: (index: number) => T): T[] {
    const valuesArray = Array(length);
    for (let i = 0; i < length; i++) {
        valuesArray[i] = valueFunction(i);
    }
    return valuesArray;
}

/** Adapts the native JS Date for use with cdk-based components that work with dates. */
@Injectable()
export class UtilDateAdapter extends DateAdapter<Date> {
    /**
     * Whether to use `timeZone: 'utc'` with `Intl.DateTimeFormat` when formatting dates.
     * Without this `Intl.DateTimeFormat` sometimes chooses the wrong timeZone, which can throw off
     * the result. (e.g. in the en-US locale `new Date(1800, 7, 14).toLocaleDateString()`
     * will produce `'8/13/1800'`.
     */
    useUtcForDisplay: boolean;

    constructor( @Optional() @Inject(MAT_DATE_LOCALE) matDateLocale: string) {
        super();
        super.setLocale(matDateLocale);

        // IE does its own time zone correction, so we disable this on IE.
        // TODO(mmalerba): replace with !platform.TRIDENT, logic currently duplicated to avoid breaking
        // change from injecting the Platform.
        this.useUtcForDisplay = !(typeof document === 'object' && !!document &&
            /(msie|trident)/i.test(navigator.userAgent));
    }

    getYear(date: Date): number {
        return date.getFullYear();
    }

    getMonth(date: Date): number {
        return date.getMonth();
    }

    getDate(date: Date): number {
        return date.getDate();
    }

    getDayOfWeek(date: Date): number {
        return date.getDay();
    }

    getMonthNames(style: 'long' | 'short' | 'narrow'): string[] {
        return DEFAULT_MONTH_NAMES[style];
    }

    getDateNames(): string[] {
        return DEFAULT_DATE_NAMES;
    }

    getDayOfWeekNames(style: 'long' | 'short' | 'narrow'): string[] {
        return DEFAULT_DAY_OF_WEEK_NAMES[style];
    }

    getYearName(date: Date): string {
        return `${this.getYear(date)}年`;
    }

    getFirstDayOfWeek(): number {
        // We can't tell using native JS Date what the first day of the week is, we default to Sunday.
        return 0;
    }

    getNumDaysInMonth(date: Date): number {
        return this.getDate(this._createDateWithOverflow(
            this.getYear(date), this.getMonth(date) + 1, 0));
    }

    clone(date: Date): Date {
        return this.createDate(this.getYear(date), this.getMonth(date), this.getDate(date));
    }

    createDate(year: number, month: number, date: number): Date {
        // Check for invalid month and date (except upper bound on date which we have to check after
        // creating the Date).
        if (month < 0 || month > 11) {
            throw Error(`Invalid month index "${month}". Month index has to be between 0 and 11.`);
        }

        if (date < 1) {
            throw Error(`Invalid date "${date}". Date has to be greater than 0.`);
        }

        let result = this._createDateWithOverflow(year, month, date);

        // Check that the date wasn't above the upper bound for the month, causing the month to overflow
        if (result.getMonth() != month) {
            throw Error(`Invalid date "${date}" for month with index "${month}".`);
        }

        return result;
    }

    today(): Date {
        return new Date();
    }

    parse(value: any): Date | null {
        return toDate(value);
    }

    format(date: Date, displayFormat: Object): string {
        return this._stripDirectionalityCharacters(formatDate(date, "YYYY-MM-DD"));
    }

    addCalendarYears(date: Date, years: number): Date {
        return this.addCalendarMonths(date, years * 12);
    }

    addCalendarMonths(date: Date, months: number): Date {
        let newDate = this._createDateWithOverflow(
            this.getYear(date), this.getMonth(date) + months, this.getDate(date));

        // It's possible to wind up in the wrong month if the original month has more days than the new
        // month. In this case we want to go to the last day of the desired month.
        // Note: the additional + 12 % 12 ensures we end up with a positive number, since JS % doesn't
        // guarantee this.
        if (this.getMonth(newDate) != ((this.getMonth(date) + months) % 12 + 12) % 12) {
            newDate = this._createDateWithOverflow(this.getYear(newDate), this.getMonth(newDate), 0);
        }

        return newDate;
    }

    addCalendarDays(date: Date, days: number): Date {
        return this._createDateWithOverflow(
            this.getYear(date), this.getMonth(date), this.getDate(date) + days);
    }

    toIso8601(date: Date): string {
        return [
            date.getUTCFullYear(),
            this._2digit(date.getUTCMonth() + 1),
            this._2digit(date.getUTCDate())
        ].join('-');
    }

    /**
     * Returns the given value if given a valid Date or null. Deserializes valid ISO 8601 strings
     * (https://www.ietf.org/rfc/rfc3339.txt) into valid Dates and empty string into null. Returns an
     * invalid date for all other values.
     */
    deserialize(value: any): Date | null {
        if (typeof value === 'string') {
            if (!value) {
                return null;
            }
            // The `Date` constructor accepts formats other than ISO 8601, so we need to make sure the
            // string is the right format first.
            if (ISO_8601_REGEX.test(value)) {
                let date = new Date(value);
                if (this.isValid(date)) {
                    return date;
                }
            }
        }
        return super.deserialize(value);
    }

    isDateInstance(obj: any) {
        return obj instanceof Date;
    }

    isValid(date: Date) {
        return !isNaN(date.getTime());
    }

    invalid(): Date {
        return new Date(NaN);
    }

    /** Creates a date but allows the month and date to overflow. */
    private _createDateWithOverflow(year: number, month: number, date: number) {
        let result = new Date(year, month, date);

        // We need to correct for the fact that JS native Date treats years in range [0, 99] as
        // abbreviations for 19xx.
        if (year >= 0 && year < 100) {
            result.setFullYear(this.getYear(result) - 1900);
        }
        return result;
    }

    /**
     * Pads a number to make it two digits.
     * @param n The number to pad.
     * @returns The padded number.
     */
    private _2digit(n: number) {
        return ('00' + n).slice(-2);
    }

    /**
     * Strip out unicode LTR and RTL characters. Edge and IE insert these into formatted dates while
     * other browsers do not. We remove them to make output consistent and because they interfere with
     * date parsing.
     * @param str The string to strip direction characters from.
     * @returns The stripped string.
     */
    private _stripDirectionalityCharacters(str: string) {
        return str.replace(/[\u200e\u200f]/g, '');
    }
}