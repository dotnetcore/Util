using Util.Ui.Builders;
using Xunit;

namespace Util.Ui.Tests.Builders {
    /// <summary>
    /// 空容器标签生成器测试
    /// </summary>
    public class EmptyContainerTagBuilderTest {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public EmptyContainerTagBuilderTest() {
            _builder = new EmptyContainerTagBuilder();
        }

        /// <summary>
        /// 空容器标签生成器
        /// </summary>
        private readonly EmptyContainerTagBuilder _builder;

        /// <summary>
        /// 默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            Assert.Empty( _builder.ToString() );
        }

        /// <summary>
        /// 测试添加内容
        /// </summary>
        [Fact]
        public void TestAppendContent() {
            _builder.AppendContent( new DivBuilder() );
            Assert.Equal( "<div></div>", _builder.ToString() );
        }

        /// <summary>
        /// 测试添加内容
        /// </summary>
        [Fact]
        public void TestAppendContent_2() {
            _builder.AppendContent( new DivBuilder() );
            _builder.AppendContent( new SpanBuilder() );
            Assert.Equal( "<div></div><span></span>", _builder.ToString() );
        }
    }
}
