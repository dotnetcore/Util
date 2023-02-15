using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgAlain.Components.PageHeaders.Builders {
    /// <summary>
    /// 页头标签生成器
    /// </summary>
    public class PageHeaderBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 初始化页头标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public PageHeaderBuilder( Config config ) : base( config, "page-header" ) {
            _config = config;
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        public PageHeaderBuilder Title() {
            SetTitle( _config.GetValue( UiConst.Title ) );
            AttributeIfNotEmpty( "[title]", _config.GetValue( AngularConst.BindTitle ) );
            SetCreateUpdateTitle();
            return this;
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        private void SetTitle( string value ) {
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                this.AttributeByI18n( "[title]", value );
                return;
            }
            AttributeIfNotEmpty( "title", value );
        }

        /// <summary>
        /// 设置创建修改标题
        /// </summary>
        private void SetCreateUpdateTitle() {
            var createTitle = _config.GetValue( UiConst.TitleCreate );
            var updateTitle = _config.GetValue( UiConst.TitleUpdate );
            if ( createTitle.IsEmpty() == false && updateTitle.IsEmpty() == false ) {
                var options = NgZorroOptionsService.GetOptions();
                if ( options.EnableI18n ) {
                    Attribute( "[title]", ( $"(isNew?'{createTitle}':'{updateTitle}')|i18n" ) );
                    return;
                }
                Attribute( "[title]", ( $"isNew?'{createTitle}':'{updateTitle}'" ) );
                return;
            }
            SetTitle( createTitle );
            SetTitle( updateTitle );
        }

        /// <summary>
        /// 配置自动设置标题
        /// </summary>
        public PageHeaderBuilder AutoTitle() {
            AttributeIfNotEmpty( "[autoTitle]", _config.GetBoolValue( UiConst.AutoTitle ) );
            AttributeIfNotEmpty( "[autoTitle]", _config.GetValue( AngularConst.BindAutoTitle ) );
            return this;
        }

        /// <summary>
        /// 配置同步标题
        /// </summary>
        public PageHeaderBuilder SyncTitle() {
            AttributeIfNotEmpty( "[syncTitle]", _config.GetBoolValue( UiConst.SyncTitle ) );
            AttributeIfNotEmpty( "[syncTitle]", _config.GetValue( AngularConst.BindSyncTitle ) );
            return this;
        }

        /// <summary>
        /// 配置首页文本
        /// </summary>
        public PageHeaderBuilder Home() {
            AttributeIfNotEmpty( "home", _config.GetValue( UiConst.Home ) );
            AttributeIfNotEmpty( "[home]", _config.GetValue( AngularConst.BindHome ) );
            return this;
        }

        /// <summary>
        /// 配置首页链接
        /// </summary>
        public PageHeaderBuilder HomeLink() {
            AttributeIfNotEmpty( "homeLink", _config.GetValue( UiConst.HomeLink ) );
            AttributeIfNotEmpty( "[homeLink]", _config.GetValue( AngularConst.BindHomeLink ) );
            return this;
        }

        /// <summary>
        /// 配置首页国际化
        /// </summary>
        public PageHeaderBuilder HomeI18n() {
            AttributeIfNotEmpty( "homeI18n", _config.GetValue( UiConst.HomeI18n ) );
            AttributeIfNotEmpty( "[homeI18n]", _config.GetValue( AngularConst.BindHomeI18n ) );
            return this;
        }

        /// <summary>
        /// 配置自动生成导航
        /// </summary>
        public PageHeaderBuilder AutoBreadcrumb() {
            AttributeIfNotEmpty( "[autoBreadcrumb]", _config.GetBoolValue( UiConst.AutoBreadcrumb ) );
            AttributeIfNotEmpty( "[autoBreadcrumb]", _config.GetValue( AngularConst.BindAutoBreadcrumb ) );
            return this;
        }

        /// <summary>
        /// 配置递归查找导航
        /// </summary>
        public PageHeaderBuilder RecursiveBreadcrumb() {
            AttributeIfNotEmpty( "[recursiveBreadcrumb]", _config.GetBoolValue( UiConst.RecursiveBreadcrumb ) );
            AttributeIfNotEmpty( "[recursiveBreadcrumb]", _config.GetValue( AngularConst.BindRecursiveBreadcrumb ) );
            return this;
        }

        /// <summary>
        /// 配置加载状态
        /// </summary>
        public PageHeaderBuilder Loading() {
            AttributeIfNotEmpty( "[loading]", _config.GetValue( UiConst.Loading ) );
            return this;
        }

        /// <summary>
        /// 配置是否定宽
        /// </summary>
        public PageHeaderBuilder Wide() {
            AttributeIfNotEmpty( "[wide]", _config.GetBoolValue( UiConst.Wide ) );
            AttributeIfNotEmpty( "[wide]", _config.GetValue( AngularConst.BindWide ) );
            return this;
        }

        /// <summary>
        /// 配置是否固定模式
        /// </summary>
        public PageHeaderBuilder Fixed() {
            AttributeIfNotEmpty( "[fixed]", _config.GetBoolValue( UiConst.Fixed ) );
            AttributeIfNotEmpty( "[fixed]", _config.GetValue( AngularConst.BindFixed ) );
            return this;
        }

        /// <summary>
        /// 配置固定偏移值
        /// </summary>
        public PageHeaderBuilder FixedOffsetTop() {
            AttributeIfNotEmpty( "[fixedOffsetTop]", _config.GetValue( UiConst.FixedOffsetTop ) );
            return this;
        }

        /// <summary>
        /// 配置自定义导航区域
        /// </summary>
        public PageHeaderBuilder Breadcrumb() {
            AttributeIfNotEmpty( "[breadcrumb]", _config.GetValue( UiConst.Breadcrumb ) );
            return this;
        }

        /// <summary>
        /// 配置自定义Logo区域
        /// </summary>
        public PageHeaderBuilder Logo() {
            AttributeIfNotEmpty( "[logo]", _config.GetValue( UiConst.Logo ) );
            return this;
        }

        /// <summary>
        /// 配置自定义操作区域
        /// </summary>
        public PageHeaderBuilder Action() {
            AttributeIfNotEmpty( "[action]", _config.GetValue( UiConst.Action ) );
            return this;
        }

        /// <summary>
        /// 配置自定义内容区域
        /// </summary>
        public PageHeaderBuilder Content() {
            AttributeIfNotEmpty( "[content]", _config.GetValue( UiConst.Content ) );
            return this;
        }

        /// <summary>
        /// 配置自定义额外信息区域
        /// </summary>
        public PageHeaderBuilder Extra() {
            AttributeIfNotEmpty( "[extra]", _config.GetValue( UiConst.Extra ) );
            return this;
        }

        /// <summary>
        /// 配置自定义标签区域
        /// </summary>
        public PageHeaderBuilder Tab() {
            AttributeIfNotEmpty( "[tab]", _config.GetValue( UiConst.Tab ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Title()
                .AutoTitle().SyncTitle()
                .Home().HomeLink().HomeI18n()
                .AutoBreadcrumb().RecursiveBreadcrumb()
                .Loading().Wide().Fixed().FixedOffsetTop()
                .Breadcrumb().Logo().Action().Content().Extra().Tab();
        }
    }
}