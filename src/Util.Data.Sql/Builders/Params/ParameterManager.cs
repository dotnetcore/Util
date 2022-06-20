using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Util.Data.Sql.Builders.Params {
    /// <summary>
    /// Sql参数管理器
    /// </summary>
    public class ParameterManager : IParameterManager {
        /// <summary>
        /// Sql方言
        /// </summary>
        protected readonly IDialect Dialect;
        /// <summary>
        /// 参数集合
        /// </summary>
        private readonly IDictionary<string, SqlParam> _params;
        /// <summary>
        /// 动态参数集合
        /// </summary>
        private readonly List<object> _dynamicParams;
        /// <summary>
        /// 参数索引
        /// </summary>
        private int _paramIndex;

        /// <summary>
        /// 初始化Sql参数管理器
        /// </summary>
        /// <param name="dialect">Sql方言</param>
        public ParameterManager( IDialect dialect ) {
            Dialect = dialect;
            _paramIndex = 0;
            _params = new Dictionary<string, SqlParam>();
            _dynamicParams = new List<object>();
        }

        /// <summary>
        /// 初始化Sql参数管理器
        /// </summary>
        /// <param name="manager">Sql方言</param>
        public ParameterManager( ParameterManager manager ) {
            Dialect = manager.Dialect;
            _paramIndex = manager._paramIndex;
            _params = new Dictionary<string, SqlParam>( manager._params );
            _dynamicParams = new List<object>( manager._dynamicParams );
        }

        /// <summary>
        /// 创建参数名
        /// </summary>
        public virtual string GenerateName() {
            var result = $"{Dialect.GetPrefix()}_p_{_paramIndex}";
            _paramIndex++;
            return result;
        }

        /// <summary>
        /// 标准化参数名
        /// </summary>
        /// <param name="name">参数名</param>
        public virtual string NormalizeName( string name ) {
            if ( name.IsEmpty() )
                return name;
            name = name.Trim();
            if ( name.StartsWith( Dialect.GetPrefix() ) )
                return name;
            return $"{Dialect.GetPrefix()}{name}";
        }

        /// <summary>
        /// 添加动态参数
        /// </summary>
        /// <param name="param">动态参数</param>
        public virtual void AddDynamicParams( object param ) {
            if ( param == null )
                return;
            _dynamicParams.Add( param );
        }

        /// <summary>
        /// 添加参数,如果参数已存在则替换
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="dbType">参数类型</param>
        /// <param name="direction">参数方向</param>
        /// <param name="size">字段长度</param>
        /// <param name="precision">数值有效位数</param>
        /// <param name="scale">数值小数位数</param>
        public virtual void Add( string name, object value = null, DbType? dbType = null, ParameterDirection? direction = null, int? size = null, byte? precision = null, byte? scale = null ) {
            if ( name.IsEmpty() )
                return;
            name = NormalizeName( name );
            if ( _params.ContainsKey( name ) )
                _params.Remove( name );
            var param = new SqlParam( name, value, dbType, direction, size, precision, scale );
            _params.Add( name, param );
        }

        /// <summary>
        /// 获取动态参数列表
        /// </summary>
        public IReadOnlyList<object> GetDynamicParams() {
            return _dynamicParams;
        }

        /// <summary>
        /// 获取参数列表
        /// </summary>
        public IReadOnlyList<SqlParam> GetParams() {
            return _params.Values.ToList();
        }

        /// <summary>
        /// 是否包含参数
        /// </summary>
        /// <param name="name">参数名</param>
        public virtual bool Contains( string name ) {
            name = NormalizeName( name );
            return _params.ContainsKey( name );
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        public virtual SqlParam GetParam( string name ) {
            name = NormalizeName( name );
            return _params.ContainsKey( name ) ? _params[name] : null;
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="name">参数名</param>
        public virtual object GetValue( string name ) {
            name = NormalizeName( name );
            return _params.ContainsKey( name ) ? _params[name].Value : null;
        }

        /// <summary>
        /// 清空参数
        /// </summary>
        public virtual void Clear() {
            _paramIndex = 0;
            _params.Clear();
        }

        /// <summary>
        /// 复制副本
        /// </summary>
        public IParameterManager Clone() {
            return new ParameterManager( this );
        }
    }
}
