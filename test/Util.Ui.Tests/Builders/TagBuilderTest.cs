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
        public void TestAttribute_1() {
            _builder.Attribute( "name", "a" );
            Assert.Equal( "<div name=\"a\"></div>", _builder.ToString() );
        }

        /// <summary>
        /// 添加同名属性，第二个被忽略
        /// </summary>
        [Fact]
        public void TestAttribute_2() {
            _builder.Attribute( "name", "a" );
            _builder.Attribute( "name", "b" );
            Assert.Equal( "<div name=\"a\"></div>", _builder.ToString() );
        }

        /// <summary>
        /// 添加同名属性，替换已存在的属性
        /// </summary>
        [Fact]
        public void TestAttribute_3() {
            _builder.Attribute( "name", "a" );
            _builder.Attribute( "name", "b", true );
            Assert.Equal( "<div name=\"b\"></div>", _builder.ToString() );
        }

        /// <summary>
        /// 添加同名属性,属性值累加
        /// </summary>
        [Fact]
        public void TestAttribute_4() {
            _builder.Attribute( "name", "a" );
            _builder.Attribute( "name", "b", append: true );
            Assert.Equal( "<div name=\"a;b\"></div>", _builder.ToString() );
        }

        /// <summary>
        /// 添加同名属性,属性值累加 - 只有一个属性
        /// </summary>
        [Fact]
        public void TestAttribute_5() {
            _builder.Attribute( "name", "a", append: true );
            Assert.Equal( "<div name=\"a\"></div>", _builder.ToString() );
        }

        /// <summary>
        /// 添加同名属性，同时设置替换和属性值累加时，替换生效
        /// </summary>
        [Fact]
        public void TestAttribute_6() {
            _builder.Attribute( "name", "a" );
            _builder.Attribute( "name", "b", true, true );
            Assert.Equal( "<div name=\"b\"></div>", _builder.ToString() );
        }

        /// <summary>
        /// 添加属性,值为空
        /// </summary>
        [Fact]
        public void TestAttribute_7() {
            _builder.Attribute( "name" );
            Assert.Equal( "<div name=\"\"></div>", _builder.ToString() );
        }

        /// <summary>
        /// 添加class属性
        /// </summary>
        [Fact]
        public void TestClass() {
            _builder.Class( "a" );
            Assert.Equal( "<div class=\"a\"></div>", _builder.ToString() );
            _builder.Class( "b" );
            Assert.Equal( "<div class=\"a b\"></div>", _builder.ToString() );
        }
    }
}
