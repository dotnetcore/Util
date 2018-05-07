import { TreeViewModel } from '../../../../util';

/**
 * 角色视图模型
 */
export class RoleViewModel extends TreeViewModel {
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
     * 备注
     */
    comment;
    /**
     * 版本号
     */
    version;
}