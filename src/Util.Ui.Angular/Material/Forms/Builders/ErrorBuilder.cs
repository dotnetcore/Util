using Microsoft.AspNetCore.Html;
using TagBuilder = Util.Ui.Builders.TagBuilder;

namespace Util.Ui.Material.Forms.Builders {
    /// <summary>
    /// 错误消息生成器
    /// </summary>
    public class ErrorBuilder : TagBuilder {
        /// <summary>
        /// 初始化错误消息生成器
        /// </summary>
        /// <param name="id">引用Id</param>
        /// <param name="type">验证类型</param>
        /// <param name="message">错误消息</param>
        public ErrorBuilder( string id, string type, string message ) : base( "mat-error" ) {
            AddAttribute( "*ngIf", $"{id}?.hasError( '{type}' )" );
            SetContent( message );
        }
    }
}