using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Lists.Builders {
    /// <summary>
    /// 列表标签生成器
    /// </summary>
    public class ListBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化列表标签生成器
        /// </summary>
        public ListBuilder( Config config ) : base( config,"nz-list" ) {
            _config = config;
        }

        /// <summary>
        /// 配置是否显示边框
        /// </summary>
        public ListBuilder Bordered() {
            AttributeIfNotEmpty( "[nzBordered]", _config.GetBoolValue( UiConst.Bordered ) );
            AttributeIfNotEmpty( "[nzBordered]", _config.GetValue( AngularConst.BindBordered ) );
            return this;
        }

        /// <summary>
        /// 配置列表底部
        /// </summary>
        public ListBuilder Footer() {
            AttributeIfNotEmpty( "nzFooter", _config.GetValue( UiConst.Footer ) );
            AttributeIfNotEmpty( "[nzFooter]", _config.GetValue( AngularConst.BindFooter ) );
            return this;
        }

        /// <summary>
        /// 配置列表头部
        /// </summary>
        public ListBuilder Header() {
            AttributeIfNotEmpty( "nzHeader", _config.GetValue( UiConst.Header ) );
            AttributeIfNotEmpty( "[nzHeader]", _config.GetValue( AngularConst.BindHeader ) );
            return this;
        }

        /// <summary>
        /// 配置列表项布局方式
        /// </summary>
        public ListBuilder ItemLayout() {
            AttributeIfNotEmpty( "nzItemLayout", _config.GetValue<ListItemLayout?>( UiConst.ItemLayout )?.Description() );
            AttributeIfNotEmpty( "[nzItemLayout]", _config.GetValue( AngularConst.BindItemLayout ) );
            return this;
        }

        /// <summary>
        /// 配置是否加载状态
        /// </summary>
        public ListBuilder Loading() {
            AttributeIfNotEmpty( "[nzLoading]", _config.GetValue( UiConst.Loading ) );
            return this;
        }

        /// <summary>
        /// 配置列表大小
        /// </summary>
        public ListBuilder Size() {
            AttributeIfNotEmpty( "nzSize", _config.GetValue<ListSize?>( UiConst.Size )?.Description() );
            AttributeIfNotEmpty( "[nzSize]", _config.GetValue( AngularConst.BindSize ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示分割线
        /// </summary>
        public ListBuilder Split() {
            AttributeIfNotEmpty( "[nzSplit]", _config.GetBoolValue( UiConst.Split ) );
            AttributeIfNotEmpty( "[nzSplit]", _config.GetValue( AngularConst.BindSplit ) );
            return this;
        }

        /// <summary>
        /// 配置栅格
        /// </summary>
        public ListBuilder Grid() {
            if( _config.GetValue<bool?>( UiConst.Grid ) == true )
                Attribute( "nzGrid" );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Bordered().Footer().Header().ItemLayout().Loading().Size().Split().Grid();
        }
    }
}