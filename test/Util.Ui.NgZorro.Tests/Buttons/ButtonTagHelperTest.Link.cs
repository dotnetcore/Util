using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Util.Ui.NgZorro.Enums;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Buttons {
    /// <summary>
    /// 按钮测试 - 链接相关
    /// </summary>
    public partial class ButtonTagHelperTest {
        /// <summary>
        /// 测试链接按钮
        /// </summary>
        [Fact]
        public void TestLinkType() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link );
            var result = new StringBuilder();
            result.Append( "<a nz-button=\"\" nzType=\"link\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试链接地址
        /// </summary>
        [Fact]
        public void TestHref() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link )
                .SetContextAttribute( UiConst.Href, "a" );
            var result = new StringBuilder();
            result.Append( "<a href=\"a\" nz-button=\"\" nzType=\"link\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试链接地址
        /// </summary>
        [Fact]
        public void TestBindHref() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link )
                .SetContextAttribute( AngularConst.BindHref, "a" );
            var result = new StringBuilder();
            result.Append( "<a nz-button=\"\" nzType=\"link\" [href]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试链接打开目标
        /// </summary>
        [Fact]
        public void TestTarget() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link )
                .SetContextAttribute( UiConst.Target, ATarget.Parent );
            var result = new StringBuilder();
            result.Append( "<a nz-button=\"\" nzType=\"link\" target=\"_parent\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试链接打开目标
        /// </summary>
        [Fact]
        public void TestBindTarget() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link )
                .SetContextAttribute( AngularConst.BindTarget, "a" );
            var result = new StringBuilder();
            result.Append( "<a nz-button=\"\" nzType=\"link\" [target]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试链接关系
        /// </summary>
        [Fact]
        public void TestRel() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link )
                .SetContextAttribute( UiConst.Rel, "a" );
            var result = new StringBuilder();
            result.Append( "<a nz-button=\"\" nzType=\"link\" rel=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试链接关系
        /// </summary>
        [Fact]
        public void TestBindRel() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link )
                .SetContextAttribute( AngularConst.BindRel, "a" );
            var result = new StringBuilder();
            result.Append( "<a nz-button=\"\" nzType=\"link\" [rel]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试路由链接
        /// </summary>
        [Fact]
        public void TestRouterLink() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link )
                .SetContextAttribute( AngularConst.RouterLink, "a" );
            var result = new StringBuilder();
            result.Append( "<a nz-button=\"\" nzType=\"link\" routerLink=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试路由链接
        /// </summary>
        [Fact]
        public void TestBindRouterLink() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link )
                .SetContextAttribute( AngularConst.BindRouterLink, "a" );
            var result = new StringBuilder();
            result.Append( "<a nz-button=\"\" nzType=\"link\" [routerLink]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试活动路由链接
        /// </summary>
        [Fact]
        public void TestRouterLinkActive() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link )
                .SetContextAttribute( AngularConst.RouterLinkActive, "a" );
            var result = new StringBuilder();
            result.Append( "<a nz-button=\"\" nzType=\"link\" routerLinkActive=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试活动路由链接
        /// </summary>
        [Fact]
        public void TestBindRouterLinkActive() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link )
                .SetContextAttribute( AngularConst.BindRouterLinkActive, "a" );
            var result = new StringBuilder();
            result.Append( "<a nz-button=\"\" nzType=\"link\" [routerLinkActive]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试路由查询参数
        /// </summary>
        [Fact]
        public void TestQueryParams() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link )
                .SetContextAttribute( UiConst.QueryParams, "a" );
            var result = new StringBuilder();
            result.Append( "<a nz-button=\"\" nzType=\"link\" [queryParams]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试路由链接查询参数处理方式
        /// </summary>
        [Fact]
        public void TestQueryParamsHandling() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link )
                .SetContextAttribute( UiConst.QueryParamsHandling, QueryParamsHandling.Merge );
            var result = new StringBuilder();
            result.Append( "<a nz-button=\"\" nzType=\"link\" queryParamsHandling=\"merge\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试路由链接查询参数处理方式
        /// </summary>
        [Fact]
        public void TestBindQueryParamsHandling() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link )
                .SetContextAttribute( AngularConst.BindQueryParamsHandling, "a" );
            var result = new StringBuilder();
            result.Append( "<a nz-button=\"\" nzType=\"link\" [queryParamsHandling]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试查询表单链接
        /// </summary>
        [Fact]
        public void TestIsSearch() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link )
                .SetContextAttribute( UiConst.IsSearch, true );
            var formShareConfig = new FormShareConfig { SearchFormShowNumber = 1 };
            formShareConfig.AddColumnId( "a" );
            formShareConfig.AddColumnId( "b" );
            formShareConfig.AddColumnId( "action" );
            _wrapper.SetItem( formShareConfig );

            var result = new StringBuilder();
            result.Append( "<a (click)=\"expand=!expand\" nz-button=\"\" nzType=\"link\">" );
            result.Append( "{{expand?'收起':'展开'}}" );
            result.Append( "<span nz-icon=\"\" [nzType]=\"expand?'up':'down'\"></span>" );
            result.Append( "</a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示表格设置
        /// </summary>
        [Fact]
        public void TestShowTableSettings() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link )
                .SetContextAttribute( UiConst.ShowTableSettings, "a" );
            var result = new StringBuilder();
            result.Append( "<a (click)=\"ts_a.show()\" class=\"card-tool-icon-btn\" nz-button=\"\" nz-tooltip=\"\" nzTooltipTitle=\"表格设置\" nzType=\"link\">" );
            result.Append( "<span nz-icon=\"\" nzType=\"setting\"></span>" );
            result.Append( "</a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试选项卡路由联动
        /// </summary>
        [Fact]
        public void TestTabLink() {
            _wrapper.SetContextAttribute( UiConst.Type, ButtonType.Link )
                .SetContextAttribute( UiConst.TabLink, "a" );
            var result = new StringBuilder();
            result.Append( "<a *nzTabLink=\"a\" nz-button=\"\" nz-tab-link=\"\" nzType=\"link\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
