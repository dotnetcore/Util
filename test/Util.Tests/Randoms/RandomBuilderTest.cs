using System;
using NSubstitute;
using Util.Datas.Queries;
using Util.Randoms;
using Xunit;

namespace Util.Tests.Randoms {
    /// <summary>
    /// 随机数生成器测试
    /// </summary>
    public class RandomBuilderTest {
        /// <summary>
        /// 创建随机数生成器
        /// </summary>
        private RandomBuilder CreateRandomBuilder( int value ) {
            var generator = Substitute.For<IRandomNumberGenerator>();
            generator.Generate( Arg.Any<int>(), Arg.Any<int>() ).Returns( value );
            return new RandomBuilder( generator );
        }

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        [Fact]
        public void TestGenerateString() {
            var builder = CreateRandomBuilder( 2 );
            var result = builder.GenerateString( 2 );
            Assert.Equal( "cc", result );
        }

        /// <summary>
        /// 生成随机字符串 - 设置文本
        /// </summary>
        [Fact]
        public void TestGenerateString_Text() {
            var builder = CreateRandomBuilder( 3 );
            var result = builder.GenerateString( 3, "12345" );
            Assert.Equal( "444", result );
        }

        /// <summary>
        /// 生成随机字母
        /// </summary>
        [Fact]
        public void TestGenerateLetters() {
            var builder = CreateRandomBuilder( 2 );
            var result = builder.GenerateLetters( 2 );
            Assert.Equal( "cc", result );
        }

        /// <summary>
        /// 生成随机汉字
        /// </summary>
        [Fact]
        public void TestGenerateChinese() {
            var builder = CreateRandomBuilder( 2 );
            var result = builder.GenerateChinese( 2 );
            Assert.Equal( "二二", result );
        }

        /// <summary>
        /// 生成随机数字
        /// </summary>
        [Fact]
        public void TestGenerateNumbers() {
            var builder = CreateRandomBuilder( 2 );
            var result = builder.GenerateNumbers( 2 );
            Assert.Equal( "22", result );
        }

        /// <summary>
        /// 生成随机布尔值
        /// </summary>
        [Fact]
        public void TestGenerateBool() {
            var builder = CreateRandomBuilder( 2 );
            var result = builder.GenerateBool();
            Assert.False( result );
            builder = CreateRandomBuilder( 3 );
            result = builder.GenerateBool();
            Assert.True( result );
        }

        /// <summary>
        /// 生成随机日期
        /// </summary>
        [Fact]
        public void TestGenerateDate() {
            var builder = CreateRandomBuilder( 2 );
            var result = builder.GenerateDate();
            Assert.Equal( new DateTime( 2, 2, 2, 2, 2, 2 ), result );
        }

        /// <summary>
        /// 生成随机枚举
        /// </summary>
        [Fact]
        public void TestGenerateEnum() {
            var builder = CreateRandomBuilder( 2 );
            var result = builder.GenerateEnum<Operator>();
            Assert.Equal( Operator.Greater, result );
        }
    }
}
