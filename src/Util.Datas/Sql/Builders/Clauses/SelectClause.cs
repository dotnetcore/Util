using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Util.Datas.Sql.Builders.Core;
using Util.Datas.Sql.Builders.Internal;

namespace Util.Datas.Sql.Builders.Clauses {
    /// <summary>
    /// Select子句
    /// </summary>
    public class SelectClause : ISelectClause {
        /// <summary>
        /// Sql生成器
        /// </summary>
        private readonly ISqlBuilder _sqlBuilder;
        /// <summary>
        /// 方言
        /// </summary>
        private readonly IDialect _dialect;
        /// <summary>
        /// 实体解析器
        /// </summary>
        private readonly IEntityResolver _resolver;
        /// <summary>
        /// 实体别名注册器
        /// </summary>
        private readonly IEntityAliasRegister _register;
        /// <summary>
        /// 列名集合
        /// </summary>
        private readonly List<ColumnCollection> _columns;
        /// <summary>
        /// 是否排除重复记录
        /// </summary>
        private bool _distinct;

        /// <summary>
        /// 初始化Select子句
        /// </summary>
        /// <param name="sqlBuilder">Sql生成器</param>
        /// <param name="dialect">方言</param>
        /// <param name="resolver">实体解析器</param>
        /// <param name="register">实体注册器</param>
        /// <param name="columns">列名集合</param>
        public SelectClause( ISqlBuilder sqlBuilder, IDialect dialect, IEntityResolver resolver, IEntityAliasRegister register, List<ColumnCollection> columns = null ) {
            _sqlBuilder = sqlBuilder;
            _dialect = dialect;
            _resolver = resolver;
            _register = register;
            _columns = columns ?? new List<ColumnCollection>();
        }

        /// <summary>
        /// 复制Select子句
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="register">实体别名注册器</param>
        public virtual ISelectClause Clone( ISqlBuilder builder, IEntityAliasRegister register ) {
            return new SelectClause( builder, _dialect, _resolver, register, new List<ColumnCollection>( _columns ) );
        }

        /// <summary>
        /// 过滤重复记录
        /// </summary>
        public void Distinct() {
            _distinct = true;
        }

        /// <summary>
        /// 求总行数
        /// </summary>
        /// <param name="columnAlias">列别名</param>
        public void Count( string columnAlias = null ) {
            if( string.IsNullOrWhiteSpace( columnAlias ) ) {
                Aggregate( "Count(*)" );
                return;
            }
            Aggregate( $"Count(*) As {_dialect.SafeName( columnAlias )}" );
        }

        /// <summary>
        /// 求总行数
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        public void Count( string column, string columnAlias ) {
            Aggregate( "Count", column, columnAlias );
        }

        /// <summary>
        /// 求总行数
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public void Count<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            var column = _resolver.GetColumn( expression );
            Count( column, columnAlias );
        }

        /// <summary>
        /// 聚合
        /// </summary>
        /// <param name="sql">Sql语句</param>
        private void Aggregate( string sql ) {
            _columns.Add( new ColumnCollection( sql, isAggregation: true ) );
        }

        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        public void Sum( string column, string columnAlias = null ) {
            Aggregate( "Sum", column, columnAlias );
        }

        /// <summary>
        /// 聚合
        /// </summary>
        private void Aggregate( string fun, string column, string columnAlias ) {
            if( string.IsNullOrWhiteSpace( columnAlias ) ) {
                Aggregate( $"{fun}({_dialect.SafeName( column )})" );
                return;
            }
            Aggregate( $"{fun}({_dialect.SafeName( column )}) As {_dialect.SafeName( columnAlias )}" );
        }

        /// <summary>
        /// 求和
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public void Sum<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            var column = _resolver.GetColumn( expression );
            Sum( column, columnAlias );
        }

        /// <summary>
        /// 求平均值
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        public void Avg( string column, string columnAlias = null ) {
            Aggregate( "Avg", column, columnAlias );
        }

        /// <summary>
        /// 求平均值
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public void Avg<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            var column = _resolver.GetColumn( expression );
            Avg( column, columnAlias );
        }

        /// <summary>
        /// 求最大值
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        public void Max( string column, string columnAlias = null ) {
            Aggregate( "Max", column, columnAlias );
        }

        /// <summary>
        /// 求最大值
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public void Max<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            var column = _resolver.GetColumn( expression );
            Max( column, columnAlias );
        }

        /// <summary>
        /// 求最小值
        /// </summary>
        /// <param name="column">列</param>
        /// <param name="columnAlias">列别名</param>
        public void Min( string column, string columnAlias = null ) {
            Aggregate( "Min", column, columnAlias );
        }

        /// <summary>
        /// 求最小值
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public void Min<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            var column = _resolver.GetColumn( expression );
            Min( column, columnAlias );
        }

        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="columns">列名</param>
        /// <param name="tableAlias">表别名</param>
        public void Select( string columns, string tableAlias = null ) {
            if( string.IsNullOrWhiteSpace( columns ) )
                return;
            _columns.Add( new ColumnCollection( columns, tableAlias ) );
        }

        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="propertyAsAlias">是否将属性名映射为列别名</param>
        public void Select<TEntity>( Expression<Func<TEntity, object[]>> expression, bool propertyAsAlias = false ) where TEntity : class {
            if( expression == null )
                return;
            _columns.Add( new ColumnCollection( _resolver.GetColumns( expression, propertyAsAlias ), tableType: typeof( TEntity ) ) );
        }

        /// <summary>
        /// 设置列名
        /// </summary>
        /// <param name="expression">列名表达式</param>
        /// <param name="columnAlias">列别名</param>
        public void Select<TEntity>( Expression<Func<TEntity, object>> expression, string columnAlias = null ) where TEntity : class {
            if( expression == null )
                return;
            var column = _resolver.GetColumn( expression );
            if( string.IsNullOrWhiteSpace( column ) )
                return;
            if( column.Contains( "As" ) == false && string.IsNullOrWhiteSpace( columnAlias ) == false )
                column += $" As {columnAlias}";
            _columns.Add( new ColumnCollection( column, tableType: typeof( TEntity ) ) );
        }

        /// <summary>
        /// 设置子查询列
        /// </summary>
        /// <param name="builder">Sql生成器</param>
        /// <param name="columnAlias">列别名</param>
        public void Select( ISqlBuilder builder, string columnAlias ) {
            if( builder == null )
                return;
            var result = builder.ToSql();
            if( string.IsNullOrWhiteSpace( columnAlias ) == false )
                result = $"({result}) As {_dialect.SafeName( columnAlias )}";
            AppendSql( result );
        }

        /// <summary>
        /// 设置子查询列
        /// </summary>
        /// <param name="action">子查询操作</param>
        /// <param name="columnAlias">列别名</param>
        public void Select( Action<ISqlBuilder> action, string columnAlias ) {
            if( action == null )
                return;
            var builder = _sqlBuilder.New();
            action( builder );
            Select( builder, columnAlias );
        }

        /// <summary>
        /// 添加到Select子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public void AppendSql( string sql ) {
            if( string.IsNullOrWhiteSpace( sql ) )
                return;
            sql = Helper.ResolveSql( sql, _dialect );
            _columns.Add( new ColumnCollection( sql, raw: true ) );
        }

        /// <summary>
        /// 输出Sql
        /// </summary>
        public string ToSql() {
            return $"Select {GetDistinct()}{GetColumns()}";
        }

        /// <summary>
        /// 获取Distinct
        /// </summary>
        private string GetDistinct() {
            if( _distinct )
                return "Distinct ";
            return null;
        }

        /// <summary>
        /// 获取列名
        /// </summary>
        protected virtual string GetColumns() {
            if( _columns.Count == 0 )
                return "*";
            var result = string.Empty;
            foreach( var item in _columns ) {
                result += item.ToSql( _dialect, _register );
                if( item.Raw == false )
                    result += ",";
            }
            return result.TrimEnd( ',' );
        }
    }
}
