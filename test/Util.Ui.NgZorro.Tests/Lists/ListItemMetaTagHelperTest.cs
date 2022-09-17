using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Lists;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Lists {
    /// <summary>
    /// 列表项元信息测试
    /// </summary>
    public class ListItemMetaTagHelperTest {
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
        public ListItemMetaTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new ListItemMetaTagHelper().ToWrapper();
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
            result.Append( "<nz-list-item-meta></nz-list-item-meta>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试头像图标
        /// </summary>
        [Fact]
        public void TestAvatar() {
            _wrapper.SetContextAttribute( UiConst.Avatar, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list-item-meta nzAvatar=\"a\"></nz-list-item-meta>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试头像图标
        /// </summary>
        [Fact]
        public void TestBindAvatar() {
            _wrapper.SetContextAttribute( AngularConst.BindAvatar, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list-item-meta [nzAvatar]=\"a\"></nz-list-item-meta>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试描述
        /// </summary>
        [Fact]
        public void TestDescription() {
            _wrapper.SetContextAttribute( UiConst.Description, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list-item-meta nzDescription=\"a\"></nz-list-item-meta>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试描述
        /// </summary>
        [Fact]
        public void TestBindDescription() {
            _wrapper.SetContextAttribute( AngularConst.BindDescription, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list-item-meta [nzDescription]=\"a\"></nz-list-item-meta>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list-item-meta nzTitle=\"a\"></nz-list-item-meta>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list-item-meta [nzTitle]=\"a\"></nz-list-item-meta>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list-item-meta>a</nz-list-item-meta>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}