using Util.Ui.Builders;

namespace Util.Ui.Zorro.Tables.Builders {
    /// <summary>
    /// 行号列生成器
    /// </summary>
    public class LineNumberColumnBuilder : TagBuilder {
        /// <summary>
        /// 初始化行号列生成器
        /// </summary>
        public LineNumberColumnBuilder() : base( "td" ) {
            base.AppendContent( "{{row.lineNumber}}" );
        }
    }
}
