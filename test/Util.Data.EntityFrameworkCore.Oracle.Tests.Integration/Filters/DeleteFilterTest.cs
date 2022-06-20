using Util.Tests.Models;
using Xunit;
using Xunit.Abstractions;

namespace Util.Data.EntityFrameworkCore.Filters {
    /// <summary>
    /// 逻辑删除过滤器测试
    /// </summary>
    public class DeleteFilterTest {
        /// <summary>
        /// 测试消息输出
        /// </summary>
        private readonly ITestOutputHelper _testOutputHelper;
        /// <summary>
        /// 逻辑删除过滤器
        /// </summary>
        private readonly DeleteFilter _filter;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public DeleteFilterTest( ITestOutputHelper testOutputHelper ) {
            _testOutputHelper = testOutputHelper;
            _filter = new DeleteFilter();
        }

        /// <summary>
        /// 测试是否启用
        /// </summary>
        [Fact]
        public void TestIsEnabled() {
            //默认值为启用
            Assert.True( _filter.IsEnabled );
            
            //禁用过滤器
            _filter.Disable();
            Assert.False( _filter.IsEnabled );

            //启用过滤器
            _filter.Enable();
            Assert.True( _filter.IsEnabled );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisable() {
            //默认值为启用
            Assert.True( _filter.IsEnabled );

            //禁用过滤器
            using( _filter.Disable() ) {
                Assert.False( _filter.IsEnabled );
            }

            //恢复启用状态
            Assert.True( _filter.IsEnabled );
        }

        /// <summary>
        /// 测试实体是否启用过滤器
        /// </summary>
        [Fact]
        public void TestIsEntityEnabled() {
            Assert.False( _filter.IsEntityEnabled<OperationLog>() );
            Assert.True( _filter.IsEntityEnabled<Product>() );
        }

        /// <summary>
        /// 测试获取表达式
        /// </summary>
        [Fact]
        public void TestGetExpression() {
            var expression = _filter.GetExpression<Product>();
            var result = "entity => Not(Property(entity, \"IsDeleted\"))";
            _testOutputHelper.WriteLine( expression.ToString() );
            Assert.Equal( result,expression.ToString() );
        }
    }
}
