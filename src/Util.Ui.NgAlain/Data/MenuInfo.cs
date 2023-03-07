using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgAlain.Data {
    /// <summary>
    /// 菜单信息
    /// </summary>
    public class MenuInfo {
        /// <summary>
        /// 初始化菜单信息
        /// </summary>
        public MenuInfo() {
            Children = new List<MenuInfo>();
            Group = true;
        }

        /// <summary>
        /// 标识
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 文本
        /// </summary>
        [Required]
        public string Text { get; set; }
        /// <summary>
        /// 多语言键
        /// </summary>
        public string I18n { get; set; }
        /// <summary>
        /// 是否显示分组名
        /// </summary>
        public bool Group { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 外部链接
        /// </summary>
        public string ExternalLink { get; set; }
        /// <summary>
        /// 链接目标,有效值: _blank,_self,_parent,_top
        /// </summary>
        public string Target { get; set; }
        /// <summary>
        /// 图标,只对一级菜单有效
        /// </summary>
        public MenuIconInfo Icon { get; set; }
        /// <summary>
        /// 徽标数,注意:group为true时无效
        /// </summary>
        public int? Badge { get; set; }
        /// <summary>
        /// 徽标是否显示小红点
        /// </summary>
        public bool BadgeDot { get; set; }
        /// <summary>
        /// 徽标状态
        /// </summary>
        public BadgeStatus BadgeStatus { get; set; }
        /// <summary>
        /// 是否打开菜单
        /// </summary>
        public bool Open { get; set; }
        /// <summary>
        /// 是否禁用菜单
        /// </summary>
        public bool Disabled { get; set; }
        /// <summary>
        /// 是否隐藏菜单
        /// </summary>
        public bool Hide { get; set; }
        /// <summary>
        /// 隐藏面包屑,不要在面包屑导航中显示
        /// </summary>
        public bool HideInBreadcrumb { get; set; }
        /// <summary>
        /// 访问控制,设置资源标识
        /// </summary>
        public string Acl { get; set; }
        /// <summary>
        /// 是否快捷菜单项
        /// </summary>
        public bool Shortcut { get; set; }
        /// <summary>
        /// 是否快捷菜单根节点
        /// </summary>
        public bool ShortcutRoot { get; set; }
        /// <summary>
        /// 是否允许路由复用
        /// </summary>
        public bool Reuse { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        public List<MenuInfo> Children { get; set; }
    }
}
