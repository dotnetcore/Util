using System.Collections.Generic;
using System.Linq;
using Util.Helpers;
using Util.Ui.Material.Enums;

namespace Util.Ui.Material.Menus.Datas {
    /// <summary>
    /// 菜单节点集合
    /// </summary>
    public class MenuNodeCollection {
        /// <summary>
        /// 初始化菜单数据
        /// </summary>
        public MenuNodeCollection() {
            Nodes = new List<MenuNode>();
            RootId = $"m_{Id.Guid()}";
        }

        /// <summary>
        /// 菜单节点列表
        /// </summary>
        public List<MenuNode> Nodes { get; set; }
        /// <summary>
        /// 根节点标识
        /// </summary>
        public string RootId { get; set; }
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

        /// <summary>
        /// 转换为菜单数据列表
        /// </summary>
        public List<MenuData> ToMenuDatas() {
            var result = GetMenuDatas();
            InitRootMenu( result );
            return result;
        }

        /// <summary>
        /// 获取菜单数据列表
        /// </summary>
        private List<MenuData> GetMenuDatas() {
            var groupNodes = from node in Nodes
                group node by node.ParentId;
            return groupNodes.Select( t => new MenuData {
                Id = GetMenuId( t.Key ),
                Items = t.Select( node => node.ToMenuItemData( Nodes ) ).ToList()
            } ).ToList();
        }

        /// <summary>
        /// 获取菜单标识
        /// </summary>
        private string GetMenuId( string parentId ) {
            if ( string.IsNullOrWhiteSpace( parentId ) )
                return RootId;
            return MenuNode.GetMenuId( parentId );
        }

        /// <summary>
        /// 初始化根菜单
        /// </summary>
        private void InitRootMenu( List<MenuData> datas ) {
            var data = datas.Find( t => t.Id == RootId );
            data.XPosition = XPosition;
            data.YPosition = YPosition;
            data.Overlap = Overlap;
        }
    }
}
