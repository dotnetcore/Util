import { Injectable } from '@angular/core';
import { UploadFile } from 'ng-zorro-antd';
import { UploadService,StateCode } from '../../util';

/**
 * 上传服务 - 用于演示，根据业务修改
 */
@Injectable()
export class TestUploadService implements UploadService {
    /**
     * 从服务端上传响应中获取附件信息,每个上传文件调用一次,附件信息由服务端业务系统存储
     * @param response 服务端响应
     */
    getItem( response ) {
        if ( !response.code && !response.data )
            return response;
        if ( response.code !== StateCode.Ok )
            return null;
        return response.data;
    }

    /**
     * 将服务端返回的附件信息,转换为上传文件
     * @param item 附件信息
     */
    toUploadFile( item: UploadFileInfo ): UploadFile {
        return {
            uid: item.id,
            size: item.size,
            name: item.name,
            type: item.type,
            url: item.url
        };
    }
}

/**
 * 自定义上传文件信息，修改为业务特定类型
 */
export class UploadFileInfo {
    /**
     * 标识
     */
    id;
    /**
     * 文件名
     */
    name;
    /**
     * 文件大小
     */
    size;
    /**
     * 文件类型
     */
    type;
    /**
     * 文件路径
     */
    url;
}