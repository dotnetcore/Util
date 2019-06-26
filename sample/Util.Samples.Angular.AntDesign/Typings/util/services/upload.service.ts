//============== 上传服务 =======================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================
import { UploadFile } from 'ng-zorro-antd';
import { util } from "../index";

/**
 * 上传服务
 */
export abstract class UploadService {
    /**
     * 解析服务端响应，获取附件信息,附件信息由服务端业务系统存储
     * @param response 服务端响应
     */
    abstract resolve( response );

    /**
     * 将附件转换为上传文件
     * @param item 附件
     */
    abstract toFile( item ): UploadFile;

    /**
     * 从模型对象中删除项
     * @param model 模型对象，即附件数组
     * @param file 移除的文件
     */
    removeFromModel( model: any[], file: UploadFile ) {
        util.helper.remove( model, t => t.id === file.uid );
    }

    /**
     * 从文件列表中删除项
     * @param fileList 文件列表
     * @param file 移除的文件
     */
    removeFromFileList( fileList: UploadFile[], file: UploadFile ) {
        util.helper.remove( fileList, t => t.uid === file.uid );
    }
}