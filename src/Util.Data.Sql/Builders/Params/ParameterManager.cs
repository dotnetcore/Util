namespace Util.Data.Sql.Builders.Params; 

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
    protected readonly IDictionary<string, SqlParam> SqlParams;
    /// <summary>
    /// 动态参数集合
    /// </summary>
    protected readonly List<object> DynamicParams;
    /// <summary>
    /// 参数索引
    /// </summary>
    protected int ParamIndex;

    /// <summary>
    /// 初始化Sql参数管理器
    /// </summary>
    /// <param name="dialect">Sql方言</param>
    public ParameterManager( IDialect dialect ) {
        Dialect = dialect;
        ParamIndex = 0;
        SqlParams = new Dictionary<string, SqlParam>();
        DynamicParams = new List<object>();
    }

    /// <summary>
    /// 初始化Sql参数管理器
    /// </summary>
    /// <param name="manager">Sql参数管理器</param>
    public ParameterManager( ParameterManager manager ) {
        Dialect = manager.Dialect;
        ParamIndex = manager.ParamIndex;
        SqlParams = new Dictionary<string, SqlParam>( manager.SqlParams );
        DynamicParams = new List<object>( manager.DynamicParams );
    }

    /// <summary>
    /// 创建参数名
    /// </summary>
    public virtual string GenerateName() {
        var result = $"{Dialect.GetPrefix()}_p_{ParamIndex}";
        ParamIndex++;
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
        DynamicParams.Add( param );
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
        if ( SqlParams.ContainsKey( name ) )
            SqlParams.Remove( name );
        value = ConvertValue( value );
        var param = new SqlParam( name, value, dbType, direction, size, precision, scale );
        SqlParams.Add( name, param );
    }

    /// <summary>
    /// 转换参数值
    /// </summary>
    /// <param name="value">参数值</param>
    protected virtual object ConvertValue( object value ) {
        return value;
    }

    /// <summary>
    /// 获取动态参数列表
    /// </summary>
    public IReadOnlyList<object> GetDynamicParams() {
        return DynamicParams;
    }

    /// <summary>
    /// 获取参数列表
    /// </summary>
    public IReadOnlyList<SqlParam> GetParams() {
        return SqlParams.Values.ToList();
    }

    /// <summary>
    /// 是否包含参数
    /// </summary>
    /// <param name="name">参数名</param>
    public virtual bool Contains( string name ) {
        name = NormalizeName( name );
        return SqlParams.ContainsKey( name );
    }

    /// <summary>
    /// 获取参数
    /// </summary>
    /// <param name="name">参数名</param>
    public virtual SqlParam GetParam( string name ) {
        name = NormalizeName( name );
        return SqlParams.TryGetValue( name, out var param ) ? param : null;
    }

    /// <summary>
    /// 获取参数值
    /// </summary>
    /// <param name="name">参数名</param>
    public virtual object GetValue( string name ) {
        name = NormalizeName( name );
        return SqlParams.TryGetValue( name, out var param ) ? param.Value : null;
    }

    /// <summary>
    /// 清空参数
    /// </summary>
    public virtual void Clear() {
        ParamIndex = 0;
        SqlParams.Clear();
    }

    /// <summary>
    /// 复制副本
    /// </summary>
    public IParameterManager Clone() {
        return new ParameterManager( this );
    }
}