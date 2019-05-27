//============== 树型模型 ==========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { ISort } from '../core/sort';
import { IKey } from './model';

/**
 * 树型视图模型
 */
export class TreeViewModel implements ISort, IKey {
    /**
     * 标识
     */
    id: string;
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
     * 级数
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
     * 类型
     */
    type?;
    /**
     * 数据
     */
    data?;
    /**
     * 展开
     */
    expanded?: boolean;
}

/**
 * 树型查询参数
 */
export class TreeQueryParameter {
    /**
     * 页索引，即第几页
     */
    page: number;
    /**
     * 每页显示行数
     */
    pageSize: number;
    /**
     * 排序条件
     */
    order: string;
    /**
     * 搜索关键字
     */
    keyword: string;
    /**
     * 父标识
     */
    parentId?: string;
}