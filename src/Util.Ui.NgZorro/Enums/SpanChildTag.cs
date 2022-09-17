using System.ComponentModel;

namespace Util.Ui.NgZorro.Enums {
    /// <summary>
    /// Span子标签
    /// </summary>
    public enum SpanChildTag {
        /// <summary>
        /// &lt;mark&gt;&lt;/mark&gt;
        /// </summary>
        [Description( "mark" )]
        Mark,
        /// <summary>
        /// &lt;strong&gt;&lt;/strong&gt;
        /// </summary>
        [Description( "strong" )]
        Strong,
        /// <summary>
        /// &lt;code&gt;&lt;/code&gt;
        /// </summary>
        [Description( "code" )]
        Code,
        /// <summary>
        /// &lt;kbd&gt;&lt;/kbd&gt;
        /// </summary>
        [Description( "kbd" )]
        Keyboard,
        /// <summary>
        /// &lt;u&gt;&lt;/u&gt; ,下划线
        /// </summary>
        [Description( "u" )]
        Underline,
        /// <summary>
        /// &lt;del&gt;&lt;/del&gt; ,删除线
        /// </summary>
        [Description( "del" )]
        Delete
    }
}
