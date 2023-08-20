using Util.Helpers;

namespace Util.Microservices.Dapr.StateManagements.Queries; 

/// <summary>
/// 状态查询辅助操作
/// </summary>
public static class StateQueryHelper {
    /// <summary>
    /// 获取属性名
    /// </summary>
    public static string GetProperty<T>( Expression<Func<T, object>> expression ) {
        var property = Lambda.GetName( expression );
        return property.IsEmpty() ? null : property.Split( '.' ).Select( Util.Helpers.String.FirstLowerCase ).Join( separator: "." );
    }
}