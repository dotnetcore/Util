using System;

namespace Util.Ui.Pages
{
    /// <summary>
    /// Html生成路径
    /// </summary>
    public class HtmlPathAttribute:Attribute
    {
        /// <summary>
        /// 生成路径，相对根路径，范例：/Typings/app/app.component.html
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 初始化Html生成路径
        /// </summary>
        /// <param name="path">生成路径</param>
        public HtmlPathAttribute(string path)
        {
            Path = path;
        }
    }
}
