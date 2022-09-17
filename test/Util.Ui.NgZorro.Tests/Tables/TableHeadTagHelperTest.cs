using System.Text;
using Util.Ui.NgZorro.Components.Tables;
using Util.Ui.NgZorro.Components.Tables.Configs;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Tables {
    /// <summary>
    /// 表头测试
    /// </summary>
    public partial class TableHeadTagHelperTest {
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
        public TableHeadTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new TableHeadTagHelper().ToWrapper();
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
            result.Append( "<thead></thead>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            //设置表格共享配置
            _wrapper.SetItem( new TableShareConfig{IsAutoCreateHeadRow = false} );
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<thead>a</thead>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}