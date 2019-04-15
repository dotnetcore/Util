//============== NgZorro上传组件包装器===================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Component, Input, ContentChild, forwardRef, AfterContentInit, Optional } from '@angular/core';
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
    `,
    styles: [`
    `]
})
export class UploadWrapperComponent implements AfterContentInit {
    /**
     * 模型
     */
    @Input() model: any[];
    /**
     * 上传组件实例
     */
    @ContentChild(forwardRef(() => NzUploadComponent)) instance: NzUploadComponent;

    /**
     * 初始化上传组件包装器
     * @param uploadService 上传服务
     */
    constructor(@Optional() private uploadService: UploadService) {
    }

    /**
     * 内容加载完成操作
     */
    ngAfterContentInit() {
    }

    /**
     * 上传变更处理
     * @param info
     */
    handleChange(info: { file, fileList, event, type }) {
        if (!info || !this.uploadService)
            return;
        if (info.type === 'success') {
            let result = this.uploadService.toResult(info.file.response);
            this.model = [...(this.model || []), result];
            return;
        }
    }

    /**
     * 上传过滤器
     */
    filters: UploadFilter[] = [
        {
            name: 'type',
            fn: (files: UploadFile[]) => {
                if (!this.instance || !this.instance.nzFileType || this.instance.nzFileType.length === 0)
                    return files;
                const types = this.instance.nzFileType.split(',');
                let validFiles = files.filter(file => ~types.indexOf(file.type));
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