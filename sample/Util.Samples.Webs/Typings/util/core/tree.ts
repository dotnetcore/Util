//============== 树节点 ==========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { ISort } from '../core/sort';
import { IKey,QueryParameter } from '../core/model';

/**
 * 树节点
 */
export class TreeNode implements ITreeNode {
    /**
     * 标识
     */
    id: string;
    /**
     * 父标识
     */
    parentId?: string;
    /**
     * 排序号
     */
    sortId?: number;
}

/**
 * 树节点
 */
export interface ITreeNode extends IKey, ISort {
    /**
     * 父标识
     */
    parentId?: string;
}

/**
 * 树型查询参数
 */
export class TreeQueryParameter extends QueryParameter {
    /**
     * 父标识
     */
    parentId?: string;
}

/**
 * 加载操作
 */
export enum LoadOperation {
    /**
     * 初次加载
     */
    FirstLoad = 1,
    /**
     * 加载子节点
     */
    LoadChild = 2,
    /**
     * 搜索
     */
    Search = 3
}

