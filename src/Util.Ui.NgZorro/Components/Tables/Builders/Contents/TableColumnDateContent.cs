using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Util.Ui.NgZorro.Components.Tables.Builders.Contents; 

/// <summary>
/// 表格单元格日期内容
/// </summary>
public class TableColumnDateContent : ITableColumnContent {
    /// <inheritdoc />
    public IHtmlContent GetDisplayContent( TableColumnBuilder builder ) {
        var config = builder.GetConfig();
        var column = config.GetValue( UiConst.Column );
        if( column.IsEmpty() )
            return null;
        var result = GetResult( config,column );
        return new StringHtmlContent( result );
    }

    /// <summary>
    /// 获取结果
    /// </summary>
    private string GetResult( Config config, string column ) {
        var result = new StringBuilder();
        result.Append( "{{" );
        result.Append( $"row.{column}|date:'{GetFormat( config )}'" );
        result.Append( "}}" );
        return result.ToString();
    }

    /// <summary>
    /// 获取日期格式
    /// </summary>
    private string GetFormat( Config config ) {
        var format = config.GetValue( UiConst.DateFormat );
        if( format.IsEmpty() == false )
            return format;
        var showDateOnly = config.GetValue<bool>( UiConst.ShowDateOnly );
        if( showDateOnly )
            return "yyyy-MM-dd";
        return "yyyy-MM-dd HH:mm";
    }
}