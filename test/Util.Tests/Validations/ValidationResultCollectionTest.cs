using System.ComponentModel.DataAnnotations;
using System.Linq;
using Util.Validations;
using Xunit;

namespace Util.Tests.Validations {
    /// <summary>
    /// 测试验证结果集合
    /// </summary>
    public class ValidationResultCollectionTest {
        /// <summary>
        /// 验证结果集合
        /// </summary>
        private readonly ValidationResultCollection _results;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ValidationResultCollectionTest() {
            _results = new ValidationResultCollection();
        }

        /// <summary>
        /// 测试在默认情况下，结果集合个数为0
        /// </summary>
        [Fact]
        public void TestDefault() {
            Assert.Equal( 0, _results.Count );
            Assert.True( _results.IsValid );
        }

        /// <summary>
        /// 测试添加null值，直接忽略
        /// </summary>
        [Fact]
        public void TestAdd_Null() {
            _results.Add( null );
            Assert.Equal( 0, _results.Count );
        }

        /// <summary>
        /// 测试添加验证成功结果，忽略
        /// </summary>
        [Fact]
        public void TestAdd_Success() {
            _results.Add( ValidationResult.Success );
            Assert.Equal( 0, _results.Count );
        }

        /// <summary>
        /// 测试添加1个验证结果
        /// </summary>
        [Fact]
        public void TestAdd_1Result() {
            _results.Add( new ValidationResult( "a" ) );
            Assert.Equal( 1, _results.Count );
            Assert.Equal( "a", _results.First().ErrorMessage );
            Assert.False( _results.IsValid );
        }

        /// <summary>
        /// 测试添加null验证结果集合，直接忽略
        /// </summary>
        [Fact]
        public void TestAddList_Null() {
            _results.AddList( null );
            Assert.Equal( 0, _results.Count );
        }

        /// <summary>
        /// 测试添加2个验证结果
        /// </summary>
        [Fact]
        public void TestAddList_2Result() {
            _results.AddList( new[] { new ValidationResult( "a" ), new ValidationResult( "b" ) } );
            Assert.Equal( 2, _results.Count );
            Assert.Equal( "b", _results.Last().ErrorMessage );
        }
    }
}
