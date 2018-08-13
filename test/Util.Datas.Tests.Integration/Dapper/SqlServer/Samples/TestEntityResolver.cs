using System;
using System.Linq;
using System.Linq.Expressions;
using Util.Datas.Sql.Queries.Builders.Abstractions;
using Util.Helpers;

namespace Util.Datas.Tests.Dapper.SqlServer.Samples {
    /// <summary>
    /// 实体解析器
    /// </summary>
    public class TestEntityResolver : IEntityResolver {
        /// <summary>
        /// 获取表
        /// </summary>
        /// <param name="entity">实体类型</param>
        public string GetTable( Type entity ) {
            return $"t_{entity.Name}";
        }

        /// <summary>
        /// 获取架构
        /// </summary>
        /// <param name="entity">实体类型</param>
        public string GetSchema( Type entity ) {
            return "s";
        }

        /// <summary>
        /// 获取列名
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="columns">列名表达式</param>
        public string GetColumns<TEntity>( Expression<Func<TEntity, object[]>> columns ) {
            return Lambda.GetLastNames( columns ).Select( column => $"t_{column}" ).Join();
        }

        public string GetColumn<TEntity>( Expression<Func<TEntity, object>> column ) {
            return $"t_{Lambda.GetLastName( column )}";
        }

        public string GetColumn( Expression expression, Type entity, bool right ) {
            return $"t_{Lambda.GetLastName( expression, right )}";
        }
    }
}