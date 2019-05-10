using Util.Tools.Offices.Core;

namespace Util.Tools.Offices {
    /// <summary>
    /// 单元格样式
    /// </summary>
    public class CellStyle {
        /// <summary>
        /// 初始化单元格样式
        /// </summary>
        public CellStyle() {
            BorderColor = Color.Black;
            FontColor = Color.Black;
            FontSize = 12;
            IsWrap = true;
        }

        /// <summary>
        /// 水平对齐
        /// </summary>
        public HorizontalAlignment Alignment { get; set; }
        /// <summary>
        /// 垂直对齐
        /// </summary>
        public VerticalAlignment VerticalAlignment { get; set; }
        /// <summary>
        /// 背景色
        /// </summary>
        public Color BackgroundColor { get; set; }
        /// <summary>
        /// 填充模式
        /// </summary>
        public FillPattern FillPattern { get; set; }
        /// <summary>
        /// 边框色
        /// </summary>
        public Color BorderColor { get; set; }
        /// <summary>
        /// 字号
        /// </summary>
        public short FontSize { get; set; }
        /// <summary>
        /// 字体颜色
        /// </summary>
        public Color FontColor { get; set; }
        /// <summary>
        /// 字体加粗
        /// </summary>
        public short FontBoldWeight { get; set; }
        /// <summary>
        /// 内容是否自动换行
        /// </summary>
        public bool IsWrap { get; set; }

        /// <summary>
        /// 创建表头样式
        /// </summary>
        public static CellStyle Head() {
            return new CellStyle {
                Alignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                BackgroundColor = Color.LightGreen,
                FillPattern = FillPattern.SolidForeground,
                FontSize = 14,
                FontBoldWeight = 700
            };
        }

        /// <summary>
        /// 创建正文样式
        /// </summary>
        public static CellStyle Body() {
            return new CellStyle();
        }

        /// <summary>
        /// 创建页脚样式
        /// </summary>
        public static CellStyle Foot() {
            return new CellStyle {
                Alignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                BackgroundColor = Color.LightGreen,
                FillPattern = FillPattern.SolidForeground,
                FontSize = 14,
                FontBoldWeight = 700
            };
        }
    }
}
