using System.Collections.Generic;
using Newtonsoft.Json;

namespace Util.Samples.Models.Home {
    /// <summary>
    /// 菜单信息
    /// </summary>
    public class MenuInfo {
        /// <summary>
        /// 初始化菜单信息
        /// </summary>
        public MenuInfo() {
            Children = new List<MenuInfo>();
        }

        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 国际化
        /// </summary>
        [JsonProperty( "i18n" )]
        public string I18N { get; set; }
        /// <summary>
        /// 组
        /// </summary>
        public bool Group { get; set; }
        /// <summary>
        /// 不要在面包屑导航中显示
        /// </summary>
        public bool HideInBreadcrumb { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>
        public List<MenuInfo> Children { get; set; }
    }
}
