using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Dividers;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Dividers {
    /// <summary>
    /// 分隔线测试
    /// </summary>
    public class DividerTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper _wrapper;
        /// <summary>
        /// 标识
        /// </summary>
        private readonly string _id;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public DividerTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new DividerTagHelper().ToWrapper();
            _id = "id";
            Id.SetId( _id );
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
            result.Append( "<nz-divider></nz-divider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚线
        /// </summary>
        [Fact]
        public void TestDashed() {
            _wrapper.SetContextAttribute( UiConst.Dashed, true );
            var result = new StringBuilder();
            result.Append( "<nz-divider [nzDashed]=\"true\"></nz-divider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试虚线
        /// </summary>
        [Fact]
        public void TestBindDashed() {
            _wrapper.SetContextAttribute( AngularConst.BindDashed, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-divider [nzDashed]=\"a\"></nz-divider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试类型
        /// </summary>
        [Fact]
        public void TestType() {
            _wrapper.SetContextAttribute( UiConst.Type, DividerType.Vertical );
            var result = new StringBuilder();
            result.Append( "<nz-divider nzType=\"vertical\"></nz-divider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试类型
        /// </summary>
        [Fact]
        public void TestBindType() {
            _wrapper.SetContextAttribute( AngularConst.BindType, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-divider [nzType]=\"a\"></nz-divider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置文字
        /// </summary>
        [Fact]
        public void TestText() {
            _wrapper.SetContextAttribute( UiConst.Text, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-divider nzText=\"a\"></nz-divider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置文字
        /// </summary>
        [Fact]
        public void TestBindText() {
            _wrapper.SetContextAttribute( AngularConst.BindText, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-divider [nzText]=\"a\"></nz-divider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置文字方向
        /// </summary>
        [Fact]
        public void TestOrientation() {
            _wrapper.SetContextAttribute( UiConst.Orientation, DividerOrientation.Right );
            var result = new StringBuilder();
            result.Append( "<nz-divider nzOrientation=\"right\"></nz-divider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置文字方向
        /// </summary>
        [Fact]
        public void TestBindOrientation() {
            _wrapper.SetContextAttribute( AngularConst.BindOrientation, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-divider [nzOrientation]=\"a\"></nz-divider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试正文样式
        /// </summary>
        [Fact]
        public void TestPlain() {
            _wrapper.SetContextAttribute( UiConst.Plain, true );
            var result = new StringBuilder();
            result.Append( "<nz-divider [nzPlain]=\"true\"></nz-divider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试正文样式
        /// </summary>
        [Fact]
        public void TestBindPlain() {
            _wrapper.SetContextAttribute( AngularConst.BindPlain, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-divider [nzPlain]=\"a\"></nz-divider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.AppendFormat( "<nz-divider [nzText]=\"m_{0}\">",_id );
            result.AppendFormat( "<ng-template #m_{0}=\"\">", _id );
            result.Append( "a" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-divider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}