using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Skeletons;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Skeletons {
    /// <summary>
    /// 骨架屏元素测试
    /// </summary>
    public class SkeletonElementTagHelperTest {
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
        public SkeletonElementTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new SkeletonElementTagHelper().ToWrapper();
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
            result.Append( "<nz-skeleton-element></nz-skeleton-element>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试类型
        /// </summary>
        [Fact]
        public void TestType() {
            _wrapper.SetContextAttribute( UiConst.Type, SkeletonElementType.Button );
            var result = new StringBuilder();
            result.Append( "<nz-skeleton-element nzType=\"button\"></nz-skeleton-element>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试类型
        /// </summary>
        [Fact]
        public void TestBindType() {
            _wrapper.SetContextAttribute( AngularConst.BindType, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-skeleton-element [nzType]=\"a\"></nz-skeleton-element>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示动画效果
        /// </summary>
        [Fact]
        public void TestActive() {
            _wrapper.SetContextAttribute( UiConst.Active, true );
            var result = new StringBuilder();
            result.Append( "<nz-skeleton-element [nzActive]=\"true\"></nz-skeleton-element>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否显示动画效果
        /// </summary>
        [Fact]
        public void TestBindActive() {
            _wrapper.SetContextAttribute( AngularConst.BindActive, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-skeleton-element [nzActive]=\"a\"></nz-skeleton-element>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试大小
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, SkeletonElementSize.Small );
            var result = new StringBuilder();
            result.Append( "<nz-skeleton-element nzSize=\"small\"></nz-skeleton-element>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试大小
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-skeleton-element [nzSize]=\"a\"></nz-skeleton-element>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试形状
        /// </summary>
        [Fact]
        public void TestShape() {
            _wrapper.SetContextAttribute( UiConst.Shape, SkeletonElementShape.Circle );
            var result = new StringBuilder();
            result.Append( "<nz-skeleton-element nzShape=\"circle\"></nz-skeleton-element>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试形状
        /// </summary>
        [Fact]
        public void TestBindShape() {
            _wrapper.SetContextAttribute( AngularConst.BindShape, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-skeleton-element [nzShape]=\"a\"></nz-skeleton-element>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-skeleton-element>a</nz-skeleton-element>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}