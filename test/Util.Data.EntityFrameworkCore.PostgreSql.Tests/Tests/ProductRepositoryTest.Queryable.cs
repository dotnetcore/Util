using System;
using System.Linq;
using Util.Data.EntityFrameworkCore.Conditions;
using Util.Data.EntityFrameworkCore.Fakes;
using Util.Data.Queries;
using Xunit;

namespace Util.Data.EntityFrameworkCore.Tests {
    /// <summary>
    /// 产品仓储测试 - 查询测试
    /// </summary>
    public partial class ProductRepositoryTest {

        #region Where

        /// <summary>
        /// 测试设置查询条件 - 添加查询条件对象
        /// </summary>
        [Fact]
        public void TestWhere() {
            //常量
            var name = "TestWhere";

            //添加实体列表
            AddProducts();
            var products = AddProducts( name: name );

            //创建查询条件
            var condition = new ProductNameCondition( name );

            //查询
            var result = _repository.Find().Where( condition ).OrderBy( t => t.Code ).ToList();

            //验证
            Assert.Equal( products.Count, result.Count );
            Assert.Equal( products[0].Code, result[0].Code );
            Assert.Equal( products[1].Code, result[1].Code );
        }

        #endregion

        #region WhereIf

        /// <summary>
        /// 测试设置查询条件 - IQueryable添加WhereIf扩展 - true
        /// </summary>
        [Fact]
        public void TestWhereIf_True() {
            //常量
            var name = "TestWhereIf_True";

            //添加实体列表
            AddProducts();
            var products = AddProducts( name: name );

            //查询
            var result = _repository.Find().WhereIf( t => t.Name == name, true ).ToList();

            //验证
            Assert.Equal( products.Count, result.Count );
        }

        /// <summary>
        /// 测试设置查询条件 - IQueryable添加WhereIf扩展 - false
        /// </summary>
        [Fact]
        public void TestWhereIf_False() {
            //常量
            var name = "TestWhereIf_False";

            //添加实体列表
            AddProducts();
            var products = AddProducts( name: name );

            //查询
            var result = _repository.Find().WhereIf( t => t.Name == name, false ).ToList();

            //验证
            Assert.NotEqual( products.Count, result.Count );
        }

        #endregion

        #region WhereIfNotEmpty

        /// <summary>
        /// 测试设置查询条件 - IQueryable添加WhereIfNotEmpty扩展 - 有效条件
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_Valid() {
            //常量
            var name = "TestWhereIfNotEmpty_Valid";

            //添加实体列表
            AddProducts();
            var products = AddProducts( name: name );

            //查询
            var result = _repository.Find().WhereIfNotEmpty( t => t.Name == name ).ToList();

            //验证
            Assert.Equal( products.Count, result.Count );
        }

        /// <summary>
        /// 测试设置查询条件 - IQueryable添加WhereIfNotEmpty扩展 - 忽略条件
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_Ignore() {
            //常量
            var name = "TestWhereIfNotEmpty_Ignore";

            //添加实体列表
            AddProducts();
            var products = AddProducts( name: name );

            //查询
            var result = _repository.Find().Where( t => t.Name == name ).WhereIfNotEmpty( t => t.Code == "" ).ToList();

            //验证
            Assert.Equal( products.Count, result.Count );
        }

        /// <summary>
        /// 测试设置查询条件 - IQueryable添加WhereIfNotEmpty扩展 - 无效条件,抛出异常
        /// </summary>
        [Fact]
        public void TestWhereIfNotEmpty_Invalid() {
            //添加实体列表
            AddProducts();

            //查询
            Assert.Throws<InvalidOperationException>( () => {
                _repository.Find().WhereIfNotEmpty( t => t.Name == "a" && t.Code == "b" );
            } );
        }

        #endregion

        #region OrIfNotEmpty

        /// <summary>
        /// 测试设置查询条件 - IQueryable添加OrIfNotEmpty扩展 - 有效条件
        /// </summary>
        [Fact]
        public void TestOrIfNotEmpty_Valid() {
            //常量
            var name1 = "TestOrIfNotEmpty_Valid_1";
            var name2 = "TestOrIfNotEmpty_Valid_2";
            var name3 = "TestOrIfNotEmpty_Valid_3";

            //添加实体列表
            AddProducts();
            AddProducts( 2, name1 );
            AddProducts( 3, name2 );
            AddProducts( 4, name3 );

            //查询
            var result = _repository.Find().OrIfNotEmpty( t => t.Name == name1,t => t.Name == name2, t => t.Name == name3 ).ToList();

            //验证
            Assert.Equal( 9, result.Count );
        }

        /// <summary>
        /// 测试设置查询条件 - IQueryable添加OrIfNotEmpty扩展 - 忽略条件
        /// </summary>
        [Fact]
        public void TestOrIfNotEmpty_Ignore() {
            //常量
            var name1 = "TestOrIfNotEmpty_Ignore_1";
            var name2 = "TestOrIfNotEmpty_Ignore_2";
            var name3 = "TestOrIfNotEmpty_Ignore_3";

            //添加实体列表
            AddProducts();
            AddProducts( 2, name1 );
            AddProducts( 3, name2 );
            AddProducts( 4, name3 );

            //查询
            var result = _repository.Find().OrIfNotEmpty( t => t.Name == name1, t => t.Name == name2, t => t.Name == "" ).ToList();

            //验证
            Assert.Equal( 5, result.Count );
        }

        #endregion

        #region Between

        /// <summary>
        /// 测试添加范围查询条件
        /// </summary>
        [Fact]
        public void TestBetween_1() {
            //常量
            var name = "TestBetween_1";
            var price = 10.1M;

            //添加实体列表
            AddProducts();
            var products = ProductFakeService.GetProducts( 5 );
            products.ForEach( product => {
                product.Init();
                product.Name = name;
                product.Price = price++;
            } );
            _repository.Add( products );
            UnitOfWork.Commit();
            UnitOfWork.ClearCache();

            //查询
            var result = _repository.Find().Where( t => t.Name == name ).Between( t => t.Price,11.5M,13.5M ).ToList();

            //验证
            Assert.Equal( 2, result.Count );
        }

        /// <summary>
        /// 测试添加范围查询条件 - 包含左边界
        /// </summary>
        [Fact]
        public void TestBetween_2() {
            //常量
            var name = "TestBetween_2";
            var price = 10.1M;

            //添加实体列表
            AddProducts();
            var products = ProductFakeService.GetProducts( 5 );
            products.ForEach( product => {
                product.Init();
                product.Name = name;
                product.Price = price++;
            } );
            _repository.Add( products );
            UnitOfWork.Commit();
            UnitOfWork.ClearCache();

            //查询
            var result = _repository.Find().Where( t => t.Name == name ).Between( t => t.Price, 11.1M, 13.1M,Boundary.Left ).ToList();

            //验证
            Assert.Equal( 2, result.Count );
        }

        /// <summary>
        /// 测试添加范围查询条件 - 包含右边界
        /// </summary>
        [Fact]
        public void TestBetween_3() {
            //常量
            var name = "TestBetween_3";
            var price = 10.1M;

            //添加实体列表
            AddProducts();
            var products = ProductFakeService.GetProducts( 5 );
            products.ForEach( product => {
                product.Init();
                product.Name = name;
                product.Price = price++;
            } );
            _repository.Add( products );
            UnitOfWork.Commit();
            UnitOfWork.ClearCache();

            //查询
            var result = _repository.Find().Where( t => t.Name == name ).Between( t => t.Price, 11.1M, 13.1M, Boundary.Right ).ToList();

            //验证
            Assert.Equal( 2, result.Count );
        }

        /// <summary>
        /// 测试添加范围查询条件 - 包含两边
        /// </summary>
        [Fact]
        public void TestBetween_4() {
            //常量
            var name = "TestBetween_4";
            var price = 10.1M;

            //添加实体列表
            AddProducts();
            var products = ProductFakeService.GetProducts( 5 );
            products.ForEach( product => {
                product.Init();
                product.Name = name;
                product.Price = price++;
            } );
            _repository.Add( products );
            UnitOfWork.Commit();
            UnitOfWork.ClearCache();

            //查询
            var result = _repository.Find().Where( t => t.Name == name ).Between( t => t.Price, 11.1M, 13.1M ).ToList();

            //验证
            Assert.Equal( 3, result.Count );
        }

        /// <summary>
        /// 测试添加范围查询条件 - 不包含边界
        /// </summary>
        [Fact]
        public void TestBetween_5() {
            //常量
            var name = "TestBetween_5";
            var price = 10.1M;

            //添加实体列表
            AddProducts();
            var products = ProductFakeService.GetProducts( 5 );
            products.ForEach( product => {
                product.Init();
                product.Name = name;
                product.Price = price++;
            } );
            _repository.Add( products );
            UnitOfWork.Commit();
            UnitOfWork.ClearCache();

            //查询
            var result = _repository.Find().Where( t => t.Name == name ).Between( t => t.Price, 11.1M, 13.1M,Boundary.Neither ).ToList();

            //验证
            Assert.Single( result );
        }

        /// <summary>
        /// 测试添加范围查询条件 - 最大值为空
        /// </summary>
        [Fact]
        public void TestBetween_6() {
            //常量
            var name = "TestBetween_6";
            var price = 10.1M;

            //添加实体列表
            AddProducts();
            var products = ProductFakeService.GetProducts( 5 );
            products.ForEach( product => {
                product.Init();
                product.Name = name;
                product.Price = price++;
            } );
            _repository.Add( products );
            UnitOfWork.Commit();
            UnitOfWork.ClearCache();

            //查询
            var result = _repository.Find().Where( t => t.Name == name ).Between( t => t.Price, 9.5M, null ).ToList();

            //验证
            Assert.Equal( 5, result.Count );
        }

        /// <summary>
        /// 测试添加范围查询条件 - 最小值为空
        /// </summary>
        [Fact]
        public void TestBetween_7() {
            //常量
            var name = "TestBetween_7";
            var price = 10.1M;

            //添加实体列表
            AddProducts();
            var products = ProductFakeService.GetProducts( 5 );
            products.ForEach( product => {
                product.Init();
                product.Name = name;
                product.Price = price++;
            } );
            _repository.Add( products );
            UnitOfWork.Commit();
            UnitOfWork.ClearCache();

            //查询
            var result = _repository.Find().Where( t => t.Name == name ).Between( t => t.Price, null, 15.5M ).ToList();

            //验证
            Assert.Equal( 5, result.Count );
        }

        #endregion
    }
}
