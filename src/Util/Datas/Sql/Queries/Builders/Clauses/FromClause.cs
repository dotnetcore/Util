using System;
using Util.Properties;
using Util.Datas.Sql.Queries.Builders.Abstractions;
using Util.Datas.Sql.Queries.Builders.Core;
using Util.Datas.Sql.Queries.Builders.Extensions;

namespace Util.Datas.Sql.Queries.Builders.Clauses {
    /// <summary>
    /// From子句
    /// </summary>
    public class FromClause : IFromClause {
        /// <summary>
        /// Sql项
        /// </summary>
        private SqlItem _item;
        /// <summary>
        /// 方言
        /// </summary>
        private readonly IDialect _dialect;
        /// <summary>
        /// 实体解析器
        /// </summary>
        private readonly IEntityResolver _resolver;
        /// <summary>
        /// 实体注册器
        /// </summary>
        private readonly IEntityAliasRegister _register;

        /// <summary>
        /// 初始化From子句
        /// </summary>
        /// <param name="dialect">方言</param>
        /// <param name="resolver">实体解析器</param>
        /// <param name="register">实体别名注册器</param>
        public FromClause( IDialect dialect, IEntityResolver resolver, IEntityAliasRegister register ) {
            _dialect = dialect;
            _resolver = resolver;
            _register = register;
        }

        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="alias">别名</param>
        public void From( string table, string alias = null ) {
            _item = CreateSqlItem( table, null, alias );
        }

        /// <summary>
        /// 创建Sql项
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="schema">架构名</param>
        /// <param name="alias">别名</param>
        protected virtual SqlItem CreateSqlItem( string table, string schema,string alias ) {
            return new SqlItem( table, schema, alias );
        }

        /// <summary>
        /// 设置表名
        /// </summary>
        /// <param name="alias">别名</param>
        /// <param name="schema">架构名</param>
        public void From<TEntity>( string alias = null, string schema = null ) where TEntity : class {
            var entity = typeof( TEntity );
            var table = _resolver.GetTableAndSchema( entity );
            _item = CreateSqlItem( table, schema, alias );
            _register.Register( entity, _resolver.GetAlias( entity, alias ) );
        }

        /// <summary>
        /// 添加到From子句
        /// </summary>
        /// <param name="sql">Sql语句</param>
        public void AppendSql( string sql ) {
            if( _item != null && _item.Raw ) {
                _item.Name += sql;
                return;
            }
            _item = new SqlItem( sql, raw: true );
        }

        /// <summary>
        /// 验证
        /// </summary>
        public void Validate() {
            if( string.IsNullOrWhiteSpace( _item?.Name ) )
                throw new InvalidOperationException( LibraryResource.TableIsEmpty );
        }

        /// <summary>
        /// 输出Sql
        /// </summary>
        public string ToSql() {
            var table = _item?.ToSql( _dialect );
            if( string.IsNullOrWhiteSpace( table ) )
                return null;
            return $"From {table}";
        }
    }
}
