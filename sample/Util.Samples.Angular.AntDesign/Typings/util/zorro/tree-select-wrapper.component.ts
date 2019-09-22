//============== NgZorro树形选择包装器=======================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Component, Input, Output, AfterContentInit, EventEmitter, Optional } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NzTreeNodeOptions, NzFormatEmitEvent } from "ng-zorro-antd";
import { FormControlWrapperBase } from './base/form-control-wrapper-base';
import { WebApi as webapi } from '../common/webapi';
import { TreeQueryParameter } from "../core/tree-model";

/**
 * NgZorro树形选择包装器
 */
@Component( {
    selector: 'x-tree-select',
    template: `
        <nz-form-control [nzValidateStatus]="(controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched))?'error':'success'">
            <nz-tree-select #controlModel="ngModel" [name]="name" [ngModel]="model" (ngModelChange)="onModelChange($event)" 
                [ngStyle]="getStyle()" [nzPlaceHolder]="placeholder" [nzNodes]="dataSource" [nzAsyncData]="async" [nzCheckable]="showCheckbox"
                [nzShowExpand]="showExpand" [nzShowLine]="showLine" [nzDefaultExpandAll]="expandAll" [nzExpandedKeys]="expandedKeys"
                [nzMultiple]="multiple" [required]="required" [nzDisabled]="disabled"
                (nzExpandChange)="expandChange($event)">
            </nz-tree-select>
            <nz-form-explain *ngIf="controlModel?.hasError( 'required' ) && (controlModel?.dirty || controlModel.touched)">{{requiredMessage}}</nz-form-explain>
        </nz-form-control>
    `
} )
export class TreeSelect extends FormControlWrapperBase implements AfterContentInit {
    /**
     * 是否异步加载
     */
    @Input() async: boolean;
    /**
     * 数据源
     */
    @Input() dataSource: NzTreeNodeOptions[];
    /**
     * 初始化时是否自动加载数据，默认为true,设置成false则手工加载
     */
    @Input() autoLoad: boolean;
    /**
     * 数据加载地址，范例：/api/test
     */
    @Input() url: string;
    /**
     * 查询参数
     */
    @Input() queryParam: TreeQueryParameter;
    /**
     * 查询参数变更事件
     */
    @Output() queryParamChange = new EventEmitter<TreeQueryParameter>();
    /**
     * 是否显示复选框
     */
    @Input() showCheckbox: boolean;
    /**
     * 节点前是否添加展开图标
     */
    @Input() showExpand: boolean;
    /**
     * 是否显示连接线
     */
    @Input() showLine: boolean;
    /**
     * 展开所有节点
     */
    @Input() expandAll: boolean;
    /**
     * 展开节点的标识列表
     */
    @Input() expandedKeys: boolean;
    /**
     * 复选框选中节点的标识列表
     */
    @Input() checkedKeys: boolean;
    /**
     * 选中节点的标识列表
     */
    @Input() selectedKeys: boolean;
    /**
     * 允许选中多个节点
     */
    @Input() multiple: boolean;
    /**
     * 宽度
     */
    @Input() width?: number;
    /**
     * 展开事件
     */
    @Output() onExpand = new EventEmitter<NzFormatEmitEvent>();

    /**
     * 初始化树形选择包装器
     */
    constructor( @Optional() form: NgForm ) {
        super( form );
        this.dataSource = new Array<any>();
        this.autoLoad = true;
        this.queryParam = new TreeQueryParameter();
        this.showExpand = true;
        this.async = true;
    }

    /**
     * 获取样式
     */
    getStyle() {
        return {
            'width': this.width ? `${this.width}px` : null
        };
    }

    /**
     * 内容加载完成时进行初始化
     */
    ngAfterContentInit() {
        if ( this.autoLoad )
            this.query();
    }

    /**
     * 发送请求
     * @param option 参数
     */
    query( option?: {
        url?: string;
        param?;
        before?: () => boolean;
        complete?: () => void;
        ok?: ( value ) => void;
    } ) {
        option = option || {};
        let url = option.url || this.url;
        if ( !url )
            return;
        let param = option.param || this.queryParam;
        webapi.get<any>( url ).param( param ).handle( {
            before: option.before,
            ok: result => {
                if ( option.ok ) {
                    option.ok( result );
                    return;
                }
                this.loadData( result );
            },
            complete: option.complete
        } );
    }

    /**
     * 加载数据
     */
    private loadData( result ) {
        if ( !result )
            return;
        this.dataSource = result.nodes || [];
        this.expandedKeys = result.expandedKeys || [];
        this.checkedKeys = result.checkedKeys || [];
        this.selectedKeys = result.selectedKeys || [];
    }

    /**
     * 刷新
     * @param queryParam 查询参数
     */
    refresh( queryParam? : TreeQueryParameter ) {
        if ( queryParam ) {
            this.queryParam = queryParam;
            this.queryParamChange.emit( queryParam );
        }
        this.queryParam.order = null;
        this.query();
    }

    /**
     * 清空数据
     */
    clear() {
        this.dataSource = [];
    }

    /**
     * 获取复选框被选中实体列表
     */
    getChecked() {
        return null;
    }

    /**
     * 获取复选框被选中实体Id列表
     */
    getCheckedIds(): string {
        return this.getChecked().map( ( value ) => value.id ).join( "," );
    }

    /**
     * 展开事件处理
     * @param event
     */
    expandChange( event ) {
        this.loadChildren( event );
        this.onExpand.emit( event );
    }

    /**
     * 加载子节点列表
     */
    private loadChildren( event: NzFormatEmitEvent ) {
        if ( !event )
            return;
        let node = event.node;
        if ( !node )
            return;
        let children = node.getChildren();
        if ( children && children.length > 0 )
            return;
        this.queryParam.operation = "LoadChild";
        this.queryParam.parentId = node.key;
        this.query({
            ok: result => {
                if ( result && result.nodes && result.nodes.length > 0 ) {
                    node.addChildren( result.nodes );
                    return;
                }
                node.isLoading = false;
                node.isLeaf = true;
            },
            complete: () => {
                this.queryParam.operation = null;
                this.queryParam.parentId = null;
            }
        } );
    }
}