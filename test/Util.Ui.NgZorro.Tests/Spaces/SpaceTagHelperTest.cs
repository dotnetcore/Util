using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Spaces;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Spaces {
    /// <summary>
    /// 间距测试
    /// </summary>
    public class SpaceTagHelperTest {
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
        public SpaceTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new SpaceTagHelper().ToWrapper();
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
            result.Append( "<nz-space></nz-space>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试间距大小
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, SpaceSize.Large );
            var result = new StringBuilder();
            result.Append( "<nz-space nzSize=\"large\"></nz-space>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试间距大小
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-space [nzSize]=\"a\"></nz-space>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试间距方向
        /// </summary>
        [Fact]
        public void TestDirection() {
            _wrapper.SetContextAttribute( UiConst.Direction, SpaceDirection.Vertical );
            var result = new StringBuilder();
            result.Append( "<nz-space nzDirection=\"vertical\"></nz-space>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试间距方向
        /// </summary>
        [Fact]
        public void TestBindDirection() {
            _wrapper.SetContextAttribute( AngularConst.BindDirection, "Ab" );
            var result = new StringBuilder();
            result.Append( "<nz-space [nzDirection]=\"Ab\"></nz-space>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试对齐方式
        /// </summary>
        [Fact]
        public void TestAlign() {
            _wrapper.SetContextAttribute( UiConst.Align, SpaceAlign.End );
            var result = new StringBuilder();
            result.Append( "<nz-space nzAlign=\"end\"></nz-space>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试对齐方式
        /// </summary>
        [Fact]
        public void TestBindAlign() {
            _wrapper.SetContextAttribute( AngularConst.BindAlign, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-space [nzAlign]=\"a\"></nz-space>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-space>" );
            result.Append( "a" );
            result.Append( "</nz-space>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}