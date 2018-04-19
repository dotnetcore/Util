import { TreeQueryParameter } from '../../../../util';

/**
 * 角色查询参数
 */
export class RoleQuery extends TreeQueryParameter {
    /**
     * 角色编号
     */
    roleId;
    /**
     * 角色编码
     */
    code;
    /**
     * 角色名称
     */
    name;
    /**
     * 角色类型
     */
    type;
    /**
     * 管理员
     */
    isAdmin;
    /**
     * 级数
     */
    level;
    /**
     * 启用
     */
    enabled;
    /**
     * 备注
     */
    comment;
    /**
     * 拼音简码
     */
    pinYin;
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
}