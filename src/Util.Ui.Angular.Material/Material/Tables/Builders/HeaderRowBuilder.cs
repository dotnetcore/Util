using Util.Ui.Builders;

namespace Util.Ui.Material.Tables.Builders {
    /// <summary>
    /// Material表头生成器
    /// </summary>
    public class HeaderRowBuilder : TagBuilder {
        /// <summary>
        /// 初始化表头生成器
        /// </summary>
        public HeaderRowBuilder() : base( "mat-header-row" ) {
        }

        /// <summary>
        /// 添加列集合
        /// </summary>
        /// <param name="columns">列集合</param>
        /// <param name="sticky">冻结表头</param>
        public void AddColumns( string columns, bool? sticky ) {
            if ( sticky == null )
                sticky = true;
            columns = GetColumns( columns );
            if( string.IsNullOrWhiteSpace( columns ) )
                return;
            AddAttribute( "*matHeaderRowDef", sticky.SafeValue() ? $"{columns};sticky:true" : columns );
        }

        /// <summary>
        /// 获取列集合
        /// </summary>
        private string GetColumns( string columns ) {
            if( string.IsNullOrWhiteSpace( columns ) )
                return null;
            return columns.StartsWith( "[" ) ? columns : $"[{columns}]";
        }
    }
}