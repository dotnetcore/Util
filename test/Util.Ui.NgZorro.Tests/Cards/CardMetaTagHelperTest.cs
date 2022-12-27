using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Cards;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Cards {
    /// <summary>
    /// 卡片元信息测试
    /// </summary>
    public class CardMetaTagHelperTest {
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
        public CardMetaTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new CardMetaTagHelper().ToWrapper();
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
            result.Append( "<nz-card-meta></nz-card-meta>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card-meta nzTitle=\"a\"></nz-card-meta>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card-meta [nzTitle]=\"a\"></nz-card-meta>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试头像
        /// </summary>
        [Fact]
        public void TestAvatar() {
            _wrapper.SetContextAttribute( UiConst.Avatar, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card-meta [nzAvatar]=\"a\"></nz-card-meta>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试描述
        /// </summary>
        [Fact]
        public void TestDescription() {
            _wrapper.SetContextAttribute( UiConst.Description, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card-meta nzDescription=\"a\"></nz-card-meta>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试描述
        /// </summary>
        [Fact]
        public void TestBindDescription() {
            _wrapper.SetContextAttribute( AngularConst.BindDescription, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card-meta [nzDescription]=\"a\"></nz-card-meta>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-card-meta>a</nz-card-meta>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}