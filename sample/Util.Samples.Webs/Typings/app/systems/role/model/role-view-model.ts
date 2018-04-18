import { TreeNode } from '../../../../util';

/**
 * 角色视图模型
 */
export class RoleViewModel extends TreeNode {
    /**
     * 角色编码
     */
    code;
    /**
     * 角色名称
     */
    name;
    /**
     * 标准化角色名称
     */
    normalizedName;
    /**
     * 角色类型
     */
    type;
    /**
     * 管理员
     */
    isAdmin;
    /**
     * 父编号
     */
    parentId;
    /**
     * 路径
     */
    path;
    /**
     * 级数
     */
    level;
    /**
     * 排序号
     */
    sortId;
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
     * 签名
     */
    sign;
    /**
     * 创建时间
     */
    creationTime;
    /**
     * 创建人编号
     */
    creatorId;
    /**
     * 最后修改时间
     */
    lastModificationTime;
    /**
     * 最后修改人编号
     */
    lastModifierId;
    /**
     * 是否删除
     */
    isDeleted;
    /**
     * 版本号
     */
    version;
}