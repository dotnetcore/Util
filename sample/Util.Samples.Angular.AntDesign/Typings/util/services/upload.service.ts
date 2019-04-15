//============== 上传服务 =======================
//Copyright 2019 何镇汐
//Licensed under the MIT license
//================================================

/**
 * 上传服务
 */
export abstract class UploadService {
    /**
     * 上传成功,将服务端返回消息转换为结果
     * @param response 服务端响应
     */
    abstract toResult(response);
}