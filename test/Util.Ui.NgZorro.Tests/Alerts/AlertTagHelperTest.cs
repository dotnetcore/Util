using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Alerts;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Alerts {
    /// <summary>
    /// 警告提示测试
    /// </summary>
    public class AlertTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public AlertTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new AlertTagHelper().ToWrapper();
            Id.SetId( "id" );
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult() {
            var result = _wrapper.GetResult();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new StringBuilder();
            result.Append( "<nz-alert></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否顶部公告
        /// </summary>
        [Fact]
        public void TestBanner() {
            _wrapper.SetContextAttribute( UiConst.Banner, true );
            var result = new StringBuilder();
            result.Append( "<nz-alert [nzBanner]=\"true\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否顶部公告
        /// </summary>
        [Fact]
        public void TestBindBanner() {
            _wrapper.SetContextAttribute( AngularConst.BindBanner, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-alert [nzBanner]=\"a\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否可关闭
        /// </summary>
        [Fact]
        public void TestCloseable() {
            _wrapper.SetContextAttribute( UiConst.Closeable, true );
            var result = new StringBuilder();
            result.Append( "<nz-alert [nzCloseable]=\"true\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否可关闭
        /// </summary>
        [Fact]
        public void TestBindCloseable() {
            _wrapper.SetContextAttribute( AngularConst.BindCloseable, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-alert [nzCloseable]=\"a\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试关闭按钮文字
        /// </summary>
        [Fact]
        public void TestCloseText() {
            _wrapper.SetContextAttribute( UiConst.CloseText, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-alert nzCloseText=\"a\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试关闭按钮文字
        /// </summary>
        [Fact]
        public void TestBindCloseText() {
            _wrapper.SetContextAttribute( AngularConst.BindCloseText, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-alert [nzCloseText]=\"a\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试描述
        /// </summary>
        [Fact]
        public void TestDescription() {
            _wrapper.SetContextAttribute( UiConst.Description, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-alert nzDescription=\"a\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试描述
        /// </summary>
        [Fact]
        public void TestBindDescription() {
            _wrapper.SetContextAttribute( AngularConst.BindDescription, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-alert [nzDescription]=\"a\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示内容
        /// </summary>
        [Fact]
        public void TestMessage() {
            _wrapper.SetContextAttribute( UiConst.Message, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-alert nzMessage=\"a\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提示内容
        /// </summary>
        [Fact]
        public void TestBindMessage() {
            _wrapper.SetContextAttribute( AngularConst.BindMessage, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-alert [nzMessage]=\"a\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示图标
        /// </summary>
        [Fact]
        public void TestShowIcon() {
            _wrapper.SetContextAttribute( UiConst.ShowIcon, true );
            var result = new StringBuilder();
            result.Append( "<nz-alert [nzShowIcon]=\"true\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示图标
        /// </summary>
        [Fact]
        public void TestBindShowIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindShowIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-alert [nzShowIcon]=\"a\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标类型
        /// </summary>
        [Fact]
        public void TestIconType() {
            _wrapper.SetContextAttribute( UiConst.IconType, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-alert nzIconType=\"account-book\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标类型
        /// </summary>
        [Fact]
        public void TestBindIconType() {
            _wrapper.SetContextAttribute( AngularConst.BindIconType, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-alert [nzIconType]=\"a\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试警告类型
        /// </summary>
        [Fact]
        public void TestType() {
            _wrapper.SetContextAttribute( UiConst.Type, AlertType.Warning );
            var result = new StringBuilder();
            result.Append( "<nz-alert nzType=\"warning\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试警告类型
        /// </summary>
        [Fact]
        public void TestBindType() {
            _wrapper.SetContextAttribute( AngularConst.BindType, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-alert [nzType]=\"a\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试关闭事件
        /// </summary>
        [Fact]
        public void TestOnClose() {
            _wrapper.SetContextAttribute( UiConst.OnClose, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-alert (nzOnClose)=\"a\"></nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容 - 自动创建模板
        /// </summary>
        [Fact]
        public void TestContent_1() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-alert [nzMessage]=\"t_id\">" );
            result.Append( "<ng-template #t_id=\"\">" );
            result.Append( "a" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容 - 设置了bind-message,则不自动创建模板
        /// </summary>
        [Fact]
        public void TestContent_2() {
            _wrapper.SetContextAttribute( AngularConst.BindMessage, "a" );
            _wrapper.AppendContent( "b" );
            var result = new StringBuilder();
            result.Append( "<nz-alert [nzMessage]=\"a\">" );
            result.Append( "b" );
            result.Append( "</nz-alert>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}