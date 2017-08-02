using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Util.Helpers {
    /// <summary>
    /// Lambda表达式操作
    /// </summary>
    public static class Lambda {

        #region GetMember(获取成员)

        /// <summary>
        /// 获取成员
        /// </summary>
        /// <param name="expression">表达式,范例：t => t.Name</param>
        public static MemberInfo GetMember( Expression expression ) {
            var memberExpression = GetMemberExpression( expression );
            if( memberExpression == null )
                return null;
            return memberExpression.Member;
        }

        /// <summary>
        /// 获取成员表达式
        /// </summary>
        /// <param name="expression">表达式</param>
        public static MemberExpression GetMemberExpression( Expression expression ) {
            if( expression == null )
                return null;
            switch( expression.NodeType ) {
                case ExpressionType.Lambda:
                    return GetMemberExpression( ( (LambdaExpression)expression ).Body );
                case ExpressionType.Convert:
                    return GetMemberExpression( ( (UnaryExpression)expression ).Operand );
                case ExpressionType.MemberAccess:
                    return (MemberExpression)expression;
            }
            return null;
        }

        #endregion

        #region GetName(获取成员名称)

        /// <summary>
        /// 获取成员名称，范例：t => t.Name,返回 Name
        /// </summary>
        /// <param name="expression">表达式,范例：t => t.Name</param>
        public static string GetName( Expression expression ) {
            var memberExpression = GetMemberExpression( expression );
            return GetMemberName( memberExpression );
        }

        /// <summary>
        /// 获取成员名称
        /// </summary>
        private static string GetMemberName( MemberExpression memberExpression ) {
            if( memberExpression == null )
                return string.Empty;
            string result = memberExpression.ToString();
            return result.Substring( result.IndexOf( "." ) + 1 );
        }

        #endregion

        #region GetNames(获取名称列表)

        /// <summary>
        /// 获取名称列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="expression">属性集合表达式,范例：t => new object[]{t.A,t.B}</param>
        public static List<string> GetNames<T>( Expression<Func<T, object[]>> expression ) {
            var result = new List<string>();
            if( expression == null )
                return result;
            var arrayExpression = expression.Body as NewArrayExpression;
            if( arrayExpression == null )
                return result;
            foreach( var each in arrayExpression.Expressions )
                AddName( result, each );
            return result;
        }

        /// <summary>
        /// 添加名称
        /// </summary>
        private static void AddName( List<string> result, Expression expression ) {
            var name = GetName( expression );
            if( string.IsNullOrWhiteSpace( name ) )
                return;
            result.Add( name );
        }

        #endregion

        #region GetValue(获取值)

        /// <summary>
        /// 获取值,范例：t => t.Name == "A",返回 A
        /// </summary>
        /// <param name="expression">表达式,范例：t => t.Name == "A"</param>
        public static object GetValue( Expression expression ) {
            if( expression == null )
                return null;
            switch( expression.NodeType ) {
                case ExpressionType.Lambda:
                    return GetValue( ( (LambdaExpression)expression ).Body );
                case ExpressionType.Convert:
                    return GetValue( ( (UnaryExpression)expression ).Operand );
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.LessThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThanOrEqual:
                    return GetValue( ( (BinaryExpression)expression ).Right );
                case ExpressionType.Call:
                    return GetMethodCallExpressionValue( expression );
                case ExpressionType.MemberAccess:
                    return GetMemberValue( (MemberExpression)expression );
                case ExpressionType.Constant:
                    return GetConstantExpressionValue( expression );
            }
            return null;
        }

        /// <summary>
        /// 获取方法调用表达式的值
        /// </summary>
        private static object GetMethodCallExpressionValue( Expression expression ) {
            var methodCallExpression = (MethodCallExpression)expression;
            var value = GetValue( methodCallExpression.Arguments.FirstOrDefault() );
            if( value != null )
                return value;
            return GetValue( methodCallExpression.Object );
        }

        /// <summary>
        /// 获取属性表达式的值
        /// </summary>
        private static object GetMemberValue( MemberExpression expression ) {
            if( expression == null )
                return null;
            var field = expression.Member as FieldInfo;
            if( field != null ) {
                var constValue = GetConstantExpressionValue( expression.Expression );
                return field.GetValue( constValue );
            }
            var property = expression.Member as PropertyInfo;
            if( property == null )
                return null;
            if( expression.Expression == null )
                return property.GetValue( null );
            var value = GetMemberValue( expression.Expression as MemberExpression );
            if( value == null )
                return null;
            return property.GetValue( value );
        }

        /// <summary>
        /// 获取常量表达式的值
        /// </summary>
        private static object GetConstantExpressionValue( Expression expression ) {
            var constantExpression = (ConstantExpression)expression;
            return constantExpression.Value;
        }

        #endregion

        #region GetParameter(获取参数)

        /// <summary>
        /// 获取参数，范例：t.Name,返回 t
        /// </summary>
        /// <param name="expression">表达式，范例：t.Name</param>
        public static ParameterExpression GetParameter( Expression expression ) {
            if( expression == null )
                return null;
            switch( expression.NodeType ) {
                case ExpressionType.Lambda:
                    return GetParameter( ( (LambdaExpression)expression ).Body );
                case ExpressionType.Convert:
                    return GetParameter( ( (UnaryExpression)expression ).Operand );
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.LessThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThanOrEqual:
                    return GetParameter( ( (BinaryExpression)expression ).Left );
                case ExpressionType.MemberAccess:
                    return GetParameter( ( (MemberExpression)expression ).Expression );
                case ExpressionType.Call:
                    return GetParameter( ( (MethodCallExpression)expression ).Object );
                case ExpressionType.Parameter:
                    return (ParameterExpression)expression;
            }
            return null;
        }

        #endregion

        #region GetCriteriaCount(获取谓词条件的个数)

        /// <summary>
        /// 获取谓词条件的个数
        /// </summary>
        /// <param name="expression">谓词表达式,范例：t => t.Name == "A"</param>
        public static int GetCriteriaCount( LambdaExpression expression ) {
            if( expression == null )
                return 0;
            var result = expression.ToString().Replace( "AndAlso", "|" ).Replace( "OrElse", "|" );
            return result.Split( '|' ).Count();
        }

        #endregion

        #region GetAttribute(获取特性)

        /// <summary>
        /// 获取特性
        /// </summary>
        /// <typeparam name="TAttribute">特性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        public static TAttribute GetAttribute<TAttribute>( Expression expression ) where TAttribute : Attribute {
            var memberInfo = GetMember( expression );
            return memberInfo.GetCustomAttribute<TAttribute>();
        }

        /// <summary>
        /// 获取特性
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <typeparam name="TAttribute">特性类型</typeparam>
        /// <param name="propertyExpression">属性表达式</param>
        public static TAttribute GetAttribute<TEntity, TProperty, TAttribute>( Expression<Func<TEntity, TProperty>> propertyExpression ) where TAttribute : Attribute {
            return GetAttribute<TAttribute>( propertyExpression );
        }

        /// <summary>
        /// 获取特性
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <typeparam name="TAttribute">特性类型</typeparam>
        /// <param name="propertyExpression">属性表达式</param>
        public static TAttribute GetAttribute<TProperty, TAttribute>( Expression<Func<TProperty>> propertyExpression ) where TAttribute : Attribute {
            return GetAttribute<TAttribute>( propertyExpression );
        }

        #endregion

        #region GetAttributes(获取特性列表)

        /// <summary>
        /// 获取特性列表
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <typeparam name="TAttribute">特性类型</typeparam>
        /// <param name="propertyExpression">属性表达式</param>
        public static IEnumerable<TAttribute> GetAttributes<TEntity, TProperty, TAttribute>( Expression<Func<TEntity, TProperty>> propertyExpression ) where TAttribute : Attribute {
            var memberInfo = GetMember( propertyExpression );
            return memberInfo.GetCustomAttributes<TAttribute>();
        }

        #endregion

        #region Constant(获取常量)

        /// <summary>
        /// 获取常量表达式
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <param name="value">值</param>
        public static ConstantExpression Constant( Expression expression, object value ) {
            var memberExpression = expression as MemberExpression;
            if( memberExpression == null )
                return Expression.Constant( value );
            return Expression.Constant( value, memberExpression.Type );
        }

        #endregion
    }
}
