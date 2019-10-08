//============== 字典服务 =======================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { Injectable } from "@angular/core";

/**
 * 字典服务
 */
@Injectable()
export class DicService<TValue> {
    /**
     * 数据
     */
    private data: Map<string, TValue>;

    /**
     * 初始化字典服务
     */
    constructor() {
        this.data = new Map<string, TValue>();
    }

    /**
     * 添加数据
     * @param key 键
     * @param value 值
     */
    add(key: string, value: TValue) {
        this.data.set(key, value);
    }

    /**
     * 获取数据
     * @param key 键
     */
    get(key: string): TValue | undefined {
        return this.data.get(key);
    }

    /**
     * 移除数据
     * @param key 键
     */
    remove(key: string) {
        this.data.delete(key);
    }
}