using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;

namespace Util.Ui.NgZorro.Components.Tables.Builders.Contents {
    /// <summary>
    /// 表格单元格布尔内容
    /// </summary>
    public class TableColumnBoolContent : ITableColumnContent {
        /// <inheritdoc />
        public IHtmlContent GetDisplayContent( TableColumnBuilder builder ) {
            var column = builder.GetConfig().GetValue( UiConst.Column );
            if ( column.IsEmpty() )
                return null;
            var options = NgZorroOptionsService.GetOptions();
            var result = new StringBuilder();
            result.Append( "{{" );
            if( options.EnableI18n )
                result.Append( $"(row.{column}?'{I18nKeys.Yes}':'{I18nKeys.No}')|i18n" );
            else
                result.Append( $"row.{column}?'是':'否'" );
            result.Append( "}}" );
            return new StringHtmlContent( result.ToString() );
        }
    }
}