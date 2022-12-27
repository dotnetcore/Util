using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util.Data.Sql.Builders.Clauses;
using Util.Helpers;

namespace Util.Data.Sql.Builders.Sets {
    /// <summary>
    /// Sql生成器集合
    /// </summary>
    public class SqlBuilderSet : ISqlBuilderSet {

        #region 字段

        /// <summary>
        /// 主Sql生成器
        /// </summary>
        protected ISqlBuilder MasterBuilder;
        /// <summary>
        /// Sql生成器集合
        /// </summary>
        protected List<SqlBuilderSetItem> SetItems;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化Sql生成器集合
        /// </summary>
        /// <param name="builder">主Sql生成器</param>
        /// <param name="setItems">Sql生成器集合</param>
        public SqlBuilderSet( ISqlBuilder builder, List<SqlBuilderSetItem> setItems = null ) {
            MasterBuilder = builder ?? throw new ArgumentNullException( nameof( builder ) );
            SetItems = setItems ?? new List<SqlBuilderSetItem>();
        }

        #endregion

        #region Set(集合操作)

        /// <summary>
        /// 集合操作
        /// </summary>
        /// <param name="operator">操作符</param>
        /// <param name="builders">Sql生成器集合</param>
        protected void Set( string @operator, IEnumerable<ISqlBuilder> builders ) {
            if( builders == null )
                return;
            foreach( var builder in builders ) {
                SetItems.Add( new SqlBuilderSetItem( @operator, builder ) );
            }
        }

        #endregion

        #region Union(合并结果集)

        /// <summary>
        /// 合并结果集
        /// </summary>
        /// <param name="builders">Sql生成器集合</param>
        public virtual void Union( params ISqlBuilder[] builders ) {
            Set( "Union", builders );
        }

        /// <summary>
        /// 合并结果集
        /// </summary>
        /// <param name="builders">Sql生成器集合</param>
        public virtual void Union( IEnumerable<ISqlBuilder> builders ) {
            Set( "Union", builders );
        }

        #endregion

        #region UnionAll(合并结果集)

        /// <summary>
        /// 合并结果集
        /// </summary>
        /// <param name="builders">Sql生成器集合</param>
        public virtual void UnionAll( params ISqlBuilder[] builders ) {
            Set( "Union All", builders );
        }

        /// <summary>
        /// 合并结果集
        /// </summary>
        /// <param name="builders">Sql生成器集合</param>
        public virtual void UnionAll( IEnumerable<ISqlBuilder> builders ) {
            Set( "Union All", builders );
        }

        #endregion

        #region Intersect(交集)

        /// <summary>
        /// 交集
        /// </summary>
        /// <param name="builders">Sql生成器集合</param>
        public virtual void Intersect( params ISqlBuilder[] builders ) {
            Set( "Intersect", builders );
        }

        /// <summary>
        /// 交集
        /// </summary>
        /// <param name="builders">Sql生成器集合</param>
        public virtual void Intersect( IEnumerable<ISqlBuilder> builders ) {
            Set( "Intersect", builders );
        }

        #endregion

        #region Except(差集)

        /// <summary>
        /// 差集
        /// </summary>
        /// <param name="builders">Sql生成器集合</param>
        public virtual void Except( params ISqlBuilder[] builders ) {
            Set( "Except", builders );
        }

        /// <summary>
        /// 差集
        /// </summary>
        /// <param name="builders">Sql生成器集合</param>
        public virtual void Except( IEnumerable<ISqlBuilder> builders ) {
            Set( "Except", builders );
        }

        #endregion

        #region ToResult(获取结果)

        /// <summary>
        /// 获取结果
        /// </summary>
        public string ToResult() {
            if( SetItems.Count == 0 )
                return GetMasterResult();
            return GetSetResult();
        }

        /// <summary>
        /// 获取主查询结果
        /// </summary>
        protected virtual string GetMasterResult() {
            var builder = new StringBuilder();
            MasterBuilder.AppendTo( builder );
            return builder.ToString();
        }

        /// <summary>
        /// 获取集合操作结果
        /// </summary>
        protected virtual string GetSetResult() {
            var builder = new StringBuilder();
            AppendMasterSql( builder );
            AppendSetSql( builder );
            AppendEndSql( builder );
            return builder.ToString();
        }

        /// <summary>
        /// 添加主查询结果
        /// </summary>
        protected virtual void AppendMasterSql( StringBuilder result ) {
            var accessor = ToSqlPartAccessor( MasterBuilder );
            AppendSql( result, accessor.StartClause );
            result.AppendLine( "(" );
            AppendSql( result, accessor.SelectClause );
            AppendSql( result, accessor.FromClause );
            AppendSql( result, accessor.JoinClause );
            AppendSql( result, accessor.WhereClause );
            AppendSql( result, accessor.GroupByClause );
            result.AppendLine( ")" );
        }

        /// <summary>
        /// 添加集合Sql
        /// </summary>
        protected virtual void AppendSetSql( StringBuilder result ) {
            foreach ( var item in SetItems ) {
                var accessor = ToSqlPartAccessor( item.Builder );
                result.AppendFormat( "{0} ", item.Operator );
                result.AppendLine();
                result.AppendLine( "(" );
                AppendSql( result, accessor.SelectClause );
                AppendSql( result, accessor.FromClause );
                AppendSql( result, accessor.JoinClause );
                AppendSql( result, accessor.WhereClause );
                AppendSql( result, accessor.GroupByClause );
                result.AppendLine( ")" );
            }
        }

        /// <summary>
        /// 添加结束Sql
        /// </summary>
        protected virtual void AppendEndSql( StringBuilder result ) {
            var accessor = ToSqlPartAccessor( MasterBuilder );
            AppendSql( result, accessor.OrderByClause );
            AppendSql( result, accessor.EndClause );
            result.RemoveEnd( $" {Common.Line}" );
        }

        /// <summary>
        /// 转换为Sql组件访问器
        /// </summary>
        protected ISqlPartAccessor ToSqlPartAccessor( ISqlBuilder builder ) {
            var accessor = builder as ISqlPartAccessor;
            if( accessor == null )
                throw new NotImplementedException( nameof( ISqlPartAccessor ) );
            return accessor;
        }

        /// <summary>
        /// 添加Sql
        /// </summary>
        protected void AppendSql( StringBuilder builder, ISqlClause content ) {
            if( content.Validate() == false )
                return;
            content.AppendTo( builder );
            builder.AppendLine( " " );
        }

        #endregion

        #region Clear(清理)

        /// <summary>
        /// 清理
        /// </summary>
        public void Clear() {
            SetItems.Clear();
        }

        #endregion

        #region Clone(复制Sql生成器集合)

        /// <inheritdoc />
        public virtual ISqlBuilderSet Clone( SqlBuilderBase builder ) {
            return new SqlBuilderSet( builder, SetItems.Select( t => t.Clone() ).ToList() );
        }

        #endregion
    }
}
