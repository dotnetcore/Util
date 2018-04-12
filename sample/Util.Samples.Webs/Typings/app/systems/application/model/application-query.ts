import { QueryParameter } from '../../../../util';

/**
 * 应用程序查询参数
 */
export class ApplicationQuery extends QueryParameter {
    /**
     * 应用程序编号
     */
    applicationId;
    /**
     * 应用程序编码
     */
    code;
    /**
     * 应用程序名称
     */
    name;
    /**
     * 备注
     */
    comment;
    /**
     * 启用
     */
    enabled;
    /**
     * 启用注册
     */
    registerEnabled;
    /**
     * 起始创建时间
     */
    beginCreationTime;
    /**
     * 结束创建时间
     */
    endCreationTime;
    /**
     * 创建人编号
     */
    creatorId;
    /**
     * 起始最后修改时间
     */
    beginLastModificationTime;
    /**
     * 结束最后修改时间
     */
    endLastModificationTime;
    /**
     * 最后修改人编号
     */
    lastModifierId;
}