using System.Collections.Generic;
using Util.Ui.Enums;

namespace Util.Ui.Material.Menus.Datas {
    /// <summary>
    /// 菜单节点
    /// </summary>
    public class MenuNode {
        /// <summary>
        /// 标识
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 父标识
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// Material图标
        /// </summary>
        public MaterialIcon? MaterialIcon { get; set; }
        /// <summary>
        /// Font Awesome图标
        /// </summary>
        public FontAwesomeIcon? FontAwesomeIcon { get; set; }
        /// <summary>
        /// 禁用
        /// </summary>
        public string Disabled { get; set; }
        /// <summary>
        /// 路由链接地址
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 单击事件处理函数,范例：handle()
        /// </summary>
        public string OnClick { get; set; }

        /// <summary>
        /// 转换为菜单项数据
        /// </summary>
        /// <param name="nodes">菜单节点列表</param>
        public MenuItemData ToMenuItemData( List<MenuNode> nodes ) {
            return new MenuItemData {
                Label = Label,
                MaterialIcon = MaterialIcon,
                FontAwesomeIcon = FontAwesomeIcon,
                Disabled = Disabled,
                Link = Link,
                OnClick = OnClick,
                MenuId = nodes.Exists( t => t.ParentId == Id && string.IsNullOrWhiteSpace( t.ParentId ) == false ) ? GetMenuId( Id ) : string.Empty
            };
        }

        /// <summary>
        /// 获取菜单标识
        /// </summary>
        /// <param name="id">标识</param>
        public static string GetMenuId( string id ) {
            return $"m_{id}";
        }
    }
}