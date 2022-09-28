using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Descriptions;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Descriptions {
    /// <summary>
    /// 描述列表测试
    /// </summary>
    public class DescriptionTagHelperTest {
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
        public DescriptionTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new DescriptionTagHelper().ToWrapper();
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
            result.Append( "<nz-descriptions></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions nzTitle=\"a\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzTitle]=\"a\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试操作区域
        /// </summary>
        [Fact]
        public void TestExtra() {
            _wrapper.SetContextAttribute( UiConst.Extra, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions nzExtra=\"a\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试操作区域
        /// </summary>
        [Fact]
        public void TestBindExtra() {
            _wrapper.SetContextAttribute( AngularConst.BindExtra, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzExtra]=\"a\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示边框
        /// </summary>
        [Fact]
        public void TestBordered() {
            _wrapper.SetContextAttribute( UiConst.Bordered, true );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzBordered]=\"true\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示边框
        /// </summary>
        [Fact]
        public void TestBindBordered() {
            _wrapper.SetContextAttribute( UiConst.Bordered, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzBordered]=\"a\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试一行中描述列表项的数量
        /// </summary>
        [Fact]
        public void TestColumn() {
            _wrapper.SetContextAttribute( UiConst.Column, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzColumn]=\"1\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列表大小
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, DescriptionSize.Small );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions nzSize=\"small\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试列表大小
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzSize]=\"a\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示冒号
        /// </summary>
        [Fact]
        public void TestColon() {
            _wrapper.SetContextAttribute( UiConst.Colon, true );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzColon]=\"true\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示冒号
        /// </summary>
        [Fact]
        public void TestBindColon() {
            _wrapper.SetContextAttribute( AngularConst.BindColon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions [nzColon]=\"a\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-descriptions>a</nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}