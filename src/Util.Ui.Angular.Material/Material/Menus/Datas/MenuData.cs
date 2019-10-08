using System.Collections.Generic;
using Util.Ui.Material.Enums;

namespace Util.Ui.Material.Menus.Datas {
    /// <summary>
    /// 菜单数据
    /// </summary>
    public class MenuData {
        /// <summary>
        /// 初始化菜单数据
        /// </summary>
        public MenuData() {
            Items = new List<MenuItemData>();
        }

        /// <summary>
        /// 菜单项列表
        /// </summary>
        public List<MenuItemData> Items { get; set; }
        /// <summary>
        /// 标识
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// X轴位置
        /// </summary>
        public XPosition? XPosition { get; set; }
        /// <summary>
        /// Y轴位置
        /// </summary>
        public YPosition? YPosition { get; set; }
        /// <summary>
        /// 弹出菜单是否与触发按钮重叠
        /// </summary>
        public bool? Overlap { get; set; }
    }
}
