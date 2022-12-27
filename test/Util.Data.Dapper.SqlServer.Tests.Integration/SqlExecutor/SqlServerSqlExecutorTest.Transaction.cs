using System;
using System.Threading.Tasks;
using Util.Data.Sql;
using Util.Tests.Configs;
using Xunit;

namespace Util.Data.Dapper.Tests.SqlExecutor {
    /// <summary>
    /// Sql Server Sql执行器测试 - 事务测试
    /// </summary>
    public partial class SqlServerSqlExecutorTest {
        /// <summary>
        /// 测试事务操作 - 不使用事务,第一次操作成功,第二次失败
        /// </summary>
        [Fact]
        public async Task TestTransaction_1() {
            //创建两个Id
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();

            try {
                //插入Id成功
                await _sqlExecutor
                    .Insert( "ProductId,Code", "Products.Product" )
                    .Values( id, TestConfig.Value )
                    .ExecuteAsync();

                //Code2列名错误,插入Id2失败
                await _sqlExecutor
                    .Insert( "ProductId,Code,Code2", "Products.Product" )
                    .Values( id2, TestConfig.Value, TestConfig.Value )
                    .ExecuteAsync();
            }
            catch {
                // ignored
            }

            //断言
            var exists = await _sqlExecutor.From( "Products.Product" ).Where( "ProductId", id ).ExecuteExistsAsync();
            var exists2 = await _sqlExecutor.From( "Products.Product" ).Where( "ProductId", id2 ).ExecuteExistsAsync();
            Assert.True( exists );
            Assert.False( exists2 );
        }

        /// <summary>
        /// 测试事务操作 - 调用BeginTransaction,CommitTransaction,RollbackTransaction
        /// </summary>
        [Fact]
        public async Task TestTransaction_2() {
            //开始事务
            _sqlExecutor.BeginTransaction();

            //创建两个Id
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();

            try {
                //插入Id成功
                await _sqlExecutor
                    .Insert( "ProductId,Code", "Products.Product" )
                    .Values( id, TestConfig.Value )
                    .ExecuteAsync();

                //Code2列名错误,插入Id2失败
                await _sqlExecutor
                    .Insert( "ProductId,Code,Code2", "Products.Product" )
                    .Values( id2, TestConfig.Value, TestConfig.Value )
                    .ExecuteAsync();

                //提交事务
                _sqlExecutor.CommitTransaction();
            }
            catch {
                //回滚事务
                _sqlExecutor.RollbackTransaction();
            }

            //断言
            var exists = await _sqlExecutor.From( "Products.Product" ).Where( "ProductId", id ).ExecuteExistsAsync();
            var exists2 = await _sqlExecutor.From( "Products.Product" ).Where( "ProductId", id2 ).ExecuteExistsAsync();
            Assert.False( exists );
            Assert.False( exists2 );
        }

        /// <summary>
        /// 测试事务操作 - 使用using调用BeginTransaction
        /// </summary>
        [Fact]
        public async Task TestTransaction_3() {
            //创建两个Id
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();

            try {
                using var transaction = _sqlExecutor.BeginTransaction();
                //插入Id成功
                await _sqlExecutor
                    .Insert( "ProductId,Code", "Products.Product" )
                    .Values( id, TestConfig.Value )
                    .ExecuteAsync();

                //Code2列名错误,插入Id2失败
                await _sqlExecutor
                    .Insert( "ProductId,Code,Code2", "Products.Product" )
                    .Values( id2, TestConfig.Value, TestConfig.Value )
                    .ExecuteAsync();

                //提交事务
                transaction.Commit();
            }
            catch {
                // ignored
            }

            //断言
            var exists = await _sqlExecutor.From( "Products.Product" ).Where( "ProductId", id ).ExecuteExistsAsync();
            var exists2 = await _sqlExecutor.From( "Products.Product" ).Where( "ProductId", id2 ).ExecuteExistsAsync();
            Assert.False( exists );
            Assert.False( exists2 );
        }

        /// <summary>
        /// 测试事务操作 - 外部传入事务
        /// </summary>
        [Fact]
        public async Task TestTransaction_4() {
            //Sql执行器实例2开始事务
            _sqlExecutor2.BeginTransaction();
            var transaction = _sqlExecutor2.GetTransaction();

            //设置Sql执行器实例1事务
            _sqlExecutor.SetTransaction( transaction );

            //创建两个Id
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();

            try {
                //插入Id成功
                await _sqlExecutor
                    .Insert( "ProductId,Code", "Products.Product" )
                    .Values( id, TestConfig.Value )
                    .ExecuteAsync();

                //Code2列名错误,插入Id2失败
                await _sqlExecutor2
                    .Insert( "ProductId,Code,Code2", "Products.Product" )
                    .Values( id2, TestConfig.Value, TestConfig.Value )
                    .ExecuteAsync();

                //提交事务
                _sqlExecutor.CommitTransaction();
            }
            catch {
                //回滚事务
                _sqlExecutor.RollbackTransaction();
            }

            //断言
            var exists = await _sqlExecutor.From( "Products.Product" ).Where( "ProductId", id ).ExecuteExistsAsync();
            var exists2 = await _sqlExecutor.From( "Products.Product" ).Where( "ProductId", id2 ).ExecuteExistsAsync();
            Assert.False( exists );
            Assert.False( exists2 );
        }

        /// <summary>
        /// 测试事务操作 - 成功提交
        /// </summary>
        [Fact]
        public async Task TestTransaction_5() {
            //开始事务
            _sqlExecutor.BeginTransaction();

            //创建两个Id
            var id = Guid.NewGuid();
            var id2 = Guid.NewGuid();

            try {
                //插入Id成功
                await _sqlExecutor
                    .Insert( "ProductId,Code", "Products.Product" )
                    .Values( id, TestConfig.Value )
                    .ExecuteAsync();

                //插入Id2成功
                await _sqlExecutor
                    .Insert( "ProductId,Code", "Products.Product" )
                    .Values( id2, TestConfig.Value )
                    .ExecuteAsync();

                //提交事务
                _sqlExecutor.CommitTransaction();
            }
            catch {
                //回滚事务
                _sqlExecutor.RollbackTransaction();
            }

            //断言
            var exists = await _sqlExecutor.From( "Products.Product" ).Where( "ProductId", id ).ExecuteExistsAsync();
            var exists2 = await _sqlExecutor.From( "Products.Product" ).Where( "ProductId", id2 ).ExecuteExistsAsync();
            Assert.True( exists );
            Assert.True( exists2 );
        }
    }
}
