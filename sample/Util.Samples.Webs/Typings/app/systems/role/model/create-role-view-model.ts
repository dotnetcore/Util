import { ViewModel } from '../../../../util';

/**
 * 创建角色视图模型
 */
export class CreateRoleViewModel extends ViewModel {
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
     * 父编号
     */
    parentId;
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
}