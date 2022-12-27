using Util.Data.Filters;
using Util.Domain;
using Util.Tests.Models;
using Xunit;

namespace Util.Data.EntityFrameworkCore.Filters {
    /// <summary>
    /// 数据过滤器管理器测试
    /// </summary>
    public class FilterManagerTest {
        /// <summary>
        /// 数据过滤器管理器
        /// </summary>
        private readonly IFilterManager _filterManager;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public FilterManagerTest( IFilterManager filterManager ) {
            _filterManager = filterManager;
        }

        /// <summary>
        /// 测试获取过滤器 - 泛型
        /// </summary>
        [Fact]
        public void TestGetFilter_1() {
            //逻辑删除过滤器已默认加载
            var filter = _filterManager.GetFilter<IDelete>();
            Assert.NotNull( filter );
            Assert.True( filter.IsEnabled );
        }

        /// <summary>
        /// 测试获取过滤器 - 非泛型
        /// </summary>
        [Fact]
        public void TestGetFilter_2() {
            //逻辑删除过滤器已默认加载
            var filter = _filterManager.GetFilter(typeof( IDelete ) );
            Assert.NotNull( filter );
        }

        /// <summary>
        /// 测试禁用过滤器
        /// </summary>
        [Fact]
        public void TestDisableFilter_1() {
            _filterManager.DisableFilter<IDelete>();
            var filter = _filterManager.GetFilter<IDelete>();
            Assert.False( filter.IsEnabled );
        }

        /// <summary>
        /// 测试禁用过滤器 - 使用using
        /// </summary>
        [Fact]
        public void TestDisableFilter_2() {
            var filter = _filterManager.GetFilter<IDelete>();
            using ( _filterManager.DisableFilter<IDelete>() ) {
                Assert.False( filter.IsEnabled );
            }
            Assert.True( filter.IsEnabled );
        }

        /// <summary>
        /// 测试启用过滤器
        /// </summary>
        [Fact]
        public void TestEnableFilter() {
            var filter = _filterManager.GetFilter<IDelete>();
            
            //禁用
            _filterManager.DisableFilter<IDelete>();
            Assert.False( filter.IsEnabled );

            //启用
            _filterManager.EnableFilter<IDelete>();
            Assert.True( filter.IsEnabled );
        }

        /// <summary>
        /// 测试实体是否启用过滤器
        /// </summary>
        [Fact]
        public void TestIsEntityEnabled() {
            Assert.False( _filterManager.IsEntityEnabled<OperationLog>() );
            Assert.True( _filterManager.IsEntityEnabled<Product>() );
        }

        /// <summary>
        /// 测试过滤器是否启用
        /// </summary>
        [Fact]
        public void TestIsEnabled() {
            Assert.True( _filterManager.IsEnabled<IDelete>() );
            Assert.False( _filterManager.IsEnabled<IUnitOfWork>() );
        }
    }
}

