using Util.Ui.Builders;
using Xunit;

namespace Util.Ui.Tests.Builders {
    /// <summary>
    /// 标签生成器测试
    /// </summary>
    public class TagBuilderTest {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public TagBuilderTest() {
            _builder = new TagBuilder( "div" );
        }

        /// <summary>
        /// 标签生成器
        /// </summary>
        private readonly TagBuilder _builder;

        /// <summary>
        /// 默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            Assert.Equal( "<div></div>", _builder.ToString() );
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        [Fact]
        public void TestAttribute() {
            _builder.Attribute( "name", "a" );
            Assert.Equal( "<div name=\"a\"></div>", _builder.ToString() );
            _builder.Attribute( "name", "b" );
            Assert.Equal( "<div name=\"a\"></div>", _builder.ToString() );
            _builder.Attribute( "name", "c",true );
            Assert.Equal( "<div name=\"c\"></div>", _builder.ToString() );
        }

        /// <summary>
        /// 添加属性 - 多个属性值累加
        /// </summary>
        [Fact]
        public void TestAttribute_Append() {
            _builder.Attribute( "name", "a" );
            _builder.Attribute( "name", "b",append:true );
            Assert.Equal( "<div name=\"a;b\"></div>", _builder.ToString() );
        }

        /// <summary>
        /// 添加class属性
        /// </summary>
        [Fact]
        public void TestClass() {
            _builder.Class( "a" );
            Assert.Equal( "<div class=\"a\"></div>", _builder.ToString() );
            _builder.Class( "b" );
            Assert.Equal( "<div class=\"b a\"></div>", _builder.ToString() );
        }
    }
}
