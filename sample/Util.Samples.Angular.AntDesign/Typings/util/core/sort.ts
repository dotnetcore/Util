//============== 排序 ============================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================

/**
 * 排序
 */
export interface ISort {
    /**
     * 排序号
     */
    sortId?: number;
}

/**
 * 排序
 * @param array 数组
 */
export function sort<T extends ISort>(array: T[]): T[] {
    return array.sort((a, b) => (a.sortId === undefined || b.sortId === undefined) ? 0 : a.sortId - b.sortId);
}