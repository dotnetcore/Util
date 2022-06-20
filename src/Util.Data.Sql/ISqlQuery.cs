using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Operations;
using Util.Data.Sql.Configs;

namespace Util.Data.Sql {
    /// <summary>
    /// Sql查询对象
    /// </summary>
    public interface ISqlQuery : ISqlQueryOperation, ISqlOptions, IDisposable {
        /// <summary>
        /// 上下文标识
        /// </summary>
        string ContextId { get; }
        /// <summary>
        /// 前一次执行的Sql及参数
        /// </summary>
        SqlBuilderResult PreviousSql { get; }
        /// <summary>
        /// 获取Sql生成器
        /// </summary>
        ISqlBuilder SqlBuilder { get; }
        /// <summary>
        /// 判断是否存在
        /// </summary>
        bool ExecuteExists();
        /// <summary>
        /// 判断是否存在
        /// </summary>
        Task<bool> ExecuteExistsAsync();
        /// <summary>
        /// 获取单值
        /// </summary>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        object ExecuteScalar( int? timeout = null );
        /// <summary>
        /// 获取单值
        /// </summary>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        T ExecuteScalar<T>( int? timeout = null );
        /// <summary>
        /// 获取单值
        /// </summary>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        Task<object> ExecuteScalarAsync( int? timeout = null );
        /// <summary>
        /// 获取单值
        /// </summary>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        Task<T> ExecuteScalarAsync<T>( int? timeout = null );
        /// <summary>
        /// 执行存储过程获取单值
        /// </summary>
        /// <param name="procedure">存储过程</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        object ExecuteProcedureScalar( string procedure, int? timeout = null );
        /// <summary>
        /// 执行存储过程获取单值
        /// </summary>
        /// <param name="procedure">存储过程</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        T ExecuteProcedureScalar<T>( string procedure, int? timeout = null );
        /// <summary>
        /// 执行存储过程获取单值
        /// </summary>
        /// <param name="procedure">存储过程</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        Task<object> ExecuteProcedureScalarAsync( string procedure, int? timeout = null );
        /// <summary>
        /// 执行存储过程获取单值
        /// </summary>
        /// <param name="procedure">存储过程</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        Task<T> ExecuteProcedureScalarAsync<T>( string procedure, int? timeout = null );
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        TEntity ExecuteSingle<TEntity>( int? timeout = null );
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        Task<TEntity> ExecuteSingleAsync<TEntity>( int? timeout = null );
        /// <summary>
        /// 执行存储过程获取单个实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="procedure">存储过程</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        TEntity ExecuteProcedureSingle<TEntity>( string procedure, int? timeout = null );
        /// <summary>
        /// 执行存储过程获取单个实体
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="procedure">存储过程</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        Task<TEntity> ExecuteProcedureSingleAsync<TEntity>( string procedure, int? timeout = null );
        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        List<dynamic> ExecuteQuery( int? timeout = null, bool buffered = true );
        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        List<TEntity> ExecuteQuery<TEntity>( int? timeout = null, bool buffered = true );
        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        List<TEntity> ExecuteQuery<T1, T2, TEntity>( Func<T1, T2, TEntity> map, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        List<TEntity> ExecuteQuery<T1, T2, T3, TEntity>( Func<T1, T2, T3, TEntity> map, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        List<TEntity> ExecuteQuery<T1, T2, T3, T4, TEntity>( Func<T1, T2, T3, T4, TEntity> map, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="T5">实体类型5</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        List<TEntity> ExecuteQuery<T1, T2, T3, T4, T5, TEntity>( Func<T1, T2, T3, T4, T5, TEntity> map, int? timeout = null, bool buffered = true );
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
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        List<TEntity> ExecuteQuery<T1, T2, T3, T4, T5, T6, TEntity>( Func<T1, T2, T3, T4, T5, T6, TEntity> map, int? timeout = null, bool buffered = true );
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
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        List<TEntity> ExecuteQuery<T1, T2, T3, T4, T5, T6, T7, TEntity>( Func<T1, T2, T3, T4, T5, T6, T7, TEntity> map, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        Task<List<dynamic>> ExecuteQueryAsync( int? timeout = null );
        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        Task<List<TEntity>> ExecuteQueryAsync<TEntity>( int? timeout = null );
        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        Task<List<TEntity>> ExecuteQueryAsync<T1, T2, TEntity>( Func<T1, T2, TEntity> map, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        Task<List<TEntity>> ExecuteQueryAsync<T1, T2, T3, TEntity>( Func<T1, T2, T3, TEntity> map, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        Task<List<TEntity>> ExecuteQueryAsync<T1, T2, T3, T4, TEntity>( Func<T1, T2, T3, T4, TEntity> map, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="T5">实体类型5</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        Task<List<TEntity>> ExecuteQueryAsync<T1, T2, T3, T4, T5, TEntity>( Func<T1, T2, T3, T4, T5, TEntity> map, int? timeout = null, bool buffered = true );
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
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        Task<List<TEntity>> ExecuteQueryAsync<T1, T2, T3, T4, T5, T6, TEntity>( Func<T1, T2, T3, T4, T5, T6, TEntity> map, int? timeout = null, bool buffered = true );
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
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        Task<List<TEntity>> ExecuteQueryAsync<T1, T2, T3, T4, T5, T6, T7, TEntity>( Func<T1, T2, T3, T4, T5, T6, T7, TEntity> map, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        /// <param name="procedure">存储过程</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        List<dynamic> ExecuteProcedureQuery( string procedure, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="procedure">存储过程</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        List<TEntity> ExecuteProcedureQuery<TEntity>( string procedure, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="procedure">存储过程</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        List<TEntity> ExecuteProcedureQuery<T1, T2, TEntity>( string procedure, Func<T1, T2, TEntity> map, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="procedure">存储过程</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        List<TEntity> ExecuteProcedureQuery<T1, T2, T3, TEntity>( string procedure, Func<T1, T2, T3, TEntity> map, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="procedure">存储过程</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        List<TEntity> ExecuteProcedureQuery<T1, T2, T3, T4, TEntity>( string procedure, Func<T1, T2, T3, T4, TEntity> map, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="T5">实体类型5</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="procedure">存储过程</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        List<TEntity> ExecuteProcedureQuery<T1, T2, T3, T4, T5, TEntity>( string procedure, Func<T1, T2, T3, T4, T5, TEntity> map, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="T5">实体类型5</typeparam>
        /// <typeparam name="T6">实体类型6</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="procedure">存储过程</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        List<TEntity> ExecuteProcedureQuery<T1, T2, T3, T4, T5, T6, TEntity>( string procedure, Func<T1, T2, T3, T4, T5, T6, TEntity> map, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="T5">实体类型5</typeparam>
        /// <typeparam name="T6">实体类型6</typeparam>
        /// <typeparam name="T7">实体类型7</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="procedure">存储过程</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        List<TEntity> ExecuteProcedureQuery<T1, T2, T3, T4, T5, T6, T7, TEntity>( string procedure, Func<T1, T2, T3, T4, T5, T6, T7, TEntity> map, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        /// <param name="procedure">存储过程</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        Task<List<dynamic>> ExecuteProcedureQueryAsync( string procedure, int? timeout = null );
        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="procedure">存储过程</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        Task<List<TEntity>> ExecuteProcedureQueryAsync<TEntity>( string procedure, int? timeout = null );
        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="procedure">存储过程</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        Task<List<TEntity>> ExecuteProcedureQueryAsync<T1, T2, TEntity>( string procedure, Func<T1, T2, TEntity> map, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="procedure">存储过程</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        Task<List<TEntity>> ExecuteProcedureQueryAsync<T1, T2, T3, TEntity>( string procedure, Func<T1, T2, T3, TEntity> map, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="procedure">存储过程</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        Task<List<TEntity>> ExecuteProcedureQueryAsync<T1, T2, T3, T4, TEntity>( string procedure, Func<T1, T2, T3, T4, TEntity> map, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="T5">实体类型5</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="procedure">存储过程</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        Task<List<TEntity>> ExecuteProcedureQueryAsync<T1, T2, T3, T4, T5, TEntity>( string procedure, Func<T1, T2, T3, T4, T5, TEntity> map, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="T5">实体类型5</typeparam>
        /// <typeparam name="T6">实体类型6</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="procedure">存储过程</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        Task<List<TEntity>> ExecuteProcedureQueryAsync<T1, T2, T3, T4, T5, T6, TEntity>( string procedure, Func<T1, T2, T3, T4, T5, T6, TEntity> map, int? timeout = null, bool buffered = true );
        /// <summary>
        /// 执行存储过程获取实体集合
        /// </summary>
        /// <typeparam name="T1">实体类型1</typeparam>
        /// <typeparam name="T2">实体类型2</typeparam>
        /// <typeparam name="T3">实体类型3</typeparam>
        /// <typeparam name="T4">实体类型4</typeparam>
        /// <typeparam name="T5">实体类型5</typeparam>
        /// <typeparam name="T6">实体类型6</typeparam>
        /// <typeparam name="T7">实体类型7</typeparam>
        /// <typeparam name="TEntity">返回的实体类型</typeparam>
        /// <param name="procedure">存储过程</param>
        /// <param name="map">映射函数</param>
        /// <param name="timeout">执行超时时间,单位:秒</param>
        /// <param name="buffered">是否缓存,默认值: true</param>
        Task<List<TEntity>> ExecuteProcedureQueryAsync<T1, T2, T3, T4, T5, T6, T7, TEntity>( string procedure, Func<T1, T2, T3, T4, T5, T6, T7, TEntity> map, int? timeout = null, bool buffered = true );
    }
}
