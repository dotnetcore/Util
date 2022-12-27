using System;
using System.Collections.Generic;
using Util.Tests.XUnitHelpers;
using Xunit;

namespace Util.Tests.Extensions {
    /// <summary>
    /// 验证扩展测试
    /// </summary>
    public class ValidationExtensionsTest {
        /// <summary>
        /// 检查空值，不为空则正常执行
        /// </summary>
        [Fact]
        public void TestCheckNull() {
            object test = new object();
            test.CheckNull( "test" );
        }

        /// <summary>
        /// 检查空值，值为null则抛出异常
        /// </summary>
        [Fact]
        public void TestCheckNull_Null_Throw() {
            AssertHelper.Throws<ArgumentNullException>( () => {
                object test = new object();
                test = null;
                test.CheckNull( "test" );
            }, "test" );
        }

        /// <summary>
        /// 测试是否空值 - 字符串
        /// </summary>
        [Theory]
        [InlineData( null,true )]
        [InlineData( "", true )]
        [InlineData( " ", true )]
        [InlineData( "a", false )]
        public void TestIsEmpty_String( string value,bool result ) {
            Assert.Equal( value.IsEmpty(),result );
        }

        /// <summary>
        /// 测试是否空值 - Guid
        /// </summary>
        [Fact]
        public void TestIsEmpty_Guid() {
            Assert.True( Guid.Empty.IsEmpty() );
            Assert.False( Guid.NewGuid().IsEmpty() );
        }

        /// <summary>
        /// 测试是否空值 - 可空Guid
        /// </summary>
        [Fact]
        public void TestIsEmpty_Guid_Nullable() {
            Guid? value = null;
            Assert.True( value.IsEmpty() );
            value = Guid.Empty;
            Assert.True( value.IsEmpty() );
            value = Guid.NewGuid();
            Assert.False( value.IsEmpty() );
        }

        /// <summary>
        /// 测试是否空值 - 集合
        /// </summary>
        [Fact]
        public void TestIsEmpty_List() {
            List<int> list = null;
            Assert.True( list.IsEmpty() );
            list = new List<int>();
            Assert.True( list.IsEmpty() );
            list.Add( 1 );
            Assert.False( list.IsEmpty() );
        }
    }
}
