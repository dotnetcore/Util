using Util.Ui.Enums;

namespace Util.Ui.Material.Menus.Datas {
    /// <summary>
    /// 菜单项数据
    /// </summary>
    public class MenuItemData {
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
        /// 子菜单标识
        /// </summary>
        public string MenuId { get; set; }
    }
}