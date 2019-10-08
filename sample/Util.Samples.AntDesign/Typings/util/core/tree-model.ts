//============== 树形模型 ==========================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { QueryParameter, ViewModel } from "./model";

/**
 * 树形参数
 */
export class TreeViewModel extends ViewModel{
    /**
     * 父标识
     */
    parentId?: string;
    /**
     * 父名称
     */
    parentName?;
    /**
     * 路径
     */
    path?;
    /**
     * 层级
     */
    level?;
    /**
     * 排序号
     */
    sortId?: number;
    /**
     * 启用
     */
    enabled?: boolean;
    /**
     * 展开
     */
    expanded?: boolean;
}

/**
 * 树形查询参数
 */
export class TreeQueryParameter extends QueryParameter {
    /**
     * 父标识
     */
    parentId?: string;
    /**
     * 启用
     */
    enabled?: boolean;
    /**
     * 操作
     */
    operation?: string;
}