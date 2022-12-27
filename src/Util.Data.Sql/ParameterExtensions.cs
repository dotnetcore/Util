using System.Collections.Generic;
using System.Data;
using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Operations;
using Util.Data.Sql.Builders.Params;

namespace Util.Data.Sql {
    /// <summary>
    /// Sql参数操作扩展
    /// </summary>
    public static class ParameterExtensions {

        #region AddDynamicParams(添加动态参数)

        /// <summary>
        /// 添加动态参数
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="param">动态参数,范例: new{ A=1,B=2 }</param>
        public static T AddDynamicParams<T>( this T source, object param ) where T : ISqlParameter {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.ParameterManager.AddDynamicParams( param );
            return source;
        }

        #endregion

        #region AddParam(添加Sql参数)

        /// <summary>
        /// 添加Sql参数
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="name">参数名</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="direction">参数方向</param>
        public static T AddParam<T>( this T source, string name, DbType dbType, ParameterDirection direction ) where T : ISqlParameter {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.ParameterManager.Add( name, null, dbType, direction );
            return source;
        }

        /// <summary>
        /// 添加Sql参数
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="direction">参数方向</param>
        /// <param name="size">字段长度</param>
        /// <param name="precision">数值有效位数</param>
        /// <param name="scale">数值小数位数</param>
        public static T AddParam<T>( this T source, string name, object value = null, DbType? dbType = null, ParameterDirection? direction = null, int? size = null, byte? precision = null, byte? scale = null ) where T : ISqlParameter {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                accessor.ParameterManager.Add( name, value, dbType, direction, size, precision, scale );
            return source;
        }

        #endregion

        #region GetParams(获取参数列表)

        /// <summary>
        /// 获取参数列表
        /// </summary>
        /// <param name="source">源</param>
        public static IReadOnlyList<SqlParam> GetParams( this ISqlParameter source ) {
            source.CheckNull( nameof( source ) );
            if( source is ISqlPartAccessor accessor )
                return accessor.ParameterManager.GetParams();
            return default;
        }

        #endregion

        #region GetDynamicParams(获取动态参数列表)

        /// <summary>
        /// 获取动态参数列表
        /// </summary>
        /// <param name="source">源</param>
        public static IReadOnlyList<object> GetDynamicParams( this ISqlParameter source ) {
            source.CheckNull( nameof( source ) );
            if ( source is ISqlPartAccessor accessor )
                return accessor.ParameterManager.GetDynamicParams();
            return default;
        }

        #endregion

        #region GetParam(获取参数值)

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="name">参数名</param>
        public static T GetParam<T>( this ISqlParameter source, string name ) {
            source.CheckNull( nameof( source ) );
            if( source is IGetParameter target )
                return target.GetParam<T>( name );
            if( source is ISqlPartAccessor accessor )
                return (T)accessor.ParameterManager.GetValue( name );
            return default;
        }

        #endregion

        #region ClearParams(清空Sql参数)

        /// <summary>
        /// 清空Sql参数
        /// </summary>
        /// <param name="source">源</param>
        public static T ClearParams<T>( this T source ) where T : ISqlParameter {
            source.CheckNull( nameof( source ) );
            if( source is IClearParameters target ) {
                target.ClearParams();
                return source;
            }
            if( source is ISqlPartAccessor accessor )
                accessor.ParameterManager.Clear();
            return source;
        }

        #endregion
    }
}
