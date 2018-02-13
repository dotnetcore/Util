using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Util.Ui.Extensions {
    /// <summary>
    /// 模型表达式扩展
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 获取成员
        /// </summary>
        /// <param name="expression">模型表达式</param>
        public static MemberInfo GetMemberInfo( this ModelExpression expression ) {
            var members = expression.Metadata.ContainerType.GetMember( expression.Metadata.PropertyName );
            return members.Length == 0 ? null : members[0];
        }

        /// <summary>
        /// 获取验证特性
        /// </summary>
        /// <param name="expression">模型表达式</param>
        public static TAttribute GetValidationAttribute<TAttribute>( this ModelExpression expression ) {
            var attribute = expression.Metadata.ValidatorMetadata.FirstOrDefault( t => t is TAttribute );
            if( attribute == null )
                return default( TAttribute );
            return (TAttribute)attribute;
        }
    }
}
