//============== 列表=============================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { ISort, sort } from '../core/sort';
import { util } from '../index';

/**
 * 列表
 */
export class SelectList {
    /**
     * 初始化列表
     * @param items 列表项集合
     */
    constructor(private items: SelectItem[]) {
    }

    /**
     * 转换为下拉列表项集合
     */
    toOptions(): SelectOption[] {
        return this.getSortedItems().map(value => new SelectOption(value));
    }

    /**
     * 获取已排序的列表项集合
     */
    private getSortedItems() {
        return sort(this.items);
    }

    /**
     * 转换为下拉列表组集合
     */
    toGroups(): SelectOptionGroup[] {
        let result: SelectOptionGroup[] = new Array<SelectOptionGroup>();
        let groups = util.helper.groupBy(this.getSortedItems(), t => t.group);
        groups.forEach((items, key) => {
            result.push(new SelectOptionGroup(key, items.map(item => new SelectOption(item)), false));
        });
        return result;
    }

    /**
     * 是否列表组
     */
    isGroup(): boolean {
        return this.items.every(value => !!value.group);
    }
}

/**
 * 列表项
 */
export class SelectItem implements ISort {
    /**
     * 文本
     */
    text: string;
    /**
     * 值
     */
    value;
    /**
     * 禁用
     */
    disabled?: boolean;
    /**
     * 排序号
     */
    sortId?: number;
    /**
     * 组
     */
    group?: string;
}

/**
 * 下拉列表项
 */
export class SelectOption {
    /**
     * 文本
     */
    text: string;
    /**
     * 值
     */
    value;
    /**
     * 禁用
     */
    disabled?: boolean;

    /**
     * 初始化下拉列表项
     * @param item 列表项
     */
    constructor(item: SelectItem) {
        this.text = item.text;
        this.value = item.value;
        this.disabled = item.disabled;
    }
}

/**
 * 下拉列表组
 */
export class SelectOptionGroup {
    /**
     * 初始化下拉列表组
     * @param text 文本
     * @param value 值
     * @param disabled 禁用
     */
    constructor(public text: string, public value: SelectOption[], public disabled?: boolean) {
    }
}