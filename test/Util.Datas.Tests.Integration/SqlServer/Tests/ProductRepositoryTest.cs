using System;
using System.Collections.Generic;
using System.Linq;
using Util.Datas.Tests.Samples.Datas.SqlServer.Repositories;
using Util.Datas.Tests.Samples.Datas.SqlServer.Stores;
using Util.Datas.Tests.Samples.Datas.SqlServer.UnitOfWorks;
using Util.Datas.Tests.Samples.Domains.Models;
using Util.Datas.Tests.Samples.Domains.Repositories;
using Util.Datas.Tests.SqlServer.Confis;
using Util.Helpers;
using Xunit;

namespace Util.Datas.Tests.SqlServer.Tests {
    /// <summary>
    /// 商品仓储测试
    /// </summary>
    public class ProductRepositoryTest : IDisposable {
        /// <summary>
        /// 容器
        /// </summary>
        private readonly Util.DependencyInjection.IContainer _container;
        /// <summary>
        /// 工作单元
        /// </summary>
        private readonly ISqlServerUnitOfWork _unitOfWork;
        /// <summary>
        /// 商品仓储
        /// </summary>
        private readonly IProductRepository _productRepository;
        /// <summary>
        /// 随机数操作
        /// </summary>
        private readonly Util.Helpers.Random _random;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ProductRepositoryTest() {
            _container = Ioc.CreateContainer( new IocConfig() );
            _unitOfWork = _container.Create<ISqlServerUnitOfWork>();
            _productRepository = _container.Create<IProductRepository>();
            _random = new Util.Helpers.Random();
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            _container.Dispose();
        }

        /// <summary>
        /// 测试添加
        /// </summary>
        [Fact]
        public void TestAdd() {
            int id = _random.Next( 999999999 );
            var order = new Product( id ) { Name = "Name", Code = "Code" };
            order.ProductType = new ProductType( "Type", new List<ProductProperty>() { new ProductProperty( "A", "1" ), new ProductProperty( "B", "2" ) } );
            _productRepository.Add( order );
            _unitOfWork.Commit();

            Product result = _productRepository.GetById( id );
            Assert.Equal( id, result.Id );
            Assert.Equal( "Type", result.ProductType.Name );
            Assert.Equal( "2", result.ProductType.Properties.ToList()[1].Value );
        }
    }
}
