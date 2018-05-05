//============== 树型Crud编辑组件基类===============
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
import { Injector } from '@angular/core';
import { TreeViewModel, EditComponentBase } from '../index';

/**
 * 树型Crud编辑组件基类
 */
export abstract class TreeEditComponentBase<TViewModel extends TreeViewModel> extends EditComponentBase<TViewModel> {
    /**
     * 父节点
     */
    parent;

    /**
     * 初始化组件
     * @param injector 注入器
     */
    constructor(injector: Injector) {
        super(injector);
    }

    /**
     * 初始化
     */
    ngOnInit() {
        super.ngOnInit();
        this.loadParent();
    }

    /**
     * 加载完成后操作
     */
    protected loadAfter(result: TViewModel) {
        this.loadParent(result.parentId);
    }

    /**
     * 加载父节点
     */
    protected loadParent(parentId?) {
        parentId = parentId || this.util.router.getQueryParam("id");
        if (!parentId)
            return;
        this.util.webapi.get(this.getLoadParentUrl()).param("id", parentId).handle({
            handler: result => {
                this.setParent(result);
            }
        });
    }

    /**
     * 获取加载父节点地址
     */
    protected getLoadParentUrl() {
        return `/api/${this.getBaseUrl()}/tree`;
    }

    /**
     * 设置父节点
     * @param parent 父节点
     */
    protected setParent(parent) {
        if (!parent)
            return;
        this.parent = parent;
        this.model.parentId = parent.id || parent.data && parent.data.id;
        this.model.parentName = parent.name || parent.data && parent.data.name;
    }
}