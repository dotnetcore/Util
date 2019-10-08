using Util.Helpers;
using Util.Ui.Zorro.Tables.Builders;
using Xunit;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Tables.Builders {
    /// <summary>
    /// 行号列生成器测试
    /// </summary>
    public class LineNumberColumnBuilderTest {
        /// <summary>
        /// 行号列生成器
        /// </summary>
        private readonly LineNumberColumnBuilder _builder;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public LineNumberColumnBuilderTest() {
            _builder = new LineNumberColumnBuilder();
        }

        /// <summary>
        /// 测试输出
        /// </summary>
        [Fact]
        public void Test() {
            var result = new String();
            result.Append( "<td>" );
            result.Append( "{{row.lineNumber}}" );
            result.Append( "</td>" );

            Assert.Equal( result.ToString(), _builder.ToString() );
        }
    }
}
