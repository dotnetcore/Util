using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Transfers.Builders {
    /// <summary>
    /// 穿梭框标签生成器
    /// </summary>
    public class TransferBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化穿梭框标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TransferBuilder( Config config ) : base( config, "nz-transfer" ) {
            _config = config;
        }

        /// <summary>
        /// 配置数据源
        /// </summary>
        public TransferBuilder Datasource() {
            AttributeIfNotEmpty( "[nzDataSource]", _config.GetValue( UiConst.Datasource ) );
            return this;
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        public TransferBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置标题集合
        /// </summary>
        public TransferBuilder Titles() {
            AttributeIfNotEmpty( "[nzTitles]", _config.GetValue( UiConst.Titles ) );
            return this;
        }

        /// <summary>
        /// 配置操作按钮标题集合
        /// </summary>
        public TransferBuilder Operations() {
            AttributeIfNotEmpty( "[nzOperations]", _config.GetValue( UiConst.Operations ) );
            return this;
        }

        /// <summary>
        /// 配置样式
        /// </summary>
        public TransferBuilder ListStyle() {
            AttributeIfNotEmpty( "[nzListStyle]", _config.GetValue( UiConst.ListStyle ) );
            return this;
        }

        /// <summary>
        /// 配置单数项目单位
        /// </summary>
        public TransferBuilder ItemUnit() {
            AttributeIfNotEmpty( "nzItemUnit", _config.GetValue( UiConst.ItemUnit ) );
            AttributeIfNotEmpty( "[nzItemUnit]", _config.GetValue( AngularConst.BindItemUnit ) );
            return this;
        }

        /// <summary>
        /// 配置复数项目单位
        /// </summary>
        public TransferBuilder ItemsUnit() {
            AttributeIfNotEmpty( "nzItemsUnit", _config.GetValue( UiConst.ItemsUnit ) );
            AttributeIfNotEmpty( "[nzItemsUnit]", _config.GetValue( AngularConst.BindItemsUnit ) );
            return this;
        }

        /// <summary>
        /// 配置渲染列表
        /// </summary>
        public TransferBuilder RenderList() {
            AttributeIfNotEmpty( "[nzRenderList]", _config.GetValue( UiConst.RenderList ) );
            return this;
        }

        /// <summary>
        /// 配置行渲染模板
        /// </summary>
        public TransferBuilder Render() {
            AttributeIfNotEmpty( "[nzRender]", _config.GetValue( UiConst.Render ) );
            return this;
        }

        /// <summary>
        /// 配置底部渲染模板
        /// </summary>
        public TransferBuilder Footer() {
            AttributeIfNotEmpty( "[nzFooter]", _config.GetValue( UiConst.Footer ) );
            return this;
        }

        /// <summary>
        /// 配置显示搜索
        /// </summary>
        public TransferBuilder ShowSearch() {
            AttributeIfNotEmpty( "[nzShowSearch]", _config.GetBoolValue( UiConst.ShowSearch ) );
            AttributeIfNotEmpty( "[nzShowSearch]", _config.GetValue( AngularConst.BindShowSearch ) );
            return this;
        }

        /// <summary>
        /// 配置过滤项函数
        /// </summary>
        public TransferBuilder FilterOption() {
            AttributeIfNotEmpty( "[nzFilterOption]", _config.GetValue( UiConst.FilterOption ) );
            return this;
        }

        /// <summary>
        /// 配置搜索框占位提示
        /// </summary>
        public TransferBuilder SearchPlaceholder() {
            AttributeIfNotEmpty( "nzSearchPlaceholder", _config.GetValue( UiConst.SearchPlaceholder ) );
            AttributeIfNotEmpty( "[nzSearchPlaceholder]", _config.GetValue( AngularConst.BindSearchPlaceholder ) );
            return this;
        }

        /// <summary>
        /// 配置空列表默认内容
        /// </summary>
        public TransferBuilder NotFoundContent() {
            AttributeIfNotEmpty( "nzNotFoundContent", _config.GetValue( UiConst.NotFoundContent ) );
            AttributeIfNotEmpty( "[nzNotFoundContent]", _config.GetValue( AngularConst.BindNotFoundContent ) );
            return this;
        }

        /// <summary>
        /// 配置可移动项函数
        /// </summary>
        public TransferBuilder CanMove() {
            AttributeIfNotEmpty( "[nzCanMove]", _config.GetValue( UiConst.CanMove ) );
            return this;
        }

        /// <summary>
        /// 配置选中项键列表
        /// </summary>
        public TransferBuilder SelectedKeys() {
            AttributeIfNotEmpty( "[nzSelectedKeys]", _config.GetValue( UiConst.SelectedKeys ) );
            return this;
        }

        /// <summary>
        /// 配置目标项键列表
        /// </summary>
        public TransferBuilder TargetKeys() {
            AttributeIfNotEmpty( "[nzTargetKeys]", _config.GetValue( UiConst.TargetKeys ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public TransferBuilder Events() {
            AttributeIfNotEmpty( "(nzChange)", _config.GetValue( UiConst.OnChange ) );
            AttributeIfNotEmpty( "(nzSearchChange)", _config.GetValue( UiConst.OnSearchChange ) );
            AttributeIfNotEmpty( "(nzSelectChange)", _config.GetValue( UiConst.OnSelectChange ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase( _config );
            Datasource().Disabled().Titles().Operations()
                .ListStyle().ItemUnit().ItemsUnit()
                .RenderList().Render().Footer()
                .ShowSearch().FilterOption().SearchPlaceholder()
                .NotFoundContent().CanMove().SelectedKeys().TargetKeys()
                .Events();
        }
    }
}