using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Tables.Builders {
    /// <summary>
    /// 表格单元格标签生成器
    /// </summary>
    public class TableColumnBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表格单元格标签生成器
        /// </summary>
        public TableColumnBuilder( Config config ) : base( "td" ) {
            _config = config;
        }

        /// <summary>
        /// 获取表格共享配置
        /// </summary>
        protected TableShareConfig GetTableShareConfig() {
            return _config.GetValueFromItems<TableShareConfig>() ?? new TableShareConfig();
        }

        /// <summary>
        /// 配置是否显示复选框
        /// </summary>
        public TableColumnBuilder ShowCheckbox() {
            AttributeIfNotEmpty( "[nzShowCheckbox]", _config.GetBoolValue( UiConst.ShowCheckbox ) );
            AttributeIfNotEmpty( "[nzShowCheckbox]", _config.GetValue( AngularConst.BindShowCheckbox ) );
            return this;
        }

        /// <summary>
        /// 配置是否禁用复选框
        /// </summary>
        public TableColumnBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置复选框是否中间状态
        /// </summary>
        public TableColumnBuilder Indeterminate() {
            AttributeIfNotEmpty( "[nzIndeterminate]", _config.GetValue( UiConst.Indeterminate ) );
            return this;
        }

        /// <summary>
        /// 配置是否选中复选框
        /// </summary>
        public TableColumnBuilder Checked() {
            AttributeIfNotEmpty( "[nzChecked]", _config.GetBoolValue( UiConst.Checked ) );
            AttributeIfNotEmpty( "[nzChecked]", _config.GetValue( AngularConst.BindChecked ) );
            AttributeIfNotEmpty( "[(nzChecked)]", _config.GetValue( AngularConst.BindonChecked ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示展开按钮
        /// </summary>
        public TableColumnBuilder ShowExpand() {
            AttributeIfNotEmpty( "[nzShowExpand]", _config.GetBoolValue( UiConst.ShowExpand ) );
            AttributeIfNotEmpty( "[nzShowExpand]", _config.GetValue( AngularConst.BindShowExpand ) );
            return this;
        }

        /// <summary>
        /// 配置是否已展开
        /// </summary>
        public TableColumnBuilder Expand() {
            AttributeIfNotEmpty( "[nzExpand]", _config.GetBoolValue( UiConst.Expand ) );
            AttributeIfNotEmpty( "[nzExpand]", _config.GetValue( AngularConst.BindExpand ) );
            AttributeIfNotEmpty( "[(nzExpand)]", _config.GetValue( AngularConst.BindonExpand ) );
            return this;
        }

        /// <summary>
        /// 配置左侧距离
        /// </summary>
        public TableColumnBuilder Left() {
            AttributeIfNotEmpty( "[nzLeft]", _config.GetBoolValue( UiConst.Left ) );
            AttributeIfNotEmpty( "[nzLeft]", _config.GetValue( AngularConst.BindLeft ) );
            return this;
        }

        /// <summary>
        /// 配置右侧距离
        /// </summary>
        public TableColumnBuilder Right() {
            AttributeIfNotEmpty( "[nzRight]", _config.GetBoolValue( UiConst.Right ) );
            AttributeIfNotEmpty( "[nzRight]", _config.GetValue( AngularConst.BindRight ) );
            return this;
        }

        /// <summary>
        /// 配置对齐方式
        /// </summary>
        public TableColumnBuilder Align() {
            AttributeIfNotEmpty( "nzAlign", _config.GetValue<TableHeadColumnAlign?>( UiConst.Align )?.Description() );
            AttributeIfNotEmpty( "[nzAlign]", _config.GetValue( AngularConst.BindAlign ) );
            return this;
        }

        /// <summary>
        /// 配置是否折行显示
        /// </summary>
        public TableColumnBuilder BreakWord() {
            AttributeIfNotEmpty( "[nzBreakWord]", _config.GetBoolValue( UiConst.BreakWord ) );
            AttributeIfNotEmpty( "[nzBreakWord]", _config.GetValue( AngularConst.BindBreakWord ) );
            return this;
        }

        /// <summary>
        /// 配置自动省略
        /// </summary>
        public TableColumnBuilder Ellipsis() {
            AttributeIfNotEmpty( "[nzEllipsis]", _config.GetBoolValue( UiConst.Ellipsis ) );
            AttributeIfNotEmpty( "[nzEllipsis]", _config.GetValue( AngularConst.BindEllipsis ) );
            return this;
        }

        /// <summary>
        /// 配置缩进宽度
        /// </summary>
        public TableColumnBuilder IndentSize() {
            AttributeIfNotEmpty( "nzIndentSize", _config.GetValue( UiConst.IndentSize ) );
            AttributeIfNotEmpty( "[nzIndentSize]", _config.GetValue( AngularConst.BindIndentSize ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public TableColumnBuilder Events() {
            AttributeIfNotEmpty( "(nzCheckedChange)", _config.GetValue( UiConst.OnCheckedChange ) );
            AttributeIfNotEmpty( "(nzExpandChange)", _config.GetValue( UiConst.OnExpandChange ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            ShowCheckbox().Disabled().Indeterminate().Checked()
                .ShowExpand().Expand()
                .Left().Right().Align().BreakWord().Ellipsis()
                .IndentSize()
                .Events();
        }
    }
}