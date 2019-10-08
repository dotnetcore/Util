//============== NgZorro上传组件包装器===================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Component, Input, ViewChild, forwardRef, Optional, Output, EventEmitter, AfterViewInit } from '@angular/core';
import { NgModel, NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { NzUploadComponent, UploadFile, UploadFilter, UploadXHRArgs } from 'ng-zorro-antd';
import { MessageConfig as config } from '../config/message-config';
import { UploadService } from "../services/upload.service";
import { Util as util } from '../util';

/**
 * NgZorro上传组件包装器
 */
@Component( {
    selector: 'x-upload',
    template: `
        <nz-upload [nzName]="name" [(nzFileList)]="files" [nzListType]="listType"
                   [nzAction]="url" [nzData]="data" [nzHeaders]="headers"
                   [nzDisabled]="disabled" [nzShowButton]="isShowButton()" [nzAccept]="accept"
                   [nzFilter]="customFilters?customFilters:filters" [nzWithCredentials]="withCredentials"
                   [nzLimit]="limit" [nzSize]="size" [nzShowUploadList]="showUploadList"
                   [nzMultiple]="multiple" [nzDirectory]="directory"
                   [nzPreview]="getPreviewHandler()" [nzBeforeUpload]="beforeUpload" 
                   [nzCustomRequest]="customRequest" [nzRemove]="remove"
                   (nzChange)="handleChange($event)" >
            <button nz-button *ngIf="listType !== 'picture-card'" [disabled]="disabled">
                <i nz-icon nzType="{{buttonIcon?buttonIcon:'upload'}}"></i>
                <span>{{buttonText}}</span>
            </button>
            <ng-container *ngIf="listType === 'picture-card'">
                <i nz-icon class="upload-icon"  [nzType]="loading ? 'loading' : buttonIcon?buttonIcon:'plus'"></i>
                <div class="upload-text">{{buttonText}}</div>
            </ng-container>
        </nz-upload>
        <nz-modal [nzVisible]="previewVisible" [nzContent]="modalContent" [nzFooter]="null" (nzOnCancel)="previewVisible = false">
            <ng-template #modalContent>
                <img [src]="previewImage" [ngStyle]="{ width: '100%' }" />
            </ng-template>
        </nz-modal>
        <nz-form-control [nzValidateStatus]="isValid()?'success':'error'">
            <input nz-input style="display: none" [name]="validationId" #validationModel="ngModel" [(ngModel)]="validation" [required]="required" />
            <nz-form-explain *ngIf="!isValid()">{{requiredMessage}}</nz-form-explain>
        </nz-form-control>
    `,
    styles: [`
        .upload-icon {
            font-size: 32px;
            color: #999;
        }
        .upload-text {
            margin-top: 8px;
            color: #666;
        }
    `]
} )
export class Upload implements AfterViewInit {
    /**
     * 加载状态
     */
    loading;
    /**
     * 延迟
     */
    timeout;
    /**
     * 已修改状态
     */
    dirty;
    /**
     * 验证标识
     */
    validationId;
    /**
     * 验证值
     */
    validation;
    /**
     * 预览图片地址
     */
    previewImage: string;
    /**
     * 预览图片可见状态
     */
    previewVisible: boolean;
    /**
     * 上传文件列表
     */
    files: UploadFile[];
    /**
     * 附件列表
     */
    private items: any[];
    /**
     * 组件不添加到FormGroup，独立存在，这样也无法基于NgForm进行表单验证
     */
    @Input() standalone: boolean;
    /**
     * 发到后台的文件参数名
     */
    @Input() name: string;
    /**
     * 上传列表的内建样式，可选值：text, picture 和 picture-card
     */
    @Input() listType: string;
    /**
     * 自定义过滤器
     */
    @Input() customFilters: UploadFilter[];
    /**
     * 禁用
     */
    @Input() disabled: boolean;
    /**
     * 限制文件大小
     */
    @Input() size: number;
    /**
     * 单次最多上传数量
     */
    @Input() limit: number;
    /**
     * 上传文件总数量限制
     */
    @Input() totalLimit: number;
    /**
     * 接受上传的文件类型
     */
    @Input() accept: string;
    /**
     * 是否显示按钮
     */
    @Input() showButton: boolean;
    /**
     * 是否显示上传列表
     */
    @Input() showUploadList: boolean | { showPreviewIcon?: boolean, showRemoveIcon?: boolean };
    /**
     * 是否允许多选
     */
    @Input() multiple: boolean;
    /**
     * 允许上传文件夹
     */
    @Input() directory: boolean;
    /**
     * 上传地址
     */
    @Input() url: string;
    /**
     * 上传所需参数或返回上传参数的方法
     */
    @Input() data;
    /**
     * 上传的请求头部
     */
    @Input() headers;
    /**
     * 上传是否携带cookie
     */
    @Input() withCredentials;
    /**
     * 按钮文本
     */
    @Input() buttonText: string;
    /**
     * 按钮图标
     */
    @Input() buttonIcon: string;
    /**
     * 必填项
     */
    @Input() required: boolean;
    /**
     * 必填项验证消息
     */
    @Input() requiredMessage: string;
    /**
     * 预览操作
     */
    @Input() preview: ( file: UploadFile ) => void;
    /**
     * 移除文件操作
     */
    @Input() remove: ( file: UploadFile ) => void;
    /**
     * 上传前操作
     */
    @Input() beforeUpload: ( file: UploadFile, fileList: UploadFile[] ) => boolean;
    /**
     * 自定义上传操作
     */
    @Input() customRequest: ( item: UploadXHRArgs ) => Subscription;
    /**
     * 模型
     */
    @Input()
    get model(): any[] {
        return this.items;
    }
    set model( value ) {
        if ( !value )
            return;
        this.items = value;
        if ( !this.uploadService )
            return;
        if ( this.timeout )
            clearTimeout( this.timeout );
        this.timeout = setTimeout( () => {
            this.files = this.items.map( item => this.uploadService.toFile( item ) );
            this.loadValidate();
        }, 500 );
    }
    /**
     * 模型变更事件
     */
    @Output() modelChange = new EventEmitter<any>();
    /**
     * 验证模型变更事件
     */
    @Output() validateModelChange = new EventEmitter<any>();
    /**
     * 上传组件实例
     */
    @ViewChild( forwardRef( () => NzUploadComponent ), { "static": false }) instance: NzUploadComponent;
    /**
     * 文本框组件模型，用于验证
     */
    @ViewChild( forwardRef( () => NgModel ), { "static": false } ) controlModel: NgModel;

    /**
     * 初始化上传组件包装器
     * @param uploadService 上传服务
     * @param form 表单组件
     */
    constructor( @Optional() public uploadService: UploadService, @Optional() public form: NgForm ) {
        this.validationId = util.helper.uuid();
        this.listType = "text";
        this.buttonText = config.upload;
        this.requiredMessage = config.uploadRequiredMessage;
        this.showButton = true;
        this.showUploadList = true;
    }

    /**
     * 初始化
     */
    ngAfterViewInit() {
        this.addControl();
    }

    /**
     * 将控件添加到FormGroup
     */
    private addControl() {
        if ( this.standalone )
            return;
        this.form && this.form.addControl( this.controlModel );
    }

    /**
     * 组件销毁
     */
    ngOnDestroy() {
        this.removeControl();
    }

    /**
     * 将控件移除FormGroup
     */
    private removeControl() {
        if ( this.standalone )
            return;
        this.form && this.form.removeControl( this.controlModel );
    }

    /**
     * 获取预览处理器
     */
    getPreviewHandler() {
        if ( this.listType === 'text' )
            return undefined;
        if ( this.preview )
            return this.preview;
        return this.handlePreview;
    }

    /**
     * 是否验证有效
     */
    isValid() {
        if ( !this.required )
            return true;
        if ( !this.dirty )
            return true;
        return this.validation;
    }

    /**
     * 是否显示按钮
     */
    isShowButton() {
        if ( this.showButton === false )
            return false;
        if ( !this.totalLimit )
            return this.showButton;
        if ( !this.files )
            return true;
        return this.files.length < this.totalLimit;
    }

    /**
     * 上传变更处理
     * @param data 上传参数
     */
    handleChange( data: { file, fileList, event, type } ) {
        if ( !data || !data.file || !this.uploadService )
            return;
        switch ( data.file.status ) {
            case 'uploading':
                this.loading = true;
                break;
            case 'done':
                this.loading = false;
                if ( !data.file.response )
                    return;
                let item = this.uploadService.resolve( data.file.response );
                if ( !item )
                    return;
                if ( data.type === 'success' ) {
                    this.model = [...( this.model || [] ), item];
                    this.modelChange.emit( this.model );
                    this.loadValidate();
                }
                break;
            case 'removed':
                this.loading = false;
                this.uploadService.removeFromModel( this.model, data.file );
                this.uploadService.removeFromFileList( this.files, data.file );
                this.modelChange.emit( this.model );
                this.loadValidate();
                break;
            case 'error':
                this.loading = false;
                break;
        }
    }

    /**
     * 加载验证值
     */
    loadValidate() {
        this.dirty = true;
        if ( this.files && this.files.length > 0 ) {
            this.validation = "1";
            return;
        }
        this.validation = undefined;
    }

    /**
     * 上传过滤器
     */
    filters: UploadFilter[] = [
        {
            name: 'type',
            fn: ( files: UploadFile[] ) => {
                if ( !this.instance || !this.instance.nzAccept )
                    return files;
                const accepts = ( <string>this.instance.nzAccept ).split( ',' );
                let validFiles = files.filter( file => !file.name || ~accepts.indexOf( util.helper.getExtension( file.name ) ) );
                let invalidFiles = util.helper.except( files, validFiles );
                if ( invalidFiles && invalidFiles.length > 0 )
                    util.message.warn( this.getMessageByType( invalidFiles ) );
                return validFiles;
            }
        },
        {
            name: 'size',
            fn: ( files: UploadFile[] ) => {
                if ( !this.instance || this.instance.nzSize === 0 )
                    return files;
                let validFiles = files.filter( file => file.size / 1024 <= this.instance.nzSize );
                let invalidFiles = util.helper.except( files, validFiles );
                if ( invalidFiles && invalidFiles.length > 0 )
                    util.message.warn( this.getMessageBySize( invalidFiles ) );
                return validFiles;
            }
        },
        {
            name: 'limit',
            fn: ( files: UploadFile[] ) => {
                if ( !this.instance || !this.instance.nzMultiple || this.instance.nzLimit === 0 )
                    return files;
                let validFiles = files.slice( -this.instance.nzLimit );
                let invalidFiles = util.helper.except( files, validFiles );
                if ( invalidFiles && invalidFiles.length > 0 )
                    util.message.warn( this.getMessageByLimit( invalidFiles ) );
                return validFiles;
            }
        }
    ];

    /**
     * 获取文件类型错误消息
     */
    private getMessageByType( files: UploadFile[] ) {
        return `${files.map( t => this.replace( config.fileTypeFilter, t.name ) + '<br/>' ).join( '' )}`;
    }

    /**
     * 获取文件大小错误消息
     */
    private getMessageBySize( files: UploadFile[] ) {
        return `${files.map( t => this.replace( config.fileSizeFilter, t.name, this.instance.nzSize ) + '<br/>' ).join( '' )}`;
    }

    /**
     * 获取文件数量错误消息
     */
    private getMessageByLimit( files: UploadFile[] ) {
        return `${files.map( t => this.replace( config.fileLimitFilter, this.instance.nzLimit ) + '<br/>' ).join( '' )}`;
    }

    /**
     * 替换{0},{1}
     */
    private replace( message, value1, value2 = null ) {
        return message.replace( /\{0\}/, String( value1 ) ).replace( /\{1\}/, String( value2 ) );
    }

    /**
     * 预览处理
     */
    handlePreview = ( file: UploadFile ) => {
        if ( !file )
            return;
        if ( !util.helper.isImage( file.url ) )
            return;
        this.previewImage = file.url || file.thumbUrl;
        this.previewVisible = true;
    };
}