﻿using System;
using System.Linq.Expressions;

namespace Util.Datas.Sql.Queries.Builders.Abstractions {
    /// <summary>
    /// 实体解析器
    /// </summary>
    public interface IEntityResolver {
        /// <summary>
        /// 获取表
        /// </summary>
        /// <param name="entity">实体类型</param>
        string GetTable( Type entity );
        /// <summary>
        /// 获取架构
        /// </summary>
        /// <param name="entity">实体类型</param>
        string GetSchema( Type entity );
        /// <summary>
        /// 获取列名
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="columns">列名表达式</param>
        string GetColumns<TEntity>( Expression<Func<TEntity, object[]>> columns );
        /// <summary>
        /// 获取列名
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="column">列名表达式</param>
        string GetColumn<TEntity>( Expression<Func<TEntity, object>> column );
        /// <summary>
        /// 获取列名
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <param name="entity">实体类型</param>
        /// <param name="right">是否取右侧操作数</param>
        string GetColumn( Expression expression, Type entity, bool right = false );
    }
}
