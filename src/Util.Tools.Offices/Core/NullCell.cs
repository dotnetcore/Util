namespace Util.Tools.Offices.Core {
    /// <summary>
    /// 空单元格
    /// </summary>
    public class NullCell : Cell {
        /// <summary>
        /// 初始化空单元格
        /// </summary>
        public NullCell()
            : base( "" ) {
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        public override bool IsNull() {
            return true;
        }
    }
}
