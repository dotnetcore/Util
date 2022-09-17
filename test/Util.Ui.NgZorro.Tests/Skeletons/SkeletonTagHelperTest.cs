using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Skeletons;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Skeletons {
    /// <summary>
    /// 骨架屏测试
    /// </summary>
    public class SkeletonTagHelperTest {
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
        public SkeletonTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new SkeletonTagHelper().ToWrapper();
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
            result.Append( "<nz-skeleton></nz-skeleton>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示动画效果
        /// </summary>
        [Fact]
        public void TestActive() {
            _wrapper.SetContextAttribute( UiConst.Active, true );
            var result = new StringBuilder();
            result.Append( "<nz-skeleton [nzActive]=\"true\"></nz-skeleton>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示动画效果
        /// </summary>
        [Fact]
        public void TestBindActive() {
            _wrapper.SetContextAttribute( AngularConst.BindActive, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-skeleton [nzActive]=\"a\"></nz-skeleton>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示头像占位图
        /// </summary>
        [Fact]
        public void TestAvatar() {
            _wrapper.SetContextAttribute( UiConst.Avatar, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-skeleton [nzAvatar]=\"a\"></nz-skeleton>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否加载状态
        /// </summary>
        [Fact]
        public void TestLoading() {
            _wrapper.SetContextAttribute( UiConst.Loading, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-skeleton [nzLoading]=\"a\"></nz-skeleton>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示段落占位图
        /// </summary>
        [Fact]
        public void TestParagraph() {
            _wrapper.SetContextAttribute( UiConst.Paragraph, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-skeleton [nzParagraph]=\"a\"></nz-skeleton>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示标题占位图
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-skeleton [nzTitle]=\"a\"></nz-skeleton>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试圆形
        /// </summary>
        [Fact]
        public void TestRound() {
            _wrapper.SetContextAttribute( UiConst.Round, true );
            var result = new StringBuilder();
            result.Append( "<nz-skeleton [nzRound]=\"true\"></nz-skeleton>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试圆形
        /// </summary>
        [Fact]
        public void TestBindRound() {
            _wrapper.SetContextAttribute( AngularConst.BindRound, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-skeleton [nzRound]=\"a\"></nz-skeleton>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-skeleton>a</nz-skeleton>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}