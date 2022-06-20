using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Util.Data.Sql {
    /// <summary>
    /// Sql查询对象操作扩展 - 查询扩展
    /// </summary>
    public static partial class SqlQueryExtensions {

        #region ToEntity(获取单个实体)

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        public static TEntity ToEntity<TEntity>( this ISqlQuery source, int? timeout = null ) {
            source.CheckNull( nameof( source ) );
            return source.ExecuteSingle<TEntity>( timeout );
        }

        #endregion

        #region ToEntityAsync(获取单个实体)

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        public static async Task<TEntity> ToEntityAsync<TEntity>( this ISqlQuery source, int? timeout = null ) {
            source.CheckNull( nameof( source ) );
            return await source.ExecuteSingleAsync<TEntity>( timeout );
        }

        #endregion

        #region ToList(获取实体集合)

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        public static List<dynamic> ToList( this ISqlQuery source, int? timeout = null, bool buffered = true ) {
            source.CheckNull( nameof( source ) );
            return source.ExecuteQuery( timeout, buffered );
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        public static List<TEntity> ToList<TEntity>( this ISqlQuery source, int? timeout = null, bool buffered = true ) {
            source.CheckNull( nameof( source ) );
            return source.ExecuteQuery<TEntity>( timeout, buffered );
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        public static List<TEntity> ToList<T1, T2, TEntity>( this ISqlQuery source, Func<T1, T2, TEntity> map, int? timeout = null, bool buffered = true ) {
            source.CheckNull( nameof( source ) );
            return source.ExecuteQuery( map, timeout, buffered );
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        public static List<TEntity> ToList<T1, T2, T3, TEntity>( this ISqlQuery source, Func<T1, T2, T3, TEntity> map, int? timeout = null, bool buffered = true ) {
            source.CheckNull( nameof( source ) );
            return source.ExecuteQuery( map, timeout, buffered );
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        public static List<TEntity> ToList<T1, T2, T3, T4, TEntity>( this ISqlQuery source, Func<T1, T2, T3, T4, TEntity> map, int? timeout = null, bool buffered = true ) {
            source.CheckNull( nameof( source ) );
            return source.ExecuteQuery( map, timeout, buffered );
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="T5">实体类型5</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        public static List<TEntity> ToList<T1, T2, T3, T4, T5, TEntity>( this ISqlQuery source, Func<T1, T2, T3, T4, T5, TEntity> map, int? timeout = null, bool buffered = true ) {
            source.CheckNull( nameof( source ) );
            return source.ExecuteQuery( map, timeout, buffered );
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="T5">实体类型5</typeparam>
        /// <typeparam name="T6">实体类型6</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        public static List<TEntity> ToList<T1, T2, T3, T4, T5, T6, TEntity>( this ISqlQuery source, Func<T1, T2, T3, T4, T5, T6, TEntity> map, int? timeout = null, bool buffered = true ) {
            source.CheckNull( nameof( source ) );
            return source.ExecuteQuery( map, timeout, buffered );
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="T5">实体类型5</typeparam>
        /// <typeparam name="T6">实体类型6</typeparam>
        /// <typeparam name="T7">实体类型7</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        public static List<TEntity> ToList<T1, T2, T3, T4, T5, T6, T7, TEntity>( this ISqlQuery source, Func<T1, T2, T3, T4, T5, T6, T7, TEntity> map, int? timeout = null, bool buffered = true ) {
            source.CheckNull( nameof( source ) );
            return source.ExecuteQuery( map, timeout, buffered );
        }

        #endregion

        #region ToListAsync(获取实体集合)

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <param name="source">源</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        public static async Task<List<dynamic>> ToListAsync( this ISqlQuery source, int? timeout = null ) {
            source.CheckNull( nameof( source ) );
            return await source.ExecuteQueryAsync( timeout );
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        public static async Task<List<TEntity>> ToListAsync<TEntity>( this ISqlQuery source, int? timeout = null ) {
            source.CheckNull( nameof( source ) );
            return await source.ExecuteQueryAsync<TEntity>( timeout );
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        public static async Task<List<TEntity>> ToListAsync<T1, T2, TEntity>( this ISqlQuery source, Func<T1, T2, TEntity> map, int? timeout = null, bool buffered = true ) {
            source.CheckNull( nameof( source ) );
            return await source.ExecuteQueryAsync( map, timeout, buffered );
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        public static async Task<List<TEntity>> ToListAsync<T1, T2, T3, TEntity>( this ISqlQuery source, Func<T1, T2, T3, TEntity> map, int? timeout = null, bool buffered = true ) {
            source.CheckNull( nameof( source ) );
            return await source.ExecuteQueryAsync( map, timeout, buffered );
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        public static async Task<List<TEntity>> ToListAsync<T1, T2, T3, T4, TEntity>( this ISqlQuery source, Func<T1, T2, T3, T4, TEntity> map, int? timeout = null, bool buffered = true ) {
            source.CheckNull( nameof( source ) );
            return await source.ExecuteQueryAsync( map, timeout, buffered );
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="T5">实体类型5</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        public static async Task<List<TEntity>> ToListAsync<T1, T2, T3, T4, T5, TEntity>( this ISqlQuery source, Func<T1, T2, T3, T4, T5, TEntity> map, int? timeout = null, bool buffered = true ) {
            source.CheckNull( nameof( source ) );
            return await source.ExecuteQueryAsync( map, timeout, buffered );
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="T5">实体类型5</typeparam>
        /// <typeparam name="T6">实体类型6</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        public static async Task<List<TEntity>> ToListAsync<T1, T2, T3, T4, T5, T6, TEntity>( this ISqlQuery source, Func<T1, T2, T3, T4, T5, T6, TEntity> map, int? timeout = null, bool buffered = true ) {
            source.CheckNull( nameof( source ) );
            return await source.ExecuteQueryAsync( map, timeout, buffered );
        }

        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="T5">实体类型5</typeparam>
        /// <typeparam name="T6">实体类型6</typeparam>
        /// <typeparam name="T7">实体类型7</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="source">源</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        public static async Task<List<TEntity>> ToListAsync<T1, T2, T3, T4, T5, T6, T7, TEntity>( this ISqlQuery source, Func<T1, T2, T3, T4, T5, T6, T7, TEntity> map, int? timeout = null, bool buffered = true ) {
            source.CheckNull( nameof( source ) );
            return await source.ExecuteQueryAsync( map, timeout, buffered );
        }

        #endregion
    }
}
