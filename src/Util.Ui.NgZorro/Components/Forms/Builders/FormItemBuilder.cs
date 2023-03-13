using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Util.Ui.NgZorro.Components.Tables.Configs;

namespace Util.Ui.NgZorro.Components.Forms.Builders {
    /// <summary>
    /// 表单项标签生成器
    /// </summary>
    public class FormItemBuilder : RowBuilderBase<FormItemBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表单项共享配置
        /// </summary>
        private readonly FormItemShareConfig _shareConfig;

        /// <summary>
        /// 初始化表单项标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public FormItemBuilder( Config config ) : base( config, "nz-form-item" ) {
            _config = config;
            _shareConfig = GetFormItemShareConfig();
        }

        /// <summary>
        /// 获取表单项共享配置
        /// </summary>
        private FormItemShareConfig GetFormItemShareConfig() {
            return _config.GetValueFromItems<FormItemShareConfig>() ?? new FormItemShareConfig();
        }

        /// <summary>
        /// 配置对齐
        /// </summary>
        public override FormItemBuilder Align() {
            Align( _shareConfig.Align );
            BindAlign( _shareConfig.BindAlign );
            return base.Align();
        }

        /// <summary>
        /// 配置间隔
        /// </summary>
        public override FormItemBuilder Gutter() {
            Gutter( _shareConfig.Gutter );
            return base.Gutter();
        }

        /// <summary>
        /// 配置水平排列方式
        /// </summary>
        public override FormItemBuilder Justify() {
            Justify( _shareConfig.Justify );
            BindJustify( _shareConfig.BindJustify );
            return base.Justify();
        }

        /// <summary>
        /// ngIf
        /// </summary>
        public FormItemBuilder AngularIf() {
            if ( _shareConfig.NgIf.IsEmpty() == false )
                this.NgIf( _shareConfig.NgIf );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            AngularIf()
                .ConfigRow().TableEdit();
        }

        /// <summary>
        /// 配置表格编辑
        /// </summary>
        private void TableEdit() {
            var config = GetTableColumnShareConfig();
            if ( config == null )
                return;
            Class( "mb0" );
        }

        /// <summary>
        /// 获取表格列共享配置
        /// </summary>
        public TableColumnShareConfig GetTableColumnShareConfig() {
            return _config.GetValueFromItems<TableColumnShareConfig>();
        }
    }
}
