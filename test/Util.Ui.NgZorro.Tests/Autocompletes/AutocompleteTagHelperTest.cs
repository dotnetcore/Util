using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Autocompletes;
using Util.Ui.NgZorro.Tests.Samples;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Autocompletes {
    /// <summary>
    /// 自动完成测试
    /// </summary>
    public partial class AutocompleteTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper<Customer> _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public AutocompleteTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new AutocompleteTagHelper().ToWrapper<Customer>();
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
            result.Append( "<nz-autocomplete></nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试引用变量
        /// </summary>
        [Fact]
        public void TestId() {
            _wrapper.SetContextAttribute( UiConst.Id, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete #a=\"\"></nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试回填选中项
        /// </summary>
        [Fact]
        public void TestBackfill() {
            _wrapper.SetContextAttribute( UiConst.Backfill, true );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete [nzBackfill]=\"true\"></nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试回填选中项
        /// </summary>
        [Fact]
        public void TestBindBackfill() {
            _wrapper.SetContextAttribute( AngularConst.BindBackfill, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete [nzBackfill]=\"a\"></nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试数据源
        /// </summary>
        [Fact]
        public void TestDataSource() {
            _wrapper.SetContextAttribute( UiConst.Datasource, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete [nzDataSource]=\"a\"></nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试高亮第一项
        /// </summary>
        [Fact]
        public void TestDefaultActiveFirstOption() {
            _wrapper.SetContextAttribute( UiConst.DefaultActiveFirstOption, true );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete [nzDefaultActiveFirstOption]=\"true\"></nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试高亮第一项
        /// </summary>
        [Fact]
        public void TestBindDefaultActiveFirstOption() {
            _wrapper.SetContextAttribute( AngularConst.BindDefaultActiveFirstOption, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete [nzDefaultActiveFirstOption]=\"a\"></nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽度
        /// </summary>
        [Fact]
        public void TestWidth() {
            _wrapper.SetContextAttribute( UiConst.Width, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete [nzWidth]=\"1\"></nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽度
        /// </summary>
        [Fact]
        public void TestBindWidth() {
            _wrapper.SetContextAttribute( AngularConst.BindWidth, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete [nzWidth]=\"a\"></nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉根元素类名
        /// </summary>
        [Fact]
        public void TestOverlayClassName() {
            _wrapper.SetContextAttribute( UiConst.OverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete nzOverlayClassName=\"a\"></nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉根元素类名
        /// </summary>
        [Fact]
        public void TestBindOverlayClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete [nzOverlayClassName]=\"a\"></nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉根元素样式
        /// </summary>
        [Fact]
        public void TestOverlayStyle() {
            _wrapper.SetContextAttribute( UiConst.OverlayStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete nzOverlayStyle=\"a\"></nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉根元素样式
        /// </summary>
        [Fact]
        public void TestBindOverlayStyle() {
            _wrapper.SetContextAttribute( AngularConst.BindOverlayStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete [nzOverlayStyle]=\"a\"></nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试比较算法函数
        /// </summary>
        [Fact]
        public void TestCompareWith() {
            _wrapper.SetContextAttribute( UiConst.CompareWith, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete [compareWith]=\"a\"></nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-autocomplete>a</nz-autocomplete>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}