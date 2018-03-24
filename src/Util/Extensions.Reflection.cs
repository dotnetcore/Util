using System.Reflection;

namespace Util {
    /// <summary>
    /// 系统扩展 - 反射
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 获取实例上的属性值
        /// </summary>
        /// <param name="member">成员信息</param>
        /// <param name="instance">成员所在的类实例</param>
        public static object GetPropertyValue( this MemberInfo member, object instance ) {
            return instance.GetType().GetProperty( member.Name ).GetValue( instance );
        }
    }
}
