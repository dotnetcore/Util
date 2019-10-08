/**
 * 提示消息配置
 */
export class MessageConfig {
    /**
     * 清除
     */
    static clear = "清除";
    /**
     * 取消
     */
    static cancel = "取消";
    /**
     * 上传
     */
    static upload = "上传";
    /**
     * 选择文件
     */
    static chooseFile = "选择文件";
    /**
     * 重 置
     */
    static reset = "重 置";
    /**
     * 提 交
     */
    static submit = "提 交";
    /**
     * 确定
     */
    static ok = "确定";
    /**
     * 进度提示
     */
    static loading = "loading...";
    /**
     * 默认项文本
     */
    static defaultOptionText = "-- 请选择 --";
    /**
     * 必填项默认验证消息
     */
    static requiredMessage = "该项必须填写";
    /**
     * 该项必须勾选
     */
    static groupRequiredMessage = "该项必须勾选";
    /**
     * 上传必填项默认验证消息
     */
    static uploadRequiredMessage = "请选择文件";
    /**
     * 最小长度默认验证消息
     */
    static minLengthMessage = "输入内容的长度必须大于{0}位";
    /**
     * 最小值默认验证消息
     */
    static minMessage = "输入值必须大于{0}";
    /**
     * 最大值默认验证消息
     */
    static maxMessage = "输入值必须小于{0}";
    /**
     * 电子邮件默认验证消息
     */
    static emailMessage = "请输入有效的电子邮件";
    /**
     * 请勾选要操作的记录
     */
    static notSelected = "请选择要操作的记录";
    /**
     * 请选择待删除的记录
     */
    static deleteNotSelected = "请选择待删除的记录";
    /**
     * 操作成功
     */
    static successed = "操作成功";
    /**
     * 删除成功
     */
    static deleteSuccessed = "删除成功";
    /**
     * 您确定删除选中的记录吗?
     */
    static deleteConfirm = "您确定删除选中的记录吗?";
    /**
     * 您确定启用选中的记录吗?
     */
    static enableConfirm = "您确定启用选中的记录吗?";
    /**
     * 您确定禁用选中的记录吗?
     */
    static disableConfirm = "您确定禁用选中的记录吗?";
    /**
     * 存在未保存的修改，确定离开?
     */
    static saveGuardConfirm = "存在未保存的修改，确定离开此页面?";
    /**
     * 确定保存吗?
     */
    static saveConfirm = "确定要保存吗?";
    /**
     * 没有需要保存的记录
     */
    static noNeedSave = "没有需要保存的记录";
    /**
     * 文件类型过滤消息
     */
    static fileTypeFilter = "{0} 文件格式不正确";
    /**
     * 文件大小过滤消息
     */
    static fileSizeFilter = "{0} 文件过大，单个文件不能超过 {1} KB";
    /**
     * 文件数量过滤消息
     */
    static fileLimitFilter = "您选择的文件过多，单次上传文件最多不能超过 {0} 个";
}