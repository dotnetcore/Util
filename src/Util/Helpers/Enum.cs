using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Util.Helpers {
    /// <summary>
    /// 枚举操作
    /// </summary>
    public static class Enum {
        /// <summary>
        /// 获取实例
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="member">成员名或值,范例:Enum1枚举有成员A=0,则传入"A"或"0"获取 Enum1.A</param>
        public static TEnum Parse<TEnum>( object member ){
            string value = member.SafeString();
            if( string.IsNullOrWhiteSpace( value ) )
                throw new ArgumentNullException( nameof(member) );
            return (TEnum)System.Enum.Parse( Common.GetType<TEnum>(), value, true );
        }

        /// <summary>
        /// 获取成员名
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="member">成员名、值、实例均可,范例:Enum1枚举有成员A=0,则传入Enum1.A或0,获取成员名"A"</param>
        public static string GetName<TEnum>( object member ) {
            return GetName( Common.GetType<TEnum>(), member );
        }

        /// <summary>
        /// 获取成员名
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        public static string GetName( Type type, object member ) {
            if( type == null )
                return string.Empty;
            if( member == null )
                return string.Empty;
            if( member is string )
                return member.ToString();
            if( type.GetTypeInfo().IsEnum == false )
                return string.Empty;
            return System.Enum.GetName( type, member );
        }

        /// <summary>
        /// 获取成员值
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="member">成员名、值、实例均可，范例:Enum1枚举有成员A=0,可传入"A"、0、Enum1.A，获取值0</param>
        public static int GetValue<TEnum>( object member ) {
            return GetValue( Common.GetType<TEnum>(), member );
        }

        /// <summary>
        /// 获取成员值
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        public static int GetValue( Type type, object member ) {
            string value = member.SafeString();
            if( string.IsNullOrWhiteSpace( value ) )
                throw new ArgumentNullException( "member" );
            return (int)System.Enum.Parse( type, member.ToString(), true );
        }

        /// <summary>
        /// 获取描述,使用System.ComponentModel.Description特性设置描述
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="member">成员名、值、实例均可</param>
        public static string GetDescription<TEnum>( object member ) {
            return Reflection.GetDescription<TEnum>( GetName<TEnum>( member ) );
        }

        /// <summary>
        /// 获取描述,使用System.ComponentModel.Description特性设置描述
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        public static string GetDescription( Type type, object member ) {
            return Reflection.GetDescription( type, GetName( type, member ) );
        }

        /// <summary>
        /// 获取描述项集合,文本设置为Description，值为Value
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        public static List<Item> GetItems<TEnum>() {
            TypeInfo enumType = Common.GetType<TEnum>().GetTypeInfo();
            ValidateEnum( enumType );
            var result = new List<Item>();
            foreach( var field in enumType.GetFields() )
                AddItem<TEnum>( result, field );
            return result.OrderBy( t => t.SortId ).ToList();
        }

        /// <summary>
        /// 验证是否枚举类型
        /// </summary>
        private static void ValidateEnum( TypeInfo enumType ) {
            if( enumType.IsEnum == false )
                throw new InvalidOperationException( string.Format( "类型 {0} 不是枚举", enumType ) );
        }

        /// <summary>
        /// 添加描述项
        /// </summary>
        private static void AddItem<TEnum>( ICollection<Item> result, FieldInfo field ) {
            if( !field.FieldType.GetTypeInfo().IsEnum )
                return;
            var value = GetValue<TEnum>( field.Name );
            var description = Reflection.GetDescription( field );
            result.Add( new Item( description, value.ToString(), value ) );
        }
    }
}
