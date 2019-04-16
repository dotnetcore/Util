//============== 上传服务 =======================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { UploadFile } from 'ng-zorro-antd';

/**
 * 上传服务
 */
export abstract class UploadService {
    /**
     * 从服务端上传响应中获取附件信息,每个上传文件调用一次,附件信息由服务端业务系统存储
     * @param response 服务端响应
     */
    abstract getItem(response);
    /**
     * 将服务端返回的附件信息,转换为上传文件
     * @param item 附件信息
     */
    abstract toUploadFile(item): UploadFile;
}