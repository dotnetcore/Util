using System.Linq;

namespace Util.Data.Sql.Builders.Core {
    /// <summary>
    /// 拆分项
    /// </summary>
    public class SplitItem {
        /// <summary>
        /// 初始化拆分项
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="separator">拆分字符</param>
        public SplitItem( string value,string separator = " " ) {
            if ( string.IsNullOrEmpty( value ) )
                return;
            var list = value.Trim().Split( separator ).Where( item => item.IsEmpty() == false ).ToList();
            if( list.Count == 1 ) {
                Left = list[0];
                return;
            }
            if ( list.Count == 2 ) {
                Left = list[0];
                Right = list[1];
            }
        }

        /// <summary>
        /// 左拆分值
        /// </summary>
        public string Left { get; set; }

        /// <summary>
        /// 右拆分值
        /// </summary>
        public string Right { get; set; }
    }
}
