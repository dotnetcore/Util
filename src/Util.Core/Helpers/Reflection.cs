using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Util.Helpers {
    /// <summary>
    /// 反射操作
    /// </summary>
    public static class Reflection {

        #region GetDescription(获取描述)

        /// <summary>
        /// 获取类型描述，使用DescriptionAttribute设置描述
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        public static string GetDescription<T>() {
            return GetDescription( Common.GetType<T>() );
        }

        /// <summary>
        /// 获取类型成员描述，使用DescriptionAttribute设置描述
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="memberName">成员名称</param>
        public static string GetDescription<T>( string memberName ) {
            return GetDescription( Common.GetType<T>(), memberName );
        }

        /// <summary>
        /// 获取类型成员描述，使用DescriptionAttribute设置描述
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="memberName">成员名称</param>
        public static string GetDescription( Type type, string memberName ) {
            if( type == null )
                return string.Empty;
            if( string.IsNullOrWhiteSpace( memberName ) )
                return string.Empty;
            return GetDescription( type.GetTypeInfo().GetMember( memberName ).FirstOrDefault() );
        }

        /// <summary>
        /// 获取类型成员描述，使用DescriptionAttribute设置描述
        /// </summary>
        /// <param name="member">成员</param>
        public static string GetDescription( MemberInfo member ) {
            if( member == null )
                return string.Empty;
            return member.GetCustomAttribute<DescriptionAttribute>() is { } attribute ? attribute.Description : member.Name;
        }

        #endregion

        #region GetDisplayName(获取显示名称)

        /// <summary>
        /// 获取显示名称，使用DisplayNameAttribute设置显示名称
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        public static string GetDisplayName<T>() {
            return GetDisplayName( Common.GetType<T>() );
        }

        /// <summary>
        /// 获取显示名称，使用DisplayAttribute或DisplayNameAttribute设置显示名称
        /// </summary>
        public static string GetDisplayName( MemberInfo member ) {
            if( member == null )
                return string.Empty;
            if( member.GetCustomAttribute<DisplayAttribute>() is { } displayAttribute )
                return displayAttribute.Name;
            if( member.GetCustomAttribute<DisplayNameAttribute>() is { } displayNameAttribute )
                return displayNameAttribute.DisplayName;
            return string.Empty;
        }

        #endregion

        #region GetDisplayNameOrDescription(获取显示名称或描述)

        /// <summary>
        /// 获取显示名称或描述,使用DisplayNameAttribute设置显示名称,使用DescriptionAttribute设置描述
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        public static string GetDisplayNameOrDescription<T>() {
            return GetDisplayNameOrDescription( Common.GetType<T>() );
        }

        /// <summary>
        /// 获取属性显示名称或描述,使用DisplayAttribute或DisplayNameAttribute设置显示名称,使用DescriptionAttribute设置描述
        /// </summary>
        public static string GetDisplayNameOrDescription( MemberInfo member ) {
            var result = GetDisplayName( member );
            return string.IsNullOrWhiteSpace( result ) ? GetDescription( member ) : result;
        }

        #endregion

        #region CreateInstance(动态创建实例)

        /// <summary>
        /// 动态创建实例
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="type">类型</param>
        /// <param name="parameters">传递给构造函数的参数</param>        
        public static T CreateInstance<T>( Type type, params object[] parameters ) {
            return Convert.To<T>( Activator.CreateInstance( type, parameters ) );
        }

        #endregion

        #region FindImplementTypes(查找实现类型列表)

        /// <summary>
        /// 在指定的程序集中查找实现类型列表
        /// </summary>
        /// <typeparam name="TFind">查找类型</typeparam>
        /// <param name="assemblies">待查找的程序集列表</param>
        public static List<Type> FindImplementTypes<TFind>( params Assembly[] assemblies ) {
            return FindImplementTypes( typeof( TFind ), assemblies );
        }

        /// <summary>
        /// 在指定的程序集中查找实现类型列表
        /// </summary>
        /// <param name="findType">查找类型</param>
        /// <param name="assemblies">待查找的程序集列表</param>
        public static List<Type> FindImplementTypes( Type findType, params Assembly[] assemblies ) {
            var result = new List<Type>();
            foreach( var assembly in assemblies )
                result.AddRange( GetTypes( findType, assembly ) );
            return result.Distinct().ToList();
        }

        /// <summary>
        /// 获取类型列表
        /// </summary>
        private static List<Type> GetTypes( Type findType, Assembly assembly ) {
            var result = new List<Type>();
            if( assembly == null )
                return result;
            Type[] types;
            try {
                types = assembly.GetTypes();
            }
            catch( ReflectionTypeLoadException ) {
                return result;
            }
            foreach( var type in types )
                AddType( result, findType, type );
            return result;
        }

        /// <summary>
        /// 添加类型
        /// </summary>
        private static void AddType( List<Type> result, Type findType, Type type ) {
            if( type.IsInterface || type.IsAbstract )
                return;
            if( findType.IsAssignableFrom( type ) == false && MatchGeneric( findType, type ) == false )
                return;
            result.Add( type );
        }

        /// <summary>
        /// 泛型匹配
        /// </summary>
        private static bool MatchGeneric( Type findType, Type type ) {
            if( findType.IsGenericTypeDefinition == false )
                return false;
            var definition = findType.GetGenericTypeDefinition();
            foreach( var implementedInterface in type.FindInterfaces( ( filter, criteria ) => true, null ) ) {
                if( implementedInterface.IsGenericType == false )
                    continue;
                return definition.IsAssignableFrom( implementedInterface.GetGenericTypeDefinition() );
            }
            return false;
        }

        #endregion

        #region GetDirectInterfaceTypes(获取直接接口类型列表)

        /// <summary>
        /// 获取直接接口类型列表
        /// </summary>
        /// <typeparam name="T">在该类型上查找接口</typeparam>
        /// <param name="baseInterfaceTypes">基接口类型列表,只返回继承了基接口的直接接口</param>
        public static List<Type> GetDirectInterfaceTypes<T>( params Type[] baseInterfaceTypes ) {
            return GetDirectInterfaceTypes( typeof( T ), baseInterfaceTypes );
        }

        /// <summary>
        /// 获取直接接口类型列表
        /// </summary>
        /// <param name="type">在该类型上查找接口</param>
        /// <param name="baseInterfaceTypes">基接口类型列表,只返回继承了基接口的直接接口</param>
        public static List<Type> GetDirectInterfaceTypes( Type type, params Type[] baseInterfaceTypes ) {
            var interfaceTypes = type.GetInterfaces();
            var directInterfaceTypes = interfaceTypes.Except( interfaceTypes.SelectMany( t => t.GetInterfaces() ) ).ToList();
            if ( baseInterfaceTypes == null || baseInterfaceTypes.Length == 0 )
                return directInterfaceTypes;
            var result = new List<Type>();
            foreach ( var interfaceType in directInterfaceTypes ) {
                if ( interfaceType.GetInterfaces().Any( baseInterfaceTypes.Contains ) == false )
                    continue;
                if ( interfaceType.IsGenericType && !interfaceType.IsGenericTypeDefinition && interfaceType.FullName == null ) {
                    result.Add( interfaceType.GetGenericTypeDefinition() );
                    continue;
                }
                result.Add( interfaceType );
            }
            return result;
        }

        #endregion

        #region IsCollection(是否集合)

        /// <summary>
        /// 是否集合
        /// </summary>
        /// <param name="type">类型</param>
        public static bool IsCollection( Type type ) {
            if( type.IsArray )
                return true;
            return IsGenericCollection( type );
        }

        #endregion

        #region IsGenericCollection(是否泛型集合)

        /// <summary>
        /// 是否泛型集合
        /// </summary>
        /// <param name="type">类型</param>
        public static bool IsGenericCollection( Type type ) {
            if( !type.IsGenericType )
                return false;
            var typeDefinition = type.GetGenericTypeDefinition();
            return typeDefinition == typeof( IEnumerable<> )
                   || typeDefinition == typeof( IReadOnlyCollection<> )
                   || typeDefinition == typeof( IReadOnlyList<> )
                   || typeDefinition == typeof( ICollection<> )
                   || typeDefinition == typeof( IList<> )
                   || typeDefinition == typeof( List<> );
        }

        #endregion

        #region IsBool(是否布尔类型)

        /// <summary>
        /// 是否布尔类型
        /// </summary>
        /// <param name="member">成员</param>
        public static bool IsBool( MemberInfo member ) {
            if( member == null )
                return false;
            switch( member.MemberType ) {
                case MemberTypes.TypeInfo:
                    return member.ToString() == "System.Boolean";
                case MemberTypes.Property:
                    return IsBool( (PropertyInfo)member );
            }
            return false;
        }

        /// <summary>
        /// 是否布尔类型
        /// </summary>
        private static bool IsBool( PropertyInfo property ) {
            return property.PropertyType == typeof( bool ) || property.PropertyType == typeof( bool? );
        }

        #endregion

        #region IsEnum(是否枚举类型)

        /// <summary>
        /// 是否枚举类型
        /// </summary>
        /// <param name="member">成员</param>
        public static bool IsEnum( MemberInfo member ) {
            if ( member == null )
                return false;
            switch ( member.MemberType ) {
                case MemberTypes.TypeInfo:
                    return ( (TypeInfo)member ).IsEnum;
                case MemberTypes.Property:
                    return IsEnum( (PropertyInfo)member );
            }
            return false;
        }

        /// <summary>
        /// 是否枚举类型
        /// </summary>
        private static bool IsEnum( PropertyInfo property ) {
            if ( property.PropertyType.GetTypeInfo().IsEnum )
                return true;
            var value = Nullable.GetUnderlyingType( property.PropertyType );
            if ( value == null )
                return false;
            return value.GetTypeInfo().IsEnum;
        }

        #endregion

        #region IsDate(是否日期类型)

        /// <summary>
        /// 是否日期类型
        /// </summary>
        /// <param name="member">成员</param>
        public static bool IsDate( MemberInfo member ) {
            if ( member == null )
                return false;
            switch ( member.MemberType ) {
                case MemberTypes.TypeInfo:
                    return member.ToString() == "System.DateTime";
                case MemberTypes.Property:
                    return IsDate( (PropertyInfo)member );
            }
            return false;
        }

        /// <summary>
        /// 是否日期类型
        /// </summary>
        private static bool IsDate( PropertyInfo property ) {
            if ( property.PropertyType == typeof( DateTime ) )
                return true;
            if ( property.PropertyType == typeof( DateTime? ) )
                return true;
            return false;
        }

        #endregion

        #region IsInt(是否整型)

        /// <summary>
        /// 是否整型
        /// </summary>
        /// <param name="member">成员</param>
        public static bool IsInt( MemberInfo member ) {
            if ( member == null )
                return false;
            switch ( member.MemberType ) {
                case MemberTypes.TypeInfo:
                    return member.ToString() == "System.Int32" || member.ToString() == "System.Int16" || member.ToString() == "System.Int64";
                case MemberTypes.Property:
                    return IsInt( (PropertyInfo)member );
            }
            return false;
        }

        /// <summary>
        /// 是否整型
        /// </summary>
        private static bool IsInt( PropertyInfo property ) {
            if ( property.PropertyType == typeof( int ) )
                return true;
            if ( property.PropertyType == typeof( int? ) )
                return true;
            if ( property.PropertyType == typeof( short ) )
                return true;
            if ( property.PropertyType == typeof( short? ) )
                return true;
            if ( property.PropertyType == typeof( long ) )
                return true;
            if ( property.PropertyType == typeof( long? ) )
                return true;
            return false;
        }

        #endregion

        #region IsNumber(是否数值类型)

        /// <summary>
        /// 是否浮点型
        /// </summary>
        /// <param name="member">成员</param>
        public static bool IsNumber( MemberInfo member ) {
            if ( member == null )
                return false;
            if ( IsInt( member ) )
                return true;
            switch ( member.MemberType ) {
                case MemberTypes.TypeInfo:
                    return member.ToString() == "System.Double" || member.ToString() == "System.Decimal" || member.ToString() == "System.Single";
                case MemberTypes.Property:
                    return IsNumber( (PropertyInfo)member );
            }
            return false;
        }

        /// <summary>
        /// 是否数值类型
        /// </summary>
        private static bool IsNumber( PropertyInfo property ) {
            if ( property.PropertyType == typeof( double ) )
                return true;
            if ( property.PropertyType == typeof( double? ) )
                return true;
            if ( property.PropertyType == typeof( decimal ) )
                return true;
            if ( property.PropertyType == typeof( decimal? ) )
                return true;
            if ( property.PropertyType == typeof( float ) )
                return true;
            if ( property.PropertyType == typeof( float? ) )
                return true;
            return false;
        }

        #endregion

        #region GetElementType(获取元素类型)

        /// <summary>
        /// 获取元素类型，如果是集合，返回集合的元素类型
        /// </summary>
        /// <param name="type">类型</param>
        public static Type GetElementType( Type type ) {
            if( IsCollection( type ) == false )
                return type;
            if( type.IsArray )
                return type.GetElementType();
            var genericArgumentsTypes = type.GetTypeInfo().GetGenericArguments();
            if( genericArgumentsTypes == null || genericArgumentsTypes.Length == 0 )
                throw new ArgumentException( nameof( genericArgumentsTypes ) );
            return genericArgumentsTypes[0];
        }

        #endregion

        #region GetTopBaseType(获取顶级基类)

        /// <summary>
        /// 获取顶级基类
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        public static Type GetTopBaseType<T>() {
            return GetTopBaseType( typeof( T ) );
        }

        /// <summary>
        /// 获取顶级基类
        /// </summary>
        /// <param name="type">类型</param>
        public static Type GetTopBaseType( Type type ) {
            if ( type == null )
                return null;
            if ( type.IsInterface )
                return type;
            if ( type.BaseType == typeof( object ) )
                return type;
            return GetTopBaseType( type.BaseType );
        }

        #endregion
    }
}
