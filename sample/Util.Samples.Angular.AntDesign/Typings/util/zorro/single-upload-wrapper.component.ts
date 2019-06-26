//============== NgZorro单文件上传组件包装器===================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Component, Input, Optional } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UploadService } from "../services/upload.service";
import { Upload } from "./upload-wrapper.component";

/**
 * NgZorro单文件上传组件包装器
 */
@Component({
    selector: 'x-single-upload',
    template: `
        <nz-upload [nzName]="name" [(nzFileList)]="files" [nzListType]="listType"
                   [nzAction]="url" [nzData]="data" [nzHeaders]="headers"
                   [nzDisabled]="disabled" [nzShowButton]="isShowButton()" [nzAccept]="accept"
                   [nzFilter]="customFilters?customFilters:filters" [nzWithCredentials]="withCredentials"
                   [nzSize]="size" [nzShowUploadList]="showUploadList"
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
})
export class SingleUpload extends Upload{
    /**
     * 附件
     */
    item;
    /**
     * 模型
     */
    @Input()
    get model() {
        return this.item;
    }
    set model(value) {
        if (!value)
            return;
        this.item = value;
        if ( !this.uploadService )
            return;
        if (this.timeout)
            clearTimeout(this.timeout);
        this.timeout = setTimeout(() => {
            this.files = [this.uploadService.toFile( value )];
            this.loadValidate();
        }, 500);
    }

    /**
     * 初始化单文件上传组件包装器
     * @param uploadService 上传服务
     * @param form 表单组件
     */
    constructor( @Optional() public uploadService: UploadService, @Optional() public form: NgForm ) {
        super( uploadService, form );
        this.totalLimit = 1;
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
                this.model = item;
                this.modelChange.emit( this.model );
                this.loadValidate();
            }
            break;
        case 'removed':
            this.loading = false;
            this.clear();
            this.modelChange.emit( this.model );
            this.loadValidate();
            break;
        case 'error':
            this.loading = false;
            break;
        }
    }

    /**
     * 清理
     */
    private clear() {
        this.files = [];
        this.item = null;
    }
}