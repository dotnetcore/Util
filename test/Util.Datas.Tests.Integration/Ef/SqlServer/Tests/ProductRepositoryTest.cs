using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Datas.Ef;
using Util.Datas.Tests.Commons.Domains.Models;
using Util.Datas.Tests.Commons.Domains.Repositories;
using Util.Datas.Tests.Ef.SqlServer.UnitOfWorks;
using Util.Dependency;
using Util.Helpers;
using Xunit;

namespace Util.Datas.Tests.Ef.SqlServer.Tests {
    /// <summary>
    /// 商品仓储测试
    /// </summary>
    [Collection( "GlobalConfig" )]
    public class ProductRepositoryTest : IDisposable {
        /// <summary>
        /// 容器作用域
        /// </summary>
        private readonly IScope _scope;
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
            _scope = Ioc.BeginScope();
            _unitOfWork = _scope.Create<ISqlServerUnitOfWork>();
            _productRepository = _scope.Create<IProductRepository>();
            _random = new Util.Helpers.Random();
        }

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            _scope.Dispose();
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
        /// 测试添加 - 添加集合
        /// </summary>
        [Fact]
        public void TestAdd_List() {
            int id = _random.Next( 999999999 );
            int id2 = _random.Next( 999999999 );
            var product = new Product( id ) { Name = "Name", Code = "Code" };
            var product2 = new Product( id2 ) { Name = "Name", Code = "Code" };
            _productRepository.Add( new[]{ product, product2 } );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            var result = _productRepository.FindByIds( id,id2 );
            Assert.Equal( 2, result.Count );
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
        /// 测试异步添加 - 添加集合
        /// </summary>
        [Fact]
        public async Task TestAddAsync_List() {
            int id = _random.Next( 999999999 );
            int id2 = _random.Next( 999999999 );
            var product = new Product( id ) { Name = "Name", Code = "Code" };
            var product2 = new Product( id2 ) { Name = "Name", Code = "Code" };
            await _productRepository.AddAsync( new[] { product, product2 } );
            await _unitOfWork.CommitAsync();
            _unitOfWork.ClearCache();

            var result = await _productRepository.FindByIdsAsync( id, id2 );
            Assert.Equal( 2, result.Count );
        }

        /// <summary>
        /// 测试更新 - 先从仓储中查找出来，修改对象属性，直接提交工作单元,该更新方法无效
        /// 原因: 如果使用了Po，从仓储中Find出来的实体只是普通对象，没有被EF跟踪，所以修改属性提交工作单元没有保存更新,必须调用Update方法
        /// </summary>
        [Fact]
        public void TestUpdate_Invalid() {
            int id = _random.Next( 999999999 );
            var product = new Product( id ) { Name = "Name", Code = "Code" };
            _productRepository.Add( product );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            var result = _productRepository.Find( id );
            result.Code = "B";
            _unitOfWork.Commit();

            result = _productRepository.GetById( id );
            Assert.Equal( "Code", result.Code );
        }

        /// <summary>
        /// 测试更新
        /// </summary>
        [Fact]
        public void TestUpdate() {
            int id = _random.Next( 999999999 );
            var product = new Product( id ) { Name = "Name", Code = "Code" };
            _productRepository.Add( product );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            //Find出来修改，必须调用Update方法才能生效
            product = _productRepository.Find( id );
            product.Code = "B";
            _productRepository.Update( product );
            _unitOfWork.Commit();
            var result = _productRepository.GetById( id );
            Assert.Equal( "B", result.Code );
            _unitOfWork.ClearCache();

            //手工定义一个待更新对象,调用Update
            product = new Product( id ) { Name = "Name", Code = "C", Version = result.Version };
            _productRepository.Update( product );
            _unitOfWork.Commit();
            result = _productRepository.GetById( id );
            Assert.Equal( "C", result.Code );
            _unitOfWork.ClearCache();

            //手工定义一个待更新对象,从仓储中Find出原对象，没有影响
            var old = _productRepository.Find( id );
            product = new Product( id ) { Name = "Name", Code = "D", Version = old.Version };
            _productRepository.Update( product );
            _unitOfWork.Commit();
            result = _productRepository.GetById( id );
            Assert.Equal( "D", result.Code );
        }

        /// <summary>
        /// 测试异步更新
        /// </summary>
        [Fact]
        public async Task TestUpdateAsync() {
            int id = _random.Next( 999999999 );
            var product = new Product( id ) { Name = "Name", Code = "Code" };
            await _productRepository.AddAsync( product );
            await _unitOfWork.CommitAsync();
            _unitOfWork.ClearCache();

            //Find出来修改，必须调用Update方法才能生效
            product = await _productRepository.FindAsync( id );
            product.Code = "B";
            await _productRepository.UpdateAsync( product );
            await _unitOfWork.CommitAsync();
            var result = _productRepository.GetById( id );
            Assert.Equal( "B", result.Code );
            _unitOfWork.ClearCache();

            //手工定义一个待更新对象,调用Update
            var old = await _productRepository.FindAsync( id );
            product = new Product( id ) { Name = "Name", Code = "C", Version = old.Version };
            await _productRepository.UpdateAsync( product );
            await _unitOfWork.CommitAsync();
            result = _productRepository.GetById( id );
            Assert.Equal( "C", result.Code );
            _unitOfWork.ClearCache();
        }

        /// <summary>
        /// 测试删除 - 传入实体标识
        /// </summary>
        [Fact]
        public void TestRemove_Key() {
            int id = _random.Next( 999999999 );
            var product = new Product( id ) { Name = "Name", Code = "Code" };
            _productRepository.Add( product );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            _productRepository.Remove( id );
            _unitOfWork.Commit();

            var result = _productRepository.GetById( id );
            Assert.NotNull( result );
            Assert.True( result.IsDeleted );
        }

        /// <summary>
        /// 测试异步删除 - 传入实体标识
        /// </summary>
        [Fact]
        public async Task TestRemoveAsync_Key() {
            int id = _random.Next( 999999999 );
            var product = new Product( id ) { Name = "Name", Code = "Code" };
            await _productRepository.AddAsync( product );
            await _unitOfWork.CommitAsync();
            _unitOfWork.ClearCache();

            await _productRepository.RemoveAsync( id );
            await _unitOfWork.CommitAsync();

            Assert.True( _productRepository.Exists( id ) );
            Assert.True( _productRepository.GetById( id ).IsDeleted );
        }

        /// <summary>
        /// 测试删除 - 传入实体
        /// </summary>
        [Fact]
        public void TestRemove_Entity() {
            int id = _random.Next( 999999999 );
            var product = new Product( id ) { Name = "Name", Code = "Code" };
            _productRepository.Add( product );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            product = _productRepository.Find( id );
            _productRepository.Remove( product );
            _unitOfWork.Commit();

            var result = _productRepository.GetById( id );
            Assert.NotNull( result );
            Assert.True( result.IsDeleted );
        }

        /// <summary>
        /// 测试异步删除 - 传入实体
        /// </summary>
        [Fact]
        public async Task TestRemoveAsync_Entity() {
            int id = _random.Next( 999999999 );
            var product = new Product( id ) { Name = "Name", Code = "Code" };
            await _productRepository.AddAsync( product );
            await _unitOfWork.CommitAsync();
            _unitOfWork.ClearCache();

            product = await _productRepository.FindAsync( id );
            await _productRepository.RemoveAsync( product );
            await _unitOfWork.CommitAsync();

            Assert.True( await _productRepository.ExistsAsync( id ) );
            Assert.True( _productRepository.GetById( id ).IsDeleted );
        }

        /// <summary>
        /// 测试删除 - 通过实体标识集合删除
        /// </summary>
        [Fact]
        public void TestRemove_Key_List() {
            int id = _random.Next( 999999999 );
            int id2 = _random.Next( 999999999 );
            var product = new Product( id ) { Name = "Name", Code = "Code" };
            var product2 = new Product( id2 ) { Name = "Name", Code = "Code" };
            _productRepository.Add( new[] { product, product2 } );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            var result = _productRepository.FindByIds( id, id2 );
            Assert.Equal( 2, result.Count );

            _productRepository.Remove( new[]{ id, id2 } );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            result = _productRepository.FindByIds( id, id2 );
            Assert.Equal( 2, result.Count );
            Assert.True( result[0].IsDeleted );
            Assert.True( result[1].IsDeleted );
        }

        /// <summary>
        /// 测试删除 - 通过实体集合删除
        /// </summary>
        [Fact]
        public void TestRemove_Entity_List() {
            int id = _random.Next( 999999999 );
            int id2 = _random.Next( 999999999 );
            var product = new Product( id ) { Name = "Name", Code = "Code" };
            var product2 = new Product( id2 ) { Name = "Name", Code = "Code" };
            _productRepository.Add( new[] { product, product2 } );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            var result = _productRepository.FindByIds( id, id2 );
            Assert.Equal( 2, result.Count );

            _productRepository.Remove( result );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            result = _productRepository.FindByIds( id, id2 );
            Assert.Equal( 2, result.Count );
            Assert.True( result[0].IsDeleted );
            Assert.True( result[1].IsDeleted );
        }

        /// <summary>
        /// 测试异步删除 - 通过实体标识集合删除
        /// </summary>
        [Fact]
        public async Task TestRemoveAsync_Key_List() {
            int id = _random.Next( 999999999 );
            int id2 = _random.Next( 999999999 );
            var product = new Product( id ) { Name = "Name", Code = "Code" };
            var product2 = new Product( id2 ) { Name = "Name", Code = "Code" };
            await _productRepository.AddAsync( new[] { product, product2 } );
            await _unitOfWork.CommitAsync();
            _unitOfWork.ClearCache();

            var result = await _productRepository.FindByIdsAsync( id, id2 );
            Assert.Equal( 2, result.Count );

            await _productRepository.RemoveAsync( new[] { id, id2 } );
            await _unitOfWork.CommitAsync();
            _unitOfWork.ClearCache();

            result = await _productRepository.FindByIdsAsync( id, id2 );
            Assert.Equal( 2, result.Count );
            Assert.True( result[0].IsDeleted );
            Assert.True( result[1].IsDeleted );
        }

        /// <summary>
        /// 测试异步删除 - 通过实体集合删除
        /// </summary>
        [Fact]
        public async Task TestRemoveAsync_Entity_List() {
            int id = _random.Next( 999999999 );
            int id2 = _random.Next( 999999999 );
            var product = new Product( id ) { Name = "Name", Code = "Code" };
            var product2 = new Product( id2 ) { Name = "Name", Code = "Code" };
            await _productRepository.AddAsync( new[] { product, product2 } );
            await _unitOfWork.CommitAsync();
            _unitOfWork.ClearCache();

            var result = await _productRepository.FindByIdsAsync( id, id2 );
            Assert.Equal( 2, result.Count );

            await _productRepository.RemoveAsync( result );
            await _unitOfWork.CommitAsync();
            _unitOfWork.ClearCache();

            result = await _productRepository.FindByIdsAsync( id, id2 );
            Assert.Equal( 2, result.Count );
            Assert.True( result[0].IsDeleted );
            Assert.True( result[1].IsDeleted );
        }
    }
}

