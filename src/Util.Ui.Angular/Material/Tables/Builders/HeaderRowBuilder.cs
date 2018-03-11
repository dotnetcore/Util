using Util.Ui.Builders;

namespace Util.Ui.Material.Tables.Builders {
    /// <summary>
    /// Material标头生成器
    /// </summary>
    public class HeaderRowBuilder : TagBuilder {
        /// <summary>
        /// 初始化标头生成器
        /// </summary>
        public HeaderRowBuilder() : base( "mat-header-row" ) {
        }

        /// <summary>
        /// 添加列集合
        /// </summary>
        /// <param name="columns">列集合</param>
        public void AddColumns( string columns ) {
            AddAttribute( "*matHeaderRowDef", GetColumns(columns) );
        }

        /// <summary>
        /// 获取列集合
        /// </summary>
        private string GetColumns( string columns ) {
            if ( string.IsNullOrWhiteSpace( columns ) )
                return null;
            return columns.StartsWith( "[" ) ? columns : $"[{columns}]";
        }
    }
}