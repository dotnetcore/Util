using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Datas.Ef;
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
            var product = new Product( id ) { Name = "Name", Code = "Code" };
            product.ProductType = new ProductType( "Type", new List<ProductProperty>() { new ProductProperty( "A", "1" ), new ProductProperty( "B", "2" ) } );
            _productRepository.Add( product );
            _unitOfWork.Commit();

            Product result = _productRepository.GetById( id );
            Assert.Equal( id, result.Id );
            Assert.Equal( "Type", result.ProductType.Name );
            Assert.Equal( "2", result.ProductType.Properties.ToList()[1].Value );
        }

        /// <summary>
        /// 测试异步添加
        /// </summary>
        [Fact]
        public async Task TestAddAsync() {
            int id = _random.Next( 999999999 );
            var product = new Product( id ) { Name = "Name", Code = "Code" };
            product.ProductType = new ProductType( "Type", new List<ProductProperty>() { new ProductProperty( "A", "1" ), new ProductProperty( "B", "2" ) } );
            await _productRepository.AddAsync( product );
            await _unitOfWork.CommitAsync();

            Product result = _productRepository.GetById( id );
            Assert.Equal( id, result.Id );
            Assert.Equal( "Type", result.ProductType.Name );
            Assert.Equal( "2", result.ProductType.Properties.ToList()[1].Value );
        }

        /// <summary>
        /// 测试更新 - 先从仓储中查找出来，直接修改对象属性，提交工作单元,该更新方法无效
        /// 原因: 如果使用了Po，从仓储中Find出来的实体只是普通对象，没有被EF跟踪，所以修改属性提交工作单元没有保存更新
        /// </summary>
        [Fact]
        public void TestUpdate_Find_Fail() {
            int id = _random.Next( 999999999 );
            var product = new Product( id ) { Name = "Name", Code = "Code" };
            product.ProductType = new ProductType( "Type", new List<ProductProperty>() { new ProductProperty( "A", "1" ), new ProductProperty( "B", "2" ) } );
            _productRepository.Add( product );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            var result = _productRepository.Find( id );
            result.Code = "B";
            _unitOfWork.Commit();

            result = _productRepository.GetById( id );
            Assert.NotEqual( "B", result.Code );
        }

        /// <summary>
        /// 测试更新 - 修改方式1：创建出修改对象，调用仓储的Update，内部修改为已更新状态，提交工作单元
        /// 适用场景：当修改前不想获取出数据库中的待修改对象，则使用本方法
        /// 应用场景：通过Http Put方法传入DTO,该DTO包含待修改实体的全部属性，将该DTO转成待更新实体，你可能觉得从数据库中获取原实体浪费资源，希望能够将待更新实体直接保存到数据库
        /// 注意1：创建的更新实体必须包含全部数据，否则导致数据丢失
        /// 注意2：如果在调用Update方法前调用了Find等方法将原对象获取出来，则更新失败
        /// 缺点：整体更新，生成的更新SQL会更新所有字段
        /// </summary>
        [Fact]
        public void TestUpdate_1() {
            int id = _random.Next( 999999999 );
            var product = new Product( id ) { Name = "Name", Code = "Code" };
            product.ProductType = new ProductType( "Type", new List<ProductProperty>() { new ProductProperty( "A", "1" ), new ProductProperty( "B", "2" ) } );
            _productRepository.Add( product );
            _unitOfWork.Commit();
            product = _productRepository.GetById( id );
            _unitOfWork.ClearCache();
            
            var product2 = new Product( id ) { Name = "Name", Code = "B", Version = product.Version };
            _productRepository.Update( product2 );
            _unitOfWork.Commit();

            var result = _productRepository.GetById( id );
            Assert.Equal( "B", result.Code );
        }

        /// <summary>
        /// 测试更新 - 修改方式2：从数据库获取出旧实体，创建出待修改的新实体，调用仓储的Update，新实体将替换旧实体，提交工作单元
        /// 适用场景：当修改前需要获取出数据库中的待修改对象，且创建了完整的待修改对象，则使用本方法
        /// 应用场景：通过Http Put方法传入DTO,该DTO包含待修改实体的全部属性，将该DTO转成待更新实体，你可能需要从数据库中获取出原来的实体，例如需要比较哪些属性发生了变化
        /// 优点：按需更新，生成的更新SQL只更新变更字段
        /// </summary>
        [Fact]
        public void TestUpdate_2() {
            int id = _random.Next( 999999999 );
            var product = new Product( id ) { Name = "Name", Code = "Code" };
            product.ProductType = new ProductType( "Type", new List<ProductProperty>() { new ProductProperty( "A", "1" ), new ProductProperty( "B", "2" ) } );
            _productRepository.Add( product );
            _unitOfWork.Commit();
            product = _productRepository.GetById( id );
            _unitOfWork.ClearCache();

            var newEntity = new Product( id ) { Name = "Name", Code = "B", Version = product.Version };
            var oldEntity = _productRepository.GetById( id );
            _productRepository.Update( newEntity, oldEntity );
            _unitOfWork.Commit();

            var result = _productRepository.GetById( id );
            Assert.Equal( "B", result.Code );
        }
    }
}
