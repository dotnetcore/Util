using System;

namespace Util.Ui {
    /// <summary>
    /// 用于控制Razor Page生成Html的路径
    /// </summary>
    public class HtmlAttribute : Attribute {
        /// <summary>
        /// 生成路径，相对根路径，范例：/ClientApp/src/app/app.component.html
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 不生成该页面的html
        /// </summary>
        public bool Ignore { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="path">生成路径，相对根路径，范例：/ClientApp/src/app/app.component.html</param>
        public HtmlAttribute( string path = null ) {
            Path = path;
        }
    }
}
