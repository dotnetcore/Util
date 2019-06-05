//============== NgZorro上传组件包装器===================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Component, Input,ViewChild, ContentChild, forwardRef, Optional, Output, EventEmitter,AfterContentInit } from '@angular/core';
import { NgModel, NgForm } from '@angular/forms';
import { NzUploadComponent, UploadFile, UploadFilter } from 'ng-zorro-antd';
import { MessageConfig as config } from '../config/message-config';
import { UploadService } from "../services/upload.service";
import { Util as util } from '../util';

/**
 * NgZorro上传组件包装器
 */
@Component({
    selector: 'nz-upload-wrapper',
    template: `        
        <ng-content></ng-content>
        <nz-form-control [nzValidateStatus]="isValid()?'success':'error'">
            <input nz-input style="display: none" [name]="validationId" #validationModel="ngModel" [(ngModel)]="validation" [required]="required" />
            <nz-form-explain *ngIf="!isValid()">{{requiredMessage}}</nz-form-explain>
        </nz-form-control>
    `,
    styles: [`
    `]
})
export class Upload implements AfterContentInit{
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
     * 必填项
     */
    @Input() required: boolean;
    /**
     * 必填项验证消息
     */
    @Input() requiredMessage: string;
    /**
     * 模型
     */
    @Input()
    get model(): any[] {
        return this.items;
    }
    set model(value) {
        if (!value)
            return;
        this.items = value;
        if ( !this.uploadService )
            return;
        if (this.timeout)
            clearTimeout(this.timeout);
        this.timeout = setTimeout(() => {
            this.files = this.items.map( item => this.uploadService.toFile( item ) );
            this.loadValidate();
        }, 500);
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
    @ContentChild( forwardRef( () => NzUploadComponent ) ) instance: NzUploadComponent;
    /**
     * 文本框组件模型，用于验证
     */
    @ViewChild( forwardRef( () => NgModel ) ) controlModel: NgModel;

    /**
     * 初始化上传组件包装器
     * @param uploadService 上传服务
     * @param form 表单组件
     */
    constructor( @Optional() public uploadService: UploadService, @Optional() public form: NgForm ) {
        this.validationId = util.helper.uuid();
        this.requiredMessage = config.uploadRequiredMessage;
    }

    /**
     * 初始化
     */
    ngAfterContentInit() {
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
     * 上传变更处理
     * @param data 上传参数
     */
    handleChange( data: { file, fileList, event, type } ) {
        if ( !data || !data.file || !this.uploadService )
            return;
        if ( data.type === 'removed' ) {
            this.uploadService.removeFromModel( this.model, data.file );
            this.uploadService.removeFromFileList( this.files, data.file );
            this.modelChange.emit( this.model );
            this.loadValidate();
            return;
        }
        if ( !data.file.response )
            return;
        let item = this.uploadService.resolve(data.file.response);
        if (!item)
            return;
        if ( data.type === 'success' ) {
            this.model = [...( this.model || [] ) , item];
            this.modelChange.emit( this.model );
            this.loadValidate();
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
            fn: (files: UploadFile[]) => {
                if (!this.instance || !this.instance.nzAccept)
                    return files;
                const accepts = (<string>this.instance.nzAccept).split(',');
                let validFiles = files.filter(file => !file.name || ~accepts.indexOf(util.helper.getExtension(file.name)));
                let invalidFiles = util.helper.except(files, validFiles);
                if (invalidFiles && invalidFiles.length > 0)
                    util.message.warn(this.getMessageByType(invalidFiles));
                return validFiles;
            }
        },
        {
            name: 'size',
            fn: (files: UploadFile[]) => {
                if (!this.instance || this.instance.nzSize === 0)
                    return files;
                let validFiles = files.filter(file => file.size / 1024 <= this.instance.nzSize);
                let invalidFiles = util.helper.except(files, validFiles);
                if (invalidFiles && invalidFiles.length > 0)
                    util.message.warn(this.getMessageBySize(invalidFiles));
                return validFiles;
            }
        },
        {
            name: 'limit',
            fn: (files: UploadFile[]) => {
                if (!this.instance || !this.instance.nzMultiple || this.instance.nzLimit === 0)
                    return files;
                let validFiles = files.slice(-this.instance.nzLimit);
                let invalidFiles = util.helper.except(files, validFiles);
                if (invalidFiles && invalidFiles.length > 0)
                    util.message.warn(this.getMessageByLimit(invalidFiles));
                return validFiles;
            }
        }
    ];

    /**
     * 获取文件类型错误消息
     */
    private getMessageByType(files: UploadFile[]) {
        return `${files.map(t => this.replace(config.fileTypeFilter, t.name) + '<br/>').join('')}`;
    }

    /**
     * 获取文件大小错误消息
     */
    private getMessageBySize(files: UploadFile[]) {
        return `${files.map(t => this.replace(config.fileSizeFilter, t.name, this.instance.nzSize) + '<br/>').join('')}`;
    }

    /**
     * 获取文件数量错误消息
     */
    private getMessageByLimit(files: UploadFile[]) {
        return `${files.map(t => this.replace(config.fileLimitFilter, this.instance.nzLimit) + '<br/>').join('')}`;
    }

    /**
     * 替换{0},{1}
     */
    private replace(message, value1, value2 = null) {
        return message.replace(/\{0\}/, String(value1)).replace(/\{1\}/, String(value2));
    }
}