using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Lists;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Lists {
    /// <summary>
    /// 列表项测试
    /// </summary>
    public class ListItemTagHelperTest {
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
        public ListItemTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new ListItemTagHelper().ToWrapper();
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
            result.Append( "<nz-list-item></nz-list-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列表项操作
        /// </summary>
        [Fact]
        public void TestActions() {
            _wrapper.SetContextAttribute( UiConst.Actions, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list-item [nzActions]=\"a\"></nz-list-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列表项内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.SetContextAttribute( UiConst.Content, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list-item nzContent=\"a\"></nz-list-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列表项内容
        /// </summary>
        [Fact]
        public void TestBindContent() {
            _wrapper.SetContextAttribute( AngularConst.BindContent, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list-item [nzContent]=\"a\"></nz-list-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列表项扩展
        /// </summary>
        [Fact]
        public void TestExtra() {
            _wrapper.SetContextAttribute( UiConst.Extra, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list-item [nzExtra]=\"a\"></nz-list-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否非flex布局
        /// </summary>
        [Fact]
        public void TestNoFlex() {
            _wrapper.SetContextAttribute( UiConst.NoFlex, "true" );
            var result = new StringBuilder();
            result.Append( "<nz-list-item [nzNoFlex]=\"true\"></nz-list-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚拟滚动循环
        /// </summary>
        [Fact]
        public void TestVirtualFor() {
            _wrapper.SetContextAttribute( UiConst.VirtualFor, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list-item *cdkVirtualFor=\"a\"></nz-list-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestAppendContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list-item>a</nz-list-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}