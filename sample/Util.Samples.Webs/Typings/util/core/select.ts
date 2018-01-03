//============== 列表=============================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
/**
 * 列表
 */
export class Select {
    /**
     * 初始化列表
     * @param items 列表项集合
     */
    constructor(private items: SelectItem[]) {
    }

    /**
     * 转换为下拉列表项集合
     */
    toSelectOptions(): SelectOption[] {
        return this.getSortedItems().map(value => new SelectOption(value));
    }

    /**
     * 获取已排序的列表项集合
     */
    private getSortedItems() {
        return this.items.sort((a, b) => a.sortId && b.sortId ? a.sortId - b.sortId : -1);
    }

    /**
     * 转换为下拉列表组集合
     */
    toSelectOptionGroups(): SelectOptionGroup[] {
        let result: SelectOptionGroup[] = new Array<SelectOptionGroup>();
        this.getSortedItems().forEach(item => {
            if (!item.group)
                return;
            let group = result.find(group => group.text === item.group);
            if (group) {
                group.value.push(new SelectOption(item));
                return;
            }
            result.push(new SelectOptionGroup(item.group, [new SelectOption(item)], false));
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
export class SelectItem {
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