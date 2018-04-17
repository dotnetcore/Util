//============== Prime树型表格 ===================
//Copyright PrimeNg
// 修改： 何镇汐
//Licensed under the MIT license
//================================================
import { NgModule, Component, Input, Output, EventEmitter, AfterContentInit, ElementRef, ContentChild, IterableDiffers, ChangeDetectorRef, ContentChildren, QueryList, Inject, forwardRef, OnInit, Renderer2, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TreeNode, Header, Footer, Column, SharedModule, DomHandler } from "primeng/primeng";
//Material模块
import { MatCommonModule, MatCheckboxModule, MatPaginatorModule, MatProgressBarModule, MatPaginator, MatRadioModule } from '@angular/material';
import { WebApi as webapi } from '../common/webapi';
import { Message as message } from '../common/message';
import { PagerList } from '../core/pager-list';
import { ITreeNode, LoadOperation, TreeQueryParameter } from '../core/tree';
import { MessageConfig as config } from '../config/message-config';
import { DicService } from '../services/dic.service';

@Component({
    selector: 'p-tree-table',
    template: `
<div class="table-container mat-elevation-z8">
    <mat-progress-bar mode="indeterminate" *ngIf="loading"></mat-progress-bar>
    <div [ngClass]="'ui-treetable ui-widget'" [ngStyle]="style" [class]="styleClass">
        <div class="ui-treetable-header ui-widget-header" *ngIf="header">
            <ng-content select="p-header"></ng-content>
        </div>
        <div class="ui-treetable-tablewrapper">
            <table #tbl class="ui-widget-content" [class]="tableStyleClass" [ngStyle]="tableStyle">
                <thead>
                    <tr class="ui-state-default">
                        <th #headerCell *ngFor="let col of columns; let lastCol = last;let i = index;"  [ngStyle]="col.headerStyle||col.style" [class]="col.headerStyleClass||col.styleClass" 
                            [ngClass]="'ui-state-default ui-unselectable-text'">
                            <mat-checkbox class="master-checkbox" *ngIf="selectionMode == 'checkbox' && i==0" [checked]="isMasterChecked()" 
                                [indeterminate]="isIndeterminate()" (change)="masterToggle()"></mat-checkbox>
                            <span class="ui-column-title" *ngIf="!col.headerTemplate">{{col.header}}</span>                                
                            <span class="ui-column-title" *ngIf="col.headerTemplate">
                                <ng-container *ngTemplateOutlet="col.headerTemplate; context: {$implicit: col}"></ng-container>
                            </span>
                        </th>
                    </tr>
                </thead>
                <tfoot *ngIf="hasFooter()">
                    <tr>
                        <td *ngFor="let col of columns" [ngStyle]="col.footerStyle||col.style" [class]="col.footerStyleClass||col.styleClass" [ngClass]="{'ui-state-default':true}">
                            <span class="ui-column-footer" *ngIf="!col.footerTemplate">{{col.footer}}</span>
                            <span class="ui-column-footer" *ngIf="col.footerTemplate">
                                <ng-container *ngTemplateOutlet="col.headerTemplate; context: {$implicit: col}"></ng-container>
                            </span>
                        </td>
                    </tr>
                </tfoot>                
                <tbody pTreeRow *ngFor="let node of dataSource" class="ui-treetable-data ui-widget-content" [node]="node" [level]="0" [labelExpand]="labelExpand" [labelCollapse]="labelCollapse"></tbody>
            </table>
        </div>
            
        <div class="ui-treetable-footer ui-widget-header" *ngIf="footer">
            <ng-content select="p-footer"></ng-content>
        </div>
    </div>
    <mat-paginator [length]="totalCount" [pageSize]="queryParam&&queryParam.pageSize" [pageSizeOptions]="pageSizeOptions"></mat-paginator>
</div>
    `,
    styles: [`
        .table-container {
            display: flex;
            flex-direction: column;
            position: relative;
        }
        ::ng-deep .ui-treetable {
            overflow: auto;
        } 
    `],
    providers: [DomHandler]
})
export class TreeTable<T extends TreeNode & ITreeNode> implements AfterContentInit {
    /**
     * 操作标记
     */
    operation: LoadOperation;
    /**
     * 查询延迟
     */
    timeout;
    /**
     * 查询延迟间隔，单位：毫秒，默认500
     */
    @Input() delay: number;
    /**
     * 显示进度条
     */
    loading: boolean;
    /**
     * 总行数
     */
    totalCount = 0;
    /**
     * 初始排序
     */
    initOrder: string;
    /**
     * 数据源
     */
    @Input() dataSource: T[];
    /**
     * 键
     */
    @Input() key: string;
    /**
     * 初始化时是否自动加载数据，默认为true,设置成false则手工加载
     */
    @Input() autoLoad: boolean;
    /**
     * 分页长度列表
     */
    @Input() pageSizeOptions: number[];
    /**
    * 基地址，基于该地址构建加载地址和删除地址，范例：传入test,则加载地址为/api/test,删除地址为/api/test/delete
    */
    @Input() baseUrl: string;
    /**
     * 数据加载地址，范例：/api/test
     */
    @Input() url: string;
    /**
     * 删除地址，注意：由于支持批量删除，所以采用Post提交，范例：/api/test/delete
     */
    @Input() deleteUrl: string;
    /**
     * 查询参数
     */
    @Input() queryParam: TreeQueryParameter;
    /**
     * 查询参数还原事件
     */
    @Output() onQueryRestore = new EventEmitter<TreeQueryParameter>();
    /**
     * 分页组件
     */
    @ViewChild(MatPaginator) paginator: MatPaginator;

    @Input() selectionMode: string;

    @Input() selection: any;

    @Input() style: any;

    @Input() styleClass: string;

    @Input() labelExpand: string = "Expand";

    @Input() labelCollapse: string = "Collapse";

    @Input() metaKeySelection: boolean = false;

    @Input() contextMenu: any;

    @Input() toggleColumnIndex: number = 0;

    @Input() tableStyle: any;

    @Input() tableStyleClass: string;

    @Input() collapsedIcon: string = "fa-caret-right";

    @Input() expandedIcon: string = "fa-caret-down";

    @Output() onRowDblclick: EventEmitter<any> = new EventEmitter();

    @Output() selectionChange: EventEmitter<any> = new EventEmitter();

    @Output() onNodeSelect: EventEmitter<any> = new EventEmitter();

    @Output() onNodeUnselect: EventEmitter<any> = new EventEmitter();

    @Output() onNodeExpand: EventEmitter<any> = new EventEmitter();

    @Output() onNodeCollapse: EventEmitter<any> = new EventEmitter();

    @Output() onContextMenuSelect: EventEmitter<any> = new EventEmitter();

    @ContentChild(Header) header: Header;

    @ContentChild(Footer) footer: Footer;

    @ContentChildren(Column) cols: QueryList<Column>;

    @ViewChild('tbl') tableViewChild: ElementRef;



    public rowTouched: boolean;

    public columns: Column[];

    columnsSubscription;

    constructor(public el: ElementRef, public domHandler: DomHandler, public changeDetector: ChangeDetectorRef, public renderer: Renderer2, private dic: DicService<TreeQueryParameter>) {
        this.pageSizeOptions = [10, 20, 50, 100];
        this.loading = false;
        this.autoLoad = true;
        this.queryParam = new TreeQueryParameter();
        this.delay = 500;
        this.selection = new Array<T>();
    }

    ngAfterContentInit() {
        this.init();
    }

    /**
     * 初始化
     */
    private init() {
        this.initColumns();
        this.initOperation();
        this.columnsSubscription = this.cols.changes.subscribe(_ => {
            this.initColumns();
            this.changeDetector.markForCheck();
        });
        this.initPaginator();
        this.restoreQueryParam();
        if (this.autoLoad)
            this.query();
    }

    /**
     * 初始化列集合
     */
    private initColumns() {
        this.columns = this.cols.toArray();
    }

    /**
     * 初始化操作标记
     */
    private initOperation() {
        this.operation = LoadOperation.FirstLoad;
    }

    /**
     * 初始化分页组件
     */
    private initPaginator() {
        this.initPage();
        this.paginator.page.subscribe(() => {
            this.clearLoadChildState();
            this.queryParam.page = this.paginator.pageIndex + 1;
            this.queryParam.pageSize = this.paginator.pageSize;
            this.query();
        });
    }

    /**
     * 初始化分页参数
     */
    private initPage() {
        this.queryParam.page = 1;
        if (this.pageSizeOptions && this.pageSizeOptions.length > 0)
            this.queryParam.pageSize = this.pageSizeOptions[0];
    }

    /**
     * 清空加载子节点状态
     */
    private clearLoadChildState() {
        if (this.operation === LoadOperation.LoadChild)
            this.operation = LoadOperation.Query;
        this.queryParam.parentId = "";
    }

    /**
     * 还原查询参数
     */
    private restoreQueryParam() {
        if (!this.key)
            return;
        let query = this.dic.get(this.key);
        if (!query)
            return;
        this.queryParam = query;
        this.onQueryRestore.emit(query);
    }

    /**
     * 查询
     */
    private query() {
        this.sendQuery(result => {
            result = new PagerList<T>(result);
            this.dataSource = result.data;
            this.paginator.pageIndex = result.page - 1;
            this.totalCount = result.totalCount;
            this.selection = new Array<T>();
        });
    }

    /**
     * 发送查询请求
     */
    private sendQuery(handler: (result: PagerList<T>) => void) {
        let url = this.url || (this.baseUrl && `/api/${this.baseUrl}`);
        if (!url) {
            console.log("树型表格url未设置");
            return;
        }
        this.processParam();
        webapi.get<PagerList<T>>(url).param(this.queryParam).handle({
            beforeHandler: () => { this.loading = true; return true; },
            handler: handler,
            completeHandler: () => this.loading = false
        });
    }

    /**
     * 对参数进行处理
     */
    private processParam() {
        if (this.operation)
            this.queryParam["operation"] = this.operation;
        this.filterParam();
        if (this.key)
            this.dic.add(this.key, this.queryParam);
    }

    /**
     * 过滤参数
     */
    private filterParam() {
        if (this.queryParam.keyword === null)
            this.queryParam.keyword = "";
        if (!this.queryParam.order)
            this.queryParam.order = "";
    }

    /**
     * 延迟搜索
     * @param delay 查询延迟间隔，单位：毫秒，默认500
     */
    search(delay?: number) {
        if (this.timeout)
            clearTimeout(this.timeout);
        this.timeout = setTimeout(() => {
            this.operation = LoadOperation.Query;
            this.query();
        }, delay || this.delay);
    }

    /**
     * 刷新
     * @param queryParam 查询参数
     */
    refresh(queryParam) {
        this.queryParam = queryParam;
        this.initOperation();
        this.initPage();
        this.queryParam.order = this.initOrder;
        this.dic.remove(this.key);
        this.query();
    }

    /**
     * 加载下级节点
     * @param node 父节点
     */
    loadChild(node: T) {
        if (!node)
            return;
        if (node.children)
            return;
        this.operation = LoadOperation.LoadChild;
        this.queryParam.parentId = node.data.id;
        this.sendQuery(result => {
            if (result && result.data && result.data.length > 0) {
                node.children = result.data;
                return;
            }
            node.leaf = true;
        });
    }

    /**
     * 获取复选框被选中实体列表
     */
    getChecked(): T[] {
        return this.selection;
    }

    /**
     * 获取复选框被选中实体Id列表
     */
    getCheckedIds(): string {
        return this.selection.map((node) => node && node.data && node.data.id).join(",");
    }

    /**
     * 批量删除被选中实体
     * @param ids 待删除的Id列表，多个Id用逗号分隔，范例：1,2,3
     * @param handler 删除成功回调函数
     * @param deleteUrl 服务端删除Api地址，如果设置了基地址baseUrl，则可以省略该参数
     */
    delete(ids?: string, handler?: () => {}, deleteUrl?: string) {
        ids = ids || this.getCheckedIds();
        if (!ids) {
            message.warn(config.deleteNotSelected);
            return;
        }
        message.confirm(config.deleteConfirm, () => {
            this.deleteRequest(ids, handler, deleteUrl);
        });
    }

    /**
     * 发送删除请求
     */
    private deleteRequest(ids?: string, handler?: () => {}, deleteUrl?: string) {
        deleteUrl = deleteUrl || this.deleteUrl || (this.baseUrl && `/api/${this.baseUrl}/delete`);
        if (!deleteUrl) {
            console.log("树型表格deleteUrl未设置");
            return;
        }
        webapi.post(deleteUrl, ids).handle({
            handler: () => {
                if (handler) {
                    handler();
                    return;
                }
                message.snack(config.deleteSuccessed);
                this.clearLoadChildState();
                this.query();
            }
        });
    }

    /**
     * 表头主复选框切换选中状态
     */
    masterToggle() {
        if (this.isMasterChecked()) {
            let length = this.selection.length;
            for (let i = 0; i < length; i++)
                this.selection.pop(this.selection[i]);
            return;
        }
        this.dataSource.forEach(node => {
            this.propagateSelectionDown(node, true);
            if (node.parent) {
                this.propagateSelectionUp(node.parent, true);
            }
            this.selectionChange.emit(this.selection);
            this.onNodeSelect.emit({ originalEvent: event, node: node });
        });
    }

    /**
     * 表头主复选框的选中状态
     */
    isMasterChecked() {
        if (!this.selection || this.selection.length === 0)
            return false;
        let length = this.getNodesLength(this.dataSource);
        return this.selection.length === length;
    }

    /**
     * 获取节点列表长度
     */
    private getNodesLength(treeNodes: TreeNode[]) {
        let allNodes = this.getAllNodes(treeNodes);
        if (!allNodes)
            return 0;
        return allNodes.length;
    }

    /**
     * 获取所有节点
     */
    private getAllNodes(treeNodes: TreeNode[]) {
        if (!treeNodes)
            return treeNodes;
        let result = Array<TreeNode>();
        result.push(...treeNodes);
        for (let i = 0; i < treeNodes.length; i++)
            result.push(...this.getAllNodes(treeNodes[i].children));
        return result;
    }

    /**
     * 获取所有下级节点
     */
    private getChildNodes(treeNodes: TreeNode[]) {
        let nodes = this.getAllNodes(treeNodes);
        nodes.splice(0, treeNodes.length);
        return nodes;
    }

    /**
     * 复选框的确定状态
     */
    isIndeterminate(treeNode: TreeNode) {
        if (!this.selection || this.selection.length === 0)
            return false;
        if (!treeNode) {
            let length = this.getNodesLength(this.dataSource);
            return this.selection.length !== length;
        }
        if (!treeNode.children || treeNode.children.length === 0)
            return false;
        let nodes = this.getChildNodes([treeNode]);
        if (nodes.every(node => this.isSelected(node)))
            return false;
        return nodes.some(node => this.isSelected(node));
    }

    isSelected(node: TreeNode) {
        return this.findIndexInSelection(node) != -1;
    }

    onRowClick(event, node: TreeNode) {
        let eventTarget = null;
        if (event) {
            eventTarget = (<Element>event.target);
            if (eventTarget.className && eventTarget.className.indexOf('ui-treetable-toggler') === 0) {
                return;
            }
        }

        if (this.selectionMode) {
            if (node.selectable === false) {
                return;
            }

            let metaSelection = this.rowTouched ? false : this.metaKeySelection;
            let index = this.findIndexInSelection(node);
            let selected = (index >= 0);

            if (this.isCheckboxSelectionMode()) {
                if (selected) {
                    this.propagateSelectionDown(node, false);
                    if (node.parent) {
                        this.propagateSelectionUp(node.parent, false);
                    }
                    this.selectionChange.emit(this.selection);
                    this.onNodeUnselect.emit({ originalEvent: event, node: node });
                }
                else {
                    this.propagateSelectionDown(node, true);
                    if (node.parent) {
                        this.propagateSelectionUp(node.parent, true);
                    }
                    this.selectionChange.emit(this.selection);
                    this.onNodeSelect.emit({ originalEvent: event, node: node });
                }
            }
            else {
                if (metaSelection) {
                    let metaKey = (event.metaKey || event.ctrlKey);

                    if (selected && metaKey) {
                        if (this.isSingleSelectionMode()) {
                            this.selectionChange.emit(null);
                        }
                        else {
                            this.selection = this.selection.filter((val, i) => i != index);
                            this.selectionChange.emit(this.selection);
                        }

                        this.onNodeUnselect.emit({ originalEvent: event, node: node });
                    }
                    else {
                        if (this.isSingleSelectionMode()) {
                            this.selectionChange.emit(node);
                        }
                        else if (this.isMultipleSelectionMode()) {
                            this.selection = (!metaKey) ? [] : this.selection || [];
                            this.selection = [...this.selection, node];
                            this.selectionChange.emit(this.selection);
                        }

                        this.onNodeSelect.emit({ originalEvent: event, node: node });
                    }
                }
                else {
                    if (this.isSingleSelectionMode()) {
                        if (selected) {
                            this.selection = null;
                            this.onNodeUnselect.emit({ originalEvent: event, node: node });
                        }
                        else {
                            this.selection = node;
                            this.onNodeSelect.emit({ originalEvent: event, node: node });
                        }
                    }
                    else {
                        if (selected) {
                            this.selection = this.selection.filter((val, i) => i != index);
                            this.onNodeUnselect.emit({ originalEvent: event, node: node });
                        }
                        else {
                            this.selection = [...this.selection || [], node];
                            this.onNodeSelect.emit({ originalEvent: event, node: node });
                        }
                    }

                    this.selectionChange.emit(this.selection);
                }
            }
        }

        this.rowTouched = false;
    }

    onRowTouchEnd() {
        this.rowTouched = true;
    }

    onRowRightClick(event: MouseEvent, node: TreeNode) {
        if (this.contextMenu) {
            let index = this.findIndexInSelection(node);
            let selected = (index >= 0);

            if (!selected) {
                if (this.isSingleSelectionMode()) {
                    this.selection = node;
                }
                else if (this.isMultipleSelectionMode()) {
                    this.selection = [node];
                    this.selectionChange.emit(this.selection);
                }

                this.selectionChange.emit(this.selection);
            }

            this.contextMenu.show(event);
            this.onContextMenuSelect.emit({ originalEvent: event, node: node });
        }
    }

    findIndexInSelection(node: TreeNode) {
        let index: number = -1;

        if (this.selectionMode && this.selection) {
            if (this.isSingleSelectionMode()) {
                index = (this.selection == node) ? 0 : - 1;
            }
            else {
                for (let i = 0; i < this.selection.length; i++) {
                    if (this.selection[i] == node) {
                        index = i;
                        break;
                    }
                }
            }
        }

        return index;
    }

    propagateSelectionUp(node: TreeNode, select: boolean) {
        if (node.children && node.children.length) {
            let selectedCount: number = 0;
            let childPartialSelected: boolean = false;
            for (let child of node.children) {
                if (this.isSelected(child)) {
                    selectedCount++;
                }
                else if (child.partialSelected) {
                    childPartialSelected = true;
                }
            }

            if (select && selectedCount == node.children.length) {
                this.selection = [...this.selection || [], node];
                node.partialSelected = false;
            }
            else {
                if (!select) {
                    let index = this.findIndexInSelection(node);
                    if (index >= 0) {
                        this.selection = this.selection.filter((val, i) => i != index);
                    }
                }

                if (childPartialSelected || selectedCount > 0 && selectedCount != node.children.length)
                    node.partialSelected = true;
                else
                    node.partialSelected = false;
            }
        }

        let parent = node.parent;
        if (parent) {
            this.propagateSelectionUp(parent, select);
        }
    }

    propagateSelectionDown(node: TreeNode, select: boolean) {
        let index = this.findIndexInSelection(node);

        if (select && index == -1) {
            this.selection = [...this.selection || [], node];
        }
        else if (!select && index > -1) {
            this.selection = this.selection.filter((val, i) => i != index);
        }

        node.partialSelected = false;

        if (node.children && node.children.length) {
            for (let child of node.children) {
                this.propagateSelectionDown(child, select);
            }
        }
    }

    isSingleSelectionMode() {
        return this.selectionMode && this.selectionMode == 'single';
    }

    isMultipleSelectionMode() {
        return this.selectionMode && this.selectionMode == 'multiple';
    }

    isCheckboxSelectionMode() {
        return this.selectionMode && this.selectionMode == 'checkbox';
    }

    hasFooter() {
        if (this.columns) {
            let columnsArr = this.cols.toArray();
            for (let i = 0; i < columnsArr.length; i++) {
                if (columnsArr[i].footer) {
                    return true;
                }
            }
        }
        return false;
    }
}

@Component({
    selector: '[pTreeRow]',
    template: `
        <div [class]="node.styleClass" [ngClass]="{'ui-treetable-row': true, 'ui-treetable-row-selectable':true}">                   
            <td *ngFor="let col of treeTable.columns; let i=index" [ngStyle]="col.bodyStyle||col.style" [class]="col.bodyStyleClass||col.styleClass" 
                (click)="onRowClick($event,i)" (dblclick)="rowDblClick($event)" (touchend)="onRowTouchEnd()" (contextmenu)="onRowRightClick($event)">
                <a href="#" *ngIf="i == treeTable.toggleColumnIndex" class="ui-treetable-toggler fa fa-fw ui-clickable" [ngClass]="node.expanded ? treeTable.expandedIcon : treeTable.collapsedIcon"
                    [ngStyle]="{'margin-left':level*16 + 'px','visibility': isLeaf() ? 'hidden' : 'visible'}"
                    (click)="toggle($event)"
                    [title]="node.expanded ? labelCollapse : labelExpand">
                </a>
                <mat-checkbox *ngIf="treeTable.selectionMode == 'checkbox' && i==0" [checked]="isSelected()" 
                    (change)="onRowClick()" (click)="$event.stopPropagation()" [indeterminate]="isIndeterminate()"></mat-checkbox>                
                <mat-radio-button name="radioTreeTable" (change)="onRowClick()" (click)="$event.stopPropagation()" 
                    *ngIf="treeTable.selectionMode == 'single' && i==0 && isLeaf()" [checked]="isSelected()"></mat-radio-button>                
                <span *ngIf="!col.template">{{resolveFieldData(node.data,col.field)}}</span>
                <ng-container *ngTemplateOutlet="col.template; context: {$implicit: col, rowData: node}"></ng-container>
            </td>
        </div>
        <div *ngIf="node.children && node.expanded" class="ui-treetable-row" style="display:table-row">
            <td [attr.colspan]="treeTable.columns.length" class="ui-treetable-child-table-container">
                <table [class]="treeTable.tableStyleClass" [ngStyle]="treeTable.tableStyle">
                    <tbody pTreeRow *ngFor="let childNode of node.children" [node]="childNode" [level]="level+1" [labelExpand]="labelExpand" [labelCollapse]="labelCollapse" [parentNode]="node"></tbody>
                </table>
            </td>
        </div>
    `
})
export class UITreeRow<T extends TreeNode & ITreeNode> implements OnInit {

    @Input() node: T;

    @Input() parentNode: TreeNode;

    @Input() level: number = 0;

    @Input() labelExpand: string = "Expand";

    @Input() labelCollapse: string = "Collapse";

    constructor( @Inject(forwardRef(() => TreeTable)) public treeTable: TreeTable<T>) { }

    ngOnInit() {
        this.node.parent = this.parentNode;
    }

    toggle(event: Event) {
        if (this.node.expanded)
            this.treeTable.onNodeCollapse.emit({ originalEvent: event, node: this.node });
        else {
            this.treeTable.loadChild(this.node);
            this.treeTable.onNodeExpand.emit({ originalEvent: event, node: this.node });
        }

        this.node.expanded = !this.node.expanded;

        event.preventDefault();
        event.stopPropagation();
    }

    isLeaf() {
        return this.node.leaf == false ? false : !(this.node.children && this.node.children.length);
    }

    isSelected() {
        var result = this.treeTable.isSelected(this.node);
        return result;
    }

    /**
     * 复选框的确定状态
     */
    isIndeterminate() {
        return this.treeTable.isIndeterminate(this.node);
    }

    onRowClick(event: MouseEvent, index: number) {
        this.treeTable.onRowClick(event, this.node);
    }

    onRowRightClick(event: MouseEvent) {
        this.treeTable.onRowRightClick(event, this.node);
    }

    rowDblClick(event: MouseEvent) {
        this.treeTable.onRowDblclick.emit({ originalEvent: event, node: this.node });
    }

    onRowTouchEnd() {
        this.treeTable.onRowTouchEnd();
    }

    resolveFieldData(data: any, field: string): any {
        if (data && field) {
            if (field.indexOf('.') == -1) {
                return data[field];
            }
            else {
                let fields: string[] = field.split('.');
                let value = data;
                for (var i = 0, len = fields.length; i < len; ++i) {
                    value = value[fields[i]];
                }
                return value;
            }
        }
        else {
            return null;
        }
    }
}

@NgModule({
    imports: [CommonModule, MatCommonModule, MatCheckboxModule, MatProgressBarModule, MatPaginatorModule, MatRadioModule],
    exports: [TreeTable, SharedModule],
    declarations: [TreeTable, UITreeRow]
})
export class TreeTableModule { }