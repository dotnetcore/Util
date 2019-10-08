using System.Collections.Generic;

namespace Util.Samples.Models.Home {
    /// <summary>
    /// 应用程序数据
    /// </summary>
    public class AppData {
        /// <summary>
        /// 初始化应用程序数据
        /// </summary>
        public AppData() {
            App = new AppInfo();
            User = new UserInfo();
            Menu = new List<MenuInfo>();
        }

        /// <summary>
        /// App信息
        /// </summary>
        public AppInfo App { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public UserInfo User { get; set; }
        /// <summary>
        /// 菜单信息
        /// </summary>
        public List<MenuInfo> Menu { get; set; }
    }
}
