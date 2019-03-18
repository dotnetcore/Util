using System.Collections.Generic;
using Util.Ui.Configs;
using Util.Ui.Material.Menus.Datas;
using Util.Ui.TagHelpers;

namespace Util.Ui.Material.Buttons.Configs {
    /// <summary>
    /// 按钮配置
    /// </summary>
    public class ButtonConfig : Config {
        /// <summary>
        /// 初始化按钮配置
        /// </summary>
        public ButtonConfig() {
        }

        /// <summary>
        /// 初始化按钮配置
        /// </summary>
        /// <param name="context">上下文</param>
        public ButtonConfig( Context context ) : base( context ) {
        }

        /// <summary>
        /// 菜单数据列表
        /// </summary>
        public List<MenuData> Data { get; set; }

        /// <summary>
        /// 使用ButtonRender渲染器
        /// </summary>
        public bool UseButtonRender() {
            return Contains( MaterialConst.MenuId ) || Contains( MaterialConst.CloseDialog );
        }
    }
}