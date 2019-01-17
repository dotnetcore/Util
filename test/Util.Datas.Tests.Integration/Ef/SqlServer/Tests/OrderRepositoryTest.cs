using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Util.Datas.Ef;
using Util.Datas.Tests.Commons.Domains.Models;
using Util.Datas.Tests.Commons.Domains.Repositories;
using Util.Datas.Tests.Ef.SqlServer.UnitOfWorks;
using Util.Datas.Tests.XUnitHelpers;
using Util.Dependency;
using Util.Exceptions;
using Util.Helpers;
using Xunit;

namespace Util.Datas.Tests.Ef.SqlServer.Tests {
    /// <summary>
    /// 订单仓储测试
    /// </summary>
    [Collection( "GlobalConfig" )]
    public class OrderRepositoryTest : IDisposable {
        /// <summary>
        /// 容器作用域
        /// </summary>
        private readonly IScope _scope;
        /// <summary>
        /// 工作单元
        /// </summary>
        private readonly ISqlServerUnitOfWork _unitOfWork;
        /// <summary>
        /// 订单仓储
        /// </summary>
        private readonly IOrderRepository _orderRepository;
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
        public OrderRepositoryTest() {
            _scope = Ioc.BeginScope();
            _unitOfWork = _scope.Create<ISqlServerUnitOfWork>();
            _orderRepository = _scope.Create<IOrderRepository>();
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
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            _orderRepository.Add( order );
            _unitOfWork.Commit();

            var result = _orderRepository.Single( t => t.Id == id );
            Assert.Equal( "Name", result.Name );
        }

        /// <summary>
        /// 测试添加 - 添加子实体
        /// </summary>
        [Fact]
        public void TestAdd_Items() {
            //创建两个商品
            var product1 = new Product( _random.Next( 999999999 ) ) { Name = "dotnet", Code = "1", Price = 10 };
            _productRepository.Add( product1 );
            var product2 = new Product( _random.Next( 999999999 ) ) { Name = "dotnetcore", Code = "2", Price = 20 };
            _productRepository.Add( product2 );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            //创建订单，添加两个订单明细
            Guid orderId = Guid.NewGuid();
            var order = new Order( orderId ) { Name = "Order", Code = "123" };
            order.AddItem( product1, 2 );
            order.AddItem( product2, 3 );
            _orderRepository.Add( order );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            //验证
            var result = _orderRepository.Find().Include( t => t.Items ).FirstOrDefault( t => t.Id == orderId );
            Assert.Equal( "123", result.Code );
            Assert.Equal( 2, result.Items.Count );

            //从外部无法通过导航属性添加订单明细，必须调用AddItem方法
            var item = new OrderItem( Guid.NewGuid(), result );
            item.Booking( product1, 2 );
            var items = result.Items.ToList();
            items.Add( item );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();
            result = _orderRepository.Find().Include( t => t.Items ).FirstOrDefault( t => t.Id == orderId );
            Assert.Equal( 2, result.Items.Count );
        }

        /// <summary>
        /// 测试添加 - 添加集合
        /// </summary>
        [Fact]
        public void TestAdd_List() {
            Guid id = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            var order2 = new Order( id2 ) { Name = "Name", Code = "Code" };
            _orderRepository.Add( new[] { order, order2 } );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            var result = _orderRepository.FindByIds( id, id2 );
            Assert.Equal( 2, result.Count );
        }

        /// <summary>
        /// 测试异步添加
        /// </summary>
        [Fact]
        public async Task TestAddAsync() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            await _orderRepository.AddAsync( order );
            await _unitOfWork.CommitAsync();

            var result = await _orderRepository.SingleAsync( t => t.Id == id );
            Assert.Equal( id, result.Id );
        }

        /// <summary>
        /// 测试异步添加 - 添加集合
        /// </summary>
        [Fact]
        public async Task TestAddAsync_List() {
            Guid id = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            var order2 = new Order( id2 ) { Name = "Name", Code = "Code" };
            await _orderRepository.AddAsync( new[] { order, order2 } );
            await _unitOfWork.CommitAsync();
            _unitOfWork.ClearCache();

            var result = await _orderRepository.FindByIdsAsync( id, id2 );
            Assert.Equal( 2, result.Count );
        }

        /// <summary>
        /// 测试更新 - 修改方式1：先从仓储中查找出来，直接修改对象属性，提交工作单元
        /// </summary>
        [Fact]
        public void TestUpdate_1() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            _orderRepository.Add( order );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            order = _orderRepository.Find( id );
            order.Code = "B";
            _unitOfWork.Commit();

            var result = _orderRepository.FindByIdNoTracking( id );
            Assert.Equal( "B", result.Code );
        }

        /// <summary>
        /// 测试更新 - 修改方式2：创建出修改对象，调用仓储的Update，提交工作单元
        /// 应用场景：通过Http Put方法传入DTO,该DTO包含待修改实体的全部属性，将该DTO转成待更新实体
        /// 注意：创建的更新实体必须包含全部数据，否则导致数据丢失
        /// </summary>
        [Fact]
        public void TestUpdate_2() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            _orderRepository.Add( order );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            order = new Order( id ) { Name = "Name", Code = "B", Version = order.Version };
            _orderRepository.Update( order );
            _unitOfWork.Commit();

            var result = _orderRepository.Single( t => t.Id == id );
            Assert.Equal( "B", result.Code );
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        [Fact]
        public void TestUpdate_Batch() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            Guid id2 = Guid.NewGuid();
            var order2 = new Order( id2 ) { Name = "Name2", Code = "Code2" };
            var list = new List<Order> {
                order,order2
            };
            _orderRepository.Add( list );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            order = new Order( id ) { Name = "Name", Code = "A", Version = order.Version };
            order2 = new Order( id2 ) { Name = "Name2", Code = "B", Version = order2.Version };
            list = new List<Order> {
                order,order2
            };
            _orderRepository.Update( list );
            _unitOfWork.Commit();

            order = _orderRepository.FindByIdNoTracking( id );
            Assert.Equal( "A", order.Code );
            order2 = _orderRepository.FindByIdNoTracking( id2 );
            Assert.Equal( "B", order2.Code );
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        [Fact]
        public void TestUpdate_Batch_2() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            Guid id2 = Guid.NewGuid();
            var order2 = new Order( id2 ) { Name = "Name2", Code = "Code2" };
            var list = new List<Order> {
                order,order2
            };
            _orderRepository.Add( list );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            order = _orderRepository.Find( id );
            order.Code = "A";
            order2 = _orderRepository.Find( id2 );
            order2.Code = "B";
            list = new List<Order> {
                order,order2
            };
            _orderRepository.Update( list );
            _unitOfWork.Commit();

            order = _orderRepository.FindByIdNoTracking( id );
            Assert.Equal( "A", order.Code );
            order2 = _orderRepository.FindByIdNoTracking( id2 );
            Assert.Equal( "B", order2.Code );
        }

        /// <summary>
        /// 测试更新 - 更新子实体
        /// </summary>
        [Fact]
        public void TestUpdate_Items() {
            //创建两个商品
            var product1 = new Product( _random.Next( 999999999 ) ) { Name = "dotnet", Code = "1", Price = 10 };
            _productRepository.Add( product1 );
            var product2 = new Product( _random.Next( 999999999 ) ) { Name = "dotnetcore", Code = "2", Price = 20 };
            _productRepository.Add( product2 );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            //创建订单，添加两个订单明细
            Guid orderId = Guid.NewGuid();
            var order = new Order( orderId ) { Name = "Order", Code = "123" };
            order.AddItem( product1, 2 );
            order.AddItem( product2, 3 );
            _orderRepository.Add( order );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            //验证
            order = _orderRepository.Find().Include( t => t.Items ).FirstOrDefault( t => t.Id == orderId );
            Assert.Equal( 2, order.Items.Count );

            //获取订单明细标识
            var itemId = order.Items.ToList()[0].Id;
            var itemId2 = order.Items.ToList()[1].Id;

            //移除一个订单明细
            order.RemoveItem( itemId );
            //修改一个订单明细
            var item = order.FindItem( itemId2 );
            item.Booking( product1, 4 );
            //提交
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            //验证
            order = _orderRepository.Find().Include( t => t.Items ).FirstOrDefault( t => t.Id == orderId );
            Assert.Equal( 1, order.Items.Count );
            Assert.Equal( 4, order.Items.ToList()[0].Quantity );
        }

        /// <summary>
        /// 测试异步更新
        /// </summary>
        [Fact]
        public async Task TestUpdateAsync() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            await _orderRepository.AddAsync( order );
            await _unitOfWork.CommitAsync();
            _unitOfWork.ClearCache();

            var oldEntity = await _orderRepository.FindAsync( id );
            order = new Order( id ) { Name = "Name", Code = "B", Version = oldEntity.Version };
            await _orderRepository.UpdateAsync( order );
            await _unitOfWork.CommitAsync();

            var result = await _orderRepository.SingleAsync( t => t.Id == id );
            Assert.Equal( "B", result.Code );
        }

        /// <summary>
        /// 测试更新并发
        /// </summary>
        [Fact]
        public void TestConcurrency() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            _orderRepository.Add( order );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            Assert.Throws<ConcurrencyException>( () => {
                var order2 = new Order( id ) { Name = "Name", Code = "B", Version = Guid.NewGuid().ToByteArray() };
                _orderRepository.Update( order2 );
                _unitOfWork.Commit();
            } );
        }

        /// <summary>
        /// 测试更新并发 - 在Find出来的对象触发乐观锁
        /// </summary>
        [Fact]
        public void TestConcurrency_2() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            _orderRepository.Add( order );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            Assert.Throws<ConcurrencyException>( () => {
                var order2 = _orderRepository.Find( id );
                order2.Code = "a";
                order2.Version = Guid.NewGuid().ToByteArray();
                _orderRepository.Update( order2 );
                _unitOfWork.Commit();
            } );
        }

        /// <summary>
        /// 测试删除 - 通过实体标识删除
        /// </summary>
        [Fact]
        public void TestRemove_Key() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            _orderRepository.Add( order );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            _orderRepository.Remove( id );
            _unitOfWork.Commit();

            Assert.False( _orderRepository.Exists( t => t.Id == id ) );
        }

        /// <summary>
        /// 测试异步删除 - 通过实体标识删除
        /// </summary>
        [Fact]
        public async Task TestRemoveAsync_Key() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            await _orderRepository.AddAsync( order );
            await _unitOfWork.CommitAsync();
            _unitOfWork.ClearCache();

            await _orderRepository.RemoveAsync( id );
            await _unitOfWork.CommitAsync();

            Assert.False( await _orderRepository.ExistsAsync( t => t.Id == id ) );
        }

        /// <summary>
        /// 测试删除 - 通过实体删除 - Find查出来，Remove
        /// </summary>
        [Fact]
        public void TestRemove_Entity() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            _orderRepository.Add( order );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            order = _orderRepository.Find( id );
            Assert.NotNull( order );
            _orderRepository.Remove( order );
            _unitOfWork.Commit();

            Assert.False( _orderRepository.Exists( id ) );
        }

        /// <summary>
        /// 测试删除 - 通过实体删除 - 创建待删除实体,Remove
        /// </summary>
        [Fact]
        public void TestRemove_Entity_2() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            _orderRepository.Add( order );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            _orderRepository.Find( id );
            order = new Order( id ) { Name = "Name", Code = "Code", Version = order.Version };
            _orderRepository.Remove( order );
            _unitOfWork.Commit();

            Assert.False( _orderRepository.Exists( id ) );
        }

        /// <summary>
        /// 测试异步删除 - 通过实体删除
        /// </summary>
        [Fact]
        public async Task TestRemoveAsync_Entity() {
            Guid id = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            await _orderRepository.AddAsync( order );
            await _unitOfWork.CommitAsync();
            _unitOfWork.ClearCache();

            order = await _orderRepository.FindAsync( id );
            Assert.NotNull( order );
            await _orderRepository.RemoveAsync( order );
            await _unitOfWork.CommitAsync();

            Assert.False( await _orderRepository.ExistsAsync( id ) );
        }

        /// <summary>
        /// 测试删除 - 通过实体标识集合删除
        /// </summary>
        [Fact]
        public void TestRemove_Key_List() {
            Guid id = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            var order2 = new Order( id2 ) { Name = "Name", Code = "Code" };
            _orderRepository.Add( new[] { order, order2 } );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            var result = _orderRepository.FindByIds( id, id2 );
            Assert.Equal( 2, result.Count );

            _orderRepository.Remove( new[] { id, id2 } );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            Assert.False( _orderRepository.Exists( id, id2 ) );
        }

        /// <summary>
        /// 测试删除 - 通过实体集合删除
        /// </summary>
        [Fact]
        public void TestRemove_Entity_List() {
            Guid id = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            var order2 = new Order( id2 ) { Name = "Name", Code = "Code" };
            _orderRepository.Add( new[] { order, order2 } );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            var result = _orderRepository.FindByIds( $"{id},{id2}" );
            Assert.Equal( 2, result.Count );

            _orderRepository.Remove( result );
            _unitOfWork.Commit();
            _unitOfWork.ClearCache();

            Assert.False( _orderRepository.Exists( id, id2 ) );
        }

        /// <summary>
        /// 测试异步删除 - 通过实体标识集合删除
        /// </summary>
        [Fact]
        public async Task TestRemoveAsync_Key_List() {
            Guid id = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            var order2 = new Order( id2 ) { Name = "Name", Code = "Code" };
            await _orderRepository.AddAsync( new[] { order, order2 } );
            await _unitOfWork.CommitAsync();
            _unitOfWork.ClearCache();

            var result = await _orderRepository.FindByIdsAsync( id, id2 );
            Assert.Equal( 2, result.Count );

            await _orderRepository.RemoveAsync( new[] { id, id2 } );
            await _unitOfWork.CommitAsync();
            _unitOfWork.ClearCache();

            Assert.False( await _orderRepository.ExistsAsync( id, id2 ) );
        }

        /// <summary>
        /// 测试异步删除 - 通过实体集合删除
        /// </summary>
        [Fact]
        public async Task TestRemoveAsync_Entity_List() {
            Guid id = Guid.NewGuid();
            Guid id2 = Guid.NewGuid();
            var order = new Order( id ) { Name = "Name", Code = "Code" };
            var order2 = new Order( id2 ) { Name = "Name", Code = "Code" };
            await _orderRepository.AddAsync( new[] { order, order2 } );
            await _unitOfWork.CommitAsync();
            _unitOfWork.ClearCache();

            var result = await _orderRepository.FindByIdsAsync( $"{id},{id2}" );
            Assert.Equal( 2, result.Count );

            await _orderRepository.RemoveAsync( result );
            await _unitOfWork.CommitAsync();
            _unitOfWork.ClearCache();

            Assert.False( await _orderRepository.ExistsAsync( id, id2 ) );
        }
    }
}
