//============== 树节点 ==========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { ISort } from '../core/sort';

/**
 * 树节点
 */
export class TreeNode implements ISort{
    /**
     * 标识
     */
    id?: string;
    /**
     * 父标识
     */
    parentId?: string;
    /**
     * 文本
     */
    text: string;
    /**
     * 排序号
     */
    sortId?: number;
}