/**
 * 下拉列表项
 */
export class SelectOption {
    /**
     * 初始化下拉列表项
     * @param text 文本
     * @param value 值
     * @param disabled 禁用
     */
    constructor(public text?: string, public value?: string, public disabled?: boolean) {
    }
}

/**
 * 下拉列表组
 */
export class SelectOptionGroup {
    /**
     * 是否组
     */
    isGroup: boolean = true;

    /**
     * 初始化下拉列表项
     * @param text 文本
     * @param value 值
     * @param disabled 禁用
     */
    constructor(public text?: string, public value?: SelectOption[], public disabled?: boolean) {
    }
}