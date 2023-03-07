using Util.Ui.NgAlain.Enums;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgAlain.Data {
    /// <summary>
    /// 菜单图标信息
    /// </summary>
    public class MenuIconInfo {
        /// <summary>
        /// 初始化菜单图标信息
        /// </summary>
        public MenuIconInfo() {
            Type = MenuIconType.Icon;
            Theme = IconTheme.Outline;
        }

        /// <summary>
        /// 图标类型
        /// </summary>
        public MenuIconType Type { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 图标主题风格
        /// </summary>
        public IconTheme Theme { get; set; }

        /// <summary>
        /// 是否旋转
        /// </summary>
        public string Spin { get; set; }

        /// <summary>
        /// 双色图标的主要颜色
        /// </summary>
        public string TwoToneColor { get; set; }

        /// <summary>
        /// 指定来自 IconFont 的图标类型
        /// </summary>
        public string Iconfont { get; set; }

        /// <summary>
        /// 图标旋转角度
        /// </summary>
        public double? Rotate { get; set; }
    }
}
