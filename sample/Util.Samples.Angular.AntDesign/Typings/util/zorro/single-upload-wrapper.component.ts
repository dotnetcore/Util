//============== NgZorro单文件上传组件包装器===================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Component, Input, Optional } from '@angular/core';
import { UploadService } from "../services/upload.service";
import { Upload } from "./upload-wrapper.component";

/**
 * NgZorro单文件上传组件包装器
 */
@Component({
    selector: 'nz-single-upload-wrapper',
    template: `
        <ng-content></ng-content>
    `,
    styles: [`
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
        }, 500);
    }

    /**
     * 初始化单文件上传组件包装器
     * @param uploadService 上传服务
     */
    constructor( @Optional() public uploadService: UploadService ) {
        super( uploadService );
    }

    /**
     * 上传变更处理
     * @param data 上传参数
     */
    handleChange(data: { file, fileList, event, type }) {
        if ( !data || !data.file || !this.uploadService )
            return;
        if ( data.type === 'removed' ) {
            this.clear();
            this.modelChange.emit( this.model );
            return;
        }
        if ( !data.file.response )
            return;
        let item = this.uploadService.resolve(data.file.response);
        if (!item)
            return;
        if ( data.type === 'success' ) {
            this.model = item;
            this.modelChange.emit( this.model );
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