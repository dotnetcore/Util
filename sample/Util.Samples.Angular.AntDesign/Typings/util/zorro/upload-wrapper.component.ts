//============== NgZorro上传组件包装器===================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//=======================================================
import { Component, Input, ContentChild, forwardRef, Optional, Output, EventEmitter } from '@angular/core';
import { NzUploadComponent, UploadFile, UploadFilter } from 'ng-zorro-antd';
import { MessageConfig as config } from '../config/message-config';
import { UploadService } from "../services/upload.service";
import { Util as util } from '../util';

/**
 * NgZorro上传组件包装器
 */
@Component( {
    selector: 'nz-upload-wrapper',
    template: `
        <ng-content></ng-content>
    `,
    styles: [`
    `]
} )
export class Upload {
    /**
     * 上传文件列表
     */
    files: UploadFile[];
    /**
     * 延迟
     */
    timeout;
    /**
     * 模型数据
     */
    data: any[];
    /**
     * 模型
     */
    @Input()
    get model(): any[] {
        return this.data;
    }
    set model( value ) {
        if ( !value )
            return;
        this.data = value;
        if ( this.timeout )
            clearTimeout( this.timeout );
        this.timeout = setTimeout( () => {
            this.files = this.data.map( item => this.uploadService.toUploadFile( item ) );
        } , 500 );
    }
    /**
     * 模型变更事件
     */
    @Output() modelChange = new EventEmitter<any>();
    /**
     * 上传组件实例
     */
    @ContentChild( forwardRef( () => NzUploadComponent ) ) instance: NzUploadComponent;

    /**
     * 初始化上传组件包装器
     * @param uploadService 上传服务
     */
    constructor( @Optional() private uploadService: UploadService ) {
    }

    /**
     * 上传变更处理
     * @param data 上传参数
     */
    handleChange( data: { file, fileList, event, type } ) {
        if ( !data || !data.file || !data.file.response || !this.uploadService )
            return;
        let item = this.uploadService.getItem( data.file.response );
        if ( !item )
            return;
        if ( data.type === 'success' )
            this.model = [...( this.model || [] ), item];
        if ( data.type === 'removed' )
            util.helper.remove( this.model, t => t === item );
        this.modelChange.emit( this.model );
    }

    /**
     * 上传过滤器
     */
    filters: UploadFilter[] = [
        {
            name: 'type',
            fn: ( files: UploadFile[] ) => {
                if ( !this.instance || !this.instance.nzFileType || this.instance.nzFileType.length === 0 )
                    return files;
                const types = this.instance.nzFileType.split( ',' );
                let validFiles = files.filter( file => !file.type || ~types.indexOf( file.type ) );
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
}