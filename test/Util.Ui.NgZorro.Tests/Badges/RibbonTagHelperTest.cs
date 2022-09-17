using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Badges;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Badges {
    /// <summary>
    /// 缎带徽标测试
    /// </summary>
    public class RibbonTagHelperTest {
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
        public RibbonTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new RibbonTagHelper().ToWrapper();
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
            result.Append( "<nz-ribbon></nz-ribbon>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试颜色
        /// </summary>
        [Fact]
        public void TestColor() {
            _wrapper.SetContextAttribute( UiConst.Color, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-ribbon nzColor=\"a\"></nz-ribbon>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试颜色
        /// </summary>
        [Fact]
        public void TestBindColor() {
            _wrapper.SetContextAttribute( AngularConst.BindColor, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-ribbon [nzColor]=\"a\"></nz-ribbon>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试位置
        /// </summary>
        [Fact]
        public void TestPlacement() {
            _wrapper.SetContextAttribute( UiConst.Placement, RibbonPlacement.End );
            var result = new StringBuilder();
            result.Append( "<nz-ribbon nzPlacement=\"end\"></nz-ribbon>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试位置
        /// </summary>
        [Fact]
        public void TestBindPlacement() {
            _wrapper.SetContextAttribute( AngularConst.BindPlacement, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-ribbon [nzPlacement]=\"a\"></nz-ribbon>" );
            Assert.Equal( result.ToString(), GetResult() );
        }


        /// <summary>
        /// 测试文本内容
        /// </summary>
        [Fact]
        public void TestText() {
            _wrapper.SetContextAttribute( UiConst.Text, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-ribbon nzText=\"a\"></nz-ribbon>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文本内容
        /// </summary>
        [Fact]
        public void TestBindText() {
            _wrapper.SetContextAttribute( AngularConst.BindText, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-ribbon [nzText]=\"a\"></nz-ribbon>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
        
        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-ribbon>a</nz-ribbon>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}