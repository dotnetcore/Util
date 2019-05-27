//============== 文件信息=========================
//Copyright 2018 何镇汐
//Licensed under the MIT license
//================================================
/**
 * 文件信息
 */
export class FileInfo {
    /**
     * 标识
     */
    id: string;
    /**
     * 文件地址
     */
    url: string;
    /**
     * 文件名
     */
    fileName: string;
    /**
     * 扩展名
     */
    extension: string;
    /**
     * 文件类型
     */
    type: FileType;
}

/**
 * 文件类型
 */
export enum FileType {
    /**
     * 图片
     */
    Image = 1,
    /**
     * 其它
     */
    Other = 2
}