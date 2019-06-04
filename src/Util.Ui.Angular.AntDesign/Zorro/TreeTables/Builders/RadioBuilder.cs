using Util.Ui.Builders;

namespace Util.Ui.Zorro.TreeTables.Builders {
    /// <summary>
    /// NgZorro树形表格单选框生成器
    /// </summary>
    public class RadioBuilder : TagBuilder {
        /// <summary>
        /// 初始化NgZorro树形表格单选框生成器
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="column">列名</param>
        public RadioBuilder( string id,string column  ) : base( "label" ) {
            base.AddAttribute( "nz-radio" );
            base.AddAttribute( "*ngIf", $"{id}.isShowRadio(row)" );
            base.AddAttribute( "name", $"radio_{id}" );
            base.AddAttribute( "(click)", "$event.stopPropagation()" );
            base.AddAttribute( "[ngModel]", $"{id}.isChecked(row)" );
            base.AddAttribute( "(ngModelChange)", $"{id}.checkRowOnly(row)" );
            base.SetContent( $"{{{{{column}}}}}" );
        }
    }
}