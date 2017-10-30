using System;
using Util.Parameters;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Parameters {
    /// <summary>
    /// 参数生成器测试
    /// </summary>
    public class ParameterBuilderTest {
        /// <summary>
        /// 参数生成器
        /// </summary>
        private readonly ParameterBuilder _dictionary;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ParameterBuilderTest() {
            _dictionary = new ParameterBuilder();
        }

        /// <summary>
        /// 验证key为空
        /// </summary>
        [Theory]
        [InlineData( null )]
        [InlineData( "" )]
        [InlineData( " " )]
        public void TestAdd_KeyIsEmpty( string key ) {
            Assert.Empty( _dictionary.Add( key, "b" ).Result( new ParameterFormatterSample() ) );
        }

        /// <summary>
        /// 验证value为空
        /// </summary>
        [Theory]
        [InlineData( null )]
        [InlineData( "" )]
        [InlineData( " " )]
        public void TestAdd_ValueIsEmpty( string value ) {
            Assert.Empty( _dictionary.Add( "a", value ).Result( new ParameterFormatterSample() ) );
        }

        /// <summary>
        /// 去除键两端空格
        /// </summary>
        [Fact]
        public void TestAdd_TrimKey() {
            Assert.Equal( "a:1", _dictionary.Add( " a ", "1" ).Result( new ParameterFormatterSample() ) );
        }

        /// <summary>
        /// 去除值两端空格
        /// </summary>
        [Fact]
        public void TestAdd_TrimValue() {
            Assert.Equal( "a:1", _dictionary.Add( "a", " 1 " ).Result( new ParameterFormatterSample() ) );
        }

        /// <summary>
        /// 添加字符串参数
        /// </summary>
        [Fact]
        public void TestAdd_String() {
            Assert.Equal( "a:1", _dictionary.Add( "a", "1" ).Result( new ParameterFormatterSample() ) );
        }

        /// <summary>
        /// 添加2个字符串参数
        /// </summary>
        [Fact]
        public void TestAdd_String_2() {
            Assert.Equal( "a:1|b:2", _dictionary.Add( "a", " 1" ).Add( "b ", "2 " ).Result( new ParameterFormatterSample() ) );
        }

        /// <summary>
        /// 添加日期参数
        /// </summary>
        [Fact]
        public void TestAdd_DateTime() {
            DateTime value = new DateTime( 2000, 10, 10, 10, 10, 10 );
            Assert.Equal( "a:2000-10-10 10:10:10", _dictionary.Add( "a", value ).Result( new ParameterFormatterSample() ) );
        }

        /// <summary>
        /// 添加日期参数 - 可空
        /// </summary>
        [Fact]
        public void TestAdd_DateTime_Nullable() {
            DateTime? value = new DateTime( 2000, 10, 10, 10, 10, 10 );
            Assert.Equal( "a:2000-10-10 10:10:10", _dictionary.Add( "a", value ).Result( new ParameterFormatterSample() ) );
        }

        /// <summary>
        /// 添加日期参数 - 可空 - 传入null
        /// </summary>
        [Fact]
        public void TestAdd_DateTime_Nullable_Null() {
            DateTime? value = null;
            Assert.Empty( _dictionary.Add( "a", value ).Result( new ParameterFormatterSample() ) );
        }

        /// <summary>
        /// 添加整型参数
        /// </summary>
        [Fact]
        public void TestAdd_Int() {
            int value = 1;
            Assert.Equal( "a:1", _dictionary.Add( "a", value ).Result( new ParameterFormatterSample() ) );
        }

        /// <summary>
        /// 添加整型参数 - 可空
        /// </summary>
        [Fact]
        public void TestAdd_Int_Nullable() {
            int? value = 1;
            Assert.Equal( "a:1", _dictionary.Add( "a", value ).Result( new ParameterFormatterSample() ) );
        }

        /// <summary>
        /// 添加整型参数 - 可空 - 传入null
        /// </summary>
        [Fact]
        public void TestAdd_Int_Nullable_Null() {
            int? value = null;
            Assert.Empty( _dictionary.Add( "a", value ).Result( new ParameterFormatterSample() ) );
        }

        /// <summary>
        /// 添加布尔参数
        /// </summary>
        [Fact]
        public void TestAdd_Bool() {
            bool value = true;
            Assert.Equal( "a:true", _dictionary.Add( "a", value ).Result( new ParameterFormatterSample() ) );
        }

        /// <summary>
        /// 添加布尔参数 - 可空
        /// </summary>
        [Fact]
        public void TestAdd_Bool_Nullable() {
            bool? value = false;
            Assert.Equal( "a:false", _dictionary.Add( "a", value ).Result( new ParameterFormatterSample() ) );
        }

        /// <summary>
        /// 添加布尔参数 - 可空 - 传入null
        /// </summary>
        [Fact]
        public void TestAdd_Bool_Nullable_Null() {
            bool? value = null;
            Assert.Empty( _dictionary.Add( "a", value ).Result( new ParameterFormatterSample() ) );
        }

        /// <summary>
        /// 已添加参数则覆盖
        /// </summary>
        [Fact]
        public void TestAdd_Exist() {
            Assert.Equal( "a:2", _dictionary.Add( "a", "1" ).Add( "a", "2" ).Result( new ParameterFormatterSample() ) );
        }
    }
}
